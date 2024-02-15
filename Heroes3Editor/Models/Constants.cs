using System;
using System.Collections.Generic;
using System.Linq;

namespace Heroes3Editor.Models
{
    public class Constants
    {
        public static Skills Skills { get; } = new Skills();
        public static Spells Spells { get; } = new Spells();
        public static Creatures Creatures { get; } = new Creatures();
        public static Weapons Weapons { get; } = new Weapons();
        public static Shields Shields { get; } = new Shields();
        public static Armor Armor { get; } = new Armor();
        public static Cloak Cloak { get; } = new Cloak();
        public static Helms Helms { get; } = new Helms();
        public static Rings Rings { get; } = new Rings();
        public static Boots Boots { get; } = new Boots();
        public static Neck Neck { get; } = new Neck();
        public static Items Items { get; } = new Items();
        public static WarMachines WarMachines { get; } = new WarMachines();
        public static Artifacts Artifacts { get; } = new Artifacts();
        public static Scrolls Scrolls { get; } = new Scrolls();

        public static CustomArtifacts CustomArtifacts { get; } = new CustomArtifacts();

        public static ArtifactInfo ArtifactInfo { get; } = new ArtifactInfo();

        private static readonly string[] _heroes = {
            "Christian", "Edric", "Orrin", "Sylvia", "Valeska", "Sorsha", "Tyris", "Lord Haart", "Catherine",
            "Roland", "Sir Mullich", "Adela", "Adelaide", "Caitlin", "Cuthbert", "Ingham", "Loynis", "Rion",
            "Sanya", "Jenova", "Kyrre", "Ivor", "Ufretin", "Clancy", "Thorgrim", "Ryland", "Mephala", "Gelu",
            "Aeris", "Alagar", "Coronius", "Elleshar", "Malcom", "Melodia", "Gem", "Uland", "Fafner", "Iona",
            "Josephine", "Neela", "Piquedram", "Rissa", "Thane", "Torosar", "Aine", "Astral", "Cyra", "Daremyth",
            "Halon", "Serena", "Solmyr", "Theodorus", "Dracon", "Calh", "Fiona", "Ignatius", "Marius", "Nymus",
            "Octavia", "Pyre", "Rashka", "Xeron", "Ash", "Axsis", "Ayden", "Calid", "Olema", "Xyron", "Xarfax",
            "Zydar", "Charna", "Clavius", "Galthran", "Isra", "Moandor", "Straker", "Tamika", "Vokial", "Aislinn",
            "Nagash", "Nimbus", "Sandro", "Septienna", "Thant", "Vidomina", "Xsi", "Ajit", "Arlach", "Dace",
            "Damacon", "Gunnar", "Lorelei", "Shakti", "Synca", "Mutare", "Mutare Drake", "Alamar", "Darkstorn",
            "Deemer", "Geon", "Jaegar", "Jeddite", "Malekith", "Sephinroth", "Crag Hack", "Gretchin", "Gurnisson",
            "Jabarkas", "Krellion", "Shiva", "Tyraxor", "Yog", "Boragus", "Kilgor", "Dessa", "Gird", "Gundula",
            "Oris", "Saurug", "Terek", "Vey", "Zubin", "Alkin", "Broghild", "Bron", "Drakon", "Gerwulf", "Korbac",
            "Tazar", "Wystan", "Andra", "Merist", "Mirlanda", "Rosic", "Styg", "Tiva", "Verdish", "Voy", "Adrienne",
            "Erdamon", "Fiur", "Ignissa", "Kalt", "Lacus", "Monere", "Pasis", "Thunar", "Aenain", "Brissa", "Ciele",
            "Gelare", "Grindan", "Inteus", "Labetha", "Luna", "Gen. Kendal", "Anabel","Cassiopeia","Corkes","Derek",
            "Elmore","Illor","Leena","Miriam","Andal","Astra","Dargem","Eovacius","Manfred","Zilare",
            "Jeremy", "Bidley", "Spint", "Casmetra", "Tark",
            "Henrietta", "Sam", "Tancred", "Melchior", "Floribert", "Wynona", "Dury", "Morton", "Celestine",
            "Todd", "Agar", "Bertram", "Wrathmont", "Ziph", "Victoria", "Eanswythe",
            "Tavin", "Murdoch", "Frederick", "Boyd",
            "Tarnum", "Giselle"
        };
        public static string[] Heroes { get; } = _heroes.OrderBy(x => x).ToArray();

        public static Dictionary<string, int> HeroOffsets = new Dictionary<string, int>()
        {

            {"Catapult_Slot", 341},
            {"SpellBook_Slot", 349},
            {"Experience", -130},
            {"CoordinatesXMarker", -150 },
            {"CoordinatesYMarker", -146 },
            {"CurrentMovementPoints", -134 },
            {"MaxMovementPoints", -138 },
            {"HeroLevel", -120},
            {"ManaPoints", -122},
            {"CoordinatesX", -195},
            {"CoordinatesY", -193},
            {"CoordinatesZ", -191},
            {"Attributes", 69}, // Primary Skills
            {"Weapon", 237},
            {"Shield", 245},
            {"Armor", 253},
            {"Helm", 213},
            {"Neck", 229},
            {"Cloak", 221},
            {"Boots", 277},
            {"LeftRing", 261},
            {"RightRing", 269},
            {"Item1", 285},
            {"Item2", 293},
            {"Item3", 301},
            {"Item4", 309},
            {"Item5", 357},
            {"Ballista", 317},
            {"Canon", 317},
            {"Ammo_Cart", 325},
            {"First_Aid_Tent", 333},
            {"NumOfSkills", -126},
            {"Skills", 13}, // Secondary Skills
            {"SkillSlots", 41},
            {"Spells", 73},
            {"SpellBook", 143}, // (???)
            {"Creatures", -56},
            {"CreatureAmounts", -28},
            {"Inventory", 365 } //64
        };

        public static void LoadHOTAItems()
        {
            WarMachines.LoadHotaReferenceCodes();
            Weapons.LoadHotaReferenceCodes();
            Shields.LoadHotaReferenceCodes();
            Armor.LoadHotaReferenceCodes();
            Cloak.LoadHotaReferenceCodes();
            Helms.LoadHotaReferenceCodes();
            Rings.LoadHotaReferenceCodes();
            Boots.LoadHotaReferenceCodes();
            Neck.LoadHotaReferenceCodes();
            Items.LoadHotaReferenceCodes();
            Creatures.LoadHotaReferenceCodes();
            Scrolls.LoadHotaReferenceCodes();
            CustomArtifacts.LoadHotaReferenceCodes();
        }

        public static void RemoveHOTAReferenceCodes()
        {
            WarMachines.RemoveHotaReferenceCodes();
            Weapons.RemoveHotaReferenceCodes();
            Shields.RemoveHotaReferenceCodes();
            Armor.RemoveHotaReferenceCodes();
            Cloak.RemoveHotaReferenceCodes();
            Helms.RemoveHotaReferenceCodes();
            Rings.RemoveHotaReferenceCodes();
            Boots.RemoveHotaReferenceCodes();
            Neck.RemoveHotaReferenceCodes();
            Items.RemoveHotaReferenceCodes();
            Creatures.RemoveHotaReferenceCodes();
            Scrolls.RemoveHotaReferenceCodes();
            CustomArtifacts.RemoveHotaReferenceCodes();
        }

        public static void LoadAllArtifacts()
        {
            Artifacts.AddArtifacts(WarMachines.GetArtifacts);
            Artifacts.AddArtifacts(Weapons.GetArtifacts);
            Artifacts.AddArtifacts(Shields.GetArtifacts);
            Artifacts.AddArtifacts(Armor.GetArtifacts);
            Artifacts.AddArtifacts(Cloak.GetArtifacts);
            Artifacts.AddArtifacts(Helms.GetArtifacts);
            Artifacts.AddArtifacts(Rings.GetArtifacts);
            Artifacts.AddArtifacts(Boots.GetArtifacts);
            Artifacts.AddArtifacts(Neck.GetArtifacts);

            Items.AddArtifacts(Scrolls.GetArtifacts); //Item: 1-5

            Artifacts.AddArtifacts(Items.GetArtifacts);
        }
    }

    public class Skills
    {
        private static readonly Dictionary<int, string> _namesByCode = new Dictionary<int, string>()
        {
            {0, "Znajdowanie drogi"}, //Pathfinding
            {1, "Łucznictwo"}, //Archery
            {2, "Logistyka"}, //Logistics
            {3, "Odkrywanie"}, //Scouting
            {4, "Dyplomacja"}, //Diplomacy
            {5, "Nawigacja"}, //Navigation
            {6, "Dowodzenie"}, //Leadership
            {7, "Mądrość"}, //Wisdom
            {8, "Mistycyzm"}, //Mysticism
            {9, "Szczęście"}, //Luck
            {10, "Balistyka"}, //Ballistics
            {11, "Sokoli wzrok"}, //Eagle Eye
            {12, "Nekromancja"}, //Necromancy
            {13, "Finanse"}, //Estates
            {14, "Magia ognia"}, //Fire Magic
            {15, "Magia powietrza"}, //Air Magic
            {16, "Magia wody"}, //Water Magic
            {17, "Magia ziemi"}, //Earth Magic
            {18, "Nauka czarów"}, //Scholar
            {19, "Taktyka"}, //Tactics
            {20, "Artyleria"}, //Artillery
            {21, "Nauka"}, //Learning
            {22, "Atak"}, //Offense
            {23, "Płatnerstwo"}, //Armorer
            {24, "Inteligencja"}, //Intelligence
            {25, "Talent magiczny"}, //Sorcery
            {26, "Odporność"}, //Resistance
            {27, "Pierwsza pomoc"}//, //First Aid
            //{28, "Zakłócanie"}
            //TODO
        };

        private static readonly Dictionary<string, int> _codesByName = _namesByCode.ToDictionary(i => i.Value, i => i.Key);

        public string[] Names { get; } = _namesByCode.Values.OrderBy(x => x).ToArray();

        public string this[int key] => _namesByCode[key];

        public int this[string key] => _codesByName[key];
    }

    public class Weapons : BaseArtifact
    {
        public Weapons()
        {
            _namesByCode = new Dictionary<short, string>()
            {
                {0x91, "Blokada" },
                {0xFF, "Brak" },
                {0x07, "Centaur's Axe" },
                {0x08, "Blackshard of the Dead Knight" },
                {0x09, "Greater Knoll's Flail" },
                {0x0A, "Ogre's Club of Havoc" },
                {0x0B, "Sword of Hellfire" },
                {0X0C, "Titan's Gladius" },
                {0x23, "Sword of Judgement" },
                {0x26, "Red Dragon Flame Tongue" },
                {0x80, "Armageddon's Blade" },
                {0x81, "Miecz Anielskiego Sojuszu" }, //combination
                {0x87, "Titans Thunder" }
            };
            _HOTANamesByCode = new Dictionary<short, string>()
            {
                {0x8F, "Ironfist of the Ogre" },
            };
        }
    }

    public class Shields : BaseArtifact
    {
        public Shields()
        {
            _namesByCode = new Dictionary<short, string>() {
                {0x91, "Blokada" },
                {0xFF, "Brak" },
                {0x0D, "Shield of the Dwarven Lords" },
                {0x0E, "Shield of the Yawning Dead" },
                {0x0F, "Buckler of the Gnoll King" },
                {0x10, "Targ of the Rampaging Ogre" },
                {0x11, "Shield of the Damned" },
                {0x12, "Sentinel's Shield" },
                {0x22, "Lion's Shield of Courage" },
                {0x27, "Dragon Scale Shield" },
            };
            _HOTANamesByCode = new Dictionary<short, string>()
            {
                {148, "Shield of Naval Glory"},
            };
        }
    }

    public class Helms : BaseArtifact
    {
        public Helms()
        {
            _namesByCode = new Dictionary<short, string>() {
                {0x91, "Blokada" },
                {0xFF, "Brak" },
                {0x13, "Helm of the Alabaster Unicorn" },
                {0x14, "Skull Helmet" },
                {0x15, "Helm of Chaos" },
                {0x16, "Crown of the Supreme Magi" },
                {0x17, "Hellstorm Helmet" },
                {0x18, "Thunder Helmet" },
                {0x24, "Helm of Heavenly Enlightenment" },
                {0x2C, "Crown of Dragontooth" },
                {0x7B, "Sea Captain's Hat" },
                {0x7C, "Spellbinder's Hat" },
                {0x88, "Kapelusz Admirała" } //combination
            };
            _HOTANamesByCode = new Dictionary<short, string>() {
                {150, "Crown of the Five Seas"},
                {155, "Hideous Mask"},
            };
        }
    }

    public class Armor : BaseArtifact
    {
        public Armor()
        {
            _namesByCode = new Dictionary<short, string>() {
                {0xFF, "Brak" },
                {0x19, "Breastplate of Petrified Wood" },
                {0x1A, "Rib Cage" },
                {0x1B, "Scales of the Greater Basilisk" },
                {0x1C, "Tunic of the Cyclops King" },
                {0x1D, "Breastplate of Brimstone" },
                {0x1E, "Titan's Cuirass" },
                {0x1F, "Armor of Wonder" },
                {0x28, "Dragon Scale Armor" },
                {0x3A, "Surcoat of Counterpoise" },
                {0x84, "Zbroja Przeklętego" }, //combination
                {0x86, "Power of the Dragon Father" }
            };
            _HOTANamesByCode = new Dictionary<short, string>() {
                {149, "Royal Armor of Nix"},
                {164, "Plate of Dying Light"}
            };
        }
    }

    public class Cloak : BaseArtifact
    {
        public Cloak()
        {
            _namesByCode = new Dictionary<short, string>()
            {
                {0x91, "Blokada" },
                {0xFF, "Brak" },
                {0x2A, "Dragon Wing Tabard" },
                {0x37, "Vampire's Cowl" },
                {0x44, "Ambassador's Sash" },
                {0x48, "Angel Wings" },
                {0x4E, "Cape of Conjuring" },
                {0x53, "Recanter's Cloak" },
                {0x63, "Cape of Velocity" },
                {0x6D, "Everflowing Crystal Cloak" },
                {0x82, "Cloak of Undead King" },
            };
            _HOTANamesByCode = new Dictionary<short, string>() {
                {159, "Cape of Silence"},
                {0x8D, "Diplomat's Cloak" },
            };
        }
    }

    public class Boots : BaseArtifact
    {
        public Boots()
        {

            _namesByCode = new Dictionary<short, string>()
            {
                {0x91, "Blokada" },
                {0xFF, "Brak" },
                {0x20, "Sandal's of the Saint" },
                {0x29, "Dragonbone Greaves" },
                {0x38, "Dead Men's Boots" },
                {0x3B, "Boots of Polarity" },
                {0x5A, "Boots of Levitation" },
                {0x62, "Boots of Speed" }
            };
            _HOTANamesByCode = new Dictionary<short, string>() {
                {0x97, "Wayfarer's Boots"},
            };
        }
    }

    public class Neck : BaseArtifact
    {
        public Neck()
        {
            _namesByCode = new Dictionary<short, string>() {

                {0x91, "Blokada" },
                {0xFF, "Brak" },
                {0x21, "Celestial Necklace of Bliss" },
                {0x2B, "Necklace of Dragonteeth" },
                {0x36, "Amulet of the Undertaker" },
                {0x39, "Garniture of Interference" },
                {0x47, "Necklace of Ocean Guidance" },
                {0x4C, "Collar of Conjuring" },
                {0x61, "Necklace of Swiftness" },
                {0x64, "Pendant of Dispassion" },
                {0x65, "Pendant of Second Sight" },
                {0x66, "Pendant of Holiness" },
                {0x67, "Pendant of Life" },
                {0x68, "Pendant of Death" },
                {0x69, "Pendant of Free Will" },
                {0x6A, "Pendant of Negativity" },
                {0x6B, "Pendant of Total Recall" },
                {0x6C, "Pendant of Courage" }
            };
            _HOTANamesByCode = new Dictionary<short, string>() {
                {0x8E, "Pendant of Reflection" },
                {157, "Pendant of Downfall"},
            };
        }
    }

    public class Rings : BaseArtifact
    {
        public Rings()
        {
            _namesByCode = new Dictionary<short, string>()
            {
                {0x91, "Blokada" },
                {0xFF, "Brak" },
                {0x25, "Quiet Eye of the Dragon" },
                {0x2D, "Still Eye of the Dragon" },
                {0x43, "Diplomat Ring" },
                {0x45, "Ring of the Wayfarer" },
                {0x46, "Equestrian's Gloves" },
                {0x4D, "Ring of Conjuring" },
                {0x5E, "Ring of Vitality" },
                {0x5F, "Ring of Life" },
                {0x6E, "Ring of Infinite Gems" },
                {0x71, "Eversmoking Ring of Sulfur" },
                {0x8B, "Ring of the Magi" },
            };
            _HOTANamesByCode = new Dictionary<short, string>() {
                {156, "Ring of Suppression"},
                {158, "Ring of Oblivion"},
                {163, "Seal of Sunset"},
            };
        }
    }

    public class Items : BaseArtifact
    {
        public Items() //1-5
        {
            _namesByCode = new Dictionary<short, string>() {
                {0x91, "Blokada" },
                {0xFF, "Brak" },
                {0x2E, "Clover of Fortune" },
                {0x2F, "Cards of Prophecy" },
                {0x30, "Ladybird of Luck" },
                {0x31, "Badge of Courage" },
                {0x32, "Crest of Valor" },
                {0x33, "Glyph of Gallantry" },
                {0x34, "Speculum" },
                {0x35, "Spyglass" },
                {0x3C, "Bow of Elven Cherrywood" },
                {0x3D, "Bowstring of the Unicorns's Mane" },
                {0x3E, "Angel Feather Arrows" },
                {0x3F, "Bird of Perception" },
                {0x40, "Stoic Watchman" },
                {0x41, "Emblem of Cognizance" },
                {0x42, "Statesmen's Medal" },
                {0x49, "Charm of Mana" },
                {0x4A, "Talisman of Mana" },
                {0x4B, "Mystic Orb of Mana" },
                {0x4F, "Orb of Firmament" },
                {0x50, "Orb of Silt" },
                {0x51, "Orb of Tempestous Fire" },
                {0x52, "Orb of Driving Rain" },
                {0x54, "Spirit of Opression" },
                {0x55, "Hourglass of the Evil Hour" },
                {0x56, "Tome of Fire Magic" },
                {0x57, "Tome of Wind Magic" },
                {0x58, "Tome of Water Magic" },
                {0x59, "Tome of Earth Magic" },
                {0x5B, "Golden Bow" },
                {0x5C, "Sphere of Permanence" },
                {0x5D, "Orb of Vulnerability" },
                {0x60, "Vial of Lifeblood" },
                {0x6F, "Everpouring Vial of Mercury" },
                {0x70, "Inexhaustable Cart of Ore" },
                {0x72, "Inexhaustable Cart of Lumber" },
                {0x73, "Endless Sack of Gold" },
                {0x74, "Endless Bag of Gold" },
                {0x75, "Endless Purse of Gold" },
                {0x76, "Legs of Legion" },
                {0x77, "Loins of Legion" },
                {0x78, "Torso of Legion" },
                {0x79, "Arms of Legion" },
                {0x7A, "Head of Legion" },
                {0x7D, "Shackles of War" },
                {0x7E, "Orb of Inhibition" },
                {0x83, "Elixir of Life" },
                {0x85, "Statue of Legion" },
                {0x89, "Łuk Strzelca" }, //combination
                {0x8A, "Wizard's Well" },
                {0x8C, "Cornucopia" },

            };
            _HOTANamesByCode = new Dictionary<short, string>() {
                {153, "Demon's Horseshoe"},
                {154, "Shaman's Puppet"},
                {160, "Golden Goose"},
                {161, "Horn of the Abyss"},
                {162, "Charm of Eclipse"},
            };
        }

        public void AddArtifacts(Dictionary<short, string> artifacts)
        {
            foreach (var element in artifacts)
            {
                if (_namesByCode.ContainsKey(element.Key))
                {
                    continue;
                }
                _namesByCode.Add(element.Key, element.Value);
            }
        }
    }

    public class WarMachines : BaseArtifact
    {
        public WarMachines()
        {
            _namesByCode = new Dictionary<short, string>() {
                {0x04, "Ballista" },
                {0x05, "Ammo_Cart" },
                {0x06, "First_Aid_Tent" }
            };
            _HOTANamesByCode = new Dictionary<short, string>() {
                {0x92, "Canon" }
            };
        }
    }

    public class CustomArtifacts : BaseArtifact //CustomInventory (Sakwa)
    {
        public CustomArtifacts()
        {
            _namesByCode = new Dictionary<short, string>() {
                {0x00, "Spell Book" },
                {0x01, "Spell Scroll" },
                {0x03, "Catapult" },
            };
        }

    }

    public class Artifacts : BaseArtifact //Inventory (Sakwa)
    {
        public Artifacts()
        {
            _namesByCode = new Dictionary<short, string>() {
                {0x02, "The Grail" }, //TODO: Only in long slot
            };
        }
        public void AddArtifacts(Dictionary<short, string> artifacts)
        {
            foreach (var element in artifacts)
            {
                if (_namesByCode.ContainsKey(element.Key))
                {
                    continue;
                }
                _namesByCode.Add(element.Key, element.Value);
            }
        }
    }

    public class Scrolls : BaseArtifact
    {
        //1000 custom offset 

        public Scrolls()
        {
            _namesByCode = new Dictionary<short, string>() {
                //{0xFF, "Brak" }, Duplicate
                {0+1000, "[Zwój] Przyzwanie okrętu"},
                {1+1000, "[Zwój] Zniszczenie okrętu"},
                {2+1000, "[Zwój] Wizja"},
                {3+1000, "[Zwój] Zasoby ziemi"},
                {4+1000, "[Zwój] Ukrycie"},
                {5+1000, "[Zwój] Aura Artefaktów"},
                {6+1000, "[Zwój] Lot"},
                {7+1000, "[Zwój] Spacer po wodzie"},
                {8+1000, "[Zwój] Wrota Wymiarów"},
                {9+1000, "[Zwój] Miejski portal"},
                {10+1000, "[Zwój] Ruchome piaski"},
                {11+1000, "[Zwój] Pole minowe"},
                {12+1000, "[Zwój] Pole siłowe"},
                {13+1000, "[Zwój] Ściana ognia"},
                {14+1000, "[Zwój] Trzęsienie ziemi"},
                {15+1000, "[Zwój] Magiczna Strzała"},
                {16+1000, "[Zwój] Lodowy pocisk"},
                {17+1000, "[Zwój] Błyskawica"},
                {18+1000, "[Zwój] Implozja"},
                {19+1000, "[Zwój] Łańcuch Piorunów"},
                {20+1000, "[Zwój] Krąg zimna"},
                {21+1000, "[Zwój] Kula ognia"},
                {22+1000, "[Zwój] Inferno"},
                {23+1000, "[Zwój] Deszcz meteorów"},
                {24+1000, "[Zwój] Fala śmierci"},
                {25+1000, "[Zwój] Zniszczenie nieumarłych"},
                {26+1000, "[Zwój] Armagedon"},
                {27+1000, "[Zwój] Tarcza"},
                {28+1000, "[Zwój] Tarcza Powietrza"},
                {29+1000, "[Zwój] Tarcza ognia"},
                {30+1000, "[Zwój] Ochrona przed powietrzem"},
                {31+1000, "[Zwój] Ochrona przed ogniem"},
                {32+1000, "[Zwój] Ochrona przed wodą"},
                {33+1000, "[Zwój] Ochrona przed ziemią"},
                {34+1000, "[Zwój] Antymagia"},
                {35+1000, "[Zwój] Rozproszenie"},
                {36+1000, "[Zwój] Magiczne zwierciadło"},
                {37+1000, "[Zwój] Uleczenie"},
                {38+1000, "[Zwój] Wskrzeszenie"},
                {39+1000, "[Zwój] Ożywienie"},
                {40+1000, "[Zwój] Ofiara"},
                {41+1000, "[Zwój] Błogosławieństwo"},
                {42+1000, "[Zwój] Klątwa"},
                {43+1000, "[Zwój] Żądza krwi"},
                {44+1000, "[Zwój] Precyzja"},
                {45+1000, "[Zwój] Osłabienie"},
                {46+1000, "[Zwój] Kamienna skóra"},
                {47+1000, "[Zwój] Promień osłabienia"},
                {48+1000, "[Zwój] Modlitwa"},
                {49+1000, "[Zwój] Radość"},
                {50+1000, "[Zwój] Przygnębienie"},
                {51+1000, "[Zwój] Fortuna"},
                {52+1000, "[Zwój] Pech"},
                {53+1000, "[Zwój] Przyśpieszenie"},
                {54+1000, "[Zwój] Spowolnienie"},
                {55+1000, "[Zwój] Pogromca"},
                {56+1000, "[Zwój] Szał"},
                {57+1000, "[Zwój] Błyskawica tytana"},
                {58+1000, "[Zwój] Kontratak"},
                {59+1000, "[Zwój] Berserk"},
                {60+1000, "[Zwój] Hipnoza"},
                {61+1000, "[Zwój] Zapomnienie"},
                {62+1000, "[Zwój] Oślepienie"},
                {63+1000, "[Zwój] Teleportacja"},
                {64+1000, "[Zwój] Usunięcie przeszkody"},
                {65+1000, "[Zwój] Klonowanie"},
                {66+1000, "[Zwój] Żywiołak ognia"},
                {67+1000, "[Zwój] Żywiołak ziemi"},
                {68+1000, "[Zwój] Żywiołak wody"},
                {69+1000, "[Zwój] Żywiołak powietrza"}
            };

            _HOTANamesByCode = new Dictionary<short, string>()
            {

            };
        }

    }


    public class ArtifactInfo
    {
        //  NAME|ATTACK|DEFENSE|SPELL POWER|KNOWLEDGE|MORALE|LUCK|OTHER
        //   0  |   1  |   2   |     3     |    4    |   5  |  6 |  7
        private static readonly Dictionary<short, string> _namesByCode = new Dictionary<short, string>()
        {
            {0x07, "Centaur's Axe|+2||||||" },
            {0x08, "Blackshard of the Dead Knight|+3||||||" },
            {0x09, "Greater Knoll's Flail|+4||||||" },
            {0x0A, "Ogre's Club of Havoc|+5||||||" },
            {0x0B, "Sword of Hellfire|+6||||||" },
            {0X0C, "Titan's Gladius|+12|-3|||||" },
            {0x0D, "Shield of the Dwarven Lords||+2|||||" },
            {0x0E, "Shield of the Yawning Dead||+3|||||" },
            {0x0F, "Buckler of the Gnoll King||+4|||||" },
            {0x10, "Targ of the Rampaging Ogre||+5|||||" },
            {0x11, "Shield of the Damned||+6|||||" },
            {0x12, "Sentinel's Shield|-3|+12|||||" },
            {0x13, "Helm of the Alabaster Unicorn||||+1|||" },
            {0x14, "Skull Helmet||||+2|||" },
            {0x15, "Helm of Chaos||||+3|||" },
            {0x16, "Crown of the Supreme Magi||||+4|||" },
            {0x17, "Hellstorm Helmet||||+5|||" },
            {0x18, "Thunder Helmet|||-2|+10|||" },
            {0x19, "Breastplate of Petrified Wood|||+1||||" },
            {0x1A, "Rib Cage|||+2||||" },
            {0x1B, "Scales of the Greater Basilisk|||+3||||" },
            {0x1C, "Tunic of the Cyclops King|||+4||||" },
            {0x1D, "Breastplate of Brimstone|||+5||||" },
            {0x1E, "Titan's Cuirass|||+10|-2|||" },
            {0x1F, "Armor of Wonder|+1|+1|+1|+1|||" },
            {0x20, "Sandal's of the Saint|+2|+2|+2|+2|||" },
            {0x21, "Celestial Necklace of Bliss|+3|+3|+3|+3|||" },
            {0x22, "Lion's Shield of Courage|+4|+4|+4|+4|||" },
            {0x23, "Sword of Judgement|+5|+5|+5|+5|||" },
            {0x24, "Helm of Heavenly Enlightenment|+6|+6|+6|+6|||" },
            {0x25, "Quiet Eye of the Dragon|+1|+1|||||" },
            {0x26, "Red Dragon Flame Tongue|+2|+2|||||" },
            {0x27, "Dragon Scale Shield|+3|+3|||||" },
            {0x28, "Dragon Scale Armor|+4|+4|||||" },
            {0x29, "Dragonbone Greaves|||+1|+1|||" },
            {0x2A, "Dragon Wing Tabard|||+2|+2|||" },
            {0x2B, "Necklace of Dragonteeth|||+3|+3|||" },
            {0x2C, "Crown of Dragontooth|||+4|+4|||" },
            {0x2D, "Still Eye of the Dragon|||||+1|+1|" },
            {0x2E, "Clover of Fortune||||||+1|" },
            {0x2F, "Cards of Prophecy||||||+1|" },
            {0x30, "Ladybird of Luck||||||+1|" },
            {0x31, "Badge of Courage|||||+1||" },
            {0x32, "Crest of Valor|||||+1||" },
            {0x33, "Glyph of Gallantry|||||+1||" },
            {0x34, "Speculum|||||||Scouting Radius +1" },
            {0x35, "Spyglass|||||||Scouting Radius +1" },
            {0x36, "Amulet of the Undertaker|||||||Necromancy +5%" },
            {0x37, "Vampire's Cowl|||||||Necromancy 10%" },
            {0x38, "Dead Men's Boots|||||||Necromancy 15%" },
            {0x39, "Garniture of Interference|||||||Magic Resistance 5%" },
            {0x3A, "Surcoat of Counterpoise|||||||Magic Resistance 10%" },
            {0x3B, "Boots of Polarity|||||||Magic Resistance 15%" },
            {0x3C, "Bow of Elven Cherrywood|||||||Archery Skill 5%" },
            {0x3D, "Bowstring of the Unicorns's Mane|||||||Archery Skill 10%" },
            {0x3E, "Angel Feather Arrows|||||||Archery Skill 15%" },
            {0x3F, "Bird of Perception|||||||Eagle Eye Skill 5%" },
            {0x40, "Stoic Watchman|||||||Eagle Eye Skill 10%" },
            {0x41, "Emblem of Cognizance|||||||Eagle Eye Skill 15%" },
            {0x42, "Statesmen's Medal|||||||Surrendering Cost -10%" },
            {0x43, "Diplomat Ring|||||||Surrendering Cost -10%" },
            {0x44, "Ambassador's Sash|||||||Surrendering Cost -10%" },
            {0x45, "Ring of the Wayfarer|||||||Unit Speed +1" },
            {0x46, "Equestrian's Gloves|||||||Hero Movement Points +300" },
            {0x47, "Necklace of Ocean Guidance|||||||Hero Sea Movement +1000" },
            {0x48, "Angel Wings|||||||Hero will fly" },
            {0x49, "Charm of Mana|||||||Regenerate +1 Mana per day" },
            {0x4A, "Talisman of Mana|||||||Regenerate +2 Mana per day" },
            {0x4B, "Mystic Orb of Mana|||||||Regenerate +3 Mana per day" },
            {0x4C, "Collar of Conjuring|||||||Spell Duration +1" },
            {0x4D, "Ring of Conjuring|||||||Spell Duration +2" },
            {0x4E, "Cape of Conjuring|||||||Spell Duration +3" },
            {0x4F, "Orb of Firmament|||||||All Air Spell Damage +50%" },
            {0x50, "Orb of Silt|||||||All Earth Spell Damage +50%" },
            {0x51, "Orb of Tempestous Fire|||||||All Fire Spell Damage +50%" },
            {0x52, "Orb of Driving Rain|||||||All Water Spell Damage +50%" },
            {0x53, "Recanter's Cloak|||||||Prevents Casting lvl 3+ Spells" },
            {0x54, "Spirit of Opression|||||||Positive Morale Disabled" },
            {0x55, "Hourglass of the Evil Hour|||||||Luck Disabled" },
            {0x56, "Tome of Fire Magic|||||||All Fire Spells Unlocked" },
            {0x57, "Tome of Wind Magic|||||||All Air Spells Unlocked" },
            {0x58, "Tome of Water Magic|||||||All Water Spells Unlocked" },
            {0x59, "Tome of Earth Magic|||||||All Earth Spells Unlocked" },
            {0x5A, "Boots of Levitation|||||||Hero Will Walk on Water" },
            {0x5B, "Golden Bow|||||||No Range and Obstacle Penalty" },
            {0x5C, "Sphere of Permanence|||||||Immune to Dispel" },
            {0x5D, "Orb of Vulnerability|||||||All Spells Unlocked, Negates Immunities" },
            {0x5E, "Ring of Vitality|||||||+1 Unit Health" },
            {0x5F, "Ring of Life|||||||+1 Unit Health" },
            {0x60, "Vial of Lifeblood|||||||+2 Unit Health" },
            {0x61, "Necklace of Swiftness|||||||+1 Unit Speed" },
            {0x62, "Boots of Speed|||||||Hero Movement Points +600" },
            {0x63, "Cape of Velocity|||||||+2 Unit Speed" },
            {0x64, "Pendant of Dispassion|||||||Immunity to Berserk" },
            {0x65, "Pendant of Second Sight|||||||Immunity to Blind" },
            {0x66, "Pendant of Holiness|||||||Immunity to Curse" },
            {0x67, "Pendant of Life|||||||Immunity to Death Ripple" },
            {0x68, "Pendant of Death|||||||Immunity to Destroy Undead" },
            {0x69, "Pendant of Free Will|||||||Immunity to Hypnotize" },
            {0x6A, "Pendant of Negativity|||||||Immunity to Lightning Bolt and Chain-Lightning" },
            {0x6B, "Pendant of Total Recall|||||||Immunity to Forgetfulness" },
            {0x6C, "Pendant of Courage|||||+3|+3|" },
            {0x6D, "Everflowing Crystal Cloak|||||||+1 Crystal per day" },
            {0x6E, "Ring of Infinite Gems|||||||+1 Gems per day" },
            {0x6F, "Everpouring Vial of Mercury|||||||+1 Mercury per day" },
            {0x70, "Inexhaustable Cart of Ore|||||||+1 Ore per day" },
            {0x71, "Eversmoking Ring of Sulfur|||||||+1 Sulfur per day" },
            {0x72, "Inexhaustable Cart of Lumber|||||||+1 Lumber per day" },
            {0x73, "Endless Sack of Gold|||||||+1000 Gold per day" },
            {0x74, "Endless Bag of Gold|||||||+750 Gold per day" },
            {0x75, "Endless Purse of Gold|||||||+500 Gold per day" },
            {0x76, "Legs of Legion|||||||Lvl 2 Creature Growth +5" },
            {0x77, "Loins of Legion|||||||Lvl 3 Creature Growth +4" },
            {0x78, "Torso of Legion|||||||Lvl 4 Creature Growth +3" },
            {0x79, "Arms of Legion|||||||Lvl 5 Creature Growth +2" },
            {0x7A, "Head of Legion|||||||Lvl 6 Creature Growth +1" },
            {0x7B, "Sea Captain's Hat|||||||Hero Sea Movement +500, Can Cast Summon Boat, Scuttle Boat, Protection from Whirlpools" },
            {0x7C, "Spellbinder's Hat|||||||When equipped, the hat enables hero to cast all 5th level spells." },
            {0x7D, "Shackles of War|||||||Neither you nor your opponent may flee or surrender" },
            {0x7E, "Orb of Inhibition|||||||Prevents Casting All Spells" },
            {0x7F, "Vial of Dragonblood|||||||Dragons receive +5 Attack and Defense" },
            {0x80, "Armageddon's Blade|+3|+3|+3|+6|||Combination Artifact: Can Cast Armageddon, Immune to Armageddon"},
            {0x81, "Angelic Alliance|+21|+21|+21|+21|||Combination Artifact: No Army Penalty for Good and Neutral troops, Can Cast Prayer" },
            {0x82, "Cloak of Undead King|||||||Combination Artifact: Necromancy +60%, Raise more Creature Types" },
            {0x83, "Elixir of Life|||||||Combination Artifact: +25% Unit Health, +4 Health Point Regeneration" },
            {0x84, "Armor of the Dammed|+3|+3|+2|+2|||Combination Artifact: Cast Slow,Curse,Weakness and Misfortune for 50 rounds in combat." },
            {0x85, "Statue of Legion|||||||Combination Artifact: Creature Growth +50% + Artifact Effects" },
            {0x86, "Power of the Dragon Father|+16|+16|+16|+16|+1|+1|Combination Artifact: Immune to Lvl 1-4 Spells" },
            {0x87, "Titans Thunder|+9|+9|+8|+8|||Combination Artifact: Can Cast Titan's Lightning Bolt" },
            {0x88, "Admiral's Hat|||||||Combination Artifact: Hero Sea Movement +1500, No Penalty to Board/Leave Boat, Can Cast Summon Boat and Scuttle Boat, Protection from Whirlpools." },
            {0x89, "Bow of the Sharpshooter|||||||Combination Artifact: No Range and Obstacle Penalty, No Melee Penalty, Archery Skill +30%" },
            {0x8A, "Wizard's Well|||||||Combination Artifact: Regenerates all spell points each day" },
            {0x8B, "Ring of the Magi|||||||Combination Artifact: Add 50 rounds to spell duration (56 rounds together with components effect)" },
            {0x8C, "Cornucopia|||||||Combination Artifact: Generates 5 of each precious resource, each day." },
            {0x8D, "Diplomat's Cloak|||||||Combination Artifact: Allows your hero to retreat or surrender when battling neutral monsters or defending a town. Multiplies your hero army strength by 3" },
            {0x8E, "Pendant of Reflection|||||||Combination Artifact: Increases hero's magic resistance by 20%,increases hero's magic resistance by 30%" },
            {0x8F, "Ironfist of the Ogre|+5|+4|+4|+4|||Combination Artifact: At the beginning of a combat casts Haste, Bloodlust, Fire Shield and Counterstrike." },
            {148, "Shield of Naval Glory|||||||Increases Defense skill by 7" },
            {149, "Royal Armor of Nix|||||||Increases Spell Power skill by 6" },
            {150, "Crown of the Five Seas|||||||Increases Knowledge skill by 6" },
            {151, "Wayfarer's Boots|||||||Allows your hero to move over rough terrain without penalty" },
            {153, "Demon's Horseshoe|||||||Decreases enemy's Luck by 1" },
            {154, "Shaman's Puppet|||||||Decreases enemy's Luck by 2" },
            {155, "Hideous Mask|||||||Decreases enemy's Morale by 1" },
            {156, "Ring of Suppression|||||||Decreases enemy's Morale by 1" },
            {157, "Pendant of Downfall|||||||Decreases enemy's Morale by 2" },
            {158, "Ring of Oblivion|||||||Makes all losses in the battle irrevocable" },
            {159, "Cape of Silence|||||||Bans all level 1 and 2 spells in battle" },
            {160, "Golden Goose|||||||Combination Artifact: brings 7000 gold per day" },
            {161, "Horn of the Abyss|||||||After a stack of living creatures is slain, a stack of Fangarms will rise in their stead and will stay loyal to the hero after the battle concludes" },
            {162, "Charm of Eclipse|||||||Reduces the Power skill of enemy hero by 10% during combat" },
            {163, "Seal of Sunset|||||||Reduces the Power skill of enemy hero by 10% during combat" },
            {164, "Plate of Dying Light|||||||Reduces the Power skill of enemy hero by 25% during combat" },
        
            {0x91,"Blokada|||||||Artefakty składane"}, //145

            {0+1000, "[Zwój] Przyzwanie okrętu||||||| Zwój z zaklęciami - Przyzwanie okrętu: ..."},
            {1+1000, "[Zwój] Zniszczenie okrętu||||||| Zwój z zaklęciami - Zniszczenie okrętu: ..."},
            {2+1000, "[Zwój] Wizja||||||| Zwój z zaklęciami - Wizja: ..."},
            {3+1000, "[Zwój] Zasoby ziemi||||||| Zwój z zaklęciami - Zasoby ziemi: ..."},
            {4+1000, "[Zwój] Ukrycie||||||| Zwój z zaklęciami - Ukrycie: ..."},
            {5+1000, "[Zwój] Aura Artefaktów||||||| Zwój z zaklęciami - Aura Artefaktów: ..."},
            {6+1000, "[Zwój] Lot||||||| Zwój z zaklęciami - Lot: ..."},
            {7+1000, "[Zwój] Spacer po wodzie||||||| Zwój z zaklęciami - Spacer po wodzie: ..."},
            {8+1000, "[Zwój] Wrota Wymiarów||||||| Zwój z zaklęciami - Wrota Wymiarów: ..."},
            {9+1000, "[Zwój] Miejski portal||||||| Zwój z zaklęciami - Miejski portal: ..."},
            {10+1000, "[Zwój] Ruchome piaski||||||| Zwój z zaklęciami - Ruchome piaski: ..."},
            {11+1000, "[Zwój] Pole minowe||||||| Zwój z zaklęciami - Pole minowe: ..."},
            {12+1000, "[Zwój] Pole siłowe||||||| Zwój z zaklęciami - Pole siłowe: ..."},
            {13+1000, "[Zwój] Ściana ognia||||||| Zwój z zaklęciami - Ściana ognia: ..."},
            {14+1000, "[Zwój] Trzęsienie ziemi||||||| Zwój z zaklęciami - Trzęsienie ziemi: ..."},
            {15+1000, "[Zwój] Magiczna Strzała||||||| Zwój z zaklęciami - Magiczna Strzała: ..."},
            {16+1000, "[Zwój] Lodowy pocisk||||||| Zwój z zaklęciami - Lodowy pocisk: ..."},
            {17+1000, "[Zwój] Błyskawica||||||| Zwój z zaklęciami - Błyskawica: ..."},
            {18+1000, "[Zwój] Implozja||||||| Zwój z zaklęciami - Implozja: ..."},
            {19+1000, "[Zwój] Łańcuch Piorunów||||||| Zwój z zaklęciami - Łańcuch Piorunów: ..."},
            {20+1000, "[Zwój] Krąg zimna||||||| Zwój z zaklęciami - Krąg zimna: ..."},
            {21+1000, "[Zwój] Kula ognia||||||| Zwój z zaklęciami - Kula ognia: ..."},
            {22+1000, "[Zwój] Inferno||||||| Zwój z zaklęciami - Inferno: ..."},
            {23+1000, "[Zwój] Deszcz meteorów||||||| Zwój z zaklęciami - Deszcz meteorów: ..."},
            {24+1000, "[Zwój] Fala śmierci||||||| Zwój z zaklęciami - Fala śmierci: ..."},
            {25+1000, "[Zwój] Zniszczenie nieumarłych||||||| Zwój z zaklęciami - Zniszczenie nieumarłych: ..."},
            {26+1000, "[Zwój] Armagedon||||||| Zwój z zaklęciami - Armagedon: ..."},
            {27+1000, "[Zwój] Tarcza||||||| Zwój z zaklęciami - Tarcza: ..."},
            {28+1000, "[Zwój] Tarcza Powietrza||||||| Zwój z zaklęciami - Tarcza Powietrza: ..."},
            {29+1000, "[Zwój] Tarcza ognia||||||| Zwój z zaklęciami - Tarcza ognia: ..."},
            {30+1000, "[Zwój] Ochrona przed powietrzem||||||| Zwój z zaklęciami - Ochrona przed powietrzem: ..."},
            {31+1000, "[Zwój] Ochrona przed ogniem||||||| Zwój z zaklęciami - Ochrona przed ogniem: ..."},
            {32+1000, "[Zwój] Ochrona przed wodą||||||| Zwój z zaklęciami - Ochrona przed wodą: ..."},
            {33+1000, "[Zwój] Ochrona przed ziemią||||||| Zwój z zaklęciami - Ochrona przed ziemią: ..."},
            {34+1000, "[Zwój] Antymagia||||||| Zwój z zaklęciami - Antymagia: ..."},
            {35+1000, "[Zwój] Rozproszenie||||||| Zwój z zaklęciami - Rozproszenie: ..."},
            {36+1000, "[Zwój] Magiczne zwierciadło||||||| Zwój z zaklęciami - Magiczne zwierciadło: ..."},
            {37+1000, "[Zwój] Uleczenie||||||| Zwój z zaklęciami - Uleczenie: ..."},
            {38+1000, "[Zwój] Wskrzeszenie||||||| Zwój z zaklęciami - Wskrzeszenie: ..."},
            {39+1000, "[Zwój] Ożywienie||||||| Zwój z zaklęciami - Ożywienie: ..."},
            {40+1000, "[Zwój] Ofiara||||||| Zwój z zaklęciami - Ofiara: ..."},
            {41+1000, "[Zwój] Błogosławieństwo||||||| Zwój z zaklęciami - Błogosławieństwo: ..."},
            {42+1000, "[Zwój] Klątwa||||||| Zwój z zaklęciami - Klątwa: ..."},
            {43+1000, "[Zwój] Żądza krwi||||||| Zwój z zaklęciami - Żądza krwi: ..."},
            {44+1000, "[Zwój] Precyzja||||||| Zwój z zaklęciami - Precyzja: ..."},
            {45+1000, "[Zwój] Osłabienie||||||| Zwój z zaklęciami - Osłabienie: ..."},
            {46+1000, "[Zwój] Kamienna skóra||||||| Zwój z zaklęciami - Kamienna skóra: ..."},
            {47+1000, "[Zwój] Promień osłabienia||||||| Zwój z zaklęciami - Promień osłabienia: ..."},
            {48+1000, "[Zwój] Modlitwa||||||| Zwój z zaklęciami - Modlitwa: ..."},
            {49+1000, "[Zwój] Radość||||||| Zwój z zaklęciami - Radość: ..."},
            {50+1000, "[Zwój] Przygnębienie||||||| Zwój z zaklęciami - Przygnębienie: ..."},
            {51+1000, "[Zwój] Fortuna||||||| Zwój z zaklęciami - Fortuna: ..."},
            {52+1000, "[Zwój] Pech||||||| Zwój z zaklęciami - Pech: ..."},
            {53+1000, "[Zwój] Przyśpieszenie||||||| Zwój z zaklęciami - Przyśpieszenie: ..."},
            {54+1000, "[Zwój] Spowolnienie||||||| Zwój z zaklęciami - Spowolnienie: ..."},
            {55+1000, "[Zwój] Pogromca||||||| Zwój z zaklęciami - Pogromca: ..."},
            {56+1000, "[Zwój] Szał||||||| Zwój z zaklęciami - Szał: ..."},
            {57+1000, "[Zwój] Błyskawica tytana||||||| Zwój z zaklęciami - Błyskawica tytana: ..."},
            {58+1000, "[Zwój] Kontratak||||||| Zwój z zaklęciami - Kontratak: ..."},
            {59+1000, "[Zwój] Berserk||||||| Zwój z zaklęciami - Berserk: ..."},
            {60+1000, "[Zwój] Hipnoza||||||| Zwój z zaklęciami - Hipnoza: ..."},
            {61+1000, "[Zwój] Zapomnienie||||||| Zwój z zaklęciami - Zapomnienie: ..."},
            {62+1000, "[Zwój] Oślepienie||||||| Zwój z zaklęciami - Oślepienie: ..."},
            {63+1000, "[Zwój] Teleportacja||||||| Zwój z zaklęciami - Teleportacja: ..."},
            {64+1000, "[Zwój] Usunięcie przeszkody||||||| Zwój z zaklęciami - Usunięcie przeszkody: ..."},
            {65+1000, "[Zwój] Klonowanie||||||| Zwój z zaklęciami - Klonowanie: ..."},
            {66+1000, "[Zwój] Żywiołak ognia||||||| Zwój z zaklęciami - Żywiołak ognia: ..."},
            {67+1000, "[Zwój] Żywiołak ziemi||||||| Zwój z zaklęciami - Żywiołak ziemi: ..."},
            {68+1000, "[Zwój] Żywiołak wody||||||| Zwój z zaklęciami - Żywiołak wody: ..."},
            {69+1000, "[Zwój] Żywiołak powietrza||||||| Zwój z zaklęciami - Żywiołak powietrza: ..."}
        };

        private static readonly Dictionary<string, short> _codesByName = _namesByCode.ToDictionary(i => i.Value, i => i.Key);

        public string[] Names { get; } = _namesByCode.Values.ToArray();

        public string this[short key] => _namesByCode[key];

        public short this[string key] => _codesByName[key];
    }

    public class Spells
    {
        private static readonly Dictionary<int, string> _namesByCode = new Dictionary<int, string>()
        {
            {0, "Summon_Boat"},
            {1, "Scuttle_Boat"},
            {2, "Visions"},
            {3, "View_Earth"},
            {4, "Disguise"},
            {5, "View_Air"},
            {6, "Fly"},
            {7, "Water_Walk"},
            {8, "Dimension_Door"},
            {9, "Town_Portal"},
            {10, "Quick_Sand"},
            {11, "Land_Mine"},
            {12, "Force_Field"},
            {13, "Fire_Wall"},
            {14, "Earthquake"},
            {15, "Magic_Arrow"},
            {16, "Ice_Bolt"},
            {17, "Lightning_Bolt"},
            {18, "Implosion"},
            {19, "Chain_Lightning"},
            {20, "Frost_Ring"},
            {21, "Fireball"},
            {22, "Inferno"},
            {23, "Meteor_Shower"},
            {24, "Death_Ripple"},
            {25, "Destroy_Undead"},
            {26, "Armageddon"},
            {27, "Shield"},
            {28, "Air_Shield"},
            {29, "Fire_Shield"},
            {30, "Protection_from_Air"},
            {31, "Protection_from_Fire"},
            {32, "Protection_from_Water"},
            {33, "Protection_from_Earth"},
            {34, "Anti_Magic"},
            {35, "Dispel"},
            {36, "Magic_Mirror"},
            {37, "Cure"},
            {38, "Resurrection"},
            {39, "Animate_Dead"},
            {40, "Sacrifice"},
            {41, "Bless"},
            {42, "Curse"},
            {43, "Bloodlust"},
            {44, "Precision"},
            {45, "Weakness"},
            {46, "Stone_Skin"},
            {47, "Disrupting_Ray"},
            {48, "Prayer"},
            {49, "Mirth"},
            {50, "Sorrow"},
            {51, "Fortune"},
            {52, "Misfortune"},
            {53, "Haste"},
            {54, "Slow"},
            {55, "Slayer"},
            {56, "Frenzy"},
            {57, "Titans_Lightning_Bolt"},
            {58, "Counterstrike"},
            {59, "Berserk"},
            {60, "Hypnotize"},
            {61, "Forgetfulness"},
            {62, "Blind"},
            {63, "Teleport"},
            {64, "Remove_Obstacle"},
            {65, "Clone"},
            {66, "Summon_Fire_Elemental"},
            {67, "Summon_Earth_Elemental"},
            {68, "Summon_Water_Elemental"},
            {69, "Summon_Air_Elemental"}
        };

        private static readonly Dictionary<string, int> _codesByName = _namesByCode.ToDictionary(i => i.Value, i => i.Key);

        public string this[int key] => _namesByCode[key];

        public int this[string key] => _codesByName[key];
    }

    public class Creatures : BaseArtifact
    {
        public Creatures()
        {
            _namesByCode = new Dictionary<short, string>() {
                {0x00, "Pikeman"},
                {0x01, "Halberdier"},
                {0x02, "Archer"},
                {0x03, "Marksman"},
                {0x04, "Griffin"},
                {0x05, "Royal Griffin"},
                {0x06, "Swordsman"},
                {0x07, "Crusader"},
                {0x08, "Monk"},
                {0x09, "Zealot"},
                {0x0A, "Cavalier"},
                {0x0B, "Champion"},
                {0x0C, "Angel"},
                {0x0D, "Archangel"},
                {0x0E, "Centaur"},
                {0x0F, "Centaur Captain"},
                {0x10, "Dwarf"},
                {0x11, "Battle Dwarf"},
                {0x12, "Wood Elf"},
                {0x13, "Grand Elf"},
                {0x14, "Pegasus"},
                {0x15, "Silver Pegasus"},
                {0x16, "Dendroid Guard"},
                {0x17, "Dendroid Soldier"},
                {0x18, "Unicorn"},
                {0x19, "War Unicorn"},
                {0x1A, "Green Dragon"},
                {0x1B, "Gold Dragon"},
                {0x1C, "Gremlin"},
                {0x1D, "Master Gremlin"},
                {0x1E, "Stone Gargoyle"},
                {0x1F, "Obsidian Gargoyle"},
                {0x20, "Stone Golem"},
                {0x21, "Iron Golem"},
                {0x22, "Mage"},
                {0x23, "Arch Mage"},
                {0x24, "Genie"},
                {0x25, "Master Genie"},
                {0x26, "Naga"},
                {0x27, "Naga Queen"},
                {0x28, "Giant"},
                {0x29, "Titan"},
                {0x2A, "Imp"},
                {0x2B, "Familiar"},
                {0x2C, "Gog"},
                {0x2D, "Magog"},
                {0x2E, "Hell Hound"},
                {0x2F, "Cerberus"},
                {0x30, "Demon"},
                {0x31, "Horned Demon"},
                {0x32, "Pit Fiend"},
                {0x33, "Pit Lord"},
                {0x34, "Efreet"},
                {0x35, "Efreet Sultan"},
                {0x36, "Devil"},
                {0x37, "Arch Devil"},
                {0x38, "Skeleton"},
                {0x39, "Skeleton Warrior"},
                {0x3A, "Walking Dead"},
                {0x3B, "Zombie"},
                {0x3C, "Wight"},
                {0x3D, "Wraith"},
                {0x3E, "Vampire"},
                {0x3F, "Vampire Lord"},
                {0x40, "Lich"},
                {0x41, "Power Lich"},
                {0x42, "Black Knight"},
                {0x43, "Dread Knight"},
                {0x44, "Bone Dragon"},
                {0x45, "Ghost Dragon"},
                {0x46, "Troglodyte"},
                {0x47, "Infernal Troglodyte"},
                {0x48, "Harpy"},
                {0x49, "Harpy Hag"},
                {0x4A, "Beholder"},
                {0x4B, "Evil Eye"},
                {0x4C, "Medusa"},
                {0x4D, "Medusa Queen"},
                {0x4E, "Minotaur"},
                {0x4F, "Minotaur King"},
                {0x50, "Manticore"},
                {0x51, "Scorpicore"},
                {0x52, "Red Dragon"},
                {0x53, "Black Dragon"},
                {0x54, "Goblin"},
                {0x55, "Hobgoblin"},
                {0x56, "Wolf Rider"},
                {0x57, "Wolf Raider"},
                {0x58, "Orc"},
                {0x59, "Orc Chieftain"},
                {0x5A, "Ogre"},
                {0x5B, "Ogre Mage"},
                {0x5C, "Roc"},
                {0x5D, "Thunderbird"},
                {0x5E, "Cyclops"},
                {0x5F, "Cyclops King"},
                {0x60, "Behemoth"},
                {0x61, "Ancient Behemoth"},
                {0x62, "Gnoll"},
                {0x63, "Gnoll Marauder"},
                {0x64, "Lizardman"},
                {0x65, "Lizard Warrior"},
                {0x66, "Serpent Fly"},
                {0x67, "Dragon Fly"},
                {0x68, "Basilisk"},
                {0x69, "Greater Basilisk"},
                {0x6A, "Gorgon"},
                {0x6B, "Mighty Gorgon"},
                {0x6C, "Wyvern"},
                {0x6D, "Wyvern Monarch"},
                {0x6E, "Hydra"},
                {0x6F, "Chaos Hydra"},
                {0x70, "Air Elemental"},
                {0x71, "Earth Elemental"},
                {0x72, "Fire Elemental"},
                {0x73, "Water Elemental"},
                {0x74, "Gold Golem"},
                {0x75, "Diamond Golem"},
                {0x76, "Pixies"},
                {0x77, "Sprites"},
                {0x78, "Psychic Elemental"},
                {0x79, "Magic Elemental"},
                {0x7B, "Ice Elemental"},
                {0x7D, "Magma Elemental"},
                {0x7F, "Storm Elemental"},
                {0x81, "Energy Elemental"},
                {0x82, "Firebird"},
                {0x83, "Phoenix"},
                {0x84, "Azure Dragon"},
                {0x85, "Crystal Dragon"},
                {0x86, "Faeri Dragon"},
                {0x87, "Rust Dragon"},
                {0x88, "Enchanter"},
                {0x89, "Sharpshooter"},
                {0x8A, "Halfling"},
                {0x8B, "Peasant"},
                {0x8C, "Boar"},
                {0x8D, "Mummy"},
                {0x8E, "Nomad"},
                {0x8F, "Rogue"},
                {0x90, "Troll"},
            };
            _HOTANamesByCode = new Dictionary<short, string>() {
                {153, "Nymph"},
                {154, "Oceanids"},
                {155, "Crew Mates"},
                {156, "Seamen"},
                {157, "Pirates"},
                {158, "Corsairs"},
                {151, "Sea Dogs"},
                {159, "Stormbirds"},
                {160, "Ayssids"},
                {161, "Sea Witches"},
                {162, "Sorceresses"},
                {163, "Nix"},
                {164, "Nix Warriors"},
                {165, "Sea Serpents"},
                {166, "Haspids"},
                {167, "Satyrs"},
                {168, "Fangarms"},
                {169, "Leprechauns"},
                {170, "Steel golems"},

                {171, "Niziołki grenadierzy"}, //"Halfling Grenadier"
                {172, "Mechanicy"}, //"Mechanic"
                {173, "Inżynierzy"}, //"Engineer"
                {174, "Pancerniki"}, //"Armadillo"
                {175, "Pancerniki alfa"}, //"Bellwether Armadillo"
                {176, "Automatony"}, //"Automaton"
                {177, "Automatony strażnicze"}, //"Sentinel Automaton"
                {178, "Czerwie pustynne"}, //"Sandworm"
                {179, "Czerwie śmierci"}, //"Olgoi-Khorkhoi"
                {180, "Najemnicy"}, //"Gunslinger"
                {181, "Łowcy nagród"}, //"Bounty Hunter"
                {182, "Koatle"}, //"Couatl"
                {183, "Karmazynowe koatle"}, //"Crimson Couatl"
                {184, "Drednoty"}, //"Dreadnought"
                {185, "Molochy"} //"Juggernaut"
            };
        }
    }
}
