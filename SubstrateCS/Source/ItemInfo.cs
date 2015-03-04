﻿using System;
using System.Collections.Generic;
using Substrate.Nbt;
using System.Collections;

namespace Substrate
{
    /// <summary>
    /// Provides named id values for known item types.
    /// </summary>
    /// <remarks>See <see cref="BlockType"/> for additional information.</remarks>
    public static class ItemType
    {
        public const int IRON_SHOVEL = 256;
        public const int IRON_PICKAXE = 257;
        public const int IRON_AXE = 258;
        public const int FLINT_AND_STEEL = 259;
        public const int APPLE = 260;
        public const int BOW = 261;
        public const int ARROW = 262;
        public const int COAL = 263;
        public const int DIAMOND = 264;
        public const int IRON_INGOT = 265;
        public const int GOLD_INGOT = 266;
        public const int IRON_SWORD = 267;
        public const int WOODEN_SWORD = 268;
        public const int WOODEN_SHOVEL = 269;
        public const int WOODEN_PICKAXE = 270;
        public const int WOODEN_AXE = 271;
        public const int STONE_SWORD = 272;
        public const int STONE_SHOVEL = 273;
        public const int STONE_PICKAXE = 274;
        public const int STONE_AXE = 275;
        public const int DIAMOND_SWORD = 276;
        public const int DIAMOND_SHOVEL = 277;
        public const int DIAMOND_PICKAXE = 278;
        public const int DIAMOND_AXE = 279;
        public const int STICK = 280;
        public const int BOWL = 281;
        public const int MUSHROOM_SOUP = 282;
        public const int GOLD_SWORD = 283;
        public const int GOLD_SHOVEL = 284;
        public const int GOLD_PICKAXE = 285;
        public const int GOLD_AXE = 286;
        public const int STRING = 287;
        public const int FEATHER = 288;
        public const int GUNPOWDER = 289;
        public const int WOODEN_HOE = 290;
        public const int STONE_HOE = 291;
        public const int IRON_HOE = 292;
        public const int DIAMOND_HOE = 293;
        public const int GOLD_HOE = 294;
        public const int SEEDS = 295;
        public const int WHEAT = 296;
        public const int BREAD = 297;
        public const int LEATHER_CAP = 298;
        public const int LEATHER_TUNIC = 299;
        public const int LEATHER_PANTS = 300;
        public const int LEATHER_BOOTS = 301;
        public const int CHAIN_HELMET = 302;
        public const int CHAIN_CHESTPLATE = 303;
        public const int CHAIN_LEGGINGS = 304;
        public const int CHAIN_BOOTS = 305;
        public const int IRON_HELMET = 306;
        public const int IRON_CHESTPLATE = 307;
        public const int IRON_LEGGINGS = 308;
        public const int IRON_BOOTS = 309;
        public const int DIAMOND_HELMET = 310;
        public const int DIAMOND_CHESTPLATE = 311;
        public const int DIAMOND_LEGGINGS = 312;
        public const int DIAMOND_BOOTS = 313;
        public const int GOLD_HELMET = 314;
        public const int GOLD_CHESTPLATE = 315;
        public const int GOLD_LEGGINGS = 316;
        public const int GOLD_BOOTS = 317;
        public const int FLINT = 318;
        public const int RAW_PORKCHOP = 319;
        public const int COOKED_PORKCHOP = 320;
        public const int PAINTING = 321;
        public const int GOLDEN_APPLE = 322;
        public const int SIGN = 323;
        public const int WOODEN_DOOR = 324;
        public const int BUCKET = 325;
        public const int WATER_BUCKET = 326;
        public const int LAVA_BUCKET = 327;
        public const int MINECART = 328;
        public const int SADDLE = 329;
        public const int IRON_DOOR = 330;
        public const int REDSTONE_DUST = 331;
        public const int SNOWBALL = 332;
        public const int BOAT = 333;
        public const int LEATHER = 334;
        public const int MILK = 335;
        public const int CLAY_BRICK = 336;
        public const int CLAY = 337;
        public const int SUGAR_CANE = 338;
        public const int PAPER = 339;
        public const int BOOK = 340;
        public const int SLIMEBALL = 341;
        public const int STORAGE_MINECART = 342;
        public const int POWERED_MINECARD = 343;
        public const int EGG = 344;
        public const int COMPASS = 345;
        public const int FISHING_ROD = 346;
        public const int CLOCK = 347;
        public const int GLOWSTONE_DUST = 348;
        public const int RAW_FISH = 349;
        public const int COOKED_FISH = 350;
        public const int DYE = 351;
        public const int BONE = 352;
        public const int SUGAR = 353;
        public const int CAKE = 354;
        public const int BED = 355;
        public const int REDSTONE_REPEATER = 356;
        public const int COOKIE = 357;
        public const int MAP = 358;
        public const int SHEARS = 359;
        public const int MELON_SLICE = 360;
        public const int PUMPKIN_SEEDS = 361;
        public const int MELON_SEEDS = 262;
        public const int RAW_BEEF = 363;
        public const int STEAK = 364;
        public const int RAW_CHICKEN = 365;
        public const int COOKED_CHICKEN = 366;
        public const int ROTTEN_FLESH = 367;
        public const int ENDER_PEARL = 368;
        public const int BLAZE_ROD = 369;
        public const int GHAST_TEAR = 370;
        public const int GOLD_NUGGET = 371;
        public const int NETHER_WART = 372;
        public const int POTION = 373;
        public const int GLASS_BOTTLE = 374;
        public const int SPIDER_EYE = 375;
        public const int FERMENTED_SPIDER_EYE = 376;
        public const int BLAZE_POWDER = 377;
        public const int MAGMA_CREAM = 378;
        public const int BREWING_STAND = 379;
        public const int CAULDRON = 380;
        public const int EYE_OF_ENDER = 381;
        public const int GLISTERING_MELON = 382;
        public const int SPAWN_EGG = 383;
        public const int BOTTLE_O_ENCHANTING = 384;
        public const int FIRE_CHARGE = 385;
        public const int BOOK_AND_QUILL = 386;
        public const int WRITTEN_BOOK = 387;
        public const int EMERALD = 388;
        public const int ITEM_FRAME = 389;
        public const int FLOWER_POT = 390;
        public const int CARROT = 391;
        public const int POTATO = 392;
        public const int BAKED_POTATO = 393;
        public const int POISON_POTATO = 394;
        public const int EMPTY_MAP = 395;
        public const int GOLDEN_CARROT = 396;
        public const int MOB_HEAD = 397;
        public const int CARROT_ON_A_STICK = 398;
        public const int NETHER_STAR = 399;
        public const int PUMPKIN_PIE = 400;
        public const int FIREWORK_ROCKET = 401;
        public const int FIREWORK_STAR = 402;
        public const int ENCHANTED_BOOK = 403;
        public const int REDSTONE_COMPARATOR = 404;
        public const int NETHER_BRICK = 405;
        public const int NETHER_QUARTZ = 406;
        public const int TNT_MINECART = 407;
        public const int HOPPER_MINECART = 408;
        public const int IRON_HORSE_ARMOR = 417;
        public const int GOLD_HORSE_ARMOR = 418;
        public const int DIAMOND_HORSE_ARMOR = 419;
        public const int LEAD = 420;
        public const int NAME_TAG = 421;
        public const int MUSIC_DISC_13 = 2256;
        public const int MUSIC_DISC_CAT = 2257;
        public const int MUSIC_DISC_BLOCKS = 2258;
        public const int MUSIC_DISC_CHIRP = 2259;
        public const int MUSIC_DISC_FAR = 2260;
        public const int MUSIC_DISC_MALL = 2261;
        public const int MUSIC_DISC_MELLOHI = 2262;
        public const int MUSIC_DISC_STAL = 2263;
        public const int MUSIC_DISC_STRAD = 2264;
        public const int MUSIC_DISC_WARD = 2265;
        public const int MUSIC_DISC_11 = 2266;
    }

    /// <summary>
    /// Provides information on a specific type of item.
    /// </summary>
    /// <remarks>By default, all known MC item types are already defined and registered, assuming Substrate
    /// is up to date with the current MC version.
    /// New item types may be created and used at runtime, and will automatically populate various static lookup tables
    /// in the <see cref="ItemInfo"/> class.</remarks>
    public class ItemInfo
    {
        private static Random _rand = new Random();

        private class CacheTableDict<T> : ICacheTable<T>
        {
            private Dictionary<int, T> _cache;

            public T this[int index]
            {
                get 
                {
                    T val;
                    if (_cache.TryGetValue(index, out val)) {
                        return val;
                    }
                    return default(T);
                }
            }

            public CacheTableDict (Dictionary<int, T> cache)
            {
                _cache = cache;
            }

            public IEnumerator<T> GetEnumerator ()
            {
                foreach (T val in _cache.Values)
                    yield return val;
            }

            IEnumerator IEnumerable.GetEnumerator ()
            {
                return GetEnumerator();
            }
        }

        private static readonly Dictionary<int, ItemInfo> _itemTable;

        private int _id = 0;
        private string _name = "";
        private string _internal_name = "";
        private int _stack = 1;

        private static readonly CacheTableDict<ItemInfo> _itemTableCache;

        /// <summary>
        /// Gets the lookup table for id-to-info values.
        /// </summary>
        public static ICacheTable<ItemInfo> ItemTable
        {
          get { return _itemTableCache; }
        }

        public static ItemInfo GetItemInfoByInternalName( string internalName )
        {
          foreach(KeyValuePair<int,ItemInfo> kvp in _itemTable)
          {
            if (kvp.Value._internal_name == internalName)
            {
              return kvp.Value;
            }
          }
          return null;
        }

        /// <summary>
        /// Gets the id of the item type.
        /// </summary>
        public int ID
        {
            get { return _id; }
        }

        /// <summary>
        /// Gets the name of the item type.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Gets the maximum stack size allowed for this item type.
        /// </summary>
        public int StackSize
        {
            get { return _stack; }
        }

        /// <summary>
        /// Constructs a new <see cref="ItemInfo"/> record for the given item id.
        /// </summary>
        /// <param name="id">The id of an item type.</param>
        public ItemInfo (int id)
        {
            _id = id;
            _itemTable[_id] = this;
        }

        /// <summary>
        /// Constructs a new <see cref="ItemInfo"/> record for the given item id and name.
        /// </summary>
        /// <param name="id">The id of an item type.</param>
        /// <param name="name">The name of an item type.</param>
        public ItemInfo (int id, string name)
        {
            _id = id;
            _name = name;
            _internal_name = "minecraft:" + name.ToLower().Replace(' ','_');
            _itemTable[_id] = this;
        }

        public ItemInfo SetInternalName (string name)
        {
            _internal_name = "minecraft:" + name;
            return this;
        }

        /// <summary>
        /// Sets the maximum stack size for this item type.
        /// </summary>
        /// <param name="stack">A stack size between 1 and 64, inclusive.</param>
        /// <returns>The object instance used to invoke this method.</returns>
        public ItemInfo SetStackSize (int stack)
        {
            _stack = stack;
            return this;
        }

        /// <summary>
        /// Chooses a registered item type at random and returns it.
        /// </summary>
        /// <returns></returns>
        public static ItemInfo GetRandomItem ()
        {
            List<ItemInfo> list = new List<ItemInfo>(_itemTable.Values);
            return list[_rand.Next(list.Count)];
        }

        public static ItemInfo IronShovel;
        public static ItemInfo IronPickaxe;
        public static ItemInfo IronAxe;
        public static ItemInfo FlintAndSteel;
        public static ItemInfo Apple;
        public static ItemInfo Bow;
        public static ItemInfo Arrow;
        public static ItemInfo Coal;
        public static ItemInfo Diamond;
        public static ItemInfo IronIngot;
        public static ItemInfo GoldIngot;
        public static ItemInfo IronSword;
        public static ItemInfo WoodenSword;
        public static ItemInfo WoodenShovel;
        public static ItemInfo WoodenPickaxe;
        public static ItemInfo WoodenAxe;
        public static ItemInfo StoneSword;
        public static ItemInfo StoneShovel;
        public static ItemInfo StonePickaxe;
        public static ItemInfo StoneAxe;
        public static ItemInfo DiamondSword;
        public static ItemInfo DiamondShovel;
        public static ItemInfo DiamondPickaxe;
        public static ItemInfo DiamondAxe;
        public static ItemInfo Stick;
        public static ItemInfo Bowl;
        public static ItemInfo MushroomSoup;
        public static ItemInfo GoldSword;
        public static ItemInfo GoldShovel;
        public static ItemInfo GoldPickaxe;
        public static ItemInfo GoldAxe;
        public static ItemInfo String;
        public static ItemInfo Feather;
        public static ItemInfo Gunpowder;
        public static ItemInfo WoodenHoe;
        public static ItemInfo StoneHoe;
        public static ItemInfo IronHoe;
        public static ItemInfo DiamondHoe;
        public static ItemInfo GoldHoe;
        public static ItemInfo Seeds;
        public static ItemInfo Wheat;
        public static ItemInfo Bread;
        public static ItemInfo LeatherCap;
        public static ItemInfo LeatherTunic;
        public static ItemInfo LeatherPants;
        public static ItemInfo LeatherBoots;
        public static ItemInfo ChainHelmet;
        public static ItemInfo ChainChestplate;
        public static ItemInfo ChainLeggings;
        public static ItemInfo ChainBoots;
        public static ItemInfo IronHelmet;
        public static ItemInfo IronChestplate;
        public static ItemInfo IronLeggings;
        public static ItemInfo IronBoots;
        public static ItemInfo DiamondHelmet;
        public static ItemInfo DiamondChestplate;
        public static ItemInfo DiamondLeggings;
        public static ItemInfo DiamondBoots;
        public static ItemInfo GoldHelmet;
        public static ItemInfo GoldChestplate;
        public static ItemInfo GoldLeggings;
        public static ItemInfo GoldBoots;
        public static ItemInfo Flint;
        public static ItemInfo RawPorkchop;
        public static ItemInfo CookedPorkchop;
        public static ItemInfo Painting;
        public static ItemInfo GoldenApple;
        public static ItemInfo Sign;
        public static ItemInfo WoodenDoor;
        public static ItemInfo Bucket;
        public static ItemInfo WaterBucket;
        public static ItemInfo LavaBucket;
        public static ItemInfo Minecart;
        public static ItemInfo Saddle;
        public static ItemInfo IronDoor;
        public static ItemInfo RedstoneDust;
        public static ItemInfo Snowball;
        public static ItemInfo Boat;
        public static ItemInfo Leather;
        public static ItemInfo Milk;
        public static ItemInfo ClayBrick;
        public static ItemInfo Clay;
        public static ItemInfo SugarCane;
        public static ItemInfo Paper;
        public static ItemInfo Book;
        public static ItemInfo Slimeball;
        public static ItemInfo StorageMinecart;
        public static ItemInfo PoweredMinecart;
        public static ItemInfo Egg;
        public static ItemInfo Compass;
        public static ItemInfo FishingRod;
        public static ItemInfo Clock;
        public static ItemInfo GlowstoneDust;
        public static ItemInfo RawFish;
        public static ItemInfo CookedFish;
        public static ItemInfo Dye;
        public static ItemInfo Bone;
        public static ItemInfo Sugar;
        public static ItemInfo Cake;
        public static ItemInfo Bed;
        public static ItemInfo RedstoneRepeater;
        public static ItemInfo Cookie;
        public static ItemInfo Map;
        public static ItemInfo Shears;
        public static ItemInfo MelonSlice;
        public static ItemInfo PumpkinSeeds;
        public static ItemInfo MelonSeeds;
        public static ItemInfo RawBeef;
        public static ItemInfo Steak;
        public static ItemInfo RawChicken;
        public static ItemInfo CookedChicken;
        public static ItemInfo RottenFlesh;
        public static ItemInfo EnderPearl;
        public static ItemInfo BlazeRod;
        public static ItemInfo GhastTear;
        public static ItemInfo GoldNugget;
        public static ItemInfo NetherWart;
        public static ItemInfo Potion;
        public static ItemInfo GlassBottle;
        public static ItemInfo SpiderEye;
        public static ItemInfo FermentedSpiderEye;
        public static ItemInfo BlazePowder;
        public static ItemInfo MagmaCream;
        public static ItemInfo BrewingStand;
        public static ItemInfo Cauldron;
        public static ItemInfo EyeOfEnder;
        public static ItemInfo GlisteringMelon;
        public static ItemInfo SpawnEgg;
        public static ItemInfo BottleOEnchanting;
        public static ItemInfo FireCharge;
        public static ItemInfo BookAndQuill;
        public static ItemInfo WrittenBook;
        public static ItemInfo Emerald;
        public static ItemInfo ItemFrame;
        public static ItemInfo FlowerPot;
        public static ItemInfo Carrot;
        public static ItemInfo Potato;
        public static ItemInfo BakedPotato;
        public static ItemInfo PoisonPotato;
        public static ItemInfo EmptyMap;
        public static ItemInfo GoldenCarrot;
        public static ItemInfo MobHead;
        public static ItemInfo CarrotOnStick;
        public static ItemInfo NetherStar;
        public static ItemInfo PumpkinPie;
        public static ItemInfo FireworkRocket;
        public static ItemInfo FireworkStar;
        public static ItemInfo EnchantedBook;
        public static ItemInfo RedstoneComparator;
        public static ItemInfo NetherBrick;
        public static ItemInfo NetherQuartz;
        public static ItemInfo TntMinecart;
        public static ItemInfo HopperMinecart;
        public static ItemInfo IronHorseArmor;
        public static ItemInfo GoldHorseArmor;
        public static ItemInfo DiamondHorseArmor;
        public static ItemInfo Lead;
        public static ItemInfo NameTag;
        public static ItemInfo MusicDisc13;
        public static ItemInfo MusicDiscCat;
        public static ItemInfo MusicDiscBlocks;
        public static ItemInfo MusicDiscChirp;
        public static ItemInfo MusicDiscFar;
        public static ItemInfo MusicDiscMall;
        public static ItemInfo MusicDiscMellohi;
        public static ItemInfo MusicDiscStal;
        public static ItemInfo MusicDiscStrad;
        public static ItemInfo MusicDiscWard;
        public static ItemInfo MusicDisc11;

        static ItemInfo ()
        {
            _itemTable = new Dictionary<int, ItemInfo>();
            _itemTableCache = new CacheTableDict<ItemInfo>(_itemTable);

            IronShovel = new ItemInfo(256, "Iron Shovel");
            IronPickaxe = new ItemInfo(257, "Iron Pickaxe");
            IronAxe = new ItemInfo(258, "Iron Axe");
            FlintAndSteel = new ItemInfo(259, "Flint and Steel");
            Apple = new ItemInfo(260, "Apple").SetStackSize(64);
            Bow = new ItemInfo(261, "Bow");
            Arrow = new ItemInfo(262, "Arrow").SetStackSize(64);
            Coal = new ItemInfo(263, "Coal").SetStackSize(64);
            Diamond = new ItemInfo(264, "Diamond").SetStackSize(64);
            IronIngot = new ItemInfo(265, "Iron Ingot").SetStackSize(64);
            GoldIngot = new ItemInfo(266, "Gold Ingot").SetStackSize(64);
            IronSword = new ItemInfo(267, "Iron Sword");
            WoodenSword = new ItemInfo(268, "Wooden Sword");
            WoodenShovel = new ItemInfo(269, "Wooden Shovel");
            WoodenPickaxe = new ItemInfo(270, "Wooden Pickaxe");
            WoodenAxe = new ItemInfo(271, "Wooden Axe");
            StoneSword = new ItemInfo(272, "Stone Sword");
            StoneShovel = new ItemInfo(273, "Stone Shovel");
            StonePickaxe = new ItemInfo(274, "Stone Pickaxe");
            StoneAxe = new ItemInfo(275, "Stone Axe");
            DiamondSword = new ItemInfo(276, "Diamond Sword");
            DiamondShovel = new ItemInfo(277, "Diamond Shovel");
            DiamondPickaxe = new ItemInfo(278, "Diamond Pickaxe");
            DiamondAxe = new ItemInfo(279, "Diamond Axe");
            Stick = new ItemInfo(280, "Stick").SetStackSize(64);
            Bowl = new ItemInfo(281, "Bowl").SetStackSize(64);
            MushroomSoup = new ItemInfo(282, "Mushroom Soup");
            GoldSword = new ItemInfo(283, "Gold Sword").SetInternalName("golden_sword");
            GoldShovel = new ItemInfo(284, "Gold Shovel").SetInternalName("golden_shovel");
            GoldPickaxe = new ItemInfo(285, "Gold Pickaxe").SetInternalName("golden_pickaxe");
            GoldAxe = new ItemInfo(286, "Gold Axe").SetInternalName("golden_axe");
            String = new ItemInfo(287, "String").SetStackSize(64);
            Feather = new ItemInfo(288, "Feather").SetStackSize(64);
            Gunpowder = new ItemInfo(289, "Gunpowder").SetStackSize(64);
            WoodenHoe = new ItemInfo(290, "Wooden Hoe");
            StoneHoe = new ItemInfo(291, "Stone Hoe");
            IronHoe = new ItemInfo(292, "Iron Hoe");
            DiamondHoe = new ItemInfo(293, "Diamond Hoe");
            GoldHoe = new ItemInfo(294, "Gold Hoe");
            Seeds = new ItemInfo(295, "Seeds").SetStackSize(64).SetInternalName("wheat_seeds");
            Wheat = new ItemInfo(296, "Wheat").SetStackSize(64);
            Bread = new ItemInfo(297, "Bread").SetStackSize(64);
            LeatherCap = new ItemInfo(298, "Leather Cap").SetInternalName("leather_helmet");
            LeatherTunic = new ItemInfo(299, "Leather Tunic").SetInternalName("leather_chestplate");
            LeatherPants = new ItemInfo(300, "Leather Pants").SetInternalName("leather_leggings");
            LeatherBoots = new ItemInfo(301, "Leather Boots");
            ChainHelmet = new ItemInfo(302, "Chain Helmet").SetInternalName("chainmail_helmet");
            ChainChestplate = new ItemInfo(303, "Chain Chestplate").SetInternalName("chainmail_chestplate");
            ChainLeggings = new ItemInfo(304, "Chain Leggings").SetInternalName("chainmail_leggings");
            ChainBoots = new ItemInfo(305, "Chain Boots").SetInternalName("chainmail_boots");
            IronHelmet = new ItemInfo(306, "Iron Helmet");
            IronChestplate = new ItemInfo(307, "Iron Chestplate");
            IronLeggings = new ItemInfo(308, "Iron Leggings");
            IronBoots = new ItemInfo(309, "Iron Boots");
            DiamondHelmet = new ItemInfo(310, "Diamond Helmet");
            DiamondChestplate = new ItemInfo(311, "Diamond Chestplate");
            DiamondLeggings = new ItemInfo(312, "Diamond Leggings");
            DiamondBoots = new ItemInfo(313, "Diamond Boots");
            GoldHelmet = new ItemInfo(314, "Gold Helmet").SetInternalName("golden_helmet");
            GoldChestplate = new ItemInfo(315, "Gold Chestplate").SetInternalName("golden_chestplate");
            GoldLeggings = new ItemInfo(316, "Gold Leggings").SetInternalName("golden_leggings");
            GoldBoots = new ItemInfo(317, "Gold Boots").SetInternalName("golden_boots");
            Flint = new ItemInfo(318, "Flint").SetStackSize(64);
            RawPorkchop = new ItemInfo(319, "Raw Porkchop").SetStackSize(64).SetInternalName("porkchop");
            CookedPorkchop = new ItemInfo(320, "Cooked Porkchop").SetStackSize(64);
            Painting = new ItemInfo(321, "Painting").SetStackSize(64);
            GoldenApple = new ItemInfo(322, "Golden Apple").SetStackSize(64);
            Sign = new ItemInfo(323, "Sign");
            WoodenDoor = new ItemInfo(324, "Door");
            Bucket = new ItemInfo(325, "Bucket");
            WaterBucket = new ItemInfo(326, "Water Bucket");
            LavaBucket = new ItemInfo(327, "Lava Bucket");
            Minecart = new ItemInfo(328, "Minecart");
            Saddle = new ItemInfo(329, "Saddle");
            IronDoor = new ItemInfo(330, "Iron Door");
            RedstoneDust = new ItemInfo(331, "Redstone Dust").SetStackSize(64).SetInternalName("redstone");
            Snowball = new ItemInfo(332, "Snowball").SetStackSize(16);
            Boat = new ItemInfo(333, "Boat");
            Leather = new ItemInfo(334, "Leather").SetStackSize(64);
            Milk = new ItemInfo(335, "Milk").SetInternalName("milk_bucket");
            ClayBrick = new ItemInfo(336, "Clay Brick").SetStackSize(64).SetInternalName("brick");
            Clay = new ItemInfo(337, "Clay").SetStackSize(64).SetInternalName("clay_ball");
            SugarCane = new ItemInfo(338, "Sugar Cane").SetStackSize(64).SetInternalName("reeds");
            Paper = new ItemInfo(339, "Paper").SetStackSize(64);
            Book = new ItemInfo(340, "Book").SetStackSize(64);
            Slimeball = new ItemInfo(341, "Slimeball").SetStackSize(64).SetInternalName("slime_ball");
            StorageMinecart = new ItemInfo(342, "Storage Minecart").SetInternalName("chest_minecart");
            PoweredMinecart = new ItemInfo(343, "Powered Minecart");
            Egg = new ItemInfo(344, "Egg").SetStackSize(16);
            Compass = new ItemInfo(345, "Compass");
            FishingRod = new ItemInfo(346, "Fishing Rod");
            Clock = new ItemInfo(347, "Clock");
            GlowstoneDust = new ItemInfo(348, "Glowstone Dust").SetStackSize(64);
            RawFish = new ItemInfo(349, "Raw Fish").SetStackSize(64).SetInternalName("fish");
            CookedFish = new ItemInfo(350, "Cooked Fish").SetStackSize(64);
            Dye = new ItemInfo(351, "Dye").SetStackSize(64);
            Bone = new ItemInfo(352, "Bone").SetStackSize(64);
            Sugar = new ItemInfo(353, "Sugar").SetStackSize(64);
            Cake = new ItemInfo(354, "Cake");
            Bed = new ItemInfo(355, "Bed");
            RedstoneRepeater = new ItemInfo(356, "Redstone Repeater").SetStackSize(64).SetInternalName("repeater");
            Cookie = new ItemInfo(357, "Cookie").SetStackSize(8);
            Map = new ItemInfo(358, "Map").SetInternalName("filled_map");
            Shears = new ItemInfo(359, "Shears");
            MelonSlice = new ItemInfo(360, "Melon Slice").SetStackSize(64);
            PumpkinSeeds = new ItemInfo(361, "Pumpkin Seeds").SetStackSize(64);
            MelonSeeds = new ItemInfo(362, "Melon Seeds").SetStackSize(64);
            RawBeef = new ItemInfo(363, "Raw Beef").SetStackSize(64).SetInternalName("beef");
            Steak = new ItemInfo(364, "Steak").SetStackSize(64).SetInternalName("cooked_beef");
            RawChicken = new ItemInfo(365, "Raw Chicken").SetStackSize(64).SetInternalName("chicken");
            CookedChicken = new ItemInfo(366, "Cooked Chicken").SetStackSize(64);
            RottenFlesh = new ItemInfo(367, "Rotten Flesh").SetStackSize(64);
            EnderPearl = new ItemInfo(368, "Ender Pearl").SetStackSize(64);
            BlazeRod = new ItemInfo(369, "Blaze Rod").SetStackSize(64);
            GhastTear = new ItemInfo(370, "Ghast Tear").SetStackSize(64);
            GoldNugget = new ItemInfo(371, "Gold Nugget").SetStackSize(64);
            NetherWart = new ItemInfo(372, "Nether Wart").SetStackSize(64);
            Potion = new ItemInfo(373, "Potion");
            GlassBottle = new ItemInfo(374, "Glass Bottle").SetStackSize(64);
            SpiderEye = new ItemInfo(375, "Spider Eye").SetStackSize(64);
            FermentedSpiderEye = new ItemInfo(376, "Fermented Spider Eye").SetStackSize(64);
            BlazePowder = new ItemInfo(377, "Blaze Powder").SetStackSize(64);
            MagmaCream = new ItemInfo(378, "Magma Cream").SetStackSize(64);
            BrewingStand = new ItemInfo(379, "Brewing Stand").SetStackSize(64);
            Cauldron = new ItemInfo(380, "Cauldron");
            EyeOfEnder = new ItemInfo(381, "Eye of Ender").SetStackSize(64).SetInternalName("ender_eye");
            GlisteringMelon = new ItemInfo(382, "Glistering Melon").SetStackSize(64).SetInternalName("speckled_melon");
            SpawnEgg = new ItemInfo(383, "Spawn Egg").SetStackSize(64);
            BottleOEnchanting = new ItemInfo(384, "Bottle O' Enchanting").SetStackSize(64).SetInternalName("experience_bottle");
            FireCharge = new ItemInfo(385, "Fire Charge").SetStackSize(64);
            BookAndQuill = new ItemInfo(386, "Book and Quill").SetInternalName("writable_book");
            WrittenBook = new ItemInfo(387, "Written Book");
            Emerald = new ItemInfo(388, "Emerald").SetStackSize(64);
            ItemFrame = new ItemInfo(389, "Item Frame").SetStackSize(64);
            FlowerPot = new ItemInfo(390, "Flower Pot").SetStackSize(64);
            Carrot = new ItemInfo(391, "Carrot").SetStackSize(64);
            Potato = new ItemInfo(392, "Potato").SetStackSize(64);
            BakedPotato = new ItemInfo(393, "Baked Potato").SetStackSize(64);
            PoisonPotato = new ItemInfo(394, "Poisonous Potato").SetStackSize(64);
            EmptyMap = new ItemInfo(395, "Empty Map").SetStackSize(64);
            GoldenCarrot = new ItemInfo(396, "Golden Carrot").SetStackSize(64);
            MobHead = new ItemInfo(397, "Mob Head").SetStackSize(64).SetInternalName("skull");
            CarrotOnStick = new ItemInfo(398, "Carrot on a Stick");
            NetherStar = new ItemInfo(399, "Nether Star").SetStackSize(64);
            PumpkinPie = new ItemInfo(400, "Pumpkin Pie").SetStackSize(64);
            FireworkRocket = new ItemInfo(401, "Firework Rocket").SetInternalName("fireworks");
            FireworkStar = new ItemInfo(402, "Firework Star").SetStackSize(64).SetInternalName("firework_charge");
            EnchantedBook = new ItemInfo(403, "Enchanted Book");
            RedstoneComparator = new ItemInfo(404, "Redstone Comparator").SetStackSize(64).SetInternalName("comparator");
            NetherBrick = new ItemInfo(405, "Nether Brick").SetStackSize(64).SetInternalName("netherbrick");
            NetherQuartz = new ItemInfo(406, "Nether Quartz").SetStackSize(64).SetInternalName("quartz");
            TntMinecart = new ItemInfo(407, "Minecart with TNT");
            HopperMinecart = new ItemInfo(408, "Minecart with Hopper");
            IronHorseArmor = new ItemInfo(417, "Iron Horse Armor");
            GoldHorseArmor = new ItemInfo(418, "Gold Horse Armor").SetInternalName("golden_horse_armor");
            DiamondHorseArmor = new ItemInfo(419, "Diamond Horse Armor");
            Lead = new ItemInfo(420, "Lead").SetStackSize(64);
            NameTag = new ItemInfo(421, "Name Tag").SetStackSize(64);
            MusicDisc13 = new ItemInfo(2256, "13 Disc").SetInternalName("record_13");
            MusicDiscCat = new ItemInfo(2257, "Cat Disc").SetInternalName("record_cat");
            MusicDiscBlocks = new ItemInfo(2258, "Blocks Disc").SetInternalName("record_blocks");
            MusicDiscChirp = new ItemInfo(2259, "Chirp Disc").SetInternalName("record_chirp");
            MusicDiscFar = new ItemInfo(2260, "Far Disc").SetInternalName("record_far");
            MusicDiscMall = new ItemInfo(2261, "Mall Disc").SetInternalName("record_mall");
            MusicDiscMellohi = new ItemInfo(2262, "Mellohi Disc").SetInternalName("record_mellohi");
            MusicDiscStal = new ItemInfo(2263, "Stal Disc").SetInternalName("record_stal");
            MusicDiscStrad = new ItemInfo(2264, "Strad Disc").SetInternalName("record_strad");
            MusicDiscWard = new ItemInfo(2265, "Ward Disc").SetInternalName("record_ward");
            MusicDisc11 = new ItemInfo(2266, "11 Disc").SetInternalName("record_11");
        }
    }
}
