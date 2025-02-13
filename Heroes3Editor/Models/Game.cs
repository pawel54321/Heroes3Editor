﻿using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using ICSharpCode.SharpZipLib.GZip;

namespace Heroes3Editor.Models
{
    public class Game
    {
        public bool IsHOTA { get; set; }
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
            var gameVersionMajor = Bytes[8];
            var gameVersionMinor = Bytes[12];

            if (gameVersionMajor >= 44 && gameVersionMinor >= 5)
            {
                SetHOTA();
            }
            else
            {
                SetClassic();
            }
            Constants.LoadAllArtifacts();
        }

        public void SetHOTA()
        {
            IsHOTA = true;
            Constants.LoadHOTAItems();
            Constants.HeroOffsets["SkillSlots"] = 923;
        }
        public void SetClassic()
        {
            IsHOTA = false;
            Constants.HeroOffsets["SkillSlots"] = 41;
            Constants.RemoveHOTAReferenceCodes();
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
            if (Regex.IsMatch(name, @"\p{IsCyrillic}"))
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                Encoding win1251 = Encoding.GetEncoding("windows-1251");
                pattern = win1251.GetBytes(name);
            }

            for (int i = startPosition - pattern.Length; i > 0; --i)
            {
                bool found = true;
                for (int j = 0; j < pattern.Length; ++j)
                {
                    if (Bytes[i + j] != pattern[j])
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    return i;
                }
            }
            return -1;
        }
    }

    public class Hero
    {
        public string Name { get; }

        private Game _game;

        public bool IsHOTAGame => _game.IsHOTA;
        public int BytePosition { get; }

        public int Experience { get; set; }

        public int CoordinatesXMarker { get; set; }
        public int CoordinatesYMarker { get; set; }
        public int CurrentMovementPoints { get; set; }
        public int MaxMovementPoints { get; set; }

        public byte HeroLevel { get; set; }

        public short ManaPoints { get; set; }

        public short CoordinatesX { get; set; }
        public short CoordinatesY { get; set; }
        public byte CoordinatesZ { get; set; }

        public byte[] Attributes { get; } = new byte[4];
        public int NumOfSkills { get; private set; }
        public string[] Skills { get; } = new string[8];
        public byte[] SkillLevels { get; } = new byte[8];

        public ISet<string> Spells { get; } = new HashSet<string>();

        public string[] Creatures { get; } = new string[7];
        public int[] CreatureAmounts { get; } = new int[7];

        public ISet<string> WarMachines { get; } = new HashSet<string>();

        public bool SpellBookState;

        public bool CatapultState;

        public string[] ArtifactInfo { get; } = new string[1];

        public IDictionary<string, string> EquippedArtifacts = new Dictionary<string, string>()
        {
            {"Helm", ""},
            {"Neck", ""},
            {"Armor", ""},
            {"Cloak", ""},
            {"Boots", ""},
            {"Weapon", ""},
            {"Shield", ""},
            {"LeftRing", ""},
            {"RightRing", ""},
            {"Item1", ""},
            {"Item2", ""},
            {"Item3", ""},
            {"Item4", ""},
            {"Item5", ""},
            {"Inventory1", ""},
            {"Inventory2", ""},
            {"Inventory3", ""},
            {"Inventory4", ""},
            {"Inventory5", ""},
            {"Inventory6", ""},
            {"Inventory7", ""},
            {"Inventory8", ""},
            {"Inventory9", ""},
            {"Inventory10", ""},
            {"Inventory11", ""},
            {"Inventory12", ""},
            {"Inventory13", ""},
            {"Inventory14", ""},
            {"Inventory15", ""},
            {"Inventory16", ""},
            {"Inventory17", ""},
            {"Inventory18", ""},
            {"Inventory19", ""},
            {"Inventory20", ""},
            {"Inventory21", ""},
            {"Inventory22", ""},
            {"Inventory23", ""},
            {"Inventory24", ""},
            {"Inventory25", ""},
            {"Inventory26", ""},
            {"Inventory27", ""},
            {"Inventory28", ""},
            {"Inventory29", ""},
            {"Inventory30", ""},
            {"Inventory31", ""},
            {"Inventory32", ""},
            {"Inventory33", ""},
            {"Inventory34", ""},
            {"Inventory35", ""},
            {"Inventory36", ""},
            {"Inventory37", ""},
            {"Inventory38", ""},
            {"Inventory39", ""},
            {"Inventory40", ""},
            {"Inventory41", ""},
            {"Inventory42", ""},
            {"Inventory43", ""},
            {"Inventory44", ""},
            {"Inventory45", ""},
            {"Inventory46", ""},
            {"Inventory47", ""},
            {"Inventory48", ""},
            {"Inventory49", ""},
            {"Inventory50", ""},
            {"Inventory51", ""},
            {"Inventory52", ""},
            {"Inventory53", ""},
            {"Inventory54", ""},
            {"Inventory55", ""},
            {"Inventory56", ""},
            {"Inventory57", ""},
            {"Inventory58", ""},
            {"Inventory59", ""},
            {"Inventory60", ""},
            {"Inventory61", ""},
            {"Inventory62", ""},
            {"Inventory63", ""},
            {"Inventory64", ""},

        };

        private const int ON = 0;
        private const int OFF = 255;

        public Hero(string name, Game game, int bytePosition)
        {
            Name = name;
            _game = game;
            BytePosition = bytePosition;

            byte[] bytesExperience = new byte[4];
            for (int i = 0; i < 4; ++i)
                bytesExperience[i] = _game.Bytes[BytePosition + Constants.HeroOffsets["Experience"] + i];

            Experience = BinaryPrimitives.ReadInt32LittleEndian(bytesExperience);

            byte[] bytesCoordinatesXMarker = new byte[4];
            for (int i = 0; i < 4; ++i)
                bytesCoordinatesXMarker[i] = _game.Bytes[BytePosition + Constants.HeroOffsets["CoordinatesXMarker"] + i];

            CoordinatesXMarker = BinaryPrimitives.ReadInt32LittleEndian(bytesCoordinatesXMarker);

            byte[] bytesCoordinatesYMarker = new byte[4];
            for (int i = 0; i < 4; ++i)
                bytesCoordinatesYMarker[i] = _game.Bytes[BytePosition + Constants.HeroOffsets["CoordinatesYMarker"] + i];

            CoordinatesYMarker = BinaryPrimitives.ReadInt32LittleEndian(bytesCoordinatesYMarker);

            byte[] bytesCurrentMovementPoints = new byte[4];
            for (int i = 0; i < 4; ++i)
                bytesCurrentMovementPoints[i] = _game.Bytes[BytePosition + Constants.HeroOffsets["CurrentMovementPoints"] + i];

            CurrentMovementPoints = BinaryPrimitives.ReadInt32LittleEndian(bytesCurrentMovementPoints);

            byte[] bytesMaxMovementPoints = new byte[4];
            for (int i = 0; i < 4; ++i)
                bytesMaxMovementPoints[i] = _game.Bytes[BytePosition + Constants.HeroOffsets["MaxMovementPoints"] + i];

            MaxMovementPoints = BinaryPrimitives.ReadInt32LittleEndian(bytesMaxMovementPoints);

            HeroLevel = _game.Bytes[BytePosition + Constants.HeroOffsets["HeroLevel"]];

            byte[] bytesManaPoints = new byte[2];
            for (int i = 0; i < 2; ++i)
                bytesManaPoints[i] = _game.Bytes[BytePosition + Constants.HeroOffsets["ManaPoints"] + i];

            ManaPoints = BinaryPrimitives.ReadInt16LittleEndian(bytesManaPoints);

            byte[] bytesCoordinatesX = new byte[2];
            for (int i = 0; i < 2; ++i)
                bytesCoordinatesX[i] = _game.Bytes[BytePosition + Constants.HeroOffsets["CoordinatesX"] + i];

            CoordinatesX = BinaryPrimitives.ReadInt16LittleEndian(bytesCoordinatesX);

            byte[] bytesCoordinatesY = new byte[2];
            for (int i = 0; i < 2; ++i)
                bytesCoordinatesY[i] = _game.Bytes[BytePosition + Constants.HeroOffsets["CoordinatesY"] + i];

            CoordinatesY = BinaryPrimitives.ReadInt16LittleEndian(bytesCoordinatesY);

            CoordinatesZ = _game.Bytes[BytePosition + Constants.HeroOffsets["CoordinatesZ"]];

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
                if (code != OFF)
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

            foreach (var warMachine in Constants.WarMachines.Names)
            {
                if (_game.Bytes[BytePosition + Constants.HeroOffsets[warMachine]] == Constants.WarMachines[warMachine])
                    WarMachines.Add(warMachine);
            }

            SpellBookState = _game.Bytes[BytePosition + Constants.HeroOffsets["SpellBook_Slot"]] == Constants.CustomArtifacts["Spell Book"];

            CatapultState = _game.Bytes[BytePosition + Constants.HeroOffsets["Catapult_Slot"]] == Constants.CustomArtifacts["Catapult"];


            var gears = new List<string>(EquippedArtifacts.Keys);
            foreach (var gear in gears)
            {
                short code; //which artifact in slot
                int slot = -1;

                if (gear.Contains("Inventory"))
                {
                    slot = int.Parse(gear.Substring("Inventory".Length)); //number of slot for Inventory
                    code = _game.Bytes[BytePosition + Constants.HeroOffsets["Inventory"] + (slot - 1) * 8];
                }
                else
                    code = _game.Bytes[BytePosition + Constants.HeroOffsets[gear]];

                if (code != OFF && code != 1) //without scrolls (skip)
                    EquippedArtifacts[gear] = Constants.Artifacts[code];

                if (code == 1 && (gear.Contains("Item") || gear.Contains("Inventory"))) // Item 1-5, Inventory 1-64 - with scrolls
                {
                    int codeTypeScroll;

                    if (gear.Contains("Inventory") && slot != -1) //Inventory - with scrolls
                        codeTypeScroll = _game.Bytes[BytePosition + Constants.HeroOffsets["Inventory"] + (slot - 1) * 8 + 4] + 1000;
                    else //Item - with scrolls
                        codeTypeScroll = _game.Bytes[BytePosition + Constants.HeroOffsets[gear] + 4] + 1000;

                    EquippedArtifacts[gear] = Constants.Artifacts[(short)codeTypeScroll]; 
                }
            }
        }

        public void UpdateExperience(int i, int value)
        {
            Experience = value;

            var amountBytes = _game.Bytes.AsSpan().Slice(BytePosition + Constants.HeroOffsets["Experience"], i);
            BinaryPrimitives.WriteInt32LittleEndian(amountBytes, value);
        }

        public void UpdateCoordinatesXMarker(int i, int value)
        {
            CoordinatesXMarker = value;

            var amountBytes = _game.Bytes.AsSpan().Slice(BytePosition + Constants.HeroOffsets["CoordinatesXMarker"], i);
            BinaryPrimitives.WriteInt32LittleEndian(amountBytes, value);
        }

        public void UpdateCoordinatesYMarker(int i, int value)
        {
            CoordinatesYMarker = value;

            var amountBytes = _game.Bytes.AsSpan().Slice(BytePosition + Constants.HeroOffsets["CoordinatesYMarker"], i);
            BinaryPrimitives.WriteInt32LittleEndian(amountBytes, value);
        }

        public void UpdateCurrentMovementPoints(int i, int value)
        {
            CurrentMovementPoints = value;

            var amountBytes = _game.Bytes.AsSpan().Slice(BytePosition + Constants.HeroOffsets["CurrentMovementPoints"], i);
            BinaryPrimitives.WriteInt32LittleEndian(amountBytes, value);
        }

        public void UpdateMaxMovementPoints(int i, int value)
        {
            MaxMovementPoints = value;

            var amountBytes = _game.Bytes.AsSpan().Slice(BytePosition + Constants.HeroOffsets["MaxMovementPoints"], i);
            BinaryPrimitives.WriteInt32LittleEndian(amountBytes, value);
        }

        public void UpdateHeroLevel(byte value)
        {
            HeroLevel = value;

            _game.Bytes[BytePosition + Constants.HeroOffsets["HeroLevel"]] = value;
        }

        public void UpdateManaPoints(int i, short value)
        {
            ManaPoints = value;

            var amountBytes = _game.Bytes.AsSpan().Slice(BytePosition + Constants.HeroOffsets["ManaPoints"], i);
            BinaryPrimitives.WriteInt16LittleEndian(amountBytes, value);
        }

        public void UpdateCoordinatesX(int i, short value)
        {
            CoordinatesX = value;

            var amountBytes = _game.Bytes.AsSpan().Slice(BytePosition + Constants.HeroOffsets["CoordinatesX"], i);
            BinaryPrimitives.WriteInt16LittleEndian(amountBytes, value);
        }

        public void UpdateCoordinatesY(int i, short value)
        {
            CoordinatesY = value;

            var amountBytes = _game.Bytes.AsSpan().Slice(BytePosition + Constants.HeroOffsets["CoordinatesY"], i);
            BinaryPrimitives.WriteInt16LittleEndian(amountBytes, value);
        }

        public void UpdateCoordinatesZ(byte value)
        {
            CoordinatesZ = value;

            _game.Bytes[BytePosition + Constants.HeroOffsets["CoordinatesZ"]] = value;
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

        public void AddSpellBook()
        {

            int position = BytePosition + Constants.HeroOffsets["SpellBook_Slot"];
            _game.Bytes[position] = (byte)Constants.CustomArtifacts["Spell Book"]; //= ON
            _game.Bytes[position + 1] = ON;
            _game.Bytes[position + 2] = ON;
            _game.Bytes[position + 3] = ON;

        }

        public void RemoveSpellBook()
        {

            int currentBytePos = BytePosition + Constants.HeroOffsets["SpellBook_Slot"];
            _game.Bytes[currentBytePos] = OFF;
            _game.Bytes[currentBytePos + 1] = OFF;
            _game.Bytes[currentBytePos + 2] = OFF;
            _game.Bytes[currentBytePos + 3] = OFF;
        }

        public void AddCatapult()
        {

            int position = BytePosition + Constants.HeroOffsets["Catapult_Slot"];
            _game.Bytes[position] = (byte)Constants.CustomArtifacts["Catapult"];
            _game.Bytes[position + 1] = ON;
            _game.Bytes[position + 2] = ON;
            _game.Bytes[position + 3] = ON;

        }

        public void RemoveCatapult()
        {

            int currentBytePos = BytePosition + Constants.HeroOffsets["Catapult_Slot"];
            _game.Bytes[currentBytePos] = OFF;
            _game.Bytes[currentBytePos + 1] = OFF;
            _game.Bytes[currentBytePos + 2] = OFF;
            _game.Bytes[currentBytePos + 3] = OFF;
        }


        public void UpdateCreature(int i, string creature)
        {
            if (Creatures[i] == null)
            {
                CreatureAmounts[i] = 1;
                UpdateCreatureAmount(i, 1);
            }

            Creatures[i] = creature;
            _game.Bytes[BytePosition + Constants.HeroOffsets["Creatures"] + i * 4] = (byte)Constants.Creatures[creature];
            _game.Bytes[BytePosition + Constants.HeroOffsets["Creatures"] + (i * 4) + 1] = ON;
            _game.Bytes[BytePosition + Constants.HeroOffsets["Creatures"] + (i * 4) + 2] = ON;
            _game.Bytes[BytePosition + Constants.HeroOffsets["Creatures"] + (i * 4) + 3] = ON;
        }

        public void UpdateCreatureAmount(int i, int amount)
        {
            var amountBytes = _game.Bytes.AsSpan().Slice(BytePosition + Constants.HeroOffsets["CreatureAmounts"] + i * 4, 4);
            BinaryPrimitives.WriteInt32LittleEndian(amountBytes, amount);
        }

        public void AddWarMachine(string warMachine)
        {
            if (!WarMachines.Add(warMachine)) return;

            int position = BytePosition + Constants.HeroOffsets[warMachine];
            _game.Bytes[position] = (byte)Constants.WarMachines[warMachine];
            _game.Bytes[position + 1] = ON;
            _game.Bytes[position + 2] = ON;
            _game.Bytes[position + 3] = ON;
        }

        public void RemoveWarMachine(string warMachine)
        {
            if (!WarMachines.Remove(warMachine)) return;

            int currentBytePos = BytePosition + Constants.HeroOffsets[warMachine];
            _game.Bytes[currentBytePos] = OFF;
            _game.Bytes[currentBytePos + 1] = OFF;
            _game.Bytes[currentBytePos + 2] = OFF;
            _game.Bytes[currentBytePos + 3] = OFF;
        }

        public void UpdateInventory(string gear, int slot, string artifact)
        {
            int currentBytePos = BytePosition + Constants.HeroOffsets["Inventory"] + (slot - 1) * 8;

            if (!artifact.Contains("Brak"))
            {
                EquippedArtifacts[gear] = artifact;

                byte[] bytes;

                if (!Constants.Scrolls.Names.Contains(artifact))
                {
                    bytes = BitConverter.GetBytes(Constants.Artifacts[artifact]);

                    _game.Bytes[currentBytePos] = bytes[0];

                }
                else
                {
                    bytes = BitConverter.GetBytes(Constants.Artifacts[artifact] - 1000);

                    _game.Bytes[currentBytePos] = (byte)Constants.CustomArtifacts["Spell Scroll"];
                    //1,2,3
                    _game.Bytes[currentBytePos + 4] = bytes[0];
                    _game.Bytes[currentBytePos + 5] = ON;
                    _game.Bytes[currentBytePos + 6] = ON;
                    _game.Bytes[currentBytePos + 7] = ON;
                }

                _game.Bytes[currentBytePos + 1] = ON;
                _game.Bytes[currentBytePos + 2] = ON;
                _game.Bytes[currentBytePos + 3] = ON;



            }
            else
            {
                EquippedArtifacts[gear] = "";
                _game.Bytes[currentBytePos] = OFF;
                _game.Bytes[currentBytePos + 1] = OFF;
                _game.Bytes[currentBytePos + 2] = OFF;
                _game.Bytes[currentBytePos + 3] = OFF;
            }

        }


        public void UpdateEquippedArtifact(string gear, string artifact)
        {
            int currentBytePos = BytePosition + Constants.HeroOffsets[gear];

            if (!artifact.Contains("Brak"))
            {
                EquippedArtifacts[gear] = artifact;

                byte[] bytes;

                if (!Constants.Scrolls.Names.Contains(artifact))
                {
                    if(artifact.Equals("Zablokowane"))
                        bytes = BitConverter.GetBytes(Constants.Items[artifact]); //Get locked (without Inventory)
                    else
                        bytes = BitConverter.GetBytes(Constants.Artifacts[artifact]);
                    
                    _game.Bytes[currentBytePos] = bytes[0];

                }
                else
                {
                    bytes = BitConverter.GetBytes(Constants.Artifacts[artifact] - 1000);

                    _game.Bytes[currentBytePos] = (byte)Constants.CustomArtifacts["Spell Scroll"];
                    //1,2,3
                    _game.Bytes[currentBytePos + 4] = bytes[0];
                    _game.Bytes[currentBytePos + 5] = ON;
                    _game.Bytes[currentBytePos + 6] = ON;
                    _game.Bytes[currentBytePos + 7] = ON;
                }

                _game.Bytes[currentBytePos + 1] = ON;
                _game.Bytes[currentBytePos + 2] = ON;
                _game.Bytes[currentBytePos + 3] = ON;


            }
            else
            {
                EquippedArtifacts[gear] = "";
                _game.Bytes[currentBytePos] = OFF;
                _game.Bytes[currentBytePos + 1] = OFF;
                _game.Bytes[currentBytePos + 2] = OFF;
                _game.Bytes[currentBytePos + 3] = OFF;
            }

        }



        //  NAME|ATTACK|DEFENSE|POWER|KNOWLEDGE|MORALE|LUCK|OTHER
        //   0  |   1  |   2   |  3  |    4    |   5  |  6 |  7
        public string[] UpdateArtifactInfo(string artifact)
        {
            if (null != artifact && !"Brak".Equals(artifact))
            {
                return Constants.ArtifactInfo[Constants.Artifacts[artifact]].Split("|");
            }
            return null;
        }
    }
}
