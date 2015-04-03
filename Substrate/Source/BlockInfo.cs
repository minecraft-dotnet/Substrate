using System;
using System.Collections.Generic;
using Substrate.Nbt;
using System.Collections;

namespace Substrate
{
    /// <summary>
    /// Provides named id values for known block types.
    /// </summary>
    /// <remarks><para>The preferred method to lookup
    /// Minecraft block IDs is to access the ID field of the corresponding static BlockInfo
    /// object in the BlockInfo class.</para>
    /// <para>The static BlockInfo objects can be re-bound to new BlockInfo objects, allowing
    /// the named object to be bound to a new block ID.  This gives the developer more flexibility
    /// in supporting nonstandard worlds, and the ability to future-proof their application against
    /// changes to Block IDs, by implementing functionality to import block/ID mappings from an
    /// external source and rebinding the objects in BlockInfo.</para></remarks>
    public static class BlockType
    {
        public const int AIR = 0;
        public const int STONE = 1;
        public const int GRASS = 2;
        public const int DIRT = 3;
        public const int COBBLESTONE = 4;
        public const int WOOD_PLANK = 5;
        public const int SAPLING = 6;
        public const int BEDROCK = 7;
        public const int WATER = 8;
        public const int STATIONARY_WATER = 9;
        public const int LAVA = 10;
        public const int STATIONARY_LAVA = 11;
        public const int SAND = 12;
        public const int GRAVEL = 13;
        public const int GOLD_ORE = 14;
        public const int IRON_ORE = 15;
        public const int COAL_ORE = 16;
        public const int WOOD = 17;
        public const int LEAVES = 18;
        public const int SPONGE = 19;
        public const int GLASS = 20;
        public const int LAPIS_ORE = 21;
        public const int LAPIS_BLOCK = 22;
        public const int DISPENSER = 23;
        public const int SANDSTONE = 24;
        public const int NOTE_BLOCK = 25;
        public const int BED = 26;
        public const int POWERED_RAIL = 27;
        public const int DETECTOR_RAIL = 28;
        public const int STICKY_PISTON = 29;
        public const int COBWEB = 30;
        public const int TALL_GRASS = 31;
        public const int DEAD_SHRUB = 32;
        public const int PISTON = 33;
        public const int PISTON_HEAD = 34;
        public const int WOOL = 35;
        public const int PISTON_MOVING = 36;
        public const int YELLOW_FLOWER = 37;
        public const int RED_ROSE = 38;
        public const int BROWN_MUSHROOM = 39;
        public const int RED_MUSHROOM = 40;
        public const int GOLD_BLOCK = 41;
        public const int IRON_BLOCK = 42;
        public const int DOUBLE_STONE_SLAB = 43;
        public const int STONE_SLAB = 44;
        public const int BRICK_BLOCK = 45;
        public const int TNT = 46;
        public const int BOOKSHELF = 47;
        public const int MOSS_STONE = 48;
        public const int OBSIDIAN = 49;
        public const int TORCH = 50;
        public const int FIRE = 51;
        public const int MONSTER_SPAWNER = 52;
        public const int WOOD_STAIRS = 53;
        public const int CHEST = 54;
        public const int REDSTONE_WIRE = 55;
        public const int DIAMOND_ORE = 56;
        public const int DIAMOND_BLOCK = 57;
        public const int CRAFTING_TABLE = 58;
        public const int CROPS = 59;
        public const int FARMLAND = 60;
        public const int FURNACE = 61;
        public const int BURNING_FURNACE = 62;
        public const int SIGN_POST = 63;
        public const int WOOD_DOOR = 64;
        public const int LADDER = 65;
        public const int RAILS = 66;
        public const int COBBLESTONE_STAIRS = 67;
        public const int WALL_SIGN = 68;
        public const int LEVER = 69;
        public const int STONE_PLATE = 70;
        public const int IRON_DOOR = 71;
        public const int WOOD_PLATE = 72;
        public const int REDSTONE_ORE = 73;
        public const int GLOWING_REDSTONE_ORE = 74;
        public const int REDSTONE_TORCH_OFF = 75;
        public const int REDSTONE_TORCH_ON = 76;
        public const int STONE_BUTTON = 77;
        public const int SNOW = 78;
        public const int ICE = 79;
        public const int SNOW_BLOCK = 80;
        public const int CACTUS = 81;
        public const int CLAY_BLOCK = 82;
        public const int SUGAR_CANE = 83;
        public const int JUKEBOX = 84;
        public const int FENCE = 85;
        public const int PUMPKIN = 86;
        public const int NETHERRACK = 87;
        public const int SOUL_SAND = 88;
        public const int GLOWSTONE_BLOCK = 89;
        public const int PORTAL = 90;
        public const int JACK_O_LANTERN = 91;
        public const int CAKE_BLOCK = 92;
        public const int REDSTONE_REPEATER_OFF = 93;
        public const int REDSTONE_REPEATER_ON = 94;
        public const int LOCKED_CHEST = 95;
        public const int STAINED_GLASS = 95;
        public const int TRAPDOOR = 96;
        public const int SILVERFISH_STONE = 97;
        public const int STONE_BRICK = 98;
        public const int HUGE_RED_MUSHROOM = 99;
        public const int HUGE_BROWN_MUSHROOM = 100;
        public const int IRON_BARS = 101;
        public const int GLASS_PANE = 102;
        public const int MELON = 103;
        public const int PUMPKIN_STEM = 104;
        public const int MELON_STEM = 105;
        public const int VINES = 106;
        public const int FENCE_GATE = 107;
        public const int BRICK_STAIRS = 108;
        public const int STONE_BRICK_STAIRS = 109;
        public const int MYCELIUM = 110;
        public const int LILLY_PAD = 111;
        public const int NETHER_BRICK = 112;
        public const int NETHER_BRICK_FENCE = 113;
        public const int NETHER_BRICK_STAIRS = 114;
        public const int NETHER_WART = 115;
        public const int ENCHANTMENT_TABLE = 116;
        public const int BREWING_STAND = 117;
        public const int CAULDRON = 118;
        public const int END_PORTAL = 119;
        public const int END_PORTAL_FRAME = 120;
        public const int END_STONE = 121;
        public const int DRAGON_EGG = 122;
        public const int REDSTONE_LAMP_OFF = 123;
        public const int REDSTONE_LAMP_ON = 124;
        public const int DOUBLE_WOOD_SLAB = 125;
        public const int WOOD_SLAB = 126;
        public const int COCOA_PLANT = 127;
        public const int SANDSTONE_STAIRS = 128;
        public const int EMERALD_ORE = 129;
        public const int ENDER_CHEST = 130;
        public const int TRIPWIRE_HOOK = 131;
        public const int TRIPWIRE = 132;
        public const int EMERALD_BLOCK = 133;
        public const int SPRUCE_WOOD_STAIRS = 134;
        public const int BIRCH_WOOD_STAIRS = 135;
        public const int JUNGLE_WOOD_STAIRS = 136;
        public const int COMMAND_BLOCK = 137;
        public const int BEACON_BLOCK = 138;
        public const int COBBLESTONE_WALL = 139;
        public const int FLOWER_POT = 140;
        public const int CARROTS = 141;
        public const int POTATOES = 142;
        public const int WOOD_BUTTON = 143;
        public const int HEADS = 144;
        public const int ANVIL = 145;
        public const int TRAPPED_CHEST = 146;
        public const int WEIGHTED_PRESSURE_PLATE_LIGHT = 147;
        public const int WEIGHTED_PRESSURE_PLATE_HEAVY = 148;
        public const int REDSTONE_COMPARATOR_INACTIVE = 149;
        public const int REDSTONE_COMPARATOR_ACTIVE = 150;
        public const int DAYLIGHT_SENSOR = 151;
        public const int REDSTONE_BLOCK = 152;
        public const int NETHER_QUARTZ_ORE = 153;
        public const int HOPPER = 154;
        public const int QUARTZ_BLOCK = 155;
        public const int QUARTZ_STAIRS = 156;
        public const int ACTIVATOR_RAIL = 157;
        public const int DROPPER = 158;
        public const int STAINED_CLAY = 159;
        public const int STAINED_GLASS_PANE = 160;
        public const int HAY_BLOCK = 170;
        public const int CARPET = 171;
        public const int HARDENED_CLAY = 172;
        public const int COAL_BLOCK = 173;
    }

    /// <summary>
    /// Represents the physical state of a block, such as solid or fluid.
    /// </summary>
    public enum BlockState
    {
        /// <summary>
        /// A solid state that stops movement.
        /// </summary>
        SOLID,

        /// <summary>
        /// A nonsolid state that can be passed through.
        /// </summary>
        NONSOLID,

        /// <summary>
        /// A fluid state that flows and impedes movement.
        /// </summary>
        FLUID
    }

    /// <summary>
    /// Provides information on a specific type of block.
    /// </summary>
    /// <remarks>By default, all known MC block types are already defined and registered, assuming Substrate
    /// is up to date with the current MC version.  All unknown blocks are given a default type and unregistered status.
    /// New block types may be created and used at runtime, and will automatically populate various static lookup tables
    /// in the <see cref="BlockInfo"/> class.</remarks>
    public class BlockInfo
    {
        /// <summary>
        /// The maximum number of sequential blocks starting at 0 that can be registered.
        /// </summary>
        public const int MAX_BLOCKS = 4096;

        /// <summary>
        /// The maximum opacity value that can be assigned to a block (fully opaque).
        /// </summary>
        public const int MAX_OPACITY = 15;

        /// <summary>
        /// The minimum opacity value that can be assigned to a block (fully transparent).
        /// </summary>
        public const int MIN_OPACITY = 0;

        /// <summary>
        /// The maximum luminance value that can be assigned to a block.
        /// </summary>
        public const int MAX_LUMINANCE = 15;

        /// <summary>
        /// The minimum luminance value that can be assigned to a block.
        /// </summary>
        public const int MIN_LUMINANCE = 0;

        private static readonly BlockInfo[] _blockTable;
        private static readonly int[] _opacityTable;
        private static readonly int[] _luminanceTable;

        private class CacheTableArray<T> : ICacheTable<T>
        {
            private T[] _cache;

            public T this[int index]
            {
                get { return _cache[index]; }
            }

            public CacheTableArray(T[] cache)
            {
                _cache = cache;
            }

            public IEnumerator<T> GetEnumerator()
            {
                for (int i = 0; i < _cache.Length; i++)
                {
                    if (_cache[i] != null)
                        yield return _cache[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        public class BlockDataLimits
        {
            private int _low;
            private int _high;
            private int _bitmask;

            public int Low
            {
                get { return _low; }
            }

            public int High
            {
                get { return _high; }
            }

            public int Bitmask
            {
                get { return _bitmask; }
            }

            public BlockDataLimits(int low, int high, int bitmask)
            {
                _low = low;
                _high = high;
                _bitmask = bitmask;
            }

            public bool Test(int data)
            {
                int rdata = data & ~_bitmask;
                return rdata >= _low && rdata <= _high;
            }
        }

        private int _id = 0;
        private string _name = "";
        private string _nameId = "";
        private int _tick = 0;
        private int _opacity = MAX_OPACITY;
        private int _luminance = MIN_LUMINANCE;
        private bool _transmitLight = false;
        private bool _blocksFluid = true;
        private bool _registered = false;

        private BlockState _state = BlockState.SOLID;

        private BlockDataLimits _dataLimits;

        private static readonly CacheTableArray<BlockInfo> _blockTableCache;
        private static readonly CacheTableArray<int> _opacityTableCache;
        private static readonly CacheTableArray<int> _luminanceTableCache;

        /// <summary>
        /// Gets the lookup table for id-to-info values.
        /// </summary>
        public static ICacheTable<BlockInfo> BlockTable
        {
            get { return _blockTableCache; }
        }

        /// <summary>
        /// Gets the lookup table for id-to-opacity values.
        /// </summary>
        public static ICacheTable<int> OpacityTable
        {
            get { return _opacityTableCache; }
        }

        /// <summary>
        /// Gets the lookup table for id-to-luminance values.
        /// </summary>
        public static ICacheTable<int> LuminanceTable
        {
            get { return _luminanceTableCache; }
        }

        /// <summary>
        /// Get's the block's Id.
        /// </summary>
        public int ID
        {
            get { return _id; }
        }

        /// <summary>
        /// Get's the name of the block type.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Gets the block's opacity value.  An opacity of 0 is fully transparent to light.
        /// May change the value in TransmitsLight.
        /// </summary>
        public int Opacity
        {
            get { return _opacity; }
            set
            {
                if (value < MIN_OPACITY || value > MAX_OPACITY)
                {
                    throw new InvalidOperationException("Invalid opacity");
                }

                _opacity = value;
                _opacityTable[_id] = _opacity;

                _transmitLight = (_opacity != MAX_OPACITY);
            }
        }

        /// <summary>
        /// Gets the block's luminance value.
        /// </summary>
        /// <remarks>Blocks with luminance act as light sources and transmit light to other blocks.</remarks>
        /// <seealso cref="AlphaBlockCollection.AutoLight"/>
        public int Luminance
        {
            get { return _luminance; }
            set
            {
                _luminance = value;
                _luminanceTable[_id] = _luminance;
            }
        }

        /// <summary>
        /// Checks whether the block transmits light to neighboring blocks.
        /// </summary>
        /// <remarks>A block may stop the transmission of light, but still be illuminated.</remarks>
        public bool TransmitsLight
        {
            get { return _transmitLight; }
            set { _transmitLight = value; }
        }

        /// <summary>
        /// Checks whether the block partially or fully blocks the transmission of light.
        /// </summary>
        public bool ObscuresLight
        {
            get { return (_opacity > MIN_OPACITY) || !_transmitLight; }
        }

        /// <summary>
        /// Checks whether the block stops fluid from passing through it.
        /// </summary>
        /// <remarks>A block that does not block fluids will be destroyed by fluid.</remarks>
        /// <seealso cref="AlphaBlockCollection.AutoFluid"/>
        public bool BlocksFluid
        {
            get { return _blocksFluid; }
            set { _blocksFluid = value; }
        }

        /// <summary>
        /// Gets the block's physical state type.
        /// May change BlocksFluid
        /// </summary>
        public BlockState State
        {
            get { return _state; }
            set
            {
                _state = value;

                if (_state == BlockState.SOLID)
                {
                    _blocksFluid = true;
                }
                else
                {
                    _blocksFluid = false;
                }
            }
        }

        /// <summary>
        /// Checks whether this block type has been registered as a known type.
        /// </summary>
        public bool Registered
        {
            get { return _registered; }
        }


        /// <summary>
        /// Sets the default tick rate/delay used for updating this block.
        /// The tick rate in frames between scheduled updates on this block.
        /// </summary>
        /// <remarks>Set to <c>0</c> to indicate that this block is not processed by tick updates.</remarks>
        /// <seealso cref="AlphaBlockCollection.AutoTileTick"/>
        public int Tick
        {
            get { return _tick; }
            set { _tick = value; }
        }

        public BlockDataLimits DataLimits
        {
            get { return _dataLimits; }
            set { _dataLimits = value; }
        }

        internal BlockInfo(int id)
        {
            _id = id;
            _name = "Unknown Block";
            _blockTable[_id] = this;
        }

        /// <summary>
        /// Constructs a new <see cref="BlockInfo"/> record for a given block id and name.
        /// </summary>
        /// <param name="id">The id of the block.</param>
        /// <param name="name">The name of the block.</param>
        /// <remarks>All user-constructed <see cref="BlockInfo"/> objects are registered automatically.</remarks>
        public BlockInfo(int id, string name)
        {
            _id = id;
            _name = name;
            _blockTable[_id] = this;
            _registered = true;
        }


        /// <summary>
        /// Tests if the given data value is valid for this block type.
        /// </summary>
        /// <param name="data">A data value to test.</param>
        /// <returns>True if the data value is valid, false otherwise.</returns>
        /// <remarks>This method uses internal information set by <see cref="BlockDataLimits"/>.</remarks>
        public bool TestData(int data)
        {
            if (_dataLimits == null)
            {
                return true;
            }
            return _dataLimits.Test(data);
        }

        public static BlockInfo Air;
        public static BlockInfo Stone;
        public static BlockInfo Grass;
        public static BlockInfo Dirt;
        public static BlockInfo Cobblestone;
        public static BlockInfo WoodPlank;
        public static BlockInfo Sapling;
        public static BlockInfo Bedrock;
        public static BlockInfo Water;
        public static BlockInfo StationaryWater;
        public static BlockInfo Lava;
        public static BlockInfo StationaryLava;
        public static BlockInfo Sand;
        public static BlockInfo Gravel;
        public static BlockInfo GoldOre;
        public static BlockInfo IronOre;
        public static BlockInfo CoalOre;
        public static BlockInfo Wood;
        public static BlockInfo Leaves;
        public static BlockInfo Sponge;
        public static BlockInfo Glass;
        public static BlockInfo LapisOre;
        public static BlockInfo LapisBlock;
        public static BlockInfoEx Dispenser;
        public static BlockInfo Sandstone;
        public static BlockInfoEx NoteBlock;
        public static BlockInfo Bed;
        public static BlockInfo PoweredRail;
        public static BlockInfo DetectorRail;
        public static BlockInfo StickyPiston;
        public static BlockInfo Cobweb;
        public static BlockInfo TallGrass;
        public static BlockInfo DeadShrub;
        public static BlockInfo Piston;
        public static BlockInfo PistonHead;
        public static BlockInfo Wool;
        public static BlockInfoEx PistonMoving;
        public static BlockInfo YellowFlower;
        public static BlockInfo RedRose;
        public static BlockInfo BrownMushroom;
        public static BlockInfo RedMushroom;
        public static BlockInfo GoldBlock;
        public static BlockInfo IronBlock;
        public static BlockInfo DoubleStoneSlab;
        public static BlockInfo StoneSlab;
        public static BlockInfo BrickBlock;
        public static BlockInfo TNT;
        public static BlockInfo Bookshelf;
        public static BlockInfo MossStone;
        public static BlockInfo Obsidian;
        public static BlockInfo Torch;
        public static BlockInfo Fire;
        public static BlockInfoEx MonsterSpawner;
        public static BlockInfo WoodStairs;
        public static BlockInfoEx Chest;
        public static BlockInfo RedstoneWire;
        public static BlockInfo DiamondOre;
        public static BlockInfo DiamondBlock;
        public static BlockInfo CraftTable;
        public static BlockInfo Crops;
        public static BlockInfo Farmland;
        public static BlockInfoEx Furnace;
        public static BlockInfoEx BurningFurnace;
        public static BlockInfoEx SignPost;
        public static BlockInfo WoodDoor;
        public static BlockInfo Ladder;
        public static BlockInfo Rails;
        public static BlockInfo CobbleStairs;
        public static BlockInfoEx WallSign;
        public static BlockInfo Lever;
        public static BlockInfo StonePlate;
        public static BlockInfo IronDoor;
        public static BlockInfo WoodPlate;
        public static BlockInfo RedstoneOre;
        public static BlockInfo GlowRedstoneOre;
        public static BlockInfo RedstoneTorch;
        public static BlockInfo RedstoneTorchOn;
        public static BlockInfo StoneButton;
        public static BlockInfo Snow;
        public static BlockInfo Ice;
        public static BlockInfo SnowBlock;
        public static BlockInfo Cactus;
        public static BlockInfo ClayBlock;
        public static BlockInfo SugarCane;
        public static BlockInfo Jukebox;
        public static BlockInfo Fence;
        public static BlockInfo Pumpkin;
        public static BlockInfo Netherrack;
        public static BlockInfo SoulSand;
        public static BlockInfo Glowstone;
        public static BlockInfo Portal;
        public static BlockInfo JackOLantern;
        public static BlockInfo CakeBlock;
        public static BlockInfo RedstoneRepeater;
        public static BlockInfo RedstoneRepeaterOn;
        public static BlockInfoEx LockedChest;
        public static BlockInfo StainedGlass;
        public static BlockInfo Trapdoor;
        public static BlockInfo SilverfishStone;
        public static BlockInfo StoneBrick;
        public static BlockInfo HugeRedMushroom;
        public static BlockInfo HugeBrownMushroom;
        public static BlockInfo IronBars;
        public static BlockInfo GlassPane;
        public static BlockInfo Melon;
        public static BlockInfo PumpkinStem;
        public static BlockInfo MelonStem;
        public static BlockInfo Vines;
        public static BlockInfo FenceGate;
        public static BlockInfo BrickStairs;
        public static BlockInfo StoneBrickStairs;
        public static BlockInfo Mycelium;
        public static BlockInfo LillyPad;
        public static BlockInfo NetherBrick;
        public static BlockInfo NetherBrickFence;
        public static BlockInfo NetherBrickStairs;
        public static BlockInfo NetherWart;
        public static BlockInfoEx EnchantmentTable;
        public static BlockInfoEx BrewingStand;
        public static BlockInfo Cauldron;
        public static BlockInfoEx EndPortal;
        public static BlockInfo EndPortalFrame;
        public static BlockInfo EndStone;
        public static BlockInfo DragonEgg;
        public static BlockInfo RedstoneLampOff;
        public static BlockInfo RedstoneLampOn;
        public static BlockInfo DoubleWoodSlab;
        public static BlockInfo WoodSlab;
        public static BlockInfo CocoaPlant;
        public static BlockInfo SandstoneStairs;
        public static BlockInfo EmeraldOre;
        public static BlockInfoEx EnderChest;
        public static BlockInfo TripwireHook;
        public static BlockInfo Tripwire;
        public static BlockInfo EmeraldBlock;
        public static BlockInfo SpruceWoodStairs;
        public static BlockInfo BirchWoodStairs;
        public static BlockInfo JungleWoodStairs;
        public static BlockInfoEx CommandBlock;
        public static BlockInfoEx BeaconBlock;
        public static BlockInfo CobblestoneWall;
        public static BlockInfo FlowerPot;
        public static BlockInfo Carrots;
        public static BlockInfo Potatoes;
        public static BlockInfo WoodButton;
        public static BlockInfo Heads;
        public static BlockInfo Anvil;
        public static BlockInfoEx TrappedChest;
        public static BlockInfo WeightedPressurePlateLight;
        public static BlockInfo WeightedPressurePlateHeavy;
        public static BlockInfo RedstoneComparatorInactive;
        public static BlockInfo RedstoneComparatorActive;
        public static BlockInfo DaylightSensor;
        public static BlockInfo RedstoneBlock;
        public static BlockInfo NetherQuartzOre;
        public static BlockInfoEx Hopper;
        public static BlockInfo QuartzBlock;
        public static BlockInfo QuartzStairs;
        public static BlockInfo ActivatorRail;
        public static BlockInfoEx Dropper;
        public static BlockInfo StainedClay;
        public static BlockInfo StainedGlassPane;
        public static BlockInfo HayBlock;
        public static BlockInfo Carpet;
        public static BlockInfo HardenedClay;
        public static BlockInfo CoalBlock;

        static BlockInfo()
        {
            _blockTable = new BlockInfo[MAX_BLOCKS];
            _opacityTable = new int[MAX_BLOCKS];
            _luminanceTable = new int[MAX_BLOCKS];

            _blockTableCache = new CacheTableArray<BlockInfo>(_blockTable);
            _opacityTableCache = new CacheTableArray<int>(_opacityTable);
            _luminanceTableCache = new CacheTableArray<int>(_luminanceTable);

            Air = new BlockInfo(0, "Air") { Opacity = 0, State = BlockState.NONSOLID };
            Stone = new BlockInfo(1, "Stone");
            Grass = new BlockInfo(2, "Grass") { Tick = 10 };
            Dirt = new BlockInfo(3, "Dirt");
            Cobblestone = new BlockInfo(4, "Cobblestone");
            WoodPlank = new BlockInfo(5, "Wooden Plank");
            Sapling = new BlockInfo(6, "Sapling") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(0, 15, 0) };
            Bedrock = new BlockInfo(7, "Bedrock");
            Water = new BlockInfo(8, "Water") { Opacity = 3, State = BlockState.FLUID, Tick = 5, DataLimits = new BlockDataLimits(0, 7, 0x8) };
            StationaryWater = new BlockInfo(9, "Stationary Water") { Opacity = 3, State = BlockState.FLUID };
            Lava = new BlockInfo(10, "Lava") { Opacity = 0, Luminance = MAX_LUMINANCE, State = BlockState.FLUID, Tick = 30, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 7, 0x8) };
            StationaryLava = new BlockInfo(11, "Stationary Lava") { Opacity = 0, Luminance = MAX_LUMINANCE, State = BlockState.FLUID, Tick = 10, TransmitsLight = false };
            Sand = new BlockInfo(12, "Sand") { Tick = 3 };
            Gravel = new BlockInfo(13, "Gravel") { Tick = 3 };
            GoldOre = new BlockInfo(14, "Gold Ore");
            IronOre = new BlockInfo(15, "Iron Ore");
            CoalOre = new BlockInfo(16, "Coal Ore");
            Wood = new BlockInfo(17, "Wood") { DataLimits = new BlockDataLimits(0, 2, 0) };
            Leaves = new BlockInfo(18, "Leaves") { Opacity = 1, Tick = 10, DataLimits = new BlockDataLimits(0, 2, 0) };
            Sponge = new BlockInfo(19, "Sponge");
            Glass = new BlockInfo(20, "Glass") { Opacity = 0 };
            LapisOre = new BlockInfo(21, "Lapis Lazuli Ore");
            LapisBlock = new BlockInfo(22, "Lapis Lazuli Block");
            Dispenser = new BlockInfoEx(23, "Dispenser") { Tick = 4, TileEntityName = "Trap", DataLimits = new BlockDataLimits(2, 5, 0) };
            Sandstone = new BlockInfo(24, "Sandstone");
            NoteBlock = new BlockInfoEx(25, "Note Block") { TileEntityName = "Music" };
            Bed = new BlockInfo(26, "Bed") { Opacity = 0, DataLimits = new BlockDataLimits(0, 3, 0x8) };
            PoweredRail = new BlockInfo(27, "Powered Rail") { Opacity = 0, State = BlockState.NONSOLID, DataLimits = new BlockDataLimits(0, 5, 0x8) };
            DetectorRail = new BlockInfo(28, "Detector Rail") { Opacity = 0, State = BlockState.NONSOLID, Tick = 20, DataLimits = new BlockDataLimits(0, 5, 0x8) };
            StickyPiston = new BlockInfo(29, "Sticky Piston") { Opacity = 0, DataLimits = new BlockDataLimits(1, 5, 0x8) };
            Cobweb = new BlockInfo(30, "Cobweb") { Opacity = 0, State = BlockState.NONSOLID };
            TallGrass = new BlockInfo(31, "Tall Grass") { Opacity = 0, State = BlockState.NONSOLID, DataLimits = new BlockDataLimits(0, 2, 0) };
            DeadShrub = new BlockInfo(32, "Dead Shrub") { Opacity = 0, State = BlockState.NONSOLID };
            Piston = new BlockInfo(33, "Piston") { Opacity = 0, DataLimits = new BlockDataLimits(1, 5, 0x8) };
            PistonHead = new BlockInfo(34, "Piston Head") { Opacity = 0, DataLimits = new BlockDataLimits(1, 5, 0x8) };
            Wool = new BlockInfo(35, "Wool") { DataLimits = new BlockDataLimits(0, 15, 0) };
            PistonMoving = new BlockInfoEx(36, "Piston Moving") { Opacity = 0, TileEntityName = "Piston" };
            YellowFlower = new BlockInfo(37, "Yellow Flower") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10 };
            RedRose = new BlockInfo(38, "Red Rose") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10 };
            BrownMushroom = new BlockInfo(39, "Brown Mushroom") { Opacity = 0, Luminance = 1, State = BlockState.NONSOLID, Tick = 10 };
            RedMushroom = new BlockInfo(40, "Red Mushroom") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10 };
            GoldBlock = new BlockInfo(41, "Gold Block");
            IronBlock = new BlockInfo(42, "Iron Block");
            DoubleStoneSlab = new BlockInfo(43, "Double Slab") { DataLimits = new BlockDataLimits(0, 5, 0x8) };
            StoneSlab = new BlockInfo(44, "Slab") { Opacity = 0, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 5, 0) };
            BrickBlock = new BlockInfo(45, "Brick Block");
            TNT = new BlockInfo(46, "TNT");
            Bookshelf = new BlockInfo(47, "Bookshelf");
            MossStone = new BlockInfo(48, "Moss Stone");
            Obsidian = new BlockInfo(49, "Obsidian");
            Torch = new BlockInfo(50, "Torch") { Opacity = 0, Luminance = MAX_LUMINANCE - 1, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(1, 5, 0) };
            Fire = new BlockInfo(51, "Fire") { Opacity = 0, Luminance = MAX_LUMINANCE, State = BlockState.NONSOLID, Tick = 40 };
            MonsterSpawner = new BlockInfoEx(52, "Monster Spawner") { Opacity = 0, TileEntityName = "MobSpawner" };
            WoodStairs = new BlockInfo(53, "Wooden Stairs") { Opacity = 0, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 3, 0x4) };
            Chest = new BlockInfoEx(54, "Chest") { Opacity = 0, TileEntityName = "Chest" };
            RedstoneWire = new BlockInfo(55, "Redstone Wire") { Opacity = 0, State = BlockState.NONSOLID };
            DiamondOre = new BlockInfo(56, "Diamond Ore");
            DiamondBlock = new BlockInfo(57, "Diamond Block");
            CraftTable = new BlockInfo(58, "Crafting Table");
            Crops = new BlockInfo(59, "Crops") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(0, 7, 0) };
            Farmland = new BlockInfo(60, "Farmland") { Opacity = 0, Tick = 10, TransmitsLight = false };
            Furnace = new BlockInfoEx(61, "Furnace") { TileEntityName = "Furnace", DataLimits = new BlockDataLimits(2, 5, 0) };
            BurningFurnace = new BlockInfoEx(62, "Burning Furnace") { Luminance = MAX_LUMINANCE - 1, TileEntityName = "Furnace", DataLimits = new BlockDataLimits(2, 5, 0) };
            SignPost = new BlockInfoEx(63, "Sign Post") { Opacity = 0, State = BlockState.NONSOLID, BlocksFluid = true, TileEntityName = "Sign", DataLimits = new BlockDataLimits(0, 15, 0) };
            WoodDoor = new BlockInfo(64, "Wooden Door") { Opacity = 0, DataLimits = new BlockDataLimits(0, 3, 0xC) };
            Ladder = new BlockInfo(65, "Ladder") { Opacity = 0, DataLimits = new BlockDataLimits(2, 5, 0) };
            Rails = new BlockInfo(66, "Rails") { Opacity = 0, State = BlockState.NONSOLID, DataLimits = new BlockDataLimits(0, 9, 0) };
            CobbleStairs = new BlockInfo(67, "Cobblestone Stairs") { Opacity = 0, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 3, 0x4) };
            WallSign = new BlockInfoEx(68, "Wall Sign") { Opacity = 0, State = BlockState.NONSOLID, BlocksFluid = true, TileEntityName = "Sign", DataLimits = new BlockDataLimits(2, 5, 0) };
            Lever = new BlockInfo(69, "Lever") { Opacity = 0, State = BlockState.NONSOLID, DataLimits = new BlockDataLimits(0, 6, 0x8) };
            StonePlate = new BlockInfo(70, "Stone Pressure Plate") { Opacity = 0, State = BlockState.NONSOLID, Tick = 20, DataLimits = new BlockDataLimits(0, 0, 0x1) };
            IronDoor = new BlockInfo(71, "Iron Door") { Opacity = 0, DataLimits = new BlockDataLimits(0, 3, 0xC) };
            WoodPlate = new BlockInfo(72, "Wooden Pressure Plate") { Opacity = 0, State = BlockState.NONSOLID, Tick = 20, DataLimits = new BlockDataLimits(0, 0, 0x1) };
            RedstoneOre = new BlockInfo(73, "Redstone Ore") { Tick = 30 };
            GlowRedstoneOre = new BlockInfo(74, "Glowing Redstone Ore") { Luminance = 9, Tick = 30 };
            RedstoneTorch = new BlockInfo(75, "Redstone Torch (Off)") { Opacity = 0, State = BlockState.NONSOLID, Tick = 2, DataLimits = new BlockDataLimits(0, 5, 0) };
            RedstoneTorchOn = new BlockInfo(76, "Redstone Torch (On)") { Opacity = 0, Luminance = 7, State = BlockState.NONSOLID, Tick = 2, DataLimits = new BlockDataLimits(0, 5, 0) };
            StoneButton = new BlockInfo(77, "Stone Button") { Opacity = 0, State = BlockState.NONSOLID, DataLimits = new BlockDataLimits(1, 4, 0x8) };
            Snow = new BlockInfo(78, "Snow") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(0, 7, 0) };
            Ice = new BlockInfo(79, "Ice") { Opacity = 3, Tick = 10 };
            SnowBlock = new BlockInfo(80, "Snow Block") { Tick = 10 };
            Cactus = new BlockInfo(81, "Cactus") { Opacity = 0, Tick = 10, BlocksFluid = true, DataLimits = new BlockDataLimits(0, 5, 0) };
            ClayBlock = new BlockInfo(82, "Clay Block");
            SugarCane = new BlockInfo(83, "Sugar Cane") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(0, 15, 0) };
            Jukebox = new BlockInfo(84, "Jukebox") { DataLimits = new BlockDataLimits(0, 2, 0) };
            Fence = new BlockInfo(85, "Fence") { Opacity = 0 };
            Pumpkin = new BlockInfo(86, "Pumpkin") { DataLimits = new BlockDataLimits(0, 3, 0) };
            Netherrack = new BlockInfo(87, "Netherrack");
            SoulSand = new BlockInfo(88, "Soul Sand");
            Glowstone = new BlockInfo(89, "Glowstone Block") { Luminance = MAX_LUMINANCE };
            Portal = new BlockInfo(90, "Portal") { Opacity = 0, Luminance = 11, State = BlockState.NONSOLID };
            JackOLantern = new BlockInfo(91, "Jack-O-Lantern") { Luminance = MAX_LUMINANCE, DataLimits = new BlockDataLimits(0, 3, 0) };
            CakeBlock = new BlockInfo(92, "Cake Block") { Opacity = 0 };
            RedstoneRepeater = new BlockInfo(93, "Redstone Repeater (Off)") { Opacity = 0, Tick = 10, DataLimits = new BlockDataLimits(0, 0, 0xF) };
            RedstoneRepeaterOn = new BlockInfo(94, "Redstone Repeater (On)") { Opacity = 0, Luminance = 7, Tick = 10, DataLimits = new BlockDataLimits(0, 0, 0xF) };
            LockedChest = new BlockInfoEx(95, "Locked Chest") { Luminance = MAX_LUMINANCE, Tick = 10 };
            StainedGlass = new BlockInfo(95, "Stained Glass") { Opacity = 0 };
            Trapdoor = new BlockInfo(96, "Trapdoor") { Opacity = 0, DataLimits = new BlockDataLimits(0, 3, 0x4) };
            SilverfishStone = new BlockInfo(97, "Stone with Silverfish") { DataLimits = new BlockDataLimits(0, 2, 0) };
            StoneBrick = new BlockInfo(98, "Stone Brick") { DataLimits = new BlockDataLimits(0, 2, 0) };
            HugeRedMushroom = new BlockInfo(99, "Huge Red Mushroom") { DataLimits = new BlockDataLimits(0, 10, 0) };
            HugeBrownMushroom = new BlockInfo(100, "Huge Brown Mushroom") { DataLimits = new BlockDataLimits(0, 10, 0) };
            IronBars = new BlockInfo(101, "Iron Bars") { Opacity = 0 };
            GlassPane = new BlockInfo(102, "Glass Pane") { Opacity = 0 };
            Melon = new BlockInfo(103, "Melon");
            PumpkinStem = new BlockInfo(104, "Pumpkin Stem") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10 };
            MelonStem = new BlockInfo(105, "Melon Stem") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10 };
            Vines = new BlockInfo(106, "Vines") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(0, 0, 0xF) };
            FenceGate = new BlockInfo(107, "Fence Gate") { Opacity = 0, DataLimits = new BlockDataLimits(0, 3, 0x4) };
            BrickStairs = new BlockInfo(108, "Brick Stairs") { Opacity = 0, TransmitsLight = false };
            StoneBrickStairs = new BlockInfo(109, "Stone Brick Stairs") { Opacity = 0, TransmitsLight = false };
            Mycelium = new BlockInfo(110, "Mycelium") { Tick = 10 };
            LillyPad = new BlockInfo(111, "Lilly Pad") { Opacity = 0, State = BlockState.NONSOLID };
            NetherBrick = new BlockInfo(112, "Nether Brick");
            NetherBrickFence = new BlockInfo(113, "Nether Brick Fence") { Opacity = 0 };
            NetherBrickStairs = new BlockInfo(114, "Nether Brick Stairs") { Opacity = 0, TransmitsLight = false };
            NetherWart = new BlockInfo(115, "Nether Wart") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10 };
            EnchantmentTable = new BlockInfoEx(116, "Enchantment Table") { Opacity = 0, TileEntityName = "EnchantTable" };
            BrewingStand = new BlockInfoEx(117, "Brewing Stand") { Opacity = 0, TileEntityName = "Cauldron", DataLimits = new BlockDataLimits(0, 0, 0x7) };
            Cauldron = new BlockInfo(118, "Cauldron") { Opacity = 0, DataLimits = new BlockDataLimits(0, 3, 0) };
            EndPortal = new BlockInfoEx(119, "End Portal") { Opacity = 0, Luminance = MAX_LUMINANCE, State = BlockState.NONSOLID, TileEntityName = "Airportal" };
            EndPortalFrame = new BlockInfo(120, "End Portal Frame") { Luminance = MAX_LUMINANCE, DataLimits = new BlockDataLimits(0, 0, 0x7) };
            EndStone = new BlockInfo(121, "End Stone");
            DragonEgg = new BlockInfo(122, "Dragon Egg") { Opacity = 0, Luminance = 1, Tick = 3 };
            RedstoneLampOff = new BlockInfo(123, "Redstone Lamp (Off)") { Tick = 2 };
            RedstoneLampOn = new BlockInfo(124, "Redstone Lamp (On)") { Luminance = 15, Tick = 2 };
            DoubleWoodSlab = new BlockInfo(125, "Double Wood Slab") { DataLimits = new BlockDataLimits(0, 5, 0x8) };
            WoodSlab = new BlockInfo(126, "Wood Slab") { TransmitsLight = false, DataLimits = new BlockDataLimits(0, 5, 0) };
            CocoaPlant = new BlockInfo(127, "Cocoa Plant") { Luminance = 2, Opacity = 0 };
            SandstoneStairs = new BlockInfo(128, "Sandstone Stairs") { Opacity = 0, TransmitsLight = false };
            EmeraldOre = new BlockInfo(129, "Emerald Ore");
            EnderChest = new BlockInfoEx(130, "Ender Chest") { Luminance = 7, Opacity = 0, TileEntityName = "EnderChest" };
            TripwireHook = new BlockInfo(131, "Tripwire Hook") { Opacity = 0, State = BlockState.NONSOLID, DataLimits = new BlockDataLimits(0, 3, 0xC) };
            Tripwire = new BlockInfo(132, "Tripwire") { Opacity = 0, State = BlockState.NONSOLID, DataLimits = new BlockDataLimits(0, 0, 0x5) };
            EmeraldBlock = new BlockInfo(133, "Emerald Block");
            SpruceWoodStairs = new BlockInfo(134, "Sprice Wood Stairs") { Opacity = 0, TransmitsLight = false };
            BirchWoodStairs = new BlockInfo(135, "Birch Wood Stairs") { Opacity = 0, TransmitsLight = false };
            JungleWoodStairs = new BlockInfo(136, "Jungle Wood Stairs") { Opacity = 0, TransmitsLight = false };
            CommandBlock = new BlockInfoEx(137, "Command Block") { TileEntityName = "Control" };
            BeaconBlock = new BlockInfoEx(138, "Beacon Block") { Opacity = 0, Luminance = MAX_LUMINANCE, TileEntityName = "Beacon" };
            CobblestoneWall = new BlockInfo(139, "Cobblestone Wall") { Opacity = 0 };
            FlowerPot = new BlockInfo(140, "Flower Pot") { Opacity = 0 };
            Carrots = new BlockInfo(141, "Carrots") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10 };
            Potatoes = new BlockInfo(142, "Potatoes") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10 };
            WoodButton = new BlockInfo(143, "Wooden Button") { Opacity = 0, State = BlockState.NONSOLID };
            Heads = new BlockInfo(144, "Heads") { Opacity = 0 };
            Anvil = new BlockInfo(145, "Anvil") { Opacity = 0, DataLimits = new BlockDataLimits(0, 0, 0xD) };
            TrappedChest = new BlockInfoEx(146, "Trapped Chest") { Opacity = 0, Tick = 10, TileEntityName = "Chest" };
            WeightedPressurePlateLight = new BlockInfo(147, "Weighted Pressure Plate (Light)") { Opacity = 0, State = BlockState.NONSOLID, Tick = 20 };
            WeightedPressurePlateHeavy = new BlockInfo(148, "Weighted Pressure Plate (Heavy)") { Opacity = 0, State = BlockState.NONSOLID, Tick = 20 };
            RedstoneComparatorInactive = new BlockInfo(149, "Redstone Comparator (Inactive)") { Opacity = 0, Tick = 10 };
            RedstoneComparatorActive = new BlockInfo(150, "Redstone Comparator (Active)") { Opacity = 0, Luminance = 9, Tick = 10 };
            DaylightSensor = new BlockInfo(151, "Daylight Sensor") { Opacity = 0, Tick = 10 };
            RedstoneBlock = new BlockInfo(152, "Block of Redstone") { Tick = 10 };
            NetherQuartzOre = new BlockInfo(153, "Neither Quartz Ore");
            Hopper = new BlockInfoEx(154, "Hopper") { Opacity = 0, Tick = 10, TileEntityName = "Hopper", DataLimits = new BlockDataLimits(0, 5, 0) };
            QuartzBlock = new BlockInfo(155, "Block of Quartz") { DataLimits = new BlockDataLimits(0, 4, 0) };
            QuartzStairs = new BlockInfo(156, "Quartz Stairs") { Opacity = 0, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 3, 0x4) };
            ActivatorRail = new BlockInfo(157, "Activator Rail") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10 };
            Dropper = new BlockInfoEx(158, "Dropper") { Tick = 10, TileEntityName = "Dropper", DataLimits = new BlockDataLimits(0, 5, 0) };
            StainedClay = new BlockInfo(159, "Stained Clay");
            StainedGlassPane = new BlockInfo(160, "Stained Glass Pane") { Opacity = 0 };
            HayBlock = new BlockInfo(170, "Hay Block");
            Carpet = new BlockInfo(171, "Carpet") { Opacity = 0, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 15, 0) };
            HardenedClay = new BlockInfo(172, "Hardened Clay");
            CoalBlock = new BlockInfo(173, "Block of Coal");

            for (int i = 0; i < MAX_BLOCKS; i++)
            {
                if (_blockTable[i] == null)
                {
                    _blockTable[i] = new BlockInfo(i);
                }
            }
        }
    }

    /// <summary>
    /// An extended <see cref="BlockInfo"/> that includes <see cref="TileEntity"/> information.
    /// </summary>
    public class BlockInfoEx : BlockInfo
    {
        private string _tileEntityName;

        /// <summary>
        /// Gets the name of the registered <see cref="TileEntity"/> type associated with this block type.
        /// Sets the name of the registered <see cref="TileEntity"/> type associated with this block type.
        /// </summary>
        /// <seealso cref="TileEntityFactory"/>
        public string TileEntityName
        {
            get { return _tileEntityName; }
            set { _tileEntityName = value; }
        }

        internal BlockInfoEx(int id) : base(id) { }

        /// <summary>
        /// Constructs a new <see cref="BlockInfoEx"/> with a given block id and name.
        /// </summary>
        /// <param name="id">The id of the block type.</param>
        /// <param name="name">The name of the block type.</param>
        public BlockInfoEx(int id, string name) : base(id, name) { }
    }
}
