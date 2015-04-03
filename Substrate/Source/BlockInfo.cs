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
        private string _tileEntityName = null;

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
        /// Get's the name ID of the block type.
        /// </summary>
        public string NameID
        {
            get { return _nameId; }
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
        /// <param name="nameId">The name ID of the block.</param>
        /// <param name="name">The name of the block.</param>
        /// <remarks>All user-constructed <see cref="BlockInfo"/> objects are registered automatically.</remarks>
        public BlockInfo(int id, string nameId, string name)
        {
            _id = id;
            _nameId = nameId;
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

        public readonly static BlockInfo Air;
        public readonly static BlockInfo Stone;
        public readonly static BlockInfo Grass;
        public readonly static BlockInfo Dirt;
        public readonly static BlockInfo Cobblestone;
        public readonly static BlockInfo WoodPlank;
        public readonly static BlockInfo Sapling;
        public readonly static BlockInfo Bedrock;
        public readonly static BlockInfo Water;
        public readonly static BlockInfo StationaryWater;
        public readonly static BlockInfo Lava;
        public readonly static BlockInfo StationaryLava;
        public readonly static BlockInfo Sand;
        public readonly static BlockInfo Gravel;
        public readonly static BlockInfo GoldOre;
        public readonly static BlockInfo IronOre;
        public readonly static BlockInfo CoalOre;
        public readonly static BlockInfo Wood;
        public readonly static BlockInfo Leaves;
        public readonly static BlockInfo Sponge;
        public readonly static BlockInfo Glass;
        public readonly static BlockInfo LapisOre;
        public readonly static BlockInfo LapisBlock;
        public readonly static BlockInfo Dispenser;
        public readonly static BlockInfo Sandstone;
        public readonly static BlockInfo NoteBlock;
        public readonly static BlockInfo Bed;
        public readonly static BlockInfo PoweredRail;
        public readonly static BlockInfo DetectorRail;
        public readonly static BlockInfo StickyPiston;
        public readonly static BlockInfo Cobweb;
        public readonly static BlockInfo TallGrass;
        public readonly static BlockInfo DeadShrub;
        public readonly static BlockInfo Piston;
        public readonly static BlockInfo PistonHead;
        public readonly static BlockInfo Wool;
        public readonly static BlockInfo PistonMoving;
        public readonly static BlockInfo YellowFlower;
        public readonly static BlockInfo RedRose;
        public readonly static BlockInfo BrownMushroom;
        public readonly static BlockInfo RedMushroom;
        public readonly static BlockInfo GoldBlock;
        public readonly static BlockInfo IronBlock;
        public readonly static BlockInfo DoubleStoneSlab;
        public readonly static BlockInfo StoneSlab;
        public readonly static BlockInfo BrickBlock;
        public readonly static BlockInfo TNT;
        public readonly static BlockInfo Bookshelf;
        public readonly static BlockInfo MossStone;
        public readonly static BlockInfo Obsidian;
        public readonly static BlockInfo Torch;
        public readonly static BlockInfo Fire;
        public readonly static BlockInfo MonsterSpawner;
        public readonly static BlockInfo WoodStairs;
        public readonly static BlockInfo Chest;
        public readonly static BlockInfo RedstoneWire;
        public readonly static BlockInfo DiamondOre;
        public readonly static BlockInfo DiamondBlock;
        public readonly static BlockInfo CraftTable;
        public readonly static BlockInfo Crops;
        public readonly static BlockInfo Farmland;
        public readonly static BlockInfo Furnace;
        public readonly static BlockInfo BurningFurnace;
        public readonly static BlockInfo SignPost;
        public readonly static BlockInfo WoodDoor;
        public readonly static BlockInfo Ladder;
        public readonly static BlockInfo Rails;
        public readonly static BlockInfo CobbleStairs;
        public readonly static BlockInfo WallSign;
        public readonly static BlockInfo Lever;
        public readonly static BlockInfo StonePlate;
        public readonly static BlockInfo IronDoor;
        public readonly static BlockInfo WoodPlate;
        public readonly static BlockInfo RedstoneOre;
        public readonly static BlockInfo GlowRedstoneOre;
        public readonly static BlockInfo RedstoneTorch;
        public readonly static BlockInfo RedstoneTorchOn;
        public readonly static BlockInfo StoneButton;
        public readonly static BlockInfo Snow;
        public readonly static BlockInfo Ice;
        public readonly static BlockInfo SnowBlock;
        public readonly static BlockInfo Cactus;
        public readonly static BlockInfo ClayBlock;
        public readonly static BlockInfo SugarCane;
        public readonly static BlockInfo Jukebox;
        public readonly static BlockInfo Fence;
        public readonly static BlockInfo Pumpkin;
        public readonly static BlockInfo Netherrack;
        public readonly static BlockInfo SoulSand;
        public readonly static BlockInfo Glowstone;
        public readonly static BlockInfo Portal;
        public readonly static BlockInfo JackOLantern;
        public readonly static BlockInfo CakeBlock;
        public readonly static BlockInfo RedstoneRepeater;
        public readonly static BlockInfo RedstoneRepeaterOn;
        public readonly static BlockInfo LockedChest;
        public readonly static BlockInfo StainedGlass;
        public readonly static BlockInfo Trapdoor;
        public readonly static BlockInfo SilverfishStone;
        public readonly static BlockInfo StoneBrick;
        public readonly static BlockInfo HugeRedMushroom;
        public readonly static BlockInfo HugeBrownMushroom;
        public readonly static BlockInfo IronBars;
        public readonly static BlockInfo GlassPane;
        public readonly static BlockInfo Melon;
        public readonly static BlockInfo PumpkinStem;
        public readonly static BlockInfo MelonStem;
        public readonly static BlockInfo Vines;
        public readonly static BlockInfo FenceGate;
        public readonly static BlockInfo BrickStairs;
        public readonly static BlockInfo StoneBrickStairs;
        public readonly static BlockInfo Mycelium;
        public readonly static BlockInfo LillyPad;
        public readonly static BlockInfo NetherBrick;
        public readonly static BlockInfo NetherBrickFence;
        public readonly static BlockInfo NetherBrickStairs;
        public readonly static BlockInfo NetherWart;
        public readonly static BlockInfo EnchantmentTable;
        public readonly static BlockInfo BrewingStand;
        public readonly static BlockInfo Cauldron;
        public readonly static BlockInfo EndPortal;
        public readonly static BlockInfo EndPortalFrame;
        public readonly static BlockInfo EndStone;
        public readonly static BlockInfo DragonEgg;
        public readonly static BlockInfo RedstoneLampOff;
        public readonly static BlockInfo RedstoneLampOn;
        public readonly static BlockInfo DoubleWoodSlab;
        public readonly static BlockInfo WoodSlab;
        public readonly static BlockInfo CocoaPlant;
        public readonly static BlockInfo SandstoneStairs;
        public readonly static BlockInfo EmeraldOre;
        public readonly static BlockInfo EnderChest;
        public readonly static BlockInfo TripwireHook;
        public readonly static BlockInfo Tripwire;
        public readonly static BlockInfo EmeraldBlock;
        public readonly static BlockInfo SpruceWoodStairs;
        public readonly static BlockInfo BirchWoodStairs;
        public readonly static BlockInfo JungleWoodStairs;
        public readonly static BlockInfo CommandBlock;
        public readonly static BlockInfo BeaconBlock;
        public readonly static BlockInfo CobblestoneWall;
        public readonly static BlockInfo FlowerPot;
        public readonly static BlockInfo Carrots;
        public readonly static BlockInfo Potatoes;
        public readonly static BlockInfo WoodButton;
        public readonly static BlockInfo Heads;
        public readonly static BlockInfo Anvil;
        public readonly static BlockInfo TrappedChest;
        public readonly static BlockInfo WeightedPressurePlateLight;
        public readonly static BlockInfo WeightedPressurePlateHeavy;
        public readonly static BlockInfo RedstoneComparatorInactive;
        public readonly static BlockInfo RedstoneComparatorActive;
        public readonly static BlockInfo DaylightSensor;
        public readonly static BlockInfo RedstoneBlock;
        public readonly static BlockInfo NetherQuartzOre;
        public readonly static BlockInfo Hopper;
        public readonly static BlockInfo QuartzBlock;
        public readonly static BlockInfo QuartzStairs;
        public readonly static BlockInfo ActivatorRail;
        public readonly static BlockInfo Dropper;
        public readonly static BlockInfo StainedClay;
        public readonly static BlockInfo StainedGlassPane;
        public readonly static BlockInfo Leaves2;
        public readonly static BlockInfo Wood2;
        public readonly static BlockInfo AcaciaWoodStairs;
        public readonly static BlockInfo DarkOakWoodStairs;
        public readonly static BlockInfo SlimeBlock;
        public readonly static BlockInfo Barrier;
        public readonly static BlockInfo IronTrapdoor;
        public readonly static BlockInfo Prismarine;
        public readonly static BlockInfo SeaLantern;
        public readonly static BlockInfo HayBlock;
        public readonly static BlockInfo Carpet;
        public readonly static BlockInfo HardenedClay;
        public readonly static BlockInfo CoalBlock;
        public readonly static BlockInfo PackedIce;
        public readonly static BlockInfo LargeFlowers;
        public readonly static BlockInfo StandingBanner;
        public readonly static BlockInfo WallBanner;
        public readonly static BlockInfo InvertedDaylightSensor;
        public readonly static BlockInfo RedSandstone;
        public readonly static BlockInfo RedSandstoneStairs;
        public readonly static BlockInfo DoubleRedSandstoneSlab;
        public readonly static BlockInfo RedSandstoneSlab;
        public readonly static BlockInfo SpruceFenceGate;
        public readonly static BlockInfo BirchFenceGate;
        public readonly static BlockInfo JungleFenceGate;
        public readonly static BlockInfo DarkOakFenceGate;
        public readonly static BlockInfo AcaciaFenceGate;
        public readonly static BlockInfo SpruceFence;
        public readonly static BlockInfo BirchFence;
        public readonly static BlockInfo JungleFence;
        public readonly static BlockInfo DarkOakFence;
        public readonly static BlockInfo AcaciaFence;
        public readonly static BlockInfo SpruceDoor;
        public readonly static BlockInfo BirchDoor;
        public readonly static BlockInfo JungleDoor;
        public readonly static BlockInfo AcaciaDoor;
        public readonly static BlockInfo DarkOakDoor;

        static BlockInfo()
        {
            _blockTable = new BlockInfo[MAX_BLOCKS];
            _opacityTable = new int[MAX_BLOCKS];
            _luminanceTable = new int[MAX_BLOCKS];

            _blockTableCache = new CacheTableArray<BlockInfo>(_blockTable);
            _opacityTableCache = new CacheTableArray<int>(_opacityTable);
            _luminanceTableCache = new CacheTableArray<int>(_luminanceTable);

            Air = new BlockInfo(0, "minecraft:air", "Air") { Opacity = 0, State = BlockState.NONSOLID };
            Stone = new BlockInfo(1, "minecraft:stone", "Stone");
            Grass = new BlockInfo(2, "minecraft:grass", "Grass") { Tick = 10 };
            Dirt = new BlockInfo(3, "minecraft:dirt", "Dirt");
            Cobblestone = new BlockInfo(4, "minecraft:cobblestone", "Cobblestone");
            WoodPlank = new BlockInfo(5, "minecraft:planks", "Wooden Plank");
            Sapling = new BlockInfo(6, "minecraft:sapling", "Sapling") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(0, 15, 0) };
            Bedrock = new BlockInfo(7, "minecraft:bedrock", "Bedrock");
            Water = new BlockInfo(8, "minecraft:flowing_water", "Water") { Opacity = 3, State = BlockState.FLUID, Tick = 5, DataLimits = new BlockDataLimits(0, 7, 0x8) };
            StationaryWater = new BlockInfo(9, "minecraft:water", "Stationary Water") { Opacity = 3, State = BlockState.FLUID };
            Lava = new BlockInfo(10, "minecraft:flowing_lava", "Lava") { Opacity = 0, Luminance = MAX_LUMINANCE, State = BlockState.FLUID, Tick = 30, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 7, 0x8) };
            StationaryLava = new BlockInfo(11, "minecraft:lava", "Stationary Lava") { Opacity = 0, Luminance = MAX_LUMINANCE, State = BlockState.FLUID, Tick = 10, TransmitsLight = false };
            Sand = new BlockInfo(12, "minecraft:sand", "Sand") { Tick = 3 };
            Gravel = new BlockInfo(13, "minecraft:gravel", "Gravel") { Tick = 3 };
            GoldOre = new BlockInfo(14, "minecraft:gold_ore", "Gold Ore");
            IronOre = new BlockInfo(15, "minecraft:iron_ore", "Iron Ore");
            CoalOre = new BlockInfo(16, "minecraft:coal_ore", "Coal Ore");
            Wood = new BlockInfo(17, "minecraft:log", "Wood") { DataLimits = new BlockDataLimits(0, 2, 0) };
            Leaves = new BlockInfo(18, "minecraft:leaves", "Leaves") { Opacity = 1, Tick = 10, DataLimits = new BlockDataLimits(0, 2, 0) };
            Sponge = new BlockInfo(19, "minecraft:sponge", "Sponge");
            Glass = new BlockInfo(20, "minecraft:glass", "Glass") { Opacity = 0 };
            LapisOre = new BlockInfo(21, "minecraft:lapis_ore", "Lapis Lazuli Ore");
            LapisBlock = new BlockInfo(22, "minecraft:lapis_block", "Lapis Lazuli Block");
            Dispenser = new BlockInfo(23, "minecraft:dispenser", "Dispenser") { Tick = 4, TileEntityName = "Trap", DataLimits = new BlockDataLimits(2, 5, 0) };
            Sandstone = new BlockInfo(24, "minecraft:sandstone", "Sandstone");
            NoteBlock = new BlockInfo(25, "minecraft:noteblock", "Note Block") { TileEntityName = "Music" };
            Bed = new BlockInfo(26, "minecraft:bed", "Bed") { Opacity = 0, DataLimits = new BlockDataLimits(0, 3, 0x8) };
            PoweredRail = new BlockInfo(27, "minecraft:golden_rail", "Powered Rail") { Opacity = 0, State = BlockState.NONSOLID, DataLimits = new BlockDataLimits(0, 5, 0x8) };
            DetectorRail = new BlockInfo(28, "minecraft:detector_rail", "Detector Rail") { Opacity = 0, State = BlockState.NONSOLID, Tick = 20, DataLimits = new BlockDataLimits(0, 5, 0x8) };
            StickyPiston = new BlockInfo(29, "minecraft:sticky_piston", "Sticky Piston") { Opacity = 0, DataLimits = new BlockDataLimits(1, 5, 0x8) };
            Cobweb = new BlockInfo(30, "minecraft:web", "Cobweb") { Opacity = 0, State = BlockState.NONSOLID };
            TallGrass = new BlockInfo(31, "minecraft:tallgrass", "Tall Grass") { Opacity = 0, State = BlockState.NONSOLID, DataLimits = new BlockDataLimits(0, 2, 0) };
            DeadShrub = new BlockInfo(32, "minecraft:deadbush", "Dead Shrub") { Opacity = 0, State = BlockState.NONSOLID };
            Piston = new BlockInfo(33, "minecraft:piston", "Piston") { Opacity = 0, DataLimits = new BlockDataLimits(1, 5, 0x8) };
            PistonHead = new BlockInfo(34, "minecraft:piston_head", "Piston Head") { Opacity = 0, DataLimits = new BlockDataLimits(1, 5, 0x8) };
            Wool = new BlockInfo(35, "minecraft:wool", "Wool") { DataLimits = new BlockDataLimits(0, 15, 0) };
            PistonMoving = new BlockInfo(36, "minecraft:piston_extension", "Piston Moving") { Opacity = 0, TileEntityName = "Piston" };
            YellowFlower = new BlockInfo(37, "minecraft:yellow_flower", "Yellow Flower") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10 };
            RedRose = new BlockInfo(38, "minecraft:red_flower", "Red Rose") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10 };
            BrownMushroom = new BlockInfo(39, "minecraft:brown_mushroom", "Brown Mushroom") { Opacity = 0, Luminance = 1, State = BlockState.NONSOLID, Tick = 10 };
            RedMushroom = new BlockInfo(40, "minecraft:red_mushroom", "Red Mushroom") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10 };
            GoldBlock = new BlockInfo(41, "minecraft:gold_block", "Gold Block");
            IronBlock = new BlockInfo(42, "minecraft:iron_block", "Iron Block");
            DoubleStoneSlab = new BlockInfo(43, "minecraft:double_stone_slab", "Double Slab") { DataLimits = new BlockDataLimits(0, 5, 0x8) };
            StoneSlab = new BlockInfo(44, "minecraft:stone_slab", "Slab") { Opacity = 0, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 5, 0) };
            BrickBlock = new BlockInfo(45, "minecraft:brick_block", "Brick Block");
            TNT = new BlockInfo(46, "minecraft:tnt", "TNT");
            Bookshelf = new BlockInfo(47, "minecraft:bookshelf", "Bookshelf");
            MossStone = new BlockInfo(48, "minecraft:mossy_cobblestone", "Moss Stone");
            Obsidian = new BlockInfo(49, "minecraft:obsidian", "Obsidian");
            Torch = new BlockInfo(50, "minecraft:torch", "Torch") { Opacity = 0, Luminance = MAX_LUMINANCE - 1, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(1, 5, 0) };
            Fire = new BlockInfo(51, "minecraft:fire", "Fire") { Opacity = 0, Luminance = MAX_LUMINANCE, State = BlockState.NONSOLID, Tick = 40 };
            MonsterSpawner = new BlockInfo(52, "minecraft:mob_spawner", "Monster Spawner") { Opacity = 0, TileEntityName = "MobSpawner" };
            WoodStairs = new BlockInfo(53, "minecraft:oak_stairs", "Wooden Stairs") { Opacity = 0, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 3, 0x4) };
            Chest = new BlockInfo(54, "minecraft:chest", "Chest") { Opacity = 0, TileEntityName = "Chest" };
            RedstoneWire = new BlockInfo(55, "minecraft:redstone_wire", "Redstone Wire") { Opacity = 0, State = BlockState.NONSOLID };
            DiamondOre = new BlockInfo(56, "minecraft:diamond_ore", "Diamond Ore");
            DiamondBlock = new BlockInfo(57, "minecraft:diamond_block", "Diamond Block");
            CraftTable = new BlockInfo(58, "minecraft:crafting_table", "Crafting Table");
            Crops = new BlockInfo(59, "minecraft:wheat", "Crops") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(0, 7, 0) };
            Farmland = new BlockInfo(60, "minecraft:farmland", "Farmland") { Opacity = 0, Tick = 10, TransmitsLight = false };
            Furnace = new BlockInfo(61, "minecraft:furnace", "Furnace") { TileEntityName = "Furnace", DataLimits = new BlockDataLimits(2, 5, 0) };
            BurningFurnace = new BlockInfo(62, "minecraft:lit_furnace", "Burning Furnace") { Luminance = MAX_LUMINANCE - 1, TileEntityName = "Furnace", DataLimits = new BlockDataLimits(2, 5, 0) };
            SignPost = new BlockInfo(63, "minecraft:standing_sign", "Sign Post") { Opacity = 0, State = BlockState.NONSOLID, BlocksFluid = true, TileEntityName = "Sign", DataLimits = new BlockDataLimits(0, 15, 0) };
            WoodDoor = new BlockInfo(64, "minecraft:wooden_door", "Wooden Door") { Opacity = 0, DataLimits = new BlockDataLimits(0, 3, 0xC) };
            Ladder = new BlockInfo(65, "minecraft:ladder", "Ladder") { Opacity = 0, DataLimits = new BlockDataLimits(2, 5, 0) };
            Rails = new BlockInfo(66, "minecraft:rail", "Rails") { Opacity = 0, State = BlockState.NONSOLID, DataLimits = new BlockDataLimits(0, 9, 0) };
            CobbleStairs = new BlockInfo(67, "minecraft:stone_stairs", "Cobblestone Stairs") { Opacity = 0, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 3, 0x4) };
            WallSign = new BlockInfo(68, "minecraft:wall_sign", "Wall Sign") { Opacity = 0, State = BlockState.NONSOLID, BlocksFluid = true, TileEntityName = "Sign", DataLimits = new BlockDataLimits(2, 5, 0) };
            Lever = new BlockInfo(69, "minecraft:lever", "Lever") { Opacity = 0, State = BlockState.NONSOLID, DataLimits = new BlockDataLimits(0, 6, 0x8) };
            StonePlate = new BlockInfo(70, "minecraft:stone_pressure_plate", "Stone Pressure Plate") { Opacity = 0, State = BlockState.NONSOLID, Tick = 20, DataLimits = new BlockDataLimits(0, 0, 0x1) };
            IronDoor = new BlockInfo(71, "minecraft:iron_door", "Iron Door") { Opacity = 0, DataLimits = new BlockDataLimits(0, 3, 0xC) };
            WoodPlate = new BlockInfo(72, "minecraft:wooden_pressure_plate", "Wooden Pressure Plate") { Opacity = 0, State = BlockState.NONSOLID, Tick = 20, DataLimits = new BlockDataLimits(0, 0, 0x1) };
            RedstoneOre = new BlockInfo(73, "minecraft:redstone_ore", "Redstone Ore") { Tick = 30 };
            GlowRedstoneOre = new BlockInfo(74, "minecraft:lit_redstone_ore", "Glowing Redstone Ore") { Luminance = 9, Tick = 30 };
            RedstoneTorch = new BlockInfo(75, "minecraft:unlit_redstone_torch", "Redstone Torch (Off)") { Opacity = 0, State = BlockState.NONSOLID, Tick = 2, DataLimits = new BlockDataLimits(0, 5, 0) };
            RedstoneTorchOn = new BlockInfo(76, "minecraft:redstone_torch", "Redstone Torch (On)") { Opacity = 0, Luminance = 7, State = BlockState.NONSOLID, Tick = 2, DataLimits = new BlockDataLimits(0, 5, 0) };
            StoneButton = new BlockInfo(77, "minecraft:stone_button", "Stone Button") { Opacity = 0, State = BlockState.NONSOLID, DataLimits = new BlockDataLimits(1, 4, 0x8) };
            Snow = new BlockInfo(78, "minecraft:snow_layer", "Snow") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(0, 7, 0) };
            Ice = new BlockInfo(79, "minecraft:ice", "Ice") { Opacity = 3, Tick = 10 };
            SnowBlock = new BlockInfo(80, "minecraft:snow", "Snow Block") { Tick = 10 };
            Cactus = new BlockInfo(81, "minecraft:cactus", "Cactus") { Opacity = 0, Tick = 10, BlocksFluid = true, DataLimits = new BlockDataLimits(0, 5, 0) };
            ClayBlock = new BlockInfo(82, "minecraft:clay", "Clay Block");
            SugarCane = new BlockInfo(83, "minecraft:reeds", "Sugar Cane") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(0, 15, 0) };
            Jukebox = new BlockInfo(84, "minecraft:jukebox", "Jukebox") { DataLimits = new BlockDataLimits(0, 2, 0) };
            Fence = new BlockInfo(85, "minecraft:fence", "Fence") { Opacity = 0 };
            Pumpkin = new BlockInfo(86, "minecraft:pumpkin", "Pumpkin") { DataLimits = new BlockDataLimits(0, 3, 0) };
            Netherrack = new BlockInfo(87, "minecraft:netherrack", "Netherrack");
            SoulSand = new BlockInfo(88, "minecraft:soul_sand", "Soul Sand");
            Glowstone = new BlockInfo(89, "minecraft:glowstone", "Glowstone Block") { Luminance = MAX_LUMINANCE };
            Portal = new BlockInfo(90, "minecraft:portal", "Portal") { Opacity = 0, Luminance = 11, State = BlockState.NONSOLID };
            JackOLantern = new BlockInfo(91, "minecraft:lit_pumpkin", "Jack-O-Lantern") { Luminance = MAX_LUMINANCE, DataLimits = new BlockDataLimits(0, 3, 0) };
            CakeBlock = new BlockInfo(92, "minecraft:cake", "Cake Block") { Opacity = 0 };
            RedstoneRepeater = new BlockInfo(93, "minecraft:unpowered_repeater", "Redstone Repeater (Off)") { Opacity = 0, Tick = 10, DataLimits = new BlockDataLimits(0, 0, 0xF) };
            RedstoneRepeaterOn = new BlockInfo(94, "minecraft:powered_repeater", "Redstone Repeater (On)") { Opacity = 0, Luminance = 7, Tick = 10, DataLimits = new BlockDataLimits(0, 0, 0xF) };
            LockedChest = new BlockInfo(95, "minecraft:chest_locked_aprilfools_super_old_legacy_we_should_not_even_have_this", "Locked Chest") { Luminance = MAX_LUMINANCE, Tick = 10 };
            StainedGlass = new BlockInfo(95, "minecraft:stained_glass", "Stained Glass") { Opacity = 0 };
            Trapdoor = new BlockInfo(96, "minecraft:trapdoor", "Trapdoor") { Opacity = 0, DataLimits = new BlockDataLimits(0, 3, 0x4) };
            SilverfishStone = new BlockInfo(97, "minecraft:monster_egg", "Stone with Silverfish") { DataLimits = new BlockDataLimits(0, 2, 0) };
            StoneBrick = new BlockInfo(98, "minecraft:stonebrick", "Stone Brick") { DataLimits = new BlockDataLimits(0, 2, 0) };
            HugeRedMushroom = new BlockInfo(99, "minecraft:brown_mushroom_block", "Huge Red Mushroom") { DataLimits = new BlockDataLimits(0, 10, 0) };
            HugeBrownMushroom = new BlockInfo(100, "minecraft:red_mushroom_block", "Huge Brown Mushroom") { DataLimits = new BlockDataLimits(0, 10, 0) };
            IronBars = new BlockInfo(101, "minecraft:iron_bars", "Iron Bars") { Opacity = 0 };
            GlassPane = new BlockInfo(102, "minecraft:glass_pane", "Glass Pane") { Opacity = 0 };
            Melon = new BlockInfo(103, "minecraft:melon_block", "Melon");
            PumpkinStem = new BlockInfo(104, "minecraft:pumpkin_stem", "Pumpkin Stem") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10 };
            MelonStem = new BlockInfo(105, "minecraft:melon_stem", "Melon Stem") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10 };
            Vines = new BlockInfo(106, "minecraft:vine", "Vines") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(0, 0, 0xF) };
            FenceGate = new BlockInfo(107, "minecraft:fence_gate", "Fence Gate") { Opacity = 0, DataLimits = new BlockDataLimits(0, 3, 0x4) };
            BrickStairs = new BlockInfo(108, "minecraft:brick_stairs", "Brick Stairs") { Opacity = 0, TransmitsLight = false };
            StoneBrickStairs = new BlockInfo(109, "minecraft:stone_brick_stairs", "Stone Brick Stairs") { Opacity = 0, TransmitsLight = false };
            Mycelium = new BlockInfo(110, "minecraft:mycelium", "Mycelium") { Tick = 10 };
            LillyPad = new BlockInfo(111, "minecraft:waterlily", "Lilly Pad") { Opacity = 0, State = BlockState.NONSOLID };
            NetherBrick = new BlockInfo(112, "minecraft:nether_brick", "Nether Brick");
            NetherBrickFence = new BlockInfo(113, "minecraft:nether_brick_fence", "Nether Brick Fence") { Opacity = 0 };
            NetherBrickStairs = new BlockInfo(114, "minecraft:nether_brick_stairs", "Nether Brick Stairs") { Opacity = 0, TransmitsLight = false };
            NetherWart = new BlockInfo(115, "minecraft:nether_wart", "Nether Wart") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10 };
            EnchantmentTable = new BlockInfo(116, "minecraft:enchanting_table", "Enchantment Table") { Opacity = 0, TileEntityName = "EnchantTable" };
            BrewingStand = new BlockInfo(117, "minecraft:brewing_stand", "Brewing Stand") { Opacity = 0, TileEntityName = "Cauldron", DataLimits = new BlockDataLimits(0, 0, 0x7) };
            Cauldron = new BlockInfo(118, "minecraft:cauldron", "Cauldron") { Opacity = 0, DataLimits = new BlockDataLimits(0, 3, 0) };
            EndPortal = new BlockInfo(119, "minecraft:end_portal", "End Portal") { Opacity = 0, Luminance = MAX_LUMINANCE, State = BlockState.NONSOLID, TileEntityName = "Airportal" };
            EndPortalFrame = new BlockInfo(120, "minecraft:end_portal_frame", "End Portal Frame") { Luminance = MAX_LUMINANCE, DataLimits = new BlockDataLimits(0, 0, 0x7) };
            EndStone = new BlockInfo(121, "minecraft:end_stone", "End Stone");
            DragonEgg = new BlockInfo(122, "minecraft:dragon_egg", "Dragon Egg") { Opacity = 0, Luminance = 1, Tick = 3 };
            RedstoneLampOff = new BlockInfo(123, "minecraft:redstone_lamp", "Redstone Lamp (Off)") { Tick = 2 };
            RedstoneLampOn = new BlockInfo(124, "minecraft:lit_redstone_lamp", "Redstone Lamp (On)") { Luminance = 15, Tick = 2 };
            DoubleWoodSlab = new BlockInfo(125, "minecraft:double_wooden_slab", "Double Wood Slab") { DataLimits = new BlockDataLimits(0, 5, 0x8) };
            WoodSlab = new BlockInfo(126, "minecraft:wooden_slab", "Wood Slab") { TransmitsLight = false, DataLimits = new BlockDataLimits(0, 5, 0) };
            CocoaPlant = new BlockInfo(127, "minecraft:cocoa", "Cocoa Plant") { Luminance = 2, Opacity = 0 };
            SandstoneStairs = new BlockInfo(128, "minecraft:sandstone_stairs", "Sandstone Stairs") { Opacity = 0, TransmitsLight = false };
            EmeraldOre = new BlockInfo(129, "minecraft:emerald_ore", "Emerald Ore");
            EnderChest = new BlockInfo(130, "minecraft:ender_chest", "Ender Chest") { Luminance = 7, Opacity = 0, TileEntityName = "EnderChest" };
            TripwireHook = new BlockInfo(131, "minecraft:tripwire_hook", "Tripwire Hook") { Opacity = 0, State = BlockState.NONSOLID, DataLimits = new BlockDataLimits(0, 3, 0xC) };
            Tripwire = new BlockInfo(132, "minecraft:tripwire", "Tripwire") { Opacity = 0, State = BlockState.NONSOLID, DataLimits = new BlockDataLimits(0, 0, 0x5) };
            EmeraldBlock = new BlockInfo(133, "minecraft:emerald_block", "Emerald Block");
            SpruceWoodStairs = new BlockInfo(134, "minecraft:spruce_stairs", "Sprice Wood Stairs") { Opacity = 0, TransmitsLight = false };
            BirchWoodStairs = new BlockInfo(135, "minecraft:birch_stairs", "Birch Wood Stairs") { Opacity = 0, TransmitsLight = false };
            JungleWoodStairs = new BlockInfo(136, "minecraft:jungle_stairs", "Jungle Wood Stairs") { Opacity = 0, TransmitsLight = false };
            CommandBlock = new BlockInfo(137, "minecraft:command_block", "Command Block") { TileEntityName = "Control" };
            BeaconBlock = new BlockInfo(138, "minecraft:beacon", "Beacon Block") { Opacity = 0, Luminance = MAX_LUMINANCE, TileEntityName = "Beacon" };
            CobblestoneWall = new BlockInfo(139, "minecraft:cobblestone_wall", "Cobblestone Wall") { Opacity = 0 };
            FlowerPot = new BlockInfo(140, "minecraft:flower_pot", "Flower Pot") { Opacity = 0 };
            Carrots = new BlockInfo(141, "minecraft:carrots", "Carrots") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10 };
            Potatoes = new BlockInfo(142, "minecraft:potatoes", "Potatoes") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10 };
            WoodButton = new BlockInfo(143, "minecraft:wooden_button", "Wooden Button") { Opacity = 0, State = BlockState.NONSOLID };
            Heads = new BlockInfo(144, "minecraft:skull", "Heads") { Opacity = 0 };
            Anvil = new BlockInfo(145, "minecraft:anvil", "Anvil") { Opacity = 0, DataLimits = new BlockDataLimits(0, 0, 0xD) };
            TrappedChest = new BlockInfo(146, "minecraft:trapped_chest", "Trapped Chest") { Opacity = 0, Tick = 10, TileEntityName = "Chest" };
            WeightedPressurePlateLight = new BlockInfo(147, "minecraft:light_weighted_pressure_plate", "Weighted Pressure Plate (Light)") { Opacity = 0, State = BlockState.NONSOLID, Tick = 20 };
            WeightedPressurePlateHeavy = new BlockInfo(148, "minecraft:heavy_weighted_pressure_plate", "Weighted Pressure Plate (Heavy)") { Opacity = 0, State = BlockState.NONSOLID, Tick = 20 };
            RedstoneComparatorInactive = new BlockInfo(149, "minecraft:unpowered_comparator", "Redstone Comparator (Inactive)") { Opacity = 0, Tick = 10 };
            RedstoneComparatorActive = new BlockInfo(150, "minecraft:powered_comparator", "Redstone Comparator (Active)") { Opacity = 0, Luminance = 9, Tick = 10 };
            DaylightSensor = new BlockInfo(151, "minecraft:daylight_detector", "Daylight Sensor") { Opacity = 0, Tick = 10 };
            RedstoneBlock = new BlockInfo(152, "minecraft:redstone_block", "Block of Redstone") { Tick = 10 };
            NetherQuartzOre = new BlockInfo(153, "minecraft:quartz_ore", "Neither Quartz Ore");
            Hopper = new BlockInfo(154, "minecraft:hopper", "Hopper") { Opacity = 0, Tick = 10, TileEntityName = "Hopper", DataLimits = new BlockDataLimits(0, 5, 0) };
            QuartzBlock = new BlockInfo(155, "minecraft:quartz_block", "Block of Quartz") { DataLimits = new BlockDataLimits(0, 4, 0) };
            QuartzStairs = new BlockInfo(156, "minecraft:quartz_stairs", "Quartz Stairs") { Opacity = 0, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 3, 0x4) };
            ActivatorRail = new BlockInfo(157, "minecraft:activator_rail", "Activator Rail") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10 };
            Dropper = new BlockInfo(158, "minecraft:dropper", "Dropper") { Tick = 10, TileEntityName = "Dropper", DataLimits = new BlockDataLimits(0, 5, 0) };
            StainedClay = new BlockInfo(159, "minecraft:stained_hardened_clay", "Stained Clay");
            StainedGlassPane = new BlockInfo(160, "minecraft:stained_glass_pane", "Stained Glass Pane") { Opacity = 0 };

            // TODO fill in details
            Leaves2 = new BlockInfo(161, "minecraft:leaves2", "Leaves (Acacia/Dark Oak)");
            Wood2 = new BlockInfo(162, "minecraft:log2", "Wood (Acacia/Dark Oak)");
            AcaciaWoodStairs = new BlockInfo(163, "minecraft:acacia_stairs", "Acacia Wood Stairs");
            DarkOakWoodStairs = new BlockInfo(164, "minecraft:dark_oak_stairs", "Dark Oak Wood Stairs");
            SlimeBlock = new BlockInfo(165, "minecraft:slime", "Slime Block");
            Barrier = new BlockInfo(166, "minecraft:barrier", "Barrier");
            IronTrapdoor = new BlockInfo(167, "minecraft:iron_trapdoor", "Iron Trapdoor");
            Prismarine = new BlockInfo(168, "minecraft:prismarine", "Prismarine");
            SeaLantern = new BlockInfo(169, "minecraft:sea_lantern", "Sea Lantern");

            HayBlock = new BlockInfo(170, "minecraft:hay_block", "Hay Block");
            Carpet = new BlockInfo(171, "minecraft:carpet", "Carpet") { Opacity = 0, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 15, 0) };
            HardenedClay = new BlockInfo(172, "minecraft:hardened_clay", "Hardened Clay");
            CoalBlock = new BlockInfo(173, "minecraft:coal_block", "Block of Coal");

            // TODO fill in details
            PackedIce = new BlockInfo(174, "minecraft:packed_ice", "Packed Ice");
            LargeFlowers = new BlockInfo(175, "minecraft:double_plant", "Large Flowers");
            StandingBanner = new BlockInfo(176, "minecraft:standing_banner", "Standing Banner");
            WallBanner = new BlockInfo(177, "minecraft:wall_banner", "Wall Banner");
            InvertedDaylightSensor = new BlockInfo(178, "minecraft:daylight_detector_inverted", "Inverted Daylight Sensor");
            RedSandstone = new BlockInfo(179, "minecraft:red_sandstone", "Red Sandstone");
            RedSandstoneStairs = new BlockInfo(180, "minecraft:red_sandstone_stairs", "Red Sandstone Stairs");
            DoubleRedSandstoneSlab = new BlockInfo(181, "minecraft:double_stone_slab2", "Double Red Sandstone Slab");
            RedSandstoneSlab = new BlockInfo(182, "minecraft:stone_slab2", "Red Sandstone Slab");
            SpruceFenceGate = new BlockInfo(183, "minecraft:spruce_fence_gate", "Spruce Fence Gate");
            BirchFenceGate = new BlockInfo(184, "minecraft:birch_fence_gate", "Birch Fence Gate");
            JungleFenceGate = new BlockInfo(185, "minecraft:jungle_fence_gate", "Jungle Fence Gate");
            DarkOakFenceGate = new BlockInfo(186, "minecraft:dark_oak_fence_gate", "Dark Oak Fence Gate");
            AcaciaFenceGate = new BlockInfo(187, "minecraft:acacia_fence_gate", "Acacia Fence Gate");
            SpruceFence = new BlockInfo(188, "minecraft:spruce_fence", "Spruce Fence");
            BirchFence = new BlockInfo(189, "minecraft:birch_fence", "Birch Fence");
            JungleFence = new BlockInfo(190, "minecraft:jungle_fence", "Jungle Fence");
            DarkOakFence = new BlockInfo(191, "minecraft:dark_oak_fence", "Dark Oak Fence");
            AcaciaFence = new BlockInfo(192, "minecraft:acacia_fence", "Acacia Fence");
            SpruceDoor = new BlockInfo(193, "minecraft:spruce_door", "Spruce Door");
            BirchDoor = new BlockInfo(194, "minecraft:birch_door", "Birch Door");
            JungleDoor = new BlockInfo(195, "minecraft:jungle_door", "Jungle Door");
            AcaciaDoor = new BlockInfo(196, "minecraft:acacia_door", "Acacia Door");
            DarkOakDoor = new BlockInfo(197, "minecraft:dark_oak_door", "Dark Oak Door");

            for (int i = 0; i < MAX_BLOCKS; i++)
            {
                if (_blockTable[i] == null)
                {
                    _blockTable[i] = new BlockInfo(i);
                }
            }
        }
    }
}
