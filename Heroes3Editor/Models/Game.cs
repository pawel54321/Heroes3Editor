﻿using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using ICSharpCode.SharpZipLib.GZip;

namespace Heroes3Editor.Models
{
    public class Game
    {
        public byte[] Bytes { get; }

        public IList<Hero> Heroes { get; } = new List<Hero>();

        // CGM is supposed to be a GZip file, but GZipStream from .NET library throws a
        // "unsupported compression method" exception, which is why we use SharpZipLib.
        // Also CGM has incorrect CRC which every tool/library complains about.
        public Game(string file)
        {
            using var fileStream = (new FileInfo(file)).OpenRead();
            using var gzipStream = new GZipInputStream(fileStream);
            using var memoryStream = new MemoryStream();
            gzipStream.CopyTo(memoryStream);
            Bytes = memoryStream.ToArray();
        }

        public void Save(string file)
        {
            using var fileStream = (new FileInfo(file)).OpenWrite();
            using var gzipStream = new GZipOutputStream(fileStream);
            using var memoryStream = new MemoryStream(Bytes);
            memoryStream.CopyTo(gzipStream);
        }

        public bool SearchHero(string name)
        {
            int startPosition = Bytes.Length;
            foreach (var hero in Heroes)
            {
                if (hero.Name == name && startPosition > hero.BytePosition)
                    startPosition = hero.BytePosition - 1;
            }

            var bytePosition = SearchHero(name, startPosition);
            if (bytePosition > 0)
            {
                Heroes.Add(new Hero(name, this, bytePosition));
                return true;
            }
            else
                return false;
        }

        private int SearchHero(string name, int startPosition)
        {
            byte[] pattern = new byte[13];
            Encoding.ASCII.GetBytes(name).CopyTo(pattern, 0);
            for (int i = startPosition - 13; i > 0; --i)
            {
                bool found = true;
                for (int j = 0; j < 13; ++j)
                    if (Bytes[i + j] != pattern[j])
                    {
                        found = false;
                        break;
                    }
                if (found)
                    return i;
            }
            return -1;
        }
    }

    public class Hero
    {
        public string Name { get; }

        private Game _game;

        public int BytePosition { get; }

        public byte[] Attributes { get; } = new byte[4];
        public int NumOfSkills { get; private set; }
        public string[] Skills { get; } = new string[8];
        public byte[] SkillLevels { get; } = new byte[8];

        public ISet<string> Spells { get; } = new HashSet<string>();

        public string[] Creatures { get; } = new string[7];
        public int[] CreatureAmounts { get; } = new int[7];

        public Hero(string name, Game game, int bytePosition)
        {
            Name = name;
            _game = game;
            BytePosition = bytePosition;

            for (int i = 0; i < 4; ++i)
                Attributes[i] = _game.Bytes[BytePosition + Constants.HeroOffsets["Attributes"] + i];

            NumOfSkills = _game.Bytes[BytePosition + Constants.HeroOffsets["NumOfSkills"]];
            for (int i = 0; i < 28; ++i)
            {
                var skillSlotIndex = _game.Bytes[BytePosition + Constants.HeroOffsets["SkillSlots"] + i];
                if (skillSlotIndex != 0)
                {
                    Skills[skillSlotIndex - 1] = Constants.Skills[i];
                    SkillLevels[skillSlotIndex - 1] = _game.Bytes[BytePosition + Constants.HeroOffsets["Skills"] + i];
                }
            }

            for (int i = 0; i < 70; ++i)
            {
                if (_game.Bytes[BytePosition + Constants.HeroOffsets["Spells"] + i] == 1)
                    Spells.Add(Constants.Spells[i]);
            }

            for (int i = 0; i < 7; ++i)
            {
                var code = _game.Bytes[BytePosition + Constants.HeroOffsets["Creatures"] + i * 4];
                if (code != 0xFF)
                {
                    Creatures[i] = Constants.Creatures[code];
                    var amountBytes = _game.Bytes.AsSpan().Slice(BytePosition + Constants.HeroOffsets["CreatureAmounts"] + i * 4, 4);
                    CreatureAmounts[i] = BinaryPrimitives.ReadInt16LittleEndian(amountBytes);
                }
                else
                {
                    CreatureAmounts[i] = 0;
                }
            }
        }

        public void UpdateAttribute(int i, byte value)
        {
            Attributes[i] = value;
            _game.Bytes[BytePosition + Constants.HeroOffsets["Attributes"] + i] = value;
        }

        public void UpdateSkill(int slot, string skill)
        {
            if (slot < 0 || slot > NumOfSkills) return;
            for (int i = 0; i < NumOfSkills; ++i)
                if (Skills[i] == skill) return;

            byte skillLevel = 1;

            if (slot < NumOfSkills)
            {
                var oldSkill = Skills[slot];
                var oldSkillLevelPosition = BytePosition + Constants.HeroOffsets["Skills"] + Constants.Skills[oldSkill];
                skillLevel = _game.Bytes[oldSkillLevelPosition];
                _game.Bytes[oldSkillLevelPosition] = 0;
                _game.Bytes[BytePosition + Constants.HeroOffsets["SkillSlots"] + Constants.Skills[oldSkill]] = 0;
            }

            Skills[slot] = skill;
            SkillLevels[slot] = skillLevel;
            _game.Bytes[BytePosition + Constants.HeroOffsets["Skills"] + Constants.Skills[skill]] = skillLevel;
            _game.Bytes[BytePosition + Constants.HeroOffsets["SkillSlots"] + Constants.Skills[skill]] = (byte)(slot + 1);

            if (slot == NumOfSkills)
            {
                ++NumOfSkills;
                _game.Bytes[BytePosition + Constants.HeroOffsets["NumOfSkills"]] = (byte)NumOfSkills;
            }
        }

        public void UpdateSkillLevel(int slot, byte level)
        {
            if (slot < 0 || slot > NumOfSkills || level < 1 || level > 3) return;

            SkillLevels[slot] = level;
            _game.Bytes[BytePosition + Constants.HeroOffsets["Skills"] + Constants.Skills[Skills[slot]]] = level;
        }

        public void AddSpell(string spell)
        {
            if (!Spells.Add(spell)) return;

            int spellPosition = BytePosition + Constants.HeroOffsets["Spells"] + Constants.Spells[spell];
            _game.Bytes[spellPosition] = 1;

            int spellBookPosition = BytePosition + Constants.HeroOffsets["SpellBook"] + Constants.Spells[spell];
            _game.Bytes[spellBookPosition] = 1;
        }

        public void RemoveSpell(string spell)
        {
            if (!Spells.Remove(spell)) return;

            int spellPosition = BytePosition + Constants.HeroOffsets["Spells"] + Constants.Spells[spell];
            _game.Bytes[spellPosition] = 0;

            int spellBookPosition = BytePosition + Constants.HeroOffsets["SpellBook"] + Constants.Spells[spell];
            _game.Bytes[spellBookPosition] = 0;
        }

        public void UpdateCreature(int i, string creature)
        {
            if (Creatures[i] == null)
            {
                CreatureAmounts[i] = 1;
                UpdateCreatureAmount(i, 1);
            }

            Creatures[i] = creature;
            _game.Bytes[BytePosition + Constants.HeroOffsets["Creatures"] + i * 4] = Constants.Creatures[creature];
        }

        public void UpdateCreatureAmount(int i, int amount)
        {
            var amountBytes = _game.Bytes.AsSpan().Slice(BytePosition + Constants.HeroOffsets["CreatureAmounts"] + i * 4, 4);
            BinaryPrimitives.WriteInt32LittleEndian(amountBytes, amount);
        }
    }
}
