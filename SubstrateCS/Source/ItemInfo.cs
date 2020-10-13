using System;
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

        private static readonly Dictionary<int, ItemInfo> _itemTable = new Dictionary<int, ItemInfo>();
        private static readonly Dictionary<string, ItemInfo> _strTable = new Dictionary<string, ItemInfo>();

        public static Dictionary<string, ItemInfo> StrTable {
            get {
                return _strTable;
            }
        }

        private int _id = 0;
        private string _name = "", _stringId = null;
        private int _stack = 1;

        private static readonly CacheTableDict<ItemInfo> _itemTableCache = new CacheTableDict<ItemInfo>(_itemTable);

        /// <summary>
        /// Gets the lookup table for id-to-info values.
        /// </summary>
        public static ICacheTable<ItemInfo> ItemTable
        {
            get { return _itemTableCache; }
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

        public string StringId {
            get {
                return _stringId;
            }
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
        public ItemInfo(int id, int meta, string name, string stringId = null) {
            _id = id;
            _name = name;
            _stringId = stringId;
            _itemTable[_id] = this;
            if (stringId != null) {
                _strTable[stringId] = this;
            }
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

        public static ItemInfo Air = new ItemInfo(0, 0, "Air", "minecraft:air");
        public static ItemInfo Stone = new ItemInfo(1, 0, "Stone", "minecraft:stone");
        public static ItemInfo Granite = new ItemInfo(1, 1, "Granite", "minecraft:stone");
        public static ItemInfo PolishedGranite = new ItemInfo(1, 2, "Polished Granite", "minecraft:stone");
        public static ItemInfo Diorite = new ItemInfo(1, 3, "Diorite", "minecraft:stone");
        public static ItemInfo PolishedDiorite = new ItemInfo(1, 4, "Polished Diorite", "minecraft:stone");
        public static ItemInfo Andesite = new ItemInfo(1, 5, "Andesite", "minecraft:stone");
        public static ItemInfo PolishedAndesite = new ItemInfo(1, 6, "Polished Andesite", "minecraft:stone");
        public static ItemInfo Grass = new ItemInfo(2, 0, "Grass", "minecraft:grass");
        public static ItemInfo Dirt = new ItemInfo(3, 0, "Dirt", "minecraft:dirt");
        public static ItemInfo CoarseDirt = new ItemInfo(3, 1, "Coarse Dirt", "minecraft:dirt");
        public static ItemInfo Podzol = new ItemInfo(3, 2, "Podzol", "minecraft:dirt");
        public static ItemInfo Cobblestone = new ItemInfo(4, 0, "Cobblestone", "minecraft:cobblestone");
        public static ItemInfo OakWoodPlank = new ItemInfo(5, 0, "Oak Wood Plank", "minecraft:planks");
        public static ItemInfo SpruceWoodPlank = new ItemInfo(5, 1, "Spruce Wood Plank", "minecraft:planks");
        public static ItemInfo BirchWoodPlank = new ItemInfo(5, 2, "Birch Wood Plank", "minecraft:planks");
        public static ItemInfo JungleWoodPlank = new ItemInfo(5, 3, "Jungle Wood Plank", "minecraft:planks");
        public static ItemInfo AcaciaWoodPlank = new ItemInfo(5, 4, "Acacia Wood Plank", "minecraft:planks");
        public static ItemInfo DarkOakWoodPlank = new ItemInfo(5, 5, "Dark Oak Wood Plank", "minecraft:planks");
        public static ItemInfo OakSapling = new ItemInfo(6, 0, "Oak Sapling", "minecraft:sapling");
        public static ItemInfo SpruceSapling = new ItemInfo(6, 1, "Spruce Sapling", "minecraft:sapling");
        public static ItemInfo BirchSapling = new ItemInfo(6, 2, "Birch Sapling", "minecraft:sapling");
        public static ItemInfo JungleSapling = new ItemInfo(6, 3, "Jungle Sapling", "minecraft:sapling");
        public static ItemInfo AcaciaSapling = new ItemInfo(6, 4, "Acacia Sapling", "minecraft:sapling");
        public static ItemInfo DarkOakSapling = new ItemInfo(6, 5, "Dark Oak Sapling", "minecraft:sapling");
        public static ItemInfo Bedrock = new ItemInfo(7, 0, "Bedrock", "minecraft:bedrock");
        public static ItemInfo FlowingWater = new ItemInfo(8, 0, "Flowing Water", "minecraft:flowing_water");
        public static ItemInfo StillWater = new ItemInfo(9, 0, "Still Water", "minecraft:water");
        public static ItemInfo FlowingLava = new ItemInfo(10, 0, "Flowing Lava", "minecraft:flowing_lava");
        public static ItemInfo StillLava = new ItemInfo(11, 0, "Still Lava", "minecraft:lava");
        public static ItemInfo Sand = new ItemInfo(12, 0, "Sand", "minecraft:sand");
        public static ItemInfo RedSand = new ItemInfo(12, 1, "Red Sand", "minecraft:sand");
        public static ItemInfo Gravel = new ItemInfo(13, 0, "Gravel", "minecraft:gravel");
        public static ItemInfo GoldOre = new ItemInfo(14, 0, "Gold Ore", "minecraft:gold_ore");
        public static ItemInfo IronOre = new ItemInfo(15, 0, "Iron Ore", "minecraft:iron_ore");
        public static ItemInfo CoalOre = new ItemInfo(16, 0, "Coal Ore", "minecraft:coal_ore");
        public static ItemInfo OakWood = new ItemInfo(17, 0, "Oak Wood", "minecraft:log");
        public static ItemInfo SpruceWood = new ItemInfo(17, 1, "Spruce Wood", "minecraft:log");
        public static ItemInfo BirchWood = new ItemInfo(17, 2, "Birch Wood", "minecraft:log");
        public static ItemInfo JungleWood = new ItemInfo(17, 3, "Jungle Wood", "minecraft:log");
        public static ItemInfo OakLeaves = new ItemInfo(18, 0, "Oak Leaves", "minecraft:leaves");
        public static ItemInfo SpruceLeaves = new ItemInfo(18, 1, "Spruce Leaves", "minecraft:leaves");
        public static ItemInfo BirchLeaves = new ItemInfo(18, 2, "Birch Leaves", "minecraft:leaves");
        public static ItemInfo JungleLeaves = new ItemInfo(18, 3, "Jungle Leaves", "minecraft:leaves");
        public static ItemInfo Sponge = new ItemInfo(19, 0, "Sponge", "minecraft:sponge");
        public static ItemInfo WetSponge = new ItemInfo(19, 1, "Wet Sponge", "minecraft:sponge");
        public static ItemInfo Glass = new ItemInfo(20, 0, "Glass", "minecraft:glass");
        public static ItemInfo LapisLazuliOre = new ItemInfo(21, 0, "Lapis Lazuli Ore", "minecraft:lapis_ore");
        public static ItemInfo LapisLazuliBlock = new ItemInfo(22, 0, "Lapis Lazuli Block", "minecraft:lapis_block");
        public static ItemInfo Dispenser = new ItemInfo(23, 0, "Dispenser", "minecraft:dispenser");
        public static ItemInfo Sandstone = new ItemInfo(24, 0, "Sandstone", "minecraft:sandstone");
        public static ItemInfo ChiseledSandstone = new ItemInfo(24, 1, "Chiseled Sandstone", "minecraft:sandstone");
        public static ItemInfo SmoothSandstone = new ItemInfo(24, 2, "Smooth Sandstone", "minecraft:sandstone");
        public static ItemInfo NoteBlock = new ItemInfo(25, 0, "Note Block", "minecraft:noteblock");
        public static ItemInfo Bed = new ItemInfo(26, 0, "Bed", "minecraft:bed");
        public static ItemInfo PoweredRail = new ItemInfo(27, 0, "Powered Rail", "minecraft:golden_rail");
        public static ItemInfo DetectorRail = new ItemInfo(28, 0, "Detector Rail", "minecraft:detector_rail");
        public static ItemInfo StickyPiston = new ItemInfo(29, 0, "Sticky Piston", "minecraft:sticky_piston");
        public static ItemInfo Cobweb = new ItemInfo(30, 0, "Cobweb", "minecraft:web");
        public static ItemInfo DeadShrub = new ItemInfo(31, 0, "Dead Shrub", "minecraft:tallgrass");
        public static ItemInfo TallGrass = new ItemInfo(31, 1, "Grass", "minecraft:tallgrass");
        public static ItemInfo Fern = new ItemInfo(31, 2, "Fern", "minecraft:tallgrass");
        public static ItemInfo DeadBush = new ItemInfo(32, 0, "Dead Bush", "minecraft:deadbush");
        public static ItemInfo Piston = new ItemInfo(33, 0, "Piston", "minecraft:piston");
        public static ItemInfo PistonHead = new ItemInfo(34, 0, "Piston Head", "minecraft:piston_head");
        public static ItemInfo WhiteWool = new ItemInfo(35, 0, "White Wool", "minecraft:wool");
        public static ItemInfo OrangeWool = new ItemInfo(35, 1, "Orange Wool", "minecraft:wool");
        public static ItemInfo MagentaWool = new ItemInfo(35, 2, "Magenta Wool", "minecraft:wool");
        public static ItemInfo LightBlueWool = new ItemInfo(35, 3, "Light Blue Wool", "minecraft:wool");
        public static ItemInfo YellowWool = new ItemInfo(35, 4, "Yellow Wool", "minecraft:wool");
        public static ItemInfo LimeWool = new ItemInfo(35, 5, "Lime Wool", "minecraft:wool");
        public static ItemInfo PinkWool = new ItemInfo(35, 6, "Pink Wool", "minecraft:wool");
        public static ItemInfo GrayWool = new ItemInfo(35, 7, "Gray Wool", "minecraft:wool");
        public static ItemInfo LightGrayWool = new ItemInfo(35, 8, "Light Gray Wool", "minecraft:wool");
        public static ItemInfo CyanWool = new ItemInfo(35, 9, "Cyan Wool", "minecraft:wool");
        public static ItemInfo PurpleWool = new ItemInfo(35, 10, "Purple Wool", "minecraft:wool");
        public static ItemInfo BlueWool = new ItemInfo(35, 11, "Blue Wool", "minecraft:wool");
        public static ItemInfo BrownWool = new ItemInfo(35, 12, "Brown Wool", "minecraft:wool");
        public static ItemInfo GreenWool = new ItemInfo(35, 13, "Green Wool", "minecraft:wool");
        public static ItemInfo RedWool = new ItemInfo(35, 14, "Red Wool", "minecraft:wool");
        public static ItemInfo BlackWool = new ItemInfo(35, 15, "Black Wool", "minecraft:wool");
        public static ItemInfo Dandelion = new ItemInfo(37, 0, "Dandelion", "minecraft:yellow_flower");
        public static ItemInfo Poppy = new ItemInfo(38, 0, "Poppy", "minecraft:red_flower");
        public static ItemInfo BlueOrchid = new ItemInfo(38, 1, "Blue Orchid", "minecraft:red_flower");
        public static ItemInfo Allium = new ItemInfo(38, 2, "Allium", "minecraft:red_flower");
        public static ItemInfo AzureBluet = new ItemInfo(38, 3, "Azure Bluet", "minecraft:red_flower");
        public static ItemInfo RedTulip = new ItemInfo(38, 4, "Red Tulip", "minecraft:red_flower");
        public static ItemInfo OrangeTulip = new ItemInfo(38, 5, "Orange Tulip", "minecraft:red_flower");
        public static ItemInfo WhiteTulip = new ItemInfo(38, 6, "White Tulip", "minecraft:red_flower");
        public static ItemInfo PinkTulip = new ItemInfo(38, 7, "Pink Tulip", "minecraft:red_flower");
        public static ItemInfo OxeyeDaisy = new ItemInfo(38, 8, "Oxeye Daisy", "minecraft:red_flower");
        public static ItemInfo BrownMushroom = new ItemInfo(39, 0, "Brown Mushroom", "minecraft:brown_mushroom");
        public static ItemInfo RedMushroom = new ItemInfo(40, 0, "Red Mushroom", "minecraft:red_mushroom");
        public static ItemInfo GoldBlock = new ItemInfo(41, 0, "Gold Block", "minecraft:gold_block");
        public static ItemInfo IronBlock = new ItemInfo(42, 0, "Iron Block", "minecraft:iron_block");
        public static ItemInfo DoubleStoneSlab = new ItemInfo(43, 0, "Double Stone Slab", "minecraft:double_stone_slab");
        public static ItemInfo DoubleSandstoneSlab = new ItemInfo(43, 1, "Double Sandstone Slab", "minecraft:double_stone_slab");
        public static ItemInfo DoubleWoodenSlab = new ItemInfo(43, 2, "Double Wooden Slab", "minecraft:double_stone_slab");
        public static ItemInfo DoubleCobblestoneSlab = new ItemInfo(43, 3, "Double Cobblestone Slab", "minecraft:double_stone_slab");
        public static ItemInfo DoubleBrickSlab = new ItemInfo(43, 4, "Double Brick Slab", "minecraft:double_stone_slab");
        public static ItemInfo DoubleStoneBrickSlab = new ItemInfo(43, 5, "Double Stone Brick Slab", "minecraft:double_stone_slab");
        public static ItemInfo DoubleNetherBrickSlab = new ItemInfo(43, 6, "Double Nether Brick Slab", "minecraft:double_stone_slab");
        public static ItemInfo DoubleQuartzSlab = new ItemInfo(43, 7, "Double Quartz Slab", "minecraft:double_stone_slab");
        public static ItemInfo StoneSlab = new ItemInfo(44, 0, "Stone Slab", "minecraft:stone_slab");
        public static ItemInfo SandstoneSlab = new ItemInfo(44, 1, "Sandstone Slab", "minecraft:stone_slab");
        public static ItemInfo WoodenSlab = new ItemInfo(44, 2, "Wooden Slab", "minecraft:stone_slab");
        public static ItemInfo CobblestoneSlab = new ItemInfo(44, 3, "Cobblestone Slab", "minecraft:stone_slab");
        public static ItemInfo BrickSlab = new ItemInfo(44, 4, "Brick Slab", "minecraft:stone_slab");
        public static ItemInfo StoneBrickSlab = new ItemInfo(44, 5, "Stone Brick Slab", "minecraft:stone_slab");
        public static ItemInfo NetherBrickSlab = new ItemInfo(44, 6, "Nether Brick Slab", "minecraft:stone_slab");
        public static ItemInfo QuartzSlab = new ItemInfo(44, 7, "Quartz Slab", "minecraft:stone_slab");
        public static ItemInfo Bricks = new ItemInfo(45, 0, "Bricks", "minecraft:brick_block");
        public static ItemInfo Tnt = new ItemInfo(46, 0, "TNT", "minecraft:tnt");
        public static ItemInfo Bookshelf = new ItemInfo(47, 0, "Bookshelf", "minecraft:bookshelf");
        public static ItemInfo MossStone = new ItemInfo(48, 0, "Moss Stone", "minecraft:mossy_cobblestone");
        public static ItemInfo Obsidian = new ItemInfo(49, 0, "Obsidian", "minecraft:obsidian");
        public static ItemInfo Torch = new ItemInfo(50, 0, "Torch", "minecraft:torch");
        public static ItemInfo Fire = new ItemInfo(51, 0, "Fire", "minecraft:fire");
        public static ItemInfo MonsterSpawner = new ItemInfo(52, 0, "Monster Spawner", "minecraft:mob_spawner");
        public static ItemInfo OakWoodStairs = new ItemInfo(53, 0, "Oak Wood Stairs", "minecraft:oak_stairs");
        public static ItemInfo Chest = new ItemInfo(54, 0, "Chest", "minecraft:chest");
        public static ItemInfo RedstoneWire = new ItemInfo(55, 0, "Redstone Wire", "minecraft:redstone_wire");
        public static ItemInfo DiamondOre = new ItemInfo(56, 0, "Diamond Ore", "minecraft:diamond_ore");
        public static ItemInfo DiamondBlock = new ItemInfo(57, 0, "Diamond Block", "minecraft:diamond_block");
        public static ItemInfo CraftingTable = new ItemInfo(58, 0, "Crafting Table", "minecraft:crafting_table");
        public static ItemInfo WheatCrops = new ItemInfo(59, 0, "Wheat Crops", "minecraft:wheat");
        public static ItemInfo Farmland = new ItemInfo(60, 0, "Farmland", "minecraft:farmland");
        public static ItemInfo Furnace = new ItemInfo(61, 0, "Furnace", "minecraft:furnace");
        public static ItemInfo BurningFurnace = new ItemInfo(62, 0, "Burning Furnace", "minecraft:lit_furnace");
        public static ItemInfo StandingSignBlock = new ItemInfo(63, 0, "Standing Sign Block", "minecraft:standing_sign");
        public static ItemInfo OakDoorBlock = new ItemInfo(64, 0, "Oak Door Block", "minecraft:wooden_door");
        public static ItemInfo Ladder = new ItemInfo(65, 0, "Ladder", "minecraft:ladder");
        public static ItemInfo Rail = new ItemInfo(66, 0, "Rail", "minecraft:rail");
        public static ItemInfo CobblestoneStairs = new ItemInfo(67, 0, "Cobblestone Stairs", "minecraft:stone_stairs");
        public static ItemInfo WallMountedSignBlock = new ItemInfo(68, 0, "Wall-mounted Sign Block", "minecraft:wall_sign");
        public static ItemInfo Lever = new ItemInfo(69, 0, "Lever", "minecraft:lever");
        public static ItemInfo StonePressurePlate = new ItemInfo(70, 0, "Stone Pressure Plate", "minecraft:stone_pressure_plate");
        public static ItemInfo IronDoorBlock = new ItemInfo(71, 0, "Iron Door Block", "minecraft:iron_door");
        public static ItemInfo WoodenPressurePlate = new ItemInfo(72, 0, "Wooden Pressure Plate", "minecraft:wooden_pressure_plate");
        public static ItemInfo RedstoneOre = new ItemInfo(73, 0, "Redstone Ore", "minecraft:redstone_ore");
        public static ItemInfo GlowingRedstoneOre = new ItemInfo(74, 0, "Glowing Redstone Ore", "minecraft:lit_redstone_ore");
        public static ItemInfo RedstoneTorchOff = new ItemInfo(75, 0, "Redstone Torch (off)", "minecraft:unlit_redstone_torch");
        public static ItemInfo RedstoneTorchOn = new ItemInfo(76, 0, "Redstone Torch (on)", "minecraft:redstone_torch");
        public static ItemInfo StoneButton = new ItemInfo(77, 0, "Stone Button", "minecraft:stone_button");
        public static ItemInfo Snow = new ItemInfo(78, 0, "Snow", "minecraft:snow_layer");
        public static ItemInfo Ice = new ItemInfo(79, 0, "Ice", "minecraft:ice");
        public static ItemInfo SnowBlock = new ItemInfo(80, 0, "Snow Block", "minecraft:snow").SetStackSize(16);
        public static ItemInfo Cactus = new ItemInfo(81, 0, "Cactus", "minecraft:cactus");
        public static ItemInfo Clay = new ItemInfo(82, 0, "Clay", "minecraft:clay");
        public static ItemInfo SugarCanes = new ItemInfo(83, 0, "Sugar Canes", "minecraft:reeds");
        public static ItemInfo Jukebox = new ItemInfo(84, 0, "Jukebox", "minecraft:jukebox");
        public static ItemInfo OakFence = new ItemInfo(85, 0, "Oak Fence", "minecraft:fence");
        public static ItemInfo Pumpkin = new ItemInfo(86, 0, "Pumpkin", "minecraft:pumpkin");
        public static ItemInfo Netherrack = new ItemInfo(87, 0, "Netherrack", "minecraft:netherrack");
        public static ItemInfo SoulSand = new ItemInfo(88, 0, "Soul Sand", "minecraft:soul_sand");
        public static ItemInfo Glowstone = new ItemInfo(89, 0, "Glowstone", "minecraft:glowstone");
        public static ItemInfo NetherPortal = new ItemInfo(90, 0, "Nether Portal", "minecraft:portal");
        public static ItemInfo JackOLantern = new ItemInfo(91, 0, "Jack o'Lantern", "minecraft:lit_pumpkin");
        public static ItemInfo CakeBlock = new ItemInfo(92, 0, "Cake Block", "minecraft:cake");
        public static ItemInfo RedstoneRepeaterBlockOff = new ItemInfo(93, 0, "Redstone Repeater Block (off)", "minecraft:unpowered_repeater");
        public static ItemInfo RedstoneRepeaterBlockOn = new ItemInfo(94, 0, "Redstone Repeater Block (on)", "minecraft:powered_repeater");
        public static ItemInfo WhiteStainedGlass = new ItemInfo(95, 0, "White Stained Glass", "minecraft:stained_glass");
        public static ItemInfo OrangeStainedGlass = new ItemInfo(95, 1, "Orange Stained Glass", "minecraft:stained_glass");
        public static ItemInfo MagentaStainedGlass = new ItemInfo(95, 2, "Magenta Stained Glass", "minecraft:stained_glass");
        public static ItemInfo LightBlueStainedGlass = new ItemInfo(95, 3, "Light Blue Stained Glass", "minecraft:stained_glass");
        public static ItemInfo YellowStainedGlass = new ItemInfo(95, 4, "Yellow Stained Glass", "minecraft:stained_glass");
        public static ItemInfo LimeStainedGlass = new ItemInfo(95, 5, "Lime Stained Glass", "minecraft:stained_glass");
        public static ItemInfo PinkStainedGlass = new ItemInfo(95, 6, "Pink Stained Glass", "minecraft:stained_glass");
        public static ItemInfo GrayStainedGlass = new ItemInfo(95, 7, "Gray Stained Glass", "minecraft:stained_glass");
        public static ItemInfo LightGrayStainedGlass = new ItemInfo(95, 8, "Light Gray Stained Glass", "minecraft:stained_glass");
        public static ItemInfo CyanStainedGlass = new ItemInfo(95, 9, "Cyan Stained Glass", "minecraft:stained_glass");
        public static ItemInfo PurpleStainedGlass = new ItemInfo(95, 10, "Purple Stained Glass", "minecraft:stained_glass");
        public static ItemInfo BlueStainedGlass = new ItemInfo(95, 11, "Blue Stained Glass", "minecraft:stained_glass");
        public static ItemInfo BrownStainedGlass = new ItemInfo(95, 12, "Brown Stained Glass", "minecraft:stained_glass");
        public static ItemInfo GreenStainedGlass = new ItemInfo(95, 13, "Green Stained Glass", "minecraft:stained_glass");
        public static ItemInfo RedStainedGlass = new ItemInfo(95, 14, "Red Stained Glass", "minecraft:stained_glass");
        public static ItemInfo BlackStainedGlass = new ItemInfo(95, 15, "Black Stained Glass", "minecraft:stained_glass");
        public static ItemInfo WoodenTrapdoor = new ItemInfo(96, 0, "Wooden Trapdoor", "minecraft:trapdoor");
        public static ItemInfo StoneMonsterEgg = new ItemInfo(97, 0, "Stone Monster Egg", "minecraft:monster_egg");
        public static ItemInfo CobblestoneMonsterEgg = new ItemInfo(97, 1, "Cobblestone Monster Egg", "minecraft:monster_egg");
        public static ItemInfo StoneBrickMonsterEgg = new ItemInfo(97, 2, "Stone Brick Monster Egg", "minecraft:monster_egg");
        public static ItemInfo MossyStoneBrickMonsterEgg = new ItemInfo(97, 3, "Mossy Stone Brick Monster Egg", "minecraft:monster_egg");
        public static ItemInfo CrackedStoneBrickMonsterEgg = new ItemInfo(97, 4, "Cracked Stone Brick Monster Egg", "minecraft:monster_egg");
        public static ItemInfo ChiseledStoneBrickMonsterEgg = new ItemInfo(97, 5, "Chiseled Stone Brick Monster Egg", "minecraft:monster_egg");
        public static ItemInfo StoneBricks = new ItemInfo(98, 0, "Stone Bricks", "minecraft:stonebrick");
        public static ItemInfo MossyStoneBricks = new ItemInfo(98, 1, "Mossy Stone Bricks", "minecraft:stonebrick");
        public static ItemInfo CrackedStoneBricks = new ItemInfo(98, 2, "Cracked Stone Bricks", "minecraft:stonebrick");
        public static ItemInfo ChiseledStoneBricks = new ItemInfo(98, 3, "Chiseled Stone Bricks", "minecraft:stonebrick");
        public static ItemInfo BrownMushroomBlock = new ItemInfo(99, 0, "Brown Mushroom Block", "minecraft:brown_mushroom_block");
        public static ItemInfo RedMushroomBlock = new ItemInfo(100, 0, "Red Mushroom Block", "minecraft:red_mushroom_block");
        public static ItemInfo IronBars = new ItemInfo(101, 0, "Iron Bars", "minecraft:iron_bars");
        public static ItemInfo GlassPane = new ItemInfo(102, 0, "Glass Pane", "minecraft:glass_pane");
        public static ItemInfo MelonBlock = new ItemInfo(103, 0, "Melon Block", "minecraft:melon_block");
        public static ItemInfo PumpkinStem = new ItemInfo(104, 0, "Pumpkin Stem", "minecraft:pumpkin_stem");
        public static ItemInfo MelonStem = new ItemInfo(105, 0, "Melon Stem", "minecraft:melon_stem");
        public static ItemInfo Vines = new ItemInfo(106, 0, "Vines", "minecraft:vine");
        public static ItemInfo OakFenceGate = new ItemInfo(107, 0, "Oak Fence Gate", "minecraft:fence_gate");
        public static ItemInfo BrickStairs = new ItemInfo(108, 0, "Brick Stairs", "minecraft:brick_stairs");
        public static ItemInfo StoneBrickStairs = new ItemInfo(109, 0, "Stone Brick Stairs", "minecraft:stone_brick_stairs");
        public static ItemInfo Mycelium = new ItemInfo(110, 0, "Mycelium", "minecraft:mycelium");
        public static ItemInfo LilyPad = new ItemInfo(111, 0, "Lily Pad", "minecraft:waterlily");
        public static ItemInfo NetherBrick = new ItemInfo(112, 0, "Nether Brick", "minecraft:nether_brick").SetStackSize(64);
        public static ItemInfo NetherBrickFence = new ItemInfo(113, 0, "Nether Brick Fence", "minecraft:nether_brick_fence");
        public static ItemInfo NetherBrickStairs = new ItemInfo(114, 0, "Nether Brick Stairs", "minecraft:nether_brick_stairs");
        public static ItemInfo NetherWart = new ItemInfo(115, 0, "Nether Wart", "minecraft:nether_wart").SetStackSize(64);
        public static ItemInfo EnchantmentTable = new ItemInfo(116, 0, "Enchantment Table", "minecraft:enchanting_table");
        public static ItemInfo BrewingStand = new ItemInfo(117, 0, "Brewing Stand", "minecraft:brewing_stand").SetStackSize(64);
        public static ItemInfo Cauldron = new ItemInfo(118, 0, "Cauldron", "minecraft:cauldron");
        public static ItemInfo EndPortal = new ItemInfo(119, 0, "End Portal", "minecraft:end_portal");
        public static ItemInfo EndPortalFrame = new ItemInfo(120, 0, "End Portal Frame", "minecraft:end_portal_frame");
        public static ItemInfo EndStone = new ItemInfo(121, 0, "End Stone", "minecraft:end_stone");
        public static ItemInfo DragonEgg = new ItemInfo(122, 0, "Dragon Egg", "minecraft:dragon_egg");
        public static ItemInfo RedstoneLampInactive = new ItemInfo(123, 0, "Redstone Lamp (inactive)", "minecraft:redstone_lamp");
        public static ItemInfo RedstoneLampActive = new ItemInfo(124, 0, "Redstone Lamp (active)", "minecraft:lit_redstone_lamp");
        public static ItemInfo DoubleOakWoodSlab = new ItemInfo(125, 0, "Double Oak Wood Slab", "minecraft:double_wooden_slab");
        public static ItemInfo DoubleSpruceWoodSlab = new ItemInfo(125, 1, "Double Spruce Wood Slab", "minecraft:double_wooden_slab");
        public static ItemInfo DoubleBirchWoodSlab = new ItemInfo(125, 2, "Double Birch Wood Slab", "minecraft:double_wooden_slab");
        public static ItemInfo DoubleJungleWoodSlab = new ItemInfo(125, 3, "Double Jungle Wood Slab", "minecraft:double_wooden_slab");
        public static ItemInfo DoubleAcaciaWoodSlab = new ItemInfo(125, 4, "Double Acacia Wood Slab", "minecraft:double_wooden_slab");
        public static ItemInfo DoubleDarkOakWoodSlab = new ItemInfo(125, 5, "Double Dark Oak Wood Slab", "minecraft:double_wooden_slab");
        public static ItemInfo OakWoodSlab = new ItemInfo(126, 0, "Oak Wood Slab", "minecraft:wooden_slab");
        public static ItemInfo SpruceWoodSlab = new ItemInfo(126, 1, "Spruce Wood Slab", "minecraft:wooden_slab");
        public static ItemInfo BirchWoodSlab = new ItemInfo(126, 2, "Birch Wood Slab", "minecraft:wooden_slab");
        public static ItemInfo JungleWoodSlab = new ItemInfo(126, 3, "Jungle Wood Slab", "minecraft:wooden_slab");
        public static ItemInfo AcaciaWoodSlab = new ItemInfo(126, 4, "Acacia Wood Slab", "minecraft:wooden_slab");
        public static ItemInfo DarkOakWoodSlab = new ItemInfo(126, 5, "Dark Oak Wood Slab", "minecraft:wooden_slab");
        public static ItemInfo Cocoa = new ItemInfo(127, 0, "Cocoa", "minecraft:cocoa");
        public static ItemInfo SandstoneStairs = new ItemInfo(128, 0, "Sandstone Stairs", "minecraft:sandstone_stairs");
        public static ItemInfo EmeraldOre = new ItemInfo(129, 0, "Emerald Ore", "minecraft:emerald_ore");
        public static ItemInfo EnderChest = new ItemInfo(130, 0, "Ender Chest", "minecraft:ender_chest");
        public static ItemInfo TripwireHook = new ItemInfo(131, 0, "Tripwire Hook", "minecraft:tripwire_hook");
        public static ItemInfo Tripwire = new ItemInfo(132, 0, "Tripwire", "minecraft:tripwire_hook");
        public static ItemInfo EmeraldBlock = new ItemInfo(133, 0, "Emerald Block", "minecraft:emerald_block");
        public static ItemInfo SpruceWoodStairs = new ItemInfo(134, 0, "Spruce Wood Stairs", "minecraft:spruce_stairs");
        public static ItemInfo BirchWoodStairs = new ItemInfo(135, 0, "Birch Wood Stairs", "minecraft:birch_stairs");
        public static ItemInfo JungleWoodStairs = new ItemInfo(136, 0, "Jungle Wood Stairs", "minecraft:jungle_stairs");
        public static ItemInfo CommandBlock = new ItemInfo(137, 0, "Command Block", "minecraft:command_block");
        public static ItemInfo Beacon = new ItemInfo(138, 0, "Beacon", "minecraft:beacon");
        public static ItemInfo CobblestoneWall = new ItemInfo(139, 0, "Cobblestone Wall", "minecraft:cobblestone_wall");
        public static ItemInfo MossyCobblestoneWall = new ItemInfo(139, 1, "Mossy Cobblestone Wall", "minecraft:cobblestone_wall");
        public static ItemInfo FlowerPot = new ItemInfo(140, 0, "Flower Pot", "minecraft:flower_pot").SetStackSize(64);
        public static ItemInfo Carrots = new ItemInfo(141, 0, "Carrots", "minecraft:carrots");
        public static ItemInfo Potatoes = new ItemInfo(142, 0, "Potatoes", "minecraft:potatoes");
        public static ItemInfo WoodenButton = new ItemInfo(143, 0, "Wooden Button", "minecraft:wooden_button");
        public static ItemInfo MobHead = new ItemInfo(144, 0, "Mob Head", "minecraft:skull");
        public static ItemInfo Anvil = new ItemInfo(145, 0, "Anvil", "minecraft:anvil");
        public static ItemInfo TrappedChest = new ItemInfo(146, 0, "Trapped Chest", "minecraft:trapped_chest");
        public static ItemInfo WeightedPressurePlateLight = new ItemInfo(147, 0, "Weighted Pressure Plate (light)", "minecraft:light_weighted_pressure_plate");
        public static ItemInfo WeightedPressurePlateHeavy = new ItemInfo(148, 0, "Weighted Pressure Plate (heavy)", "minecraft:heavy_weighted_pressure_plate");
        public static ItemInfo RedstoneComparatorInactive = new ItemInfo(149, 0, "Redstone Comparator (inactive)", "minecraft:unpowered_comparator");
        public static ItemInfo RedstoneComparatorActive = new ItemInfo(150, 0, "Redstone Comparator (active)", "minecraft:powered_comparator");
        public static ItemInfo DaylightSensor = new ItemInfo(151, 0, "Daylight Sensor", "minecraft:daylight_detector");
        public static ItemInfo RedstoneBlock = new ItemInfo(152, 0, "Redstone Block", "minecraft:redstone_block");
        public static ItemInfo NetherQuartzOre = new ItemInfo(153, 0, "Nether Quartz Ore", "minecraft:quartz_ore");
        public static ItemInfo Hopper = new ItemInfo(154, 0, "Hopper", "minecraft:hopper");
        public static ItemInfo QuartzBlock = new ItemInfo(155, 0, "Quartz Block", "minecraft:quartz_block");
        public static ItemInfo ChiseledQuartzBlock = new ItemInfo(155, 1, "Chiseled Quartz Block", "minecraft:quartz_block");
        public static ItemInfo PillarQuartzBlock = new ItemInfo(155, 2, "Pillar Quartz Block", "minecraft:quartz_block");
        public static ItemInfo QuartzStairs = new ItemInfo(156, 0, "Quartz Stairs", "minecraft:quartz_stairs");
        public static ItemInfo ActivatorRail = new ItemInfo(157, 0, "Activator Rail", "minecraft:activator_rail");
        public static ItemInfo Dropper = new ItemInfo(158, 0, "Dropper", "minecraft:dropper");
        public static ItemInfo WhiteHardenedClay = new ItemInfo(159, 0, "White Hardened Clay", "minecraft:stained_hardened_clay");
        public static ItemInfo OrangeHardenedClay = new ItemInfo(159, 1, "Orange Hardened Clay", "minecraft:stained_hardened_clay");
        public static ItemInfo MagentaHardenedClay = new ItemInfo(159, 2, "Magenta Hardened Clay", "minecraft:stained_hardened_clay");
        public static ItemInfo LightBlueHardenedClay = new ItemInfo(159, 3, "Light Blue Hardened Clay", "minecraft:stained_hardened_clay");
        public static ItemInfo YellowHardenedClay = new ItemInfo(159, 4, "Yellow Hardened Clay", "minecraft:stained_hardened_clay");
        public static ItemInfo LimeHardenedClay = new ItemInfo(159, 5, "Lime Hardened Clay", "minecraft:stained_hardened_clay");
        public static ItemInfo PinkHardenedClay = new ItemInfo(159, 6, "Pink Hardened Clay", "minecraft:stained_hardened_clay");
        public static ItemInfo GrayHardenedClay = new ItemInfo(159, 7, "Gray Hardened Clay", "minecraft:stained_hardened_clay");
        public static ItemInfo LightGrayHardenedClay = new ItemInfo(159, 8, "Light Gray Hardened Clay", "minecraft:stained_hardened_clay");
        public static ItemInfo CyanHardenedClay = new ItemInfo(159, 9, "Cyan Hardened Clay", "minecraft:stained_hardened_clay");
        public static ItemInfo PurpleHardenedClay = new ItemInfo(159, 10, "Purple Hardened Clay", "minecraft:stained_hardened_clay");
        public static ItemInfo BlueHardenedClay = new ItemInfo(159, 11, "Blue Hardened Clay", "minecraft:stained_hardened_clay");
        public static ItemInfo BrownHardenedClay = new ItemInfo(159, 12, "Brown Hardened Clay", "minecraft:stained_hardened_clay");
        public static ItemInfo GreenHardenedClay = new ItemInfo(159, 13, "Green Hardened Clay", "minecraft:stained_hardened_clay");
        public static ItemInfo RedHardenedClay = new ItemInfo(159, 14, "Red Hardened Clay", "minecraft:stained_hardened_clay");
        public static ItemInfo BlackHardenedClay = new ItemInfo(159, 15, "Black Hardened Clay", "minecraft:stained_hardened_clay");
        public static ItemInfo WhiteStainedGlassPane = new ItemInfo(160, 0, "White Stained Glass Pane", "minecraft:stained_glass_pane");
        public static ItemInfo OrangeStainedGlassPane = new ItemInfo(160, 1, "Orange Stained Glass Pane", "minecraft:stained_glass_pane");
        public static ItemInfo MagentaStainedGlassPane = new ItemInfo(160, 2, "Magenta Stained Glass Pane", "minecraft:stained_glass_pane");
        public static ItemInfo LightBlueStainedGlassPane = new ItemInfo(160, 3, "Light Blue Stained Glass Pane", "minecraft:stained_glass_pane");
        public static ItemInfo YellowStainedGlassPane = new ItemInfo(160, 4, "Yellow Stained Glass Pane", "minecraft:stained_glass_pane");
        public static ItemInfo LimeStainedGlassPane = new ItemInfo(160, 5, "Lime Stained Glass Pane", "minecraft:stained_glass_pane");
        public static ItemInfo PinkStainedGlassPane = new ItemInfo(160, 6, "Pink Stained Glass Pane", "minecraft:stained_glass_pane");
        public static ItemInfo GrayStainedGlassPane = new ItemInfo(160, 7, "Gray Stained Glass Pane", "minecraft:stained_glass_pane");
        public static ItemInfo LightGrayStainedGlassPane = new ItemInfo(160, 8, "Light Gray Stained Glass Pane", "minecraft:stained_glass_pane");
        public static ItemInfo CyanStainedGlassPane = new ItemInfo(160, 9, "Cyan Stained Glass Pane", "minecraft:stained_glass_pane");
        public static ItemInfo PurpleStainedGlassPane = new ItemInfo(160, 10, "Purple Stained Glass Pane", "minecraft:stained_glass_pane");
        public static ItemInfo BlueStainedGlassPane = new ItemInfo(160, 11, "Blue Stained Glass Pane", "minecraft:stained_glass_pane");
        public static ItemInfo BrownStainedGlassPane = new ItemInfo(160, 12, "Brown Stained Glass Pane", "minecraft:stained_glass_pane");
        public static ItemInfo GreenStainedGlassPane = new ItemInfo(160, 13, "Green Stained Glass Pane", "minecraft:stained_glass_pane");
        public static ItemInfo RedStainedGlassPane = new ItemInfo(160, 14, "Red Stained Glass Pane", "minecraft:stained_glass_pane");
        public static ItemInfo BlackStainedGlassPane = new ItemInfo(160, 15, "Black Stained Glass Pane", "minecraft:stained_glass_pane");
        public static ItemInfo AcaciaLeaves = new ItemInfo(161, 0, "Acacia Leaves", "minecraft:leaves2");
        public static ItemInfo DarkOakLeaves = new ItemInfo(161, 1, "Dark Oak Leaves", "minecraft:leaves2");
        public static ItemInfo AcaciaWood = new ItemInfo(162, 0, "Acacia Wood", "minecraft:log2");
        public static ItemInfo DarkOakWood = new ItemInfo(162, 1, "Dark Oak Wood", "minecraft:log2");
        public static ItemInfo AcaciaWoodStairs = new ItemInfo(163, 0, "Acacia Wood Stairs", "minecraft:acacia_stairs");
        public static ItemInfo DarkOakWoodStairs = new ItemInfo(164, 0, "Dark Oak Wood Stairs", "minecraft:dark_oak_stairs");
        public static ItemInfo SlimeBlock = new ItemInfo(165, 0, "Slime Block", "minecraft:slime");
        public static ItemInfo Barrier = new ItemInfo(166, 0, "Barrier", "minecraft:barrier");
        public static ItemInfo IronTrapdoor = new ItemInfo(167, 0, "Iron Trapdoor", "minecraft:iron_trapdoor");
        public static ItemInfo Prismarine = new ItemInfo(168, 0, "Prismarine", "minecraft:prismarine");
        public static ItemInfo PrismarineBricks = new ItemInfo(168, 1, "Prismarine Bricks", "minecraft:prismarine");
        public static ItemInfo DarkPrismarine = new ItemInfo(168, 2, "Dark Prismarine", "minecraft:prismarine");
        public static ItemInfo SeaLantern = new ItemInfo(169, 0, "Sea Lantern", "minecraft:sea_lantern");
        public static ItemInfo HayBale = new ItemInfo(170, 0, "Hay Bale", "minecraft:hay_block");
        public static ItemInfo WhiteCarpet = new ItemInfo(171, 0, "White Carpet", "minecraft:carpet");
        public static ItemInfo OrangeCarpet = new ItemInfo(171, 1, "Orange Carpet", "minecraft:carpet");
        public static ItemInfo MagentaCarpet = new ItemInfo(171, 2, "Magenta Carpet", "minecraft:carpet");
        public static ItemInfo LightBlueCarpet = new ItemInfo(171, 3, "Light Blue Carpet", "minecraft:carpet");
        public static ItemInfo YellowCarpet = new ItemInfo(171, 4, "Yellow Carpet", "minecraft:carpet");
        public static ItemInfo LimeCarpet = new ItemInfo(171, 5, "Lime Carpet", "minecraft:carpet");
        public static ItemInfo PinkCarpet = new ItemInfo(171, 6, "Pink Carpet", "minecraft:carpet");
        public static ItemInfo GrayCarpet = new ItemInfo(171, 7, "Gray Carpet", "minecraft:carpet");
        public static ItemInfo LightGrayCarpet = new ItemInfo(171, 8, "Light Gray Carpet", "minecraft:carpet");
        public static ItemInfo CyanCarpet = new ItemInfo(171, 9, "Cyan Carpet", "minecraft:carpet");
        public static ItemInfo PurpleCarpet = new ItemInfo(171, 10, "Purple Carpet", "minecraft:carpet");
        public static ItemInfo BlueCarpet = new ItemInfo(171, 11, "Blue Carpet", "minecraft:carpet");
        public static ItemInfo BrownCarpet = new ItemInfo(171, 12, "Brown Carpet", "minecraft:carpet");
        public static ItemInfo GreenCarpet = new ItemInfo(171, 13, "Green Carpet", "minecraft:carpet");
        public static ItemInfo RedCarpet = new ItemInfo(171, 14, "Red Carpet", "minecraft:carpet");
        public static ItemInfo BlackCarpet = new ItemInfo(171, 15, "Black Carpet", "minecraft:carpet");
        public static ItemInfo HardenedClay = new ItemInfo(172, 0, "Hardened Clay", "minecraft:hardened_clay");
        public static ItemInfo BlockOfCoal = new ItemInfo(173, 0, "Block of Coal", "minecraft:coal_block");
        public static ItemInfo PackedIce = new ItemInfo(174, 0, "Packed Ice", "minecraft:packed_ice");
        public static ItemInfo Sunflower = new ItemInfo(175, 0, "Sunflower", "minecraft:double_plant");
        public static ItemInfo Lilac = new ItemInfo(175, 1, "Lilac", "minecraft:double_plant");
        public static ItemInfo DoubleTallgrass = new ItemInfo(175, 2, "Double Tallgrass", "minecraft:double_plant");
        public static ItemInfo LargeFern = new ItemInfo(175, 3, "Large Fern", "minecraft:double_plant");
        public static ItemInfo RoseBush = new ItemInfo(175, 4, "Rose Bush", "minecraft:double_plant");
        public static ItemInfo Peony = new ItemInfo(175, 5, "Peony", "minecraft:double_plant");
        public static ItemInfo FreeStandingBanner = new ItemInfo(176, 0, "Free-standing Banner", "minecraft:standing_banner");
        public static ItemInfo WallMountedBanner = new ItemInfo(177, 0, "Wall-mounted Banner", "minecraft:wall_banner");
        public static ItemInfo InvertedDaylightSensor = new ItemInfo(178, 0, "Inverted Daylight Sensor", "minecraft:daylight_detector_inverted");
        public static ItemInfo RedSandstone = new ItemInfo(179, 0, "Red Sandstone", "minecraft:red_sandstone");
        public static ItemInfo ChiseledRedSandstone = new ItemInfo(179, 1, "Chiseled Red Sandstone", "minecraft:red_sandstone");
        public static ItemInfo SmoothRedSandstone = new ItemInfo(179, 2, "Smooth Red Sandstone", "minecraft:red_sandstone");
        public static ItemInfo RedSandstoneStairs = new ItemInfo(180, 0, "Red Sandstone Stairs", "minecraft:red_sandstone_stairs");
        public static ItemInfo DoubleRedSandstoneSlab = new ItemInfo(181, 0, "Double Red Sandstone Slab", "minecraft:double_stone_slab2");
        public static ItemInfo RedSandstoneSlab = new ItemInfo(182, 0, "Red Sandstone Slab", "minecraft:stone_slab2");
        public static ItemInfo SpruceFenceGate = new ItemInfo(183, 0, "Spruce Fence Gate", "minecraft:spruce_fence_gate");
        public static ItemInfo BirchFenceGate = new ItemInfo(184, 0, "Birch Fence Gate", "minecraft:birch_fence_gate");
        public static ItemInfo JungleFenceGate = new ItemInfo(185, 0, "Jungle Fence Gate", "minecraft:jungle_fence_gate");
        public static ItemInfo DarkOakFenceGate = new ItemInfo(186, 0, "Dark Oak Fence Gate", "minecraft:dark_oak_fence_gate");
        public static ItemInfo AcaciaFenceGate = new ItemInfo(187, 0, "Acacia Fence Gate", "minecraft:acacia_fence_gate");
        public static ItemInfo SpruceFence = new ItemInfo(188, 0, "Spruce Fence", "minecraft:spruce_fence");
        public static ItemInfo BirchFence = new ItemInfo(189, 0, "Birch Fence", "minecraft:birch_fence");
        public static ItemInfo JungleFence = new ItemInfo(190, 0, "Jungle Fence", "minecraft:jungle_fence");
        public static ItemInfo DarkOakFence = new ItemInfo(191, 0, "Dark Oak Fence", "minecraft:dark_oak_fence");
        public static ItemInfo AcaciaFence = new ItemInfo(192, 0, "Acacia Fence", "minecraft:acacia_fence");
        public static ItemInfo SpruceDoorBlock = new ItemInfo(193, 0, "Spruce Door Block", "minecraft:spruce_door");
        public static ItemInfo BirchDoorBlock = new ItemInfo(194, 0, "Birch Door Block", "minecraft:birch_door");
        public static ItemInfo JungleDoorBlock = new ItemInfo(195, 0, "Jungle Door Block", "minecraft:jungle_door");
        public static ItemInfo AcaciaDoorBlock = new ItemInfo(196, 0, "Acacia Door Block", "minecraft:acacia_door");
        public static ItemInfo DarkOakDoorBlock = new ItemInfo(197, 0, "Dark Oak Door Block", "minecraft:dark_oak_door");
        public static ItemInfo EndRod = new ItemInfo(198, 0, "End Rod", "minecraft:end_rod");
        public static ItemInfo ChorusPlant = new ItemInfo(199, 0, "Chorus Plant", "minecraft:chorus_plant");
        public static ItemInfo ChorusFlower = new ItemInfo(200, 0, "Chorus Flower", "minecraft:chorus_flower");
        public static ItemInfo PurpurBlock = new ItemInfo(201, 0, "Purpur Block", "minecraft:purpur_block");
        public static ItemInfo PurpurPillar = new ItemInfo(202, 0, "Purpur Pillar", "minecraft:purpur_pillar");
        public static ItemInfo PurpurStairs = new ItemInfo(203, 0, "Purpur Stairs", "minecraft:purpur_stairs");
        public static ItemInfo PurpurDoubleSlab = new ItemInfo(204, 0, "Purpur Double Slab", "minecraft:purpur_double_slab");
        public static ItemInfo PurpurSlab = new ItemInfo(205, 0, "Purpur Slab", "minecraft:purpur_slab");
        public static ItemInfo EndStoneBricks = new ItemInfo(206, 0, "End Stone Bricks", "minecraft:end_bricks");
        public static ItemInfo BeetrootBlock = new ItemInfo(207, 0, "Beetroot Block", "minecraft:beetroots");
        public static ItemInfo GrassPath = new ItemInfo(208, 0, "Grass Path", "minecraft:grass_path");
        public static ItemInfo EndGateway = new ItemInfo(209, 0, "End Gateway", "minecraft:end_gateway");
        public static ItemInfo RepeatingCommandBlock = new ItemInfo(210, 0, "Repeating Command Block", "minecraft:repeating_command_block");
        public static ItemInfo ChainCommandBlock = new ItemInfo(211, 0, "Chain Command Block", "minecraft:chain_command_block");
        public static ItemInfo FrostedIce = new ItemInfo(212, 0, "Frosted Ice", "minecraft:frosted_ice");
        public static ItemInfo MagmaBlock = new ItemInfo(213, 0, "Magma Block", "minecraft:magma");
        public static ItemInfo NetherWartBlock = new ItemInfo(214, 0, "Nether Wart Block", "minecraft:nether_wart_block");
        public static ItemInfo RedNetherBrick = new ItemInfo(215, 0, "Red Nether Brick", "minecraft:red_nether_brick");
        public static ItemInfo BoneBlock = new ItemInfo(216, 0, "Bone Block", "minecraft:bone_block");
        public static ItemInfo StructureVoid = new ItemInfo(217, 0, "Structure Void", "minecraft:structure_void");
        public static ItemInfo Observer = new ItemInfo(218, 0, "Observer", "minecraft:observer");
        public static ItemInfo WhiteShulkerBox = new ItemInfo(219, 0, "White Shulker Box", "minecraft:white_shulker_box");
        public static ItemInfo OrangeShulkerBox = new ItemInfo(220, 0, "Orange Shulker Box", "minecraft:orange_shulker_box");
        public static ItemInfo MagentaShulkerBox = new ItemInfo(221, 0, "Magenta Shulker Box", "minecraft:magenta_shulker_box");
        public static ItemInfo LightBlueShulkerBox = new ItemInfo(222, 0, "Light Blue Shulker Box", "minecraft:light_blue_shulker_box");
        public static ItemInfo YellowShulkerBox = new ItemInfo(223, 0, "Yellow Shulker Box", "minecraft:yellow_shulker_box");
        public static ItemInfo LimeShulkerBox = new ItemInfo(224, 0, "Lime Shulker Box", "minecraft:lime_shulker_box");
        public static ItemInfo PinkShulkerBox = new ItemInfo(225, 0, "Pink Shulker Box", "minecraft:pink_shulker_box");
        public static ItemInfo GrayShulkerBox = new ItemInfo(226, 0, "Gray Shulker Box", "minecraft:gray_shulker_box");
        public static ItemInfo LightGrayShulkerBox = new ItemInfo(227, 0, "Light Gray Shulker Box", "minecraft:silver_shulker_box");
        public static ItemInfo CyanShulkerBox = new ItemInfo(228, 0, "Cyan Shulker Box", "minecraft:cyan_shulker_box");
        public static ItemInfo PurpleShulkerBox = new ItemInfo(229, 0, "Purple Shulker Box", "minecraft:purple_shulker_box");
        public static ItemInfo BlueShulkerBox = new ItemInfo(230, 0, "Blue Shulker Box", "minecraft:blue_shulker_box");
        public static ItemInfo BrownShulkerBox = new ItemInfo(231, 0, "Brown Shulker Box", "minecraft:brown_shulker_box");
        public static ItemInfo GreenShulkerBox = new ItemInfo(232, 0, "Green Shulker Box", "minecraft:green_shulker_box");
        public static ItemInfo RedShulkerBox = new ItemInfo(233, 0, "Red Shulker Box", "minecraft:red_shulker_box");
        public static ItemInfo BlackShulkerBox = new ItemInfo(234, 0, "Black Shulker Box", "minecraft:black_shulker_box");
        public static ItemInfo WhiteGlazedTerracotta = new ItemInfo(235, 0, "White Glazed Terracotta", "minecraft:white_glazed_terracotta");
        public static ItemInfo OrangeGlazedTerracotta = new ItemInfo(236, 0, "Orange Glazed Terracotta", "minecraft:orange_glazed_terracotta");
        public static ItemInfo MagentaGlazedTerracotta = new ItemInfo(237, 0, "Magenta Glazed Terracotta", "minecraft:magenta_glazed_terracotta");
        public static ItemInfo LightBlueGlazedTerracotta = new ItemInfo(238, 0, "Light Blue Glazed Terracotta", "minecraft:light_blue_glazed_terracotta");
        public static ItemInfo YellowGlazedTerracotta = new ItemInfo(239, 0, "Yellow Glazed Terracotta", "minecraft:yellow_glazed_terracotta");
        public static ItemInfo LimeGlazedTerracotta = new ItemInfo(240, 0, "Lime Glazed Terracotta", "minecraft:lime_glazed_terracotta");
        public static ItemInfo PinkGlazedTerracotta = new ItemInfo(241, 0, "Pink Glazed Terracotta", "minecraft:pink_glazed_terracotta");
        public static ItemInfo GrayGlazedTerracotta = new ItemInfo(242, 0, "Gray Glazed Terracotta", "minecraft:gray_glazed_terracotta");
        public static ItemInfo LightGrayGlazedTerracotta = new ItemInfo(243, 0, "Light Gray Glazed Terracotta", "minecraft:light_gray_glazed_terracotta");
        public static ItemInfo CyanGlazedTerracotta = new ItemInfo(244, 0, "Cyan Glazed Terracotta", "minecraft:cyan_glazed_terracotta");
        public static ItemInfo PurpleGlazedTerracotta = new ItemInfo(245, 0, "Purple Glazed Terracotta", "minecraft:purple_glazed_terracotta");
        public static ItemInfo BlueGlazedTerracotta = new ItemInfo(246, 0, "Blue Glazed Terracotta", "minecraft:blue_glazed_terracotta");
        public static ItemInfo BrownGlazedTerracotta = new ItemInfo(247, 0, "Brown Glazed Terracotta", "minecraft:brown_glazed_terracotta");
        public static ItemInfo GreenGlazedTerracotta = new ItemInfo(248, 0, "Green Glazed Terracotta", "minecraft:green_glazed_terracotta");
        public static ItemInfo RedGlazedTerracotta = new ItemInfo(249, 0, "Red Glazed Terracotta", "minecraft:red_glazed_terracotta");
        public static ItemInfo BlackGlazedTerracotta = new ItemInfo(250, 0, "Black Glazed Terracotta", "minecraft:black_glazed_terracotta");
        public static ItemInfo WhiteConcrete = new ItemInfo(251, 0, "White Concrete", "minecraft:concrete");
        public static ItemInfo OrangeConcrete = new ItemInfo(251, 1, "Orange Concrete", "minecraft:concrete");
        public static ItemInfo MagentaConcrete = new ItemInfo(251, 2, "Magenta Concrete", "minecraft:concrete");
        public static ItemInfo LightBlueConcrete = new ItemInfo(251, 3, "Light Blue Concrete", "minecraft:concrete");
        public static ItemInfo YellowConcrete = new ItemInfo(251, 4, "Yellow Concrete", "minecraft:concrete");
        public static ItemInfo LimeConcrete = new ItemInfo(251, 5, "Lime Concrete", "minecraft:concrete");
        public static ItemInfo PinkConcrete = new ItemInfo(251, 6, "Pink Concrete", "minecraft:concrete");
        public static ItemInfo GrayConcrete = new ItemInfo(251, 7, "Gray Concrete", "minecraft:concrete");
        public static ItemInfo LightGrayConcrete = new ItemInfo(251, 8, "Light Gray Concrete", "minecraft:concrete");
        public static ItemInfo CyanConcrete = new ItemInfo(251, 9, "Cyan Concrete", "minecraft:concrete");
        public static ItemInfo PurpleConcrete = new ItemInfo(251, 10, "Purple Concrete", "minecraft:concrete");
        public static ItemInfo BlueConcrete = new ItemInfo(251, 11, "Blue Concrete", "minecraft:concrete");
        public static ItemInfo BrownConcrete = new ItemInfo(251, 12, "Brown Concrete", "minecraft:concrete");
        public static ItemInfo GreenConcrete = new ItemInfo(251, 13, "Green Concrete", "minecraft:concrete");
        public static ItemInfo RedConcrete = new ItemInfo(251, 14, "Red Concrete", "minecraft:concrete");
        public static ItemInfo BlackConcrete = new ItemInfo(251, 15, "Black Concrete", "minecraft:concrete");
        public static ItemInfo WhiteConcretePowder = new ItemInfo(252, 0, "White Concrete Powder", "minecraft:concrete_powder");
        public static ItemInfo OrangeConcretePowder = new ItemInfo(252, 1, "Orange Concrete Powder", "minecraft:concrete_powder");
        public static ItemInfo MagentaConcretePowder = new ItemInfo(252, 2, "Magenta Concrete Powder", "minecraft:concrete_powder");
        public static ItemInfo LightBlueConcretePowder = new ItemInfo(252, 3, "Light Blue Concrete Powder", "minecraft:concrete_powder");
        public static ItemInfo YellowConcretePowder = new ItemInfo(252, 4, "Yellow Concrete Powder", "minecraft:concrete_powder");
        public static ItemInfo LimeConcretePowder = new ItemInfo(252, 5, "Lime Concrete Powder", "minecraft:concrete_powder");
        public static ItemInfo PinkConcretePowder = new ItemInfo(252, 6, "Pink Concrete Powder", "minecraft:concrete_powder");
        public static ItemInfo GrayConcretePowder = new ItemInfo(252, 7, "Gray Concrete Powder", "minecraft:concrete_powder");
        public static ItemInfo LightGrayConcretePowder = new ItemInfo(252, 8, "Light Gray Concrete Powder", "minecraft:concrete_powder");
        public static ItemInfo CyanConcretePowder = new ItemInfo(252, 9, "Cyan Concrete Powder", "minecraft:concrete_powder");
        public static ItemInfo PurpleConcretePowder = new ItemInfo(252, 10, "Purple Concrete Powder", "minecraft:concrete_powder");
        public static ItemInfo BlueConcretePowder = new ItemInfo(252, 11, "Blue Concrete Powder", "minecraft:concrete_powder");
        public static ItemInfo BrownConcretePowder = new ItemInfo(252, 12, "Brown Concrete Powder", "minecraft:concrete_powder");
        public static ItemInfo GreenConcretePowder = new ItemInfo(252, 13, "Green Concrete Powder", "minecraft:concrete_powder");
        public static ItemInfo RedConcretePowder = new ItemInfo(252, 14, "Red Concrete Powder", "minecraft:concrete_powder");
        public static ItemInfo BlackConcretePowder = new ItemInfo(252, 15, "Black Concrete Powder", "minecraft:concrete_powder");
        public static ItemInfo StructureBlock = new ItemInfo(255, 0, "Structure Block", "minecraft:structure_block");
        public static ItemInfo IronShovel = new ItemInfo(256, 0, "Iron Shovel", "minecraft:iron_shovel");
        public static ItemInfo IronPickaxe = new ItemInfo(257, 0, "Iron Pickaxe", "minecraft:iron_pickaxe");
        public static ItemInfo IronAxe = new ItemInfo(258, 0, "Iron Axe", "minecraft:iron_axe");
        public static ItemInfo FlintAndSteel = new ItemInfo(259, 0, "Flint and Steel", "minecraft:flint_and_steel");
        public static ItemInfo Apple = new ItemInfo(260, 0, "Apple", "minecraft:apple").SetStackSize(64);
        public static ItemInfo Bow = new ItemInfo(261, 0, "Bow", "minecraft:bow");
        public static ItemInfo Arrow = new ItemInfo(262, 0, "Arrow", "minecraft:arrow").SetStackSize(64);
        public static ItemInfo Coal = new ItemInfo(263, 0, "Coal", "minecraft:coal").SetStackSize(64);
        public static ItemInfo Charcoal = new ItemInfo(263, 1, "Charcoal", "minecraft:coal");
        public static ItemInfo Diamond = new ItemInfo(264, 0, "Diamond", "minecraft:diamond").SetStackSize(64);
        public static ItemInfo IronIngot = new ItemInfo(265, 0, "Iron Ingot", "minecraft:iron_ingot").SetStackSize(64);
        public static ItemInfo GoldIngot = new ItemInfo(266, 0, "Gold Ingot", "minecraft:gold_ingot").SetStackSize(64);
        public static ItemInfo IronSword = new ItemInfo(267, 0, "Iron Sword", "minecraft:iron_sword");
        public static ItemInfo WoodenSword = new ItemInfo(268, 0, "Wooden Sword", "minecraft:wooden_sword");
        public static ItemInfo WoodenShovel = new ItemInfo(269, 0, "Wooden Shovel", "minecraft:wooden_shovel");
        public static ItemInfo WoodenPickaxe = new ItemInfo(270, 0, "Wooden Pickaxe", "minecraft:wooden_pickaxe");
        public static ItemInfo WoodenAxe = new ItemInfo(271, 0, "Wooden Axe", "minecraft:wooden_axe");
        public static ItemInfo StoneSword = new ItemInfo(272, 0, "Stone Sword", "minecraft:stone_sword");
        public static ItemInfo StoneShovel = new ItemInfo(273, 0, "Stone Shovel", "minecraft:stone_shovel");
        public static ItemInfo StonePickaxe = new ItemInfo(274, 0, "Stone Pickaxe", "minecraft:stone_pickaxe");
        public static ItemInfo StoneAxe = new ItemInfo(275, 0, "Stone Axe", "minecraft:stone_axe");
        public static ItemInfo DiamondSword = new ItemInfo(276, 0, "Diamond Sword", "minecraft:diamond_sword");
        public static ItemInfo DiamondShovel = new ItemInfo(277, 0, "Diamond Shovel", "minecraft:diamond_shovel");
        public static ItemInfo DiamondPickaxe = new ItemInfo(278, 0, "Diamond Pickaxe", "minecraft:diamond_pickaxe");
        public static ItemInfo DiamondAxe = new ItemInfo(279, 0, "Diamond Axe", "minecraft:diamond_axe");
        public static ItemInfo Stick = new ItemInfo(280, 0, "Stick", "minecraft:stick").SetStackSize(64);
        public static ItemInfo Bowl = new ItemInfo(281, 0, "Bowl", "minecraft:bowl").SetStackSize(64);
        public static ItemInfo MushroomStew = new ItemInfo(282, 0, "Mushroom Stew", "minecraft:mushroom_stew");
        public static ItemInfo GoldenSword = new ItemInfo(283, 0, "Golden Sword", "minecraft:golden_sword");
        public static ItemInfo GoldenShovel = new ItemInfo(284, 0, "Golden Shovel", "minecraft:golden_shovel");
        public static ItemInfo GoldenPickaxe = new ItemInfo(285, 0, "Golden Pickaxe", "minecraft:golden_pickaxe");
        public static ItemInfo GoldenAxe = new ItemInfo(286, 0, "Golden Axe", "minecraft:golden_axe");
        public static ItemInfo String = new ItemInfo(287, 0, "String", "minecraft:string").SetStackSize(64);
        public static ItemInfo Feather = new ItemInfo(288, 0, "Feather", "minecraft:feather").SetStackSize(64);
        public static ItemInfo Gunpowder = new ItemInfo(289, 0, "Gunpowder", "minecraft:gunpowder").SetStackSize(64);
        public static ItemInfo WoodenHoe = new ItemInfo(290, 0, "Wooden Hoe", "minecraft:wooden_hoe");
        public static ItemInfo StoneHoe = new ItemInfo(291, 0, "Stone Hoe", "minecraft:stone_hoe");
        public static ItemInfo IronHoe = new ItemInfo(292, 0, "Iron Hoe", "minecraft:iron_hoe");
        public static ItemInfo DiamondHoe = new ItemInfo(293, 0, "Diamond Hoe", "minecraft:diamond_hoe");
        public static ItemInfo GoldenHoe = new ItemInfo(294, 0, "Golden Hoe", "minecraft:golden_hoe");
        public static ItemInfo WheatSeeds = new ItemInfo(295, 0, "Wheat Seeds", "minecraft:wheat_seeds").SetStackSize(64);
        public static ItemInfo Wheat = new ItemInfo(296, 0, "Wheat", "minecraft:wheat").SetStackSize(64);
        public static ItemInfo Bread = new ItemInfo(297, 0, "Bread", "minecraft:bread").SetStackSize(64);
        public static ItemInfo LeatherHelmet = new ItemInfo(298, 0, "Leather Helmet", "minecraft:leather_helmet");
        public static ItemInfo LeatherTunic = new ItemInfo(299, 0, "Leather Tunic", "minecraft:leather_chestplate");
        public static ItemInfo LeatherPants = new ItemInfo(300, 0, "Leather Pants", "minecraft:leather_leggings");
        public static ItemInfo LeatherBoots = new ItemInfo(301, 0, "Leather Boots", "minecraft:leather_boots");
        public static ItemInfo ChainmailHelmet = new ItemInfo(302, 0, "Chainmail Helmet", "minecraft:chainmail_helmet");
        public static ItemInfo ChainmailChestplate = new ItemInfo(303, 0, "Chainmail Chestplate", "minecraft:chainmail_chestplate");
        public static ItemInfo ChainmailLeggings = new ItemInfo(304, 0, "Chainmail Leggings", "minecraft:chainmail_leggings");
        public static ItemInfo ChainmailBoots = new ItemInfo(305, 0, "Chainmail Boots", "minecraft:chainmail_boots");
        public static ItemInfo IronHelmet = new ItemInfo(306, 0, "Iron Helmet", "minecraft:iron_helmet");
        public static ItemInfo IronChestplate = new ItemInfo(307, 0, "Iron Chestplate", "minecraft:iron_chestplate");
        public static ItemInfo IronLeggings = new ItemInfo(308, 0, "Iron Leggings", "minecraft:iron_leggings");
        public static ItemInfo IronBoots = new ItemInfo(309, 0, "Iron Boots", "minecraft:iron_boots");
        public static ItemInfo DiamondHelmet = new ItemInfo(310, 0, "Diamond Helmet", "minecraft:diamond_helmet");
        public static ItemInfo DiamondChestplate = new ItemInfo(311, 0, "Diamond Chestplate", "minecraft:diamond_chestplate");
        public static ItemInfo DiamondLeggings = new ItemInfo(312, 0, "Diamond Leggings", "minecraft:diamond_leggings");
        public static ItemInfo DiamondBoots = new ItemInfo(313, 0, "Diamond Boots", "minecraft:diamond_boots");
        public static ItemInfo GoldenHelmet = new ItemInfo(314, 0, "Golden Helmet", "minecraft:golden_helmet");
        public static ItemInfo GoldenChestplate = new ItemInfo(315, 0, "Golden Chestplate", "minecraft:golden_chestplate");
        public static ItemInfo GoldenLeggings = new ItemInfo(316, 0, "Golden Leggings", "minecraft:golden_leggings");
        public static ItemInfo GoldenBoots = new ItemInfo(317, 0, "Golden Boots", "minecraft:golden_boots");
        public static ItemInfo Flint = new ItemInfo(318, 0, "Flint", "minecraft:flint").SetStackSize(64);
        public static ItemInfo RawPorkchop = new ItemInfo(319, 0, "Raw Porkchop", "minecraft:porkchop").SetStackSize(64);
        public static ItemInfo CookedPorkchop = new ItemInfo(320, 0, "Cooked Porkchop", "minecraft:cooked_porkchop").SetStackSize(64);
        public static ItemInfo Painting = new ItemInfo(321, 0, "Painting", "minecraft:painting").SetStackSize(64);
        public static ItemInfo GoldenApple = new ItemInfo(322, 0, "Golden Apple", "minecraft:golden_apple").SetStackSize(64);
        public static ItemInfo EnchantedGoldenApple = new ItemInfo(322, 1, "Enchanted Golden Apple", "minecraft:golden_apple");
        public static ItemInfo Sign = new ItemInfo(323, 0, "Sign", "minecraft:sign");
        public static ItemInfo OakDoor = new ItemInfo(324, 0, "Oak Door", "minecraft:wooden_door");
        public static ItemInfo Bucket = new ItemInfo(325, 0, "Bucket", "minecraft:bucket");
        public static ItemInfo WaterBucket = new ItemInfo(326, 0, "Water Bucket", "minecraft:water_bucket");
        public static ItemInfo LavaBucket = new ItemInfo(327, 0, "Lava Bucket", "minecraft:lava_bucket");
        public static ItemInfo Minecart = new ItemInfo(328, 0, "Minecart", "minecraft:minecart");
        public static ItemInfo Saddle = new ItemInfo(329, 0, "Saddle", "minecraft:saddle");
        public static ItemInfo IronDoor = new ItemInfo(330, 0, "Iron Door", "minecraft:iron_door");
        public static ItemInfo Redstone = new ItemInfo(331, 0, "Redstone", "minecraft:redstone");
        public static ItemInfo Snowball = new ItemInfo(332, 0, "Snowball", "minecraft:snowball");
        public static ItemInfo OakBoat = new ItemInfo(333, 0, "Oak Boat", "minecraft:boat");
        public static ItemInfo Leather = new ItemInfo(334, 0, "Leather", "minecraft:leather").SetStackSize(64);
        public static ItemInfo MilkBucket = new ItemInfo(335, 0, "Milk Bucket", "minecraft:milk_bucket");
        public static ItemInfo ClayBrick = new ItemInfo(336, 0, "Brick", "minecraft:brick").SetStackSize(64);
        public static ItemInfo ClayBall = new ItemInfo(337, 0, "Clay", "minecraft:clay_ball").SetStackSize(64);
        public static ItemInfo Paper = new ItemInfo(339, 0, "Paper", "minecraft:paper");
        public static ItemInfo Book = new ItemInfo(340, 0, "Book", "minecraft:book").SetStackSize(64);
        public static ItemInfo Slimeball = new ItemInfo(341, 0, "Slimeball", "minecraft:slime_ball").SetStackSize(64);
        public static ItemInfo MinecartWithChest = new ItemInfo(342, 0, "Minecart with Chest", "minecraft:chest_minecart");
        public static ItemInfo MinecartWithFurnace = new ItemInfo(343, 0, "Minecart with Furnace", "minecraft:furnace_minecart");
        public static ItemInfo Egg = new ItemInfo(344, 0, "Egg", "minecraft:egg").SetStackSize(16);
        public static ItemInfo Compass = new ItemInfo(345, 0, "Compass", "minecraft:compass");
        public static ItemInfo FishingRod = new ItemInfo(346, 0, "Fishing Rod", "minecraft:fishing_rod");
        public static ItemInfo Clock = new ItemInfo(347, 0, "Clock", "minecraft:clock");
        public static ItemInfo GlowstoneDust = new ItemInfo(348, 0, "Glowstone Dust", "minecraft:glowstone_dust").SetStackSize(64);
        public static ItemInfo RawFish = new ItemInfo(349, 0, "Raw Fish", "minecraft:fish").SetStackSize(64);
        public static ItemInfo RawSalmon = new ItemInfo(349, 1, "Raw Salmon", "minecraft:fish").SetStackSize(64);
        public static ItemInfo Clownfish = new ItemInfo(349, 2, "Clownfish", "minecraft:fish").SetStackSize(64);
        public static ItemInfo Pufferfish = new ItemInfo(349, 3, "Pufferfish", "minecraft:fish").SetStackSize(64);
        public static ItemInfo CookedFish = new ItemInfo(350, 0, "Cooked Fish", "minecraft:cooked_fish").SetStackSize(64);
        public static ItemInfo CookedSalmon = new ItemInfo(350, 1, "Cooked Salmon", "minecraft:cooked_fish").SetStackSize(64);
        public static ItemInfo InkSack = new ItemInfo(351, 0, "Ink Sack", "minecraft:dye").SetStackSize(64);
        public static ItemInfo RoseRed = new ItemInfo(351, 1, "Rose Red", "minecraft:dye").SetStackSize(64);
        public static ItemInfo CactusGreen = new ItemInfo(351, 2, "Cactus Green", "minecraft:dye").SetStackSize(64);
        public static ItemInfo CocoBeans = new ItemInfo(351, 3, "Coco Beans", "minecraft:dye").SetStackSize(64);
        public static ItemInfo LapisLazuli = new ItemInfo(351, 4, "Lapis Lazuli", "minecraft:dye").SetStackSize(64);
        public static ItemInfo PurpleDye = new ItemInfo(351, 5, "Purple Dye", "minecraft:dye").SetStackSize(64);
        public static ItemInfo CyanDye = new ItemInfo(351, 6, "Cyan Dye", "minecraft:dye").SetStackSize(64);
        public static ItemInfo LightGrayDye = new ItemInfo(351, 7, "Light Gray Dye", "minecraft:dye").SetStackSize(64);
        public static ItemInfo GrayDye = new ItemInfo(351, 8, "Gray Dye", "minecraft:dye").SetStackSize(64);
        public static ItemInfo PinkDye = new ItemInfo(351, 9, "Pink Dye", "minecraft:dye").SetStackSize(64);
        public static ItemInfo LimeDye = new ItemInfo(351, 10, "Lime Dye", "minecraft:dye").SetStackSize(64);
        public static ItemInfo DandelionYellow = new ItemInfo(351, 11, "Dandelion Yellow", "minecraft:dye").SetStackSize(64);
        public static ItemInfo LightBlueDye = new ItemInfo(351, 12, "Light Blue Dye", "minecraft:dye").SetStackSize(64);
        public static ItemInfo MagentaDye = new ItemInfo(351, 13, "Magenta Dye", "minecraft:dye").SetStackSize(64);
        public static ItemInfo OrangeDye = new ItemInfo(351, 14, "Orange Dye", "minecraft:dye").SetStackSize(64);
        public static ItemInfo BoneMeal = new ItemInfo(351, 15, "Bone Meal", "minecraft:dye").SetStackSize(64);
        public static ItemInfo Bone = new ItemInfo(352, 0, "Bone", "minecraft:bone");
        public static ItemInfo Sugar = new ItemInfo(353, 0, "Sugar", "minecraft:sugar").SetStackSize(64);
        public static ItemInfo Cake = new ItemInfo(354, 0, "Cake", "minecraft:cake");
        public static ItemInfo RedstoneRepeater = new ItemInfo(356, 0, "Redstone Repeater", "minecraft:repeater").SetStackSize(64);
        public static ItemInfo Cookie = new ItemInfo(357, 0, "Cookie", "minecraft:cookie").SetStackSize(64);
        public static ItemInfo Map = new ItemInfo(358, 0, "Map", "minecraft:filled_map");
        public static ItemInfo Shears = new ItemInfo(359, 0, "Shears", "minecraft:shears");
        public static ItemInfo Melon = new ItemInfo(360, 0, "Melon", "minecraft:melon");
        public static ItemInfo PumpkinSeeds = new ItemInfo(361, 0, "Pumpkin Seeds", "minecraft:pumpkin_seeds").SetStackSize(64);
        public static ItemInfo MelonSeeds = new ItemInfo(362, 0, "Melon Seeds", "minecraft:melon_seeds").SetStackSize(64);
        public static ItemInfo RawBeef = new ItemInfo(363, 0, "Raw Beef", "minecraft:beef").SetStackSize(64);
        public static ItemInfo Steak = new ItemInfo(364, 0, "Steak", "minecraft:cooked_beef").SetStackSize(64);
        public static ItemInfo RawChicken = new ItemInfo(365, 0, "Raw Chicken", "minecraft:chicken").SetStackSize(64);
        public static ItemInfo CookedChicken = new ItemInfo(366, 0, "Cooked Chicken", "minecraft:cooked_chicken").SetStackSize(64);
        public static ItemInfo RottenFlesh = new ItemInfo(367, 0, "Rotten Flesh", "minecraft:rotten_flesh").SetStackSize(64);
        public static ItemInfo EnderPearl = new ItemInfo(368, 0, "Ender Pearl", "minecraft:ender_pearl").SetStackSize(64);
        public static ItemInfo BlazeRod = new ItemInfo(369, 0, "Blaze Rod", "minecraft:blaze_rod").SetStackSize(64);
        public static ItemInfo GhastTear = new ItemInfo(370, 0, "Ghast Tear", "minecraft:ghast_tear").SetStackSize(64);
        public static ItemInfo GoldNugget = new ItemInfo(371, 0, "Gold Nugget", "minecraft:gold_nugget").SetStackSize(64);
        public static ItemInfo Potion = new ItemInfo(373, 0, "Potion", "minecraft:potion");
        public static ItemInfo GlassBottle = new ItemInfo(374, 0, "Glass Bottle", "minecraft:glass_bottle");
        public static ItemInfo SpiderEye = new ItemInfo(375, 0, "Spider Eye", "minecraft:spider_eye").SetStackSize(64);
        public static ItemInfo FermentedSpiderEye = new ItemInfo(376, 0, "Fermented Spider Eye", "minecraft:fermented_spider_eye").SetStackSize(64);
        public static ItemInfo BlazePowder = new ItemInfo(377, 0, "Blaze Powder", "minecraft:blaze_powder").SetStackSize(64);
        public static ItemInfo MagmaCream = new ItemInfo(378, 0, "Magma Cream", "minecraft:magma_cream").SetStackSize(64);
        public static ItemInfo EyeOfEnder = new ItemInfo(381, 0, "Eye of Ender", "minecraft:ender_eye").SetStackSize(64);
        public static ItemInfo GlisteringMelon = new ItemInfo(382, 0, "Glistering Melon", "minecraft:speckled_melon");
        public static ItemInfo SpawnElderGuardian = new ItemInfo(383, 4, "Spawn Elder Guardian", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnWitherSkeleton = new ItemInfo(383, 5, "Spawn Wither Skeleton", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnStray = new ItemInfo(383, 6, "Spawn Stray", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnHusk = new ItemInfo(383, 23, "Spawn Husk", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnZombieVillager = new ItemInfo(383, 27, "Spawn Zombie Villager", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnSkeletonHorse = new ItemInfo(383, 28, "Spawn Skeleton Horse", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnZombieHorse = new ItemInfo(383, 29, "Spawn Zombie Horse", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnDonkey = new ItemInfo(383, 31, "Spawn Donkey", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnMule = new ItemInfo(383, 32, "Spawn Mule", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnEvoker = new ItemInfo(383, 34, "Spawn Evoker", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnVex = new ItemInfo(383, 35, "Spawn Vex", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnVindicator = new ItemInfo(383, 36, "Spawn Vindicator", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnCreeper = new ItemInfo(383, 50, "Spawn Creeper", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnSkeleton = new ItemInfo(383, 51, "Spawn Skeleton", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnSpider = new ItemInfo(383, 52, "Spawn Spider", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnZombie = new ItemInfo(383, 54, "Spawn Zombie", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnSlime = new ItemInfo(383, 55, "Spawn Slime", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnGhast = new ItemInfo(383, 56, "Spawn Ghast", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnZombiePigman = new ItemInfo(383, 57, "Spawn Zombie Pigman", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnEnderman = new ItemInfo(383, 58, "Spawn Enderman", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnCaveSpider = new ItemInfo(383, 59, "Spawn Cave Spider", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnSilverfish = new ItemInfo(383, 60, "Spawn Silverfish", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnBlaze = new ItemInfo(383, 61, "Spawn Blaze", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnMagmaCube = new ItemInfo(383, 62, "Spawn Magma Cube", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnBat = new ItemInfo(383, 65, "Spawn Bat", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnWitch = new ItemInfo(383, 66, "Spawn Witch", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnEndermite = new ItemInfo(383, 67, "Spawn Endermite", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnGuardian = new ItemInfo(383, 68, "Spawn Guardian", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnShulker = new ItemInfo(383, 69, "Spawn Shulker", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnPig = new ItemInfo(383, 90, "Spawn Pig", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnSheep = new ItemInfo(383, 91, "Spawn Sheep", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnCow = new ItemInfo(383, 92, "Spawn Cow", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnChicken = new ItemInfo(383, 93, "Spawn Chicken", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnSquid = new ItemInfo(383, 94, "Spawn Squid", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnWolf = new ItemInfo(383, 95, "Spawn Wolf", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnMooshroom = new ItemInfo(383, 96, "Spawn Mooshroom", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnOcelot = new ItemInfo(383, 98, "Spawn Ocelot", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnHorse = new ItemInfo(383, 100, "Spawn Horse", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnRabbit = new ItemInfo(383, 101, "Spawn Rabbit", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnPolarBear = new ItemInfo(383, 102, "Spawn Polar Bear", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnLlama = new ItemInfo(383, 103, "Spawn Llama", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnParrot = new ItemInfo(383, 105, "Spawn Parrot", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo SpawnVillager = new ItemInfo(383, 120, "Spawn Villager", "minecraft:spawn_egg").SetStackSize(64);
        public static ItemInfo BottleOEnchanting = new ItemInfo(384, 0, "Bottle o' Enchanting", "minecraft:experience_bottle").SetStackSize(64);
        public static ItemInfo FireCharge = new ItemInfo(385, 0, "Fire Charge", "minecraft:fire_charge").SetStackSize(64);
        public static ItemInfo BookAndQuill = new ItemInfo(386, 0, "Book and Quill", "minecraft:writable_book");
        public static ItemInfo WrittenBook = new ItemInfo(387, 0, "Written Book", "minecraft:written_book");
        public static ItemInfo Emerald = new ItemInfo(388, 0, "Emerald", "minecraft:emerald").SetStackSize(64);
        public static ItemInfo ItemFrame = new ItemInfo(389, 0, "Item Frame", "minecraft:item_frame").SetStackSize(64);
        public static ItemInfo Carrot = new ItemInfo(391, 0, "Carrot", "minecraft:carrot").SetStackSize(64);
        public static ItemInfo Potato = new ItemInfo(392, 0, "Potato", "minecraft:potato").SetStackSize(64);
        public static ItemInfo BakedPotato = new ItemInfo(393, 0, "Baked Potato", "minecraft:baked_potato").SetStackSize(64);
        public static ItemInfo PoisonousPotato = new ItemInfo(394, 0, "Poisonous Potato", "minecraft:poisonous_potato").SetStackSize(64);
        public static ItemInfo EmptyMap = new ItemInfo(395, 0, "Empty Map", "minecraft:map").SetStackSize(64);
        public static ItemInfo GoldenCarrot = new ItemInfo(396, 0, "Golden Carrot", "minecraft:golden_carrot").SetStackSize(64);
        public static ItemInfo MobHeadSkeleton = new ItemInfo(397, 0, "Mob Head (Skeleton)", "minecraft:skull").SetStackSize(64);
        public static ItemInfo MobHeadWitherSkeleton = new ItemInfo(397, 1, "Mob Head (Wither Skeleton)", "minecraft:skull").SetStackSize(64);
        public static ItemInfo MobHeadZombie = new ItemInfo(397, 2, "Mob Head (Zombie)", "minecraft:skull").SetStackSize(64);
        public static ItemInfo MobHeadHuman = new ItemInfo(397, 3, "Mob Head (Human)", "minecraft:skull").SetStackSize(64);
        public static ItemInfo MobHeadCreeper = new ItemInfo(397, 4, "Mob Head (Creeper)", "minecraft:skull").SetStackSize(64);
        public static ItemInfo MobHeadDragon = new ItemInfo(397, 5, "Mob Head (Dragon)", "minecraft:skull").SetStackSize(64);
        public static ItemInfo CarrotOnAStick = new ItemInfo(398, 0, "Carrot on a Stick", "minecraft:carrot_on_a_stick");
        public static ItemInfo NetherStar = new ItemInfo(399, 0, "Nether Star", "minecraft:nether_star").SetStackSize(64);
        public static ItemInfo PumpkinPie = new ItemInfo(400, 0, "Pumpkin Pie", "minecraft:pumpkin_pie").SetStackSize(64);
        public static ItemInfo FireworkRocket = new ItemInfo(401, 0, "Firework Rocket", "minecraft:fireworks");
        public static ItemInfo FireworkStar = new ItemInfo(402, 0, "Firework Star", "minecraft:firework_charge").SetStackSize(64);
        public static ItemInfo EnchantedBook = new ItemInfo(403, 0, "Enchanted Book", "minecraft:enchanted_book");
        public static ItemInfo RedstoneComparator = new ItemInfo(404, 0, "Redstone Comparator", "minecraft:comparator").SetStackSize(64);
        public static ItemInfo NetherQuartz = new ItemInfo(406, 0, "Nether Quartz", "minecraft:quartz").SetStackSize(64);
        public static ItemInfo MinecartWithTnt = new ItemInfo(407, 0, "Minecart with TNT", "minecraft:tnt_minecart");
        public static ItemInfo MinecartWithHopper = new ItemInfo(408, 0, "Minecart with Hopper", "minecraft:hopper_minecart");
        public static ItemInfo PrismarineShard = new ItemInfo(409, 0, "Prismarine Shard", "minecraft:prismarine_shard");
        public static ItemInfo PrismarineCrystals = new ItemInfo(410, 0, "Prismarine Crystals", "minecraft:prismarine_crystals");
        public static ItemInfo RawRabbit = new ItemInfo(411, 0, "Raw Rabbit", "minecraft:rabbit");
        public static ItemInfo CookedRabbit = new ItemInfo(412, 0, "Cooked Rabbit", "minecraft:cooked_rabbit");
        public static ItemInfo RabbitStew = new ItemInfo(413, 0, "Rabbit Stew", "minecraft:rabbit_stew");
        public static ItemInfo RabbitSFoot = new ItemInfo(414, 0, "Rabbit's Foot", "minecraft:rabbit_foot");
        public static ItemInfo RabbitHide = new ItemInfo(415, 0, "Rabbit Hide", "minecraft:rabbit_hide");
        public static ItemInfo ArmorStand = new ItemInfo(416, 0, "Armor Stand", "minecraft:armor_stand");
        public static ItemInfo IronHorseArmor = new ItemInfo(417, 0, "Iron Horse Armor", "minecraft:iron_horse_armor");
        public static ItemInfo GoldenHorseArmor = new ItemInfo(418, 0, "Golden Horse Armor", "minecraft:golden_horse_armor");
        public static ItemInfo DiamondHorseArmor = new ItemInfo(419, 0, "Diamond Horse Armor", "minecraft:diamond_horse_armor");
        public static ItemInfo Lead = new ItemInfo(420, 0, "Lead", "minecraft:lead").SetStackSize(64);
        public static ItemInfo NameTag = new ItemInfo(421, 0, "Name Tag", "minecraft:name_tag").SetStackSize(64);
        public static ItemInfo MinecartWithCommandBlock = new ItemInfo(422, 0, "Minecart with Command Block", "minecraft:command_block_minecart");
        public static ItemInfo RawMutton = new ItemInfo(423, 0, "Raw Mutton", "minecraft:mutton");
        public static ItemInfo CookedMutton = new ItemInfo(424, 0, "Cooked Mutton", "minecraft:cooked_mutton");
        public static ItemInfo Banner = new ItemInfo(425, 0, "Banner", "minecraft:banner");
        public static ItemInfo EndCrystal = new ItemInfo(426, 0, "End Crystal", "minecraft:end_crystal");
        public static ItemInfo SpruceDoor = new ItemInfo(427, 0, "Spruce Door", "minecraft:spruce_door");
        public static ItemInfo BirchDoor = new ItemInfo(428, 0, "Birch Door", "minecraft:birch_door");
        public static ItemInfo JungleDoor = new ItemInfo(429, 0, "Jungle Door", "minecraft:jungle_door");
        public static ItemInfo AcaciaDoor = new ItemInfo(430, 0, "Acacia Door", "minecraft:acacia_door");
        public static ItemInfo DarkOakDoor = new ItemInfo(431, 0, "Dark Oak Door", "minecraft:dark_oak_door");
        public static ItemInfo ChorusFruit = new ItemInfo(432, 0, "Chorus Fruit", "minecraft:chorus_fruit");
        public static ItemInfo PoppedChorusFruit = new ItemInfo(433, 0, "Popped Chorus Fruit", "minecraft:popped_chorus_fruit");
        public static ItemInfo Beetroot = new ItemInfo(434, 0, "Beetroot", "minecraft:beetroot");
        public static ItemInfo BeetrootSeeds = new ItemInfo(435, 0, "Beetroot Seeds", "minecraft:beetroot_seeds").SetStackSize(64);
        public static ItemInfo BeetrootSoup = new ItemInfo(436, 0, "Beetroot Soup", "minecraft:beetroot_soup");
        public static ItemInfo DragonSBreath = new ItemInfo(437, 0, "Dragon's Breath", "minecraft:dragon_breath");
        public static ItemInfo SplashPotion = new ItemInfo(438, 0, "Splash Potion", "minecraft:splash_potion");
        public static ItemInfo SpectralArrow = new ItemInfo(439, 0, "Spectral Arrow", "minecraft:spectral_arrow");
        public static ItemInfo TippedArrow = new ItemInfo(440, 0, "Tipped Arrow", "minecraft:tipped_arrow");
        public static ItemInfo LingeringPotion = new ItemInfo(441, 0, "Lingering Potion", "minecraft:lingering_potion");
        public static ItemInfo Shield = new ItemInfo(442, 0, "Shield", "minecraft:shield");
        public static ItemInfo Elytra = new ItemInfo(443, 0, "Elytra", "minecraft:elytra");
        public static ItemInfo SpruceBoat = new ItemInfo(444, 0, "Spruce Boat", "minecraft:spruce_boat");
        public static ItemInfo BirchBoat = new ItemInfo(445, 0, "Birch Boat", "minecraft:birch_boat");
        public static ItemInfo JungleBoat = new ItemInfo(446, 0, "Jungle Boat", "minecraft:jungle_boat");
        public static ItemInfo AcaciaBoat = new ItemInfo(447, 0, "Acacia Boat", "minecraft:acacia_boat");
        public static ItemInfo DarkOakBoat = new ItemInfo(448, 0, "Dark Oak Boat", "minecraft:dark_oak_boat");
        public static ItemInfo TotemOfUndying = new ItemInfo(449, 0, "Totem of Undying", "minecraft:totem_of_undying");
        public static ItemInfo ShulkerShell = new ItemInfo(450, 0, "Shulker Shell", "minecraft:shulker_shell");
        public static ItemInfo IronNugget = new ItemInfo(452, 0, "Iron Nugget", "minecraft:iron_nugget");
        public static ItemInfo KnowledgeBook = new ItemInfo(453, 0, "Knowledge Book", "minecraft:knowledge_book");
        public static ItemInfo Music13Disc = new ItemInfo(2256, 0, "13 Disc", "minecraft:record_13");
        public static ItemInfo MusicCatDisc = new ItemInfo(2257, 0, "Cat Disc", "minecraft:record_cat");
        public static ItemInfo MusicBlocksDisc = new ItemInfo(2258, 0, "Blocks Disc", "minecraft:record_blocks");
        public static ItemInfo MusicChirpDisc = new ItemInfo(2259, 0, "Chirp Disc", "minecraft:record_chirp");
        public static ItemInfo MusicFarDisc = new ItemInfo(2260, 0, "Far Disc", "minecraft:record_far");
        public static ItemInfo MusicMallDisc = new ItemInfo(2261, 0, "Mall Disc", "minecraft:record_mall");
        public static ItemInfo MusicMellohiDisc = new ItemInfo(2262, 0, "Mellohi Disc", "minecraft:record_mellohi");
        public static ItemInfo MusicStalDisc = new ItemInfo(2263, 0, "Stal Disc", "minecraft:record_stal");
        public static ItemInfo MusicStradDisc = new ItemInfo(2264, 0, "Strad Disc", "minecraft:record_strad");
        public static ItemInfo MusicWardDisc = new ItemInfo(2265, 0, "Ward Disc", "minecraft:record_ward");
        public static ItemInfo Music11Disc = new ItemInfo(2266, 0, "11 Disc", "minecraft:record_11");
        public static ItemInfo MusicWaitDisc = new ItemInfo(2267, 0, "Wait Disc", "minecraft:record_wait");
    }
}
