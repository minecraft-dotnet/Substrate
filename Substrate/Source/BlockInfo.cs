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
        private static readonly Dictionary<string, BlockInfo> _nameIdLookup;
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
            public int Low { get; private set; }

            public int High { get; private set; }

            public int Bitmask { get; private set; }

            public BlockDataLimits(int low, int high, int bitmask = 0)
            {
                Low = low;
                High = high;
                Bitmask = bitmask;
            }

            public bool Test(int data)
            {
                int rdata = data & ~Bitmask;
                return rdata >= Low && rdata <= High;
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

        public static BlockInfo GetBlockByNameId(string nameId)
        {
            BlockInfo bi;
            if (_nameIdLookup.TryGetValue(nameId, out bi))
            {
                return bi;
            }

            return null;
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
            _nameIdLookup.Add(_nameId, this);
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
                return data == 0;
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
        public readonly static BlockInfo PistonExtension;
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
        public readonly static BlockInfo EndRod;
        public readonly static BlockInfo ChorusPlant;
        public readonly static BlockInfo ChorusFlower;
        public readonly static BlockInfo PurpurBlock;
        public readonly static BlockInfo PurpurPillar;
        public readonly static BlockInfo PurpurStairs;
        public readonly static BlockInfo PurpurDoubleSlab;
        public readonly static BlockInfo PurpurSlab;
        public readonly static BlockInfo EndStoneBricks;
        public readonly static BlockInfo BeetrootSeeds;
        public readonly static BlockInfo GrassPath;
        public readonly static BlockInfo EndGateway;
        public readonly static BlockInfo RepeatingCommandBlock;
        public readonly static BlockInfo ChainCommandBlock;
        public readonly static BlockInfo FrostedIce;
        public readonly static BlockInfo MagmaBlock;
        public readonly static BlockInfo NetherWartBlock;
        public readonly static BlockInfo RedNetherBrick;
        public readonly static BlockInfo BoneBlock;
        public readonly static BlockInfo StructureVoid;
        public readonly static BlockInfo Observer;
        public readonly static BlockInfo WhiteShulkerBox;
        public readonly static BlockInfo OrangeShulkerBox;
        public readonly static BlockInfo MagentaShulkerBox;
        public readonly static BlockInfo LightBlueShulkerBox;
        public readonly static BlockInfo YellowShulkerBox;
        public readonly static BlockInfo LimeShulkerBox;
        public readonly static BlockInfo PinkShulkerBox;
        public readonly static BlockInfo GrayShulkerBox;
        public readonly static BlockInfo LightGrayShulkerBox;
        public readonly static BlockInfo CyanShulkerBox;
        public readonly static BlockInfo PurpleShulkerBox;
        public readonly static BlockInfo BlueShulkerBox;
        public readonly static BlockInfo BrownShulkerBox;
        public readonly static BlockInfo GreenShulkerBox;
        public readonly static BlockInfo RedShulkerBox;
        public readonly static BlockInfo BlackShulkerBox;
        public readonly static BlockInfo WhiteGlazedTerracotta;
        public readonly static BlockInfo OrangeGlazedTerracotta;
        public readonly static BlockInfo MagentaGlazedTerracotta;
        public readonly static BlockInfo LightBlueGlazedTerracotta;
        public readonly static BlockInfo YellowGlazedTerracotta;
        public readonly static BlockInfo LimeGlazedTerracotta;
        public readonly static BlockInfo PinkGlazedTerracotta;
        public readonly static BlockInfo GrayGlazedTerracotta;
        public readonly static BlockInfo LightGrayGlazedTerracotta;
        public readonly static BlockInfo CyanGlazedTerracotta;
        public readonly static BlockInfo PurpleGlazedTerracotta;
        public readonly static BlockInfo BlueGlazedTerracotta;
        public readonly static BlockInfo BrownGlazedTerracotta;
        public readonly static BlockInfo GreenGlazedTerracotta;
        public readonly static BlockInfo RedGlazedTerracotta;
        public readonly static BlockInfo BlackGlazedTerracotta;
        public readonly static BlockInfo Concrete;
        public readonly static BlockInfo ConcretePowder;
        public readonly static BlockInfo StructureBlock;

        static BlockInfo()
        {
            _blockTable = new BlockInfo[MAX_BLOCKS];
            _nameIdLookup = new Dictionary<string, BlockInfo>();
            _opacityTable = new int[MAX_BLOCKS];
            _luminanceTable = new int[MAX_BLOCKS];

            _blockTableCache = new CacheTableArray<BlockInfo>(_blockTable);
            _opacityTableCache = new CacheTableArray<int>(_opacityTable);
            _luminanceTableCache = new CacheTableArray<int>(_luminanceTable);

            Air = new BlockInfo(0, "minecraft:air", "Air") { Opacity = 0, State = BlockState.NONSOLID };
            Stone = new BlockInfo(1, "minecraft:stone", "Stone") { DataLimits = new BlockDataLimits(0, 6) };
            Grass = new BlockInfo(2, "minecraft:grass", "Grass") { Tick = 10, DataLimits = new BlockDataLimits(0, 2) };
            Dirt = new BlockInfo(3, "minecraft:dirt", "Dirt") { DataLimits = new BlockDataLimits(0, 2) };
            Cobblestone = new BlockInfo(4, "minecraft:cobblestone", "Cobblestone");
            WoodPlank = new BlockInfo(5, "minecraft:planks", "Wooden Plank") { DataLimits = new BlockDataLimits(0, 5) };
            Sapling = new BlockInfo(6, "minecraft:sapling", "Sapling") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(0, 5, 0x8) };
            Bedrock = new BlockInfo(7, "minecraft:bedrock", "Bedrock");
            Water = new BlockInfo(8, "minecraft:flowing_water", "Water") { Opacity = 3, State = BlockState.FLUID, Tick = 5, DataLimits = new BlockDataLimits(0, 7, 0x8) };
            StationaryWater = new BlockInfo(9, "minecraft:water", "Stationary Water") { Opacity = 3, State = BlockState.FLUID, DataLimits = new BlockDataLimits(0, 15) };
            Lava = new BlockInfo(10, "minecraft:flowing_lava", "Lava") { Opacity = 0, Luminance = MAX_LUMINANCE, State = BlockState.FLUID, Tick = 30, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 7, 0x8) };
            StationaryLava = new BlockInfo(11, "minecraft:lava", "Stationary Lava") { Opacity = 0, Luminance = MAX_LUMINANCE, State = BlockState.FLUID, DataLimits = new BlockDataLimits(0, 15), Tick = 10, TransmitsLight = false };
            Sand = new BlockInfo(12, "minecraft:sand", "Sand") { Tick = 3, DataLimits = new BlockDataLimits(0, 1) };
            Gravel = new BlockInfo(13, "minecraft:gravel", "Gravel") { Tick = 3 };
            GoldOre = new BlockInfo(14, "minecraft:gold_ore", "Gold Ore");
            IronOre = new BlockInfo(15, "minecraft:iron_ore", "Iron Ore");
            CoalOre = new BlockInfo(16, "minecraft:coal_ore", "Coal Ore");
            Wood = new BlockInfo(17, "minecraft:log", "Wood") { DataLimits = new BlockDataLimits(0, 15) };
            Leaves = new BlockInfo(18, "minecraft:leaves", "Leaves") { Opacity = 1, Tick = 10, DataLimits = new BlockDataLimits(0, 3, 0xC) };
            Sponge = new BlockInfo(19, "minecraft:sponge", "Sponge") { DataLimits = new BlockDataLimits(0, 1) };
            Glass = new BlockInfo(20, "minecraft:glass", "Glass") { Opacity = 0 };
            LapisOre = new BlockInfo(21, "minecraft:lapis_ore", "Lapis Lazuli Ore");
            LapisBlock = new BlockInfo(22, "minecraft:lapis_block", "Lapis Lazuli Block");
            Dispenser = new BlockInfo(23, "minecraft:dispenser", "Dispenser") { Tick = 4, TileEntityName = "Trap", DataLimits = new BlockDataLimits(0, 5, 0x8) };
            Sandstone = new BlockInfo(24, "minecraft:sandstone", "Sandstone") { DataLimits = new BlockDataLimits(0, 2) };
            NoteBlock = new BlockInfo(25, "minecraft:noteblock", "Note Block") { TileEntityName = "Music" };
            Bed = new BlockInfo(26, "minecraft:bed", "Bed") { Opacity = 0, DataLimits = new BlockDataLimits(0, 3, 0xC) };
            PoweredRail = new BlockInfo(27, "minecraft:golden_rail", "Powered Rail") { Opacity = 0, State = BlockState.NONSOLID, DataLimits = new BlockDataLimits(0, 5, 0x8) };
            DetectorRail = new BlockInfo(28, "minecraft:detector_rail", "Detector Rail") { Opacity = 0, State = BlockState.NONSOLID, Tick = 20, DataLimits = new BlockDataLimits(0, 5, 0x8) };
            StickyPiston = new BlockInfo(29, "minecraft:sticky_piston", "Sticky Piston") { Opacity = 0, DataLimits = new BlockDataLimits(0, 5, 0x8) };
            Cobweb = new BlockInfo(30, "minecraft:web", "Cobweb") { Opacity = 0, State = BlockState.NONSOLID };
            TallGrass = new BlockInfo(31, "minecraft:tallgrass", "Tall Grass") { Opacity = 0, State = BlockState.NONSOLID, DataLimits = new BlockDataLimits(0, 2, 0) };
            DeadShrub = new BlockInfo(32, "minecraft:deadbush", "Dead Shrub") { Opacity = 0, State = BlockState.NONSOLID };
            Piston = new BlockInfo(33, "minecraft:piston", "Piston") { Opacity = 0, DataLimits = new BlockDataLimits(0, 5, 0x8) };
            PistonHead = new BlockInfo(34, "minecraft:piston_head", "Piston Head") { Opacity = 0, DataLimits = new BlockDataLimits(0, 5, 0x8) };
            Wool = new BlockInfo(35, "minecraft:wool", "Wool") { DataLimits = new BlockDataLimits(0, 15) };
            PistonExtension = new BlockInfo(36, "minecraft:piston_extension", "Piston Extension") { Opacity = 0, TileEntityName = "Piston", DataLimits = new BlockDataLimits(0, 19) };
            YellowFlower = new BlockInfo(37, "minecraft:yellow_flower", "Yellow Flower") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(0, 0) };
            RedRose = new BlockInfo(38, "minecraft:red_flower", "Red Rose") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(0, 8) };
            BrownMushroom = new BlockInfo(39, "minecraft:brown_mushroom", "Brown Mushroom") { Opacity = 0, Luminance = 1, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(0, 15) };
            RedMushroom = new BlockInfo(40, "minecraft:red_mushroom", "Red Mushroom") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(0, 15) };
            GoldBlock = new BlockInfo(41, "minecraft:gold_block", "Gold Block");
            IronBlock = new BlockInfo(42, "minecraft:iron_block", "Iron Block");
            DoubleStoneSlab = new BlockInfo(43, "minecraft:double_stone_slab", "Double Slab") { DataLimits = new BlockDataLimits(0, 9, 0x8) };
            StoneSlab = new BlockInfo(44, "minecraft:stone_slab", "Slab") { Opacity = 0, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 9, 0x8) };
            BrickBlock = new BlockInfo(45, "minecraft:brick_block", "Brick Block");
            TNT = new BlockInfo(46, "minecraft:tnt", "TNT") { DataLimits = new BlockDataLimits(0, 1) };
            Bookshelf = new BlockInfo(47, "minecraft:bookshelf", "Bookshelf");
            MossStone = new BlockInfo(48, "minecraft:mossy_cobblestone", "Moss Stone");
            Obsidian = new BlockInfo(49, "minecraft:obsidian", "Obsidian");
            Torch = new BlockInfo(50, "minecraft:torch", "Torch") { Opacity = 0, Luminance = MAX_LUMINANCE - 1, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(1, 5) };
            Fire = new BlockInfo(51, "minecraft:fire", "Fire") { Opacity = 0, Luminance = MAX_LUMINANCE, State = BlockState.NONSOLID, Tick = 40, DataLimits = new BlockDataLimits(0, 15) };
            MonsterSpawner = new BlockInfo(52, "minecraft:mob_spawner", "Monster Spawner") { Opacity = 0, TileEntityName = "MobSpawner" };
            WoodStairs = new BlockInfo(53, "minecraft:oak_stairs", "Wooden Stairs") { Opacity = 0, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 3, 0x4) };
            Chest = new BlockInfo(54, "minecraft:chest", "Chest") { Opacity = 0, TileEntityName = "Chest", DataLimits = new BlockDataLimits(2, 5) };
            RedstoneWire = new BlockInfo(55, "minecraft:redstone_wire", "Redstone Wire") { Opacity = 0, State = BlockState.NONSOLID, DataLimits = new BlockDataLimits(0, 15) };
            DiamondOre = new BlockInfo(56, "minecraft:diamond_ore", "Diamond Ore");
            DiamondBlock = new BlockInfo(57, "minecraft:diamond_block", "Diamond Block");
            CraftTable = new BlockInfo(58, "minecraft:crafting_table", "Crafting Table");
            Crops = new BlockInfo(59, "minecraft:wheat", "Crops") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(0, 7) };
            Farmland = new BlockInfo(60, "minecraft:farmland", "Farmland") { Opacity = 0, Tick = 10, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 7) };
            Furnace = new BlockInfo(61, "minecraft:furnace", "Furnace") { TileEntityName = "Furnace", DataLimits = new BlockDataLimits(2, 5, 0) };
            BurningFurnace = new BlockInfo(62, "minecraft:lit_furnace", "Burning Furnace") { Luminance = MAX_LUMINANCE - 1, TileEntityName = "Furnace", DataLimits = new BlockDataLimits(2, 5, 0) };
            SignPost = new BlockInfo(63, "minecraft:standing_sign", "Sign Post") { Opacity = 0, State = BlockState.NONSOLID, BlocksFluid = true, TileEntityName = "Sign", DataLimits = new BlockDataLimits(0, 15) };
            WoodDoor = new BlockInfo(64, "minecraft:wooden_door", "Wooden Door") { Opacity = 0, DataLimits = new BlockDataLimits(0, 0, 0xF) };
            Ladder = new BlockInfo(65, "minecraft:ladder", "Ladder") { Opacity = 0, DataLimits = new BlockDataLimits(2, 5, 0) };
            Rails = new BlockInfo(66, "minecraft:rail", "Rails") { Opacity = 0, State = BlockState.NONSOLID, DataLimits = new BlockDataLimits(0, 9, 0) };
            CobbleStairs = new BlockInfo(67, "minecraft:stone_stairs", "Cobblestone Stairs") { Opacity = 0, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 3, 0x4) };
            WallSign = new BlockInfo(68, "minecraft:wall_sign", "Wall Sign") { Opacity = 0, State = BlockState.NONSOLID, BlocksFluid = true, TileEntityName = "Sign", DataLimits = new BlockDataLimits(2, 5) };
            Lever = new BlockInfo(69, "minecraft:lever", "Lever") { Opacity = 0, State = BlockState.NONSOLID, DataLimits = new BlockDataLimits(0, 7, 0x8) };
            StonePlate = new BlockInfo(70, "minecraft:stone_pressure_plate", "Stone Pressure Plate") { Opacity = 0, State = BlockState.NONSOLID, Tick = 20, DataLimits = new BlockDataLimits(0, 0, 0x1) };
            IronDoor = new BlockInfo(71, "minecraft:iron_door", "Iron Door") { Opacity = 0, DataLimits = new BlockDataLimits(0, 0, 0xF) };
            WoodPlate = new BlockInfo(72, "minecraft:wooden_pressure_plate", "Wooden Pressure Plate") { Opacity = 0, State = BlockState.NONSOLID, Tick = 20, DataLimits = new BlockDataLimits(0, 0, 0x1) };
            RedstoneOre = new BlockInfo(73, "minecraft:redstone_ore", "Redstone Ore") { Tick = 30 };
            GlowRedstoneOre = new BlockInfo(74, "minecraft:lit_redstone_ore", "Glowing Redstone Ore") { Luminance = 9, Tick = 30 };
            RedstoneTorch = new BlockInfo(75, "minecraft:unlit_redstone_torch", "Redstone Torch (Off)") { Opacity = 0, State = BlockState.NONSOLID, Tick = 2, DataLimits = new BlockDataLimits(1, 5) };
            RedstoneTorchOn = new BlockInfo(76, "minecraft:redstone_torch", "Redstone Torch (On)") { Opacity = 0, Luminance = 7, State = BlockState.NONSOLID, Tick = 2, DataLimits = new BlockDataLimits(1, 5) };
            StoneButton = new BlockInfo(77, "minecraft:stone_button", "Stone Button") { Opacity = 0, State = BlockState.NONSOLID, DataLimits = new BlockDataLimits(0, 5, 0x8) };
            Snow = new BlockInfo(78, "minecraft:snow_layer", "Snow") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(0, 7, 0) };
            Ice = new BlockInfo(79, "minecraft:ice", "Ice") { Opacity = 3, Tick = 10 };
            SnowBlock = new BlockInfo(80, "minecraft:snow", "Snow Block") { Tick = 10 };
            Cactus = new BlockInfo(81, "minecraft:cactus", "Cactus") { Opacity = 0, Tick = 10, BlocksFluid = true, DataLimits = new BlockDataLimits(0, 15) };
            ClayBlock = new BlockInfo(82, "minecraft:clay", "Clay Block");
            SugarCane = new BlockInfo(83, "minecraft:reeds", "Sugar Cane") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(0, 15) };
            Jukebox = new BlockInfo(84, "minecraft:jukebox", "Jukebox") { DataLimits = new BlockDataLimits(0, 1) };
            Fence = new BlockInfo(85, "minecraft:fence", "Fence") { Opacity = 0 };
            Pumpkin = new BlockInfo(86, "minecraft:pumpkin", "Pumpkin") { DataLimits = new BlockDataLimits(0, 3, 0x4) };
            Netherrack = new BlockInfo(87, "minecraft:netherrack", "Netherrack");
            SoulSand = new BlockInfo(88, "minecraft:soul_sand", "Soul Sand");
            Glowstone = new BlockInfo(89, "minecraft:glowstone", "Glowstone Block") { Luminance = MAX_LUMINANCE };
            Portal = new BlockInfo(90, "minecraft:portal", "Portal") { Opacity = 0, Luminance = 11, State = BlockState.NONSOLID, DataLimits = new BlockDataLimits(0, 2) };
            JackOLantern = new BlockInfo(91, "minecraft:lit_pumpkin", "Jack-O-Lantern") { Luminance = MAX_LUMINANCE, DataLimits = new BlockDataLimits(0, 3, 0x4) };
            CakeBlock = new BlockInfo(92, "minecraft:cake", "Cake Block") { Opacity = 0, DataLimits = new BlockDataLimits(0, 6) };
            RedstoneRepeater = new BlockInfo(93, "minecraft:unpowered_repeater", "Redstone Repeater (Off)") { Opacity = 0, Tick = 10, DataLimits = new BlockDataLimits(0, 0, 0xF) };
            RedstoneRepeaterOn = new BlockInfo(94, "minecraft:powered_repeater", "Redstone Repeater (On)") { Opacity = 0, Luminance = 7, Tick = 10, DataLimits = new BlockDataLimits(0, 0, 0xF) };
            //LockedChest = new BlockInfo(95, "minecraft:chest_locked_aprilfools_super_old_legacy_we_should_not_even_have_this", "Locked Chest") { Luminance = MAX_LUMINANCE, Tick = 10 };
            StainedGlass = new BlockInfo(95, "minecraft:stained_glass", "Stained Glass") { Opacity = 0, DataLimits = new BlockDataLimits(0, 15) };
            Trapdoor = new BlockInfo(96, "minecraft:trapdoor", "Trapdoor") { Opacity = 0, DataLimits = new BlockDataLimits(0, 3, 0xC) };
            SilverfishStone = new BlockInfo(97, "minecraft:monster_egg", "Stone with Silverfish") { DataLimits = new BlockDataLimits(0, 5) };
            StoneBrick = new BlockInfo(98, "minecraft:stonebrick", "Stone Brick") { DataLimits = new BlockDataLimits(0, 3) };
            HugeRedMushroom = new BlockInfo(99, "minecraft:brown_mushroom_block", "Huge Red Mushroom") { DataLimits = new BlockDataLimits(0, 15) }; // VERIFYME data values
            HugeBrownMushroom = new BlockInfo(100, "minecraft:red_mushroom_block", "Huge Brown Mushroom") { DataLimits = new BlockDataLimits(0, 15) }; // VERIFYME data values
            IronBars = new BlockInfo(101, "minecraft:iron_bars", "Iron Bars") { Opacity = 0 };
            GlassPane = new BlockInfo(102, "minecraft:glass_pane", "Glass Pane") { Opacity = 0 };
            Melon = new BlockInfo(103, "minecraft:melon_block", "Melon");
            PumpkinStem = new BlockInfo(104, "minecraft:pumpkin_stem", "Pumpkin Stem") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(0, 7) };
            MelonStem = new BlockInfo(105, "minecraft:melon_stem", "Melon Stem") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(0, 7) };
            Vines = new BlockInfo(106, "minecraft:vine", "Vines") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(0, 0, 0xF) };
            FenceGate = new BlockInfo(107, "minecraft:fence_gate", "Fence Gate") { Opacity = 0, DataLimits = new BlockDataLimits(0, 3, 0xC) }; // VERIFYME data values
            BrickStairs = new BlockInfo(108, "minecraft:brick_stairs", "Brick Stairs") { Opacity = 0, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 3, 0x4) };
            StoneBrickStairs = new BlockInfo(109, "minecraft:stone_brick_stairs", "Stone Brick Stairs") { Opacity = 0, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 3, 0x4) };
            Mycelium = new BlockInfo(110, "minecraft:mycelium", "Mycelium") { Tick = 10 };
            LillyPad = new BlockInfo(111, "minecraft:waterlily", "Lilly Pad") { Opacity = 0, State = BlockState.NONSOLID };
            NetherBrick = new BlockInfo(112, "minecraft:nether_brick", "Nether Brick");
            NetherBrickFence = new BlockInfo(113, "minecraft:nether_brick_fence", "Nether Brick Fence") { Opacity = 0 };
            NetherBrickStairs = new BlockInfo(114, "minecraft:nether_brick_stairs", "Nether Brick Stairs") { Opacity = 0, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 3, 0x4) };
            NetherWart = new BlockInfo(115, "minecraft:nether_wart", "Nether Wart") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(0, 3) };
            EnchantmentTable = new BlockInfo(116, "minecraft:enchanting_table", "Enchantment Table") { Opacity = 0, TileEntityName = "EnchantTable" };
            BrewingStand = new BlockInfo(117, "minecraft:brewing_stand", "Brewing Stand") { Opacity = 0, TileEntityName = "Cauldron", DataLimits = new BlockDataLimits(0, 0, 0x7) };
            Cauldron = new BlockInfo(118, "minecraft:cauldron", "Cauldron") { Opacity = 0, DataLimits = new BlockDataLimits(0, 3, 0) };
            EndPortal = new BlockInfo(119, "minecraft:end_portal", "End Portal") { Opacity = 0, Luminance = MAX_LUMINANCE, State = BlockState.NONSOLID, TileEntityName = "Airportal", DataLimits = new BlockDataLimits(0, 3, 0x4) };
            EndPortalFrame = new BlockInfo(120, "minecraft:end_portal_frame", "End Portal Frame") { Luminance = MAX_LUMINANCE, DataLimits = new BlockDataLimits(0, 0, 0x7) };
            EndStone = new BlockInfo(121, "minecraft:end_stone", "End Stone");
            DragonEgg = new BlockInfo(122, "minecraft:dragon_egg", "Dragon Egg") { Opacity = 0, Luminance = 1, Tick = 3 };
            RedstoneLampOff = new BlockInfo(123, "minecraft:redstone_lamp", "Redstone Lamp (Off)") { Tick = 2 };
            RedstoneLampOn = new BlockInfo(124, "minecraft:lit_redstone_lamp", "Redstone Lamp (On)") { Luminance = 15, Tick = 2 };
            DoubleWoodSlab = new BlockInfo(125, "minecraft:double_wooden_slab", "Double Wood Slab") { DataLimits = new BlockDataLimits(0, 5) };
            WoodSlab = new BlockInfo(126, "minecraft:wooden_slab", "Wood Slab") { TransmitsLight = false, DataLimits = new BlockDataLimits(0, 5, 0x8) };
            CocoaPlant = new BlockInfo(127, "minecraft:cocoa", "Cocoa Plant") { Luminance = 2, Opacity = 0, DataLimits = new BlockDataLimits(0, 3, 0xC) };
            SandstoneStairs = new BlockInfo(128, "minecraft:sandstone_stairs", "Sandstone Stairs") { Opacity = 0, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 3, 0x4) };
            EmeraldOre = new BlockInfo(129, "minecraft:emerald_ore", "Emerald Ore");
            EnderChest = new BlockInfo(130, "minecraft:ender_chest", "Ender Chest") { Luminance = 7, Opacity = 0, TileEntityName = "EnderChest", DataLimits = new BlockDataLimits(2, 5) };
            TripwireHook = new BlockInfo(131, "minecraft:tripwire_hook", "Tripwire Hook") { Opacity = 0, State = BlockState.NONSOLID, DataLimits = new BlockDataLimits(0, 3, 0xC) };
            Tripwire = new BlockInfo(132, "minecraft:tripwire", "Tripwire") { Opacity = 0, State = BlockState.NONSOLID, DataLimits = new BlockDataLimits(0, 0, 0xF) };
            EmeraldBlock = new BlockInfo(133, "minecraft:emerald_block", "Emerald Block");
            SpruceWoodStairs = new BlockInfo(134, "minecraft:spruce_stairs", "Sprice Wood Stairs") { Opacity = 0, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 3, 0x4) };
            BirchWoodStairs = new BlockInfo(135, "minecraft:birch_stairs", "Birch Wood Stairs") { Opacity = 0, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 3, 0x4) };
            JungleWoodStairs = new BlockInfo(136, "minecraft:jungle_stairs", "Jungle Wood Stairs") { Opacity = 0, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 3, 0x4) };
            CommandBlock = new BlockInfo(137, "minecraft:command_block", "Command Block") { TileEntityName = "Control", DataLimits = new BlockDataLimits(0, 13) };
            BeaconBlock = new BlockInfo(138, "minecraft:beacon", "Beacon Block") { Opacity = 0, Luminance = MAX_LUMINANCE, TileEntityName = "Beacon" };
            CobblestoneWall = new BlockInfo(139, "minecraft:cobblestone_wall", "Cobblestone Wall") { Opacity = 0, DataLimits = new BlockDataLimits(0, 1) };
            FlowerPot = new BlockInfo(140, "minecraft:flower_pot", "Flower Pot") { Opacity = 0, DataLimits = new BlockDataLimits(0, 15) }; // VERIFYME data values
            Carrots = new BlockInfo(141, "minecraft:carrots", "Carrots") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(0, 7) };
            Potatoes = new BlockInfo(142, "minecraft:potatoes", "Potatoes") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(0, 7) };
            WoodButton = new BlockInfo(143, "minecraft:wooden_button", "Wooden Button") { Opacity = 0, State = BlockState.NONSOLID, DataLimits = new BlockDataLimits(0, 5, 0x8) };
            Heads = new BlockInfo(144, "minecraft:skull", "Heads") { Opacity = 0, DataLimits = new BlockDataLimits(0, 5, 0x8) };  // VERIFYME data values
            Anvil = new BlockInfo(145, "minecraft:anvil", "Anvil") { Opacity = 0, DataLimits = new BlockDataLimits(0, 3, 0xC) };
            TrappedChest = new BlockInfo(146, "minecraft:trapped_chest", "Trapped Chest") { Opacity = 0, Tick = 10, TileEntityName = "Chest", DataLimits = new BlockDataLimits(2, 5) };
            WeightedPressurePlateLight = new BlockInfo(147, "minecraft:light_weighted_pressure_plate", "Weighted Pressure Plate (Light)") { Opacity = 0, State = BlockState.NONSOLID, Tick = 20, DataLimits = new BlockDataLimits(0, 15) };
            WeightedPressurePlateHeavy = new BlockInfo(148, "minecraft:heavy_weighted_pressure_plate", "Weighted Pressure Plate (Heavy)") { Opacity = 0, State = BlockState.NONSOLID, Tick = 20, DataLimits = new BlockDataLimits(0, 15) };
            RedstoneComparatorInactive = new BlockInfo(149, "minecraft:unpowered_comparator", "Redstone Comparator (Inactive)") { Opacity = 0, Tick = 10, DataLimits = new BlockDataLimits(0, 3, 0xC) };
            RedstoneComparatorActive = new BlockInfo(150, "minecraft:powered_comparator", "Redstone Comparator (Active)") { Opacity = 0, Luminance = 9, Tick = 10, DataLimits = new BlockDataLimits(0, 3, 0xC) };
            DaylightSensor = new BlockInfo(151, "minecraft:daylight_detector", "Daylight Sensor") { Opacity = 0, Tick = 10, DataLimits = new BlockDataLimits(0, 15) };
            RedstoneBlock = new BlockInfo(152, "minecraft:redstone_block", "Block of Redstone") { Tick = 10 };
            NetherQuartzOre = new BlockInfo(153, "minecraft:quartz_ore", "Neither Quartz Ore");
            Hopper = new BlockInfo(154, "minecraft:hopper", "Hopper") { Opacity = 0, Tick = 10, TileEntityName = "Hopper", DataLimits = new BlockDataLimits(0, 5, 0x8) };
            QuartzBlock = new BlockInfo(155, "minecraft:quartz_block", "Block of Quartz") { DataLimits = new BlockDataLimits(0, 4, 0) };
            QuartzStairs = new BlockInfo(156, "minecraft:quartz_stairs", "Quartz Stairs") { Opacity = 0, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 3, 0x4) };
            ActivatorRail = new BlockInfo(157, "minecraft:activator_rail", "Activator Rail") { Opacity = 0, State = BlockState.NONSOLID, Tick = 10, DataLimits = new BlockDataLimits(0, 5, 0x8) };
            Dropper = new BlockInfo(158, "minecraft:dropper", "Dropper") { Tick = 10, TileEntityName = "Dropper", DataLimits = new BlockDataLimits(0, 5, 0x8) };
            StainedClay = new BlockInfo(159, "minecraft:stained_hardened_clay", "Stained Clay") { DataLimits = new BlockDataLimits(0, 15) };
            StainedGlassPane = new BlockInfo(160, "minecraft:stained_glass_pane", "Stained Glass Pane") { Opacity = 0, DataLimits = new BlockDataLimits(0, 15) };

            // TODO fill in details
            Leaves2 = new BlockInfo(161, "minecraft:leaves2", "Leaves (Acacia/Dark Oak)") { DataLimits = new BlockDataLimits(0, 1, 0xC) };
            Wood2 = new BlockInfo(162, "minecraft:log2", "Wood (Acacia/Dark Oak)") { DataLimits = new BlockDataLimits(0, 13) };
            AcaciaWoodStairs = new BlockInfo(163, "minecraft:acacia_stairs", "Acacia Wood Stairs") { DataLimits = new BlockDataLimits(0, 3, 0x4) };
            DarkOakWoodStairs = new BlockInfo(164, "minecraft:dark_oak_stairs", "Dark Oak Wood Stairs") { DataLimits = new BlockDataLimits(0, 3, 0x4) };
            SlimeBlock = new BlockInfo(165, "minecraft:slime", "Slime Block");
            Barrier = new BlockInfo(166, "minecraft:barrier", "Barrier");
            IronTrapdoor = new BlockInfo(167, "minecraft:iron_trapdoor", "Iron Trapdoor") { DataLimits = new BlockDataLimits(0, 15) };
            Prismarine = new BlockInfo(168, "minecraft:prismarine", "Prismarine") { DataLimits = new BlockDataLimits(0, 2) };
            SeaLantern = new BlockInfo(169, "minecraft:sea_lantern", "Sea Lantern");

            HayBlock = new BlockInfo(170, "minecraft:hay_block", "Hay Block") { DataLimits = new BlockDataLimits(0, 8) };
            Carpet = new BlockInfo(171, "minecraft:carpet", "Carpet") { Opacity = 0, TransmitsLight = false, DataLimits = new BlockDataLimits(0, 15) };
            HardenedClay = new BlockInfo(172, "minecraft:hardened_clay", "Hardened Clay");
            CoalBlock = new BlockInfo(173, "minecraft:coal_block", "Block of Coal") { DataLimits = new BlockDataLimits(0, 1) };

            // TODO fill in details
            PackedIce = new BlockInfo(174, "minecraft:packed_ice", "Packed Ice");
            LargeFlowers = new BlockInfo(175, "minecraft:double_plant", "Large Flowers") { DataLimits = new BlockDataLimits(0, 5, 0x8) };
            StandingBanner = new BlockInfo(176, "minecraft:standing_banner", "Standing Banner") { DataLimits = new BlockDataLimits(0, 15) };
            WallBanner = new BlockInfo(177, "minecraft:wall_banner", "Wall Banner") { DataLimits = new BlockDataLimits(2, 5) };
            InvertedDaylightSensor = new BlockInfo(178, "minecraft:daylight_detector_inverted", "Inverted Daylight Sensor") { DataLimits = new BlockDataLimits(0, 15) };
            RedSandstone = new BlockInfo(179, "minecraft:red_sandstone", "Red Sandstone") { DataLimits = new BlockDataLimits(0, 2) };
            RedSandstoneStairs = new BlockInfo(180, "minecraft:red_sandstone_stairs", "Red Sandstone Stairs") { DataLimits = new BlockDataLimits(0, 3, 0x4) };
            DoubleRedSandstoneSlab = new BlockInfo(181, "minecraft:double_stone_slab2", "Double Red Sandstone Slab") { DataLimits = new BlockDataLimits(0, 0, 0x8) };
            RedSandstoneSlab = new BlockInfo(182, "minecraft:stone_slab2", "Red Sandstone Slab") { DataLimits = new BlockDataLimits(0, 0, 0x8) };
            SpruceFenceGate = new BlockInfo(183, "minecraft:spruce_fence_gate", "Spruce Fence Gate") { DataLimits = new BlockDataLimits(0, 3, 0xC) }; // VERIFYME data values
            BirchFenceGate = new BlockInfo(184, "minecraft:birch_fence_gate", "Birch Fence Gate") { DataLimits = new BlockDataLimits(0, 3, 0xC) }; // VERIFYME data values
            JungleFenceGate = new BlockInfo(185, "minecraft:jungle_fence_gate", "Jungle Fence Gate") { DataLimits = new BlockDataLimits(0, 3, 0xC) }; // VERIFYME data values
            DarkOakFenceGate = new BlockInfo(186, "minecraft:dark_oak_fence_gate", "Dark Oak Fence Gate") { DataLimits = new BlockDataLimits(0, 3, 0xC) }; // VERIFYME data values
            AcaciaFenceGate = new BlockInfo(187, "minecraft:acacia_fence_gate", "Acacia Fence Gate") { DataLimits = new BlockDataLimits(0, 3, 0xC) }; // VERIFYME data values
            SpruceFence = new BlockInfo(188, "minecraft:spruce_fence", "Spruce Fence");
            BirchFence = new BlockInfo(189, "minecraft:birch_fence", "Birch Fence");
            JungleFence = new BlockInfo(190, "minecraft:jungle_fence", "Jungle Fence");
            DarkOakFence = new BlockInfo(191, "minecraft:dark_oak_fence", "Dark Oak Fence");
            AcaciaFence = new BlockInfo(192, "minecraft:acacia_fence", "Acacia Fence");
            SpruceDoor = new BlockInfo(193, "minecraft:spruce_door", "Spruce Door") { DataLimits = new BlockDataLimits(0, 0, 0xF) };
            BirchDoor = new BlockInfo(194, "minecraft:birch_door", "Birch Door") { DataLimits = new BlockDataLimits(0, 0, 0xF) };
            JungleDoor = new BlockInfo(195, "minecraft:jungle_door", "Jungle Door") { DataLimits = new BlockDataLimits(0, 0, 0xF) };
            AcaciaDoor = new BlockInfo(196, "minecraft:acacia_door", "Acacia Door") { DataLimits = new BlockDataLimits(0, 0, 0xF) };
            DarkOakDoor = new BlockInfo(197, "minecraft:dark_oak_door", "Dark Oak Door") { DataLimits = new BlockDataLimits(0, 0, 0xF) };

            // TODO details
            EndRod = new BlockInfo(198, "minecraft:end_rod", "End Rod") { DataLimits = new BlockDataLimits(0, 5) };
            ChorusPlant = new BlockInfo(199, "minecraft:chorus_plant", "Chorus Plant");
            ChorusFlower = new BlockInfo(200, "minecraft:chorus_flower", "Chorus Flower") { DataLimits = new BlockDataLimits(0, 5) };
            PurpurBlock = new BlockInfo(201, "minecraft:purpur_block", "Purpur Block");
            PurpurPillar = new BlockInfo(202, "minecraft:purpur_pillar", "Purpur Pillar") { DataLimits = new BlockDataLimits(0, 8) };
            PurpurStairs = new BlockInfo(203, "minecraft:purpur_stairs", "Purpur Stairs") { DataLimits = new BlockDataLimits(0, 7) };
            PurpurDoubleSlab = new BlockInfo(204, "minecraft:purpur_double_slab", "Purpur Double Slab");
            PurpurSlab = new BlockInfo(205, "minecraft:purpur_slab", "Purpur Slab") { DataLimits = new BlockDataLimits(0, 8) };
            EndStoneBricks = new BlockInfo(206, "minecraft:end_bricks", "End Stone Bricks");
            BeetrootSeeds = new BlockInfo(207, "minecraft:beetroots", "Beetroot Seeds") { DataLimits = new BlockDataLimits(0, 3) };
            GrassPath = new BlockInfo(208, "minecraft:grass_path", "Grass Path");
            EndGateway = new BlockInfo(209, "minecraft:end_gateway", "End Gateway");

            RepeatingCommandBlock = new BlockInfo(210, "minecraft:repeating_command_block", "Repeating Command Block") { DataLimits = new BlockDataLimits(0, 13) };
            ChainCommandBlock = new BlockInfo(211, "minecraft:chain_command_block", "Chain Command Block") { DataLimits = new BlockDataLimits(0, 13) };
            FrostedIce = new BlockInfo(212, "minecraft:frosted_ice", "Frosted Ice") { DataLimits = new BlockDataLimits(0, 3) };
            MagmaBlock = new BlockInfo(213, "minecraft:magma", "Magma Block");
            NetherWartBlock = new BlockInfo(214, "minecraft:nether_wart_block", "Nether Wart Block");
            RedNetherBrick = new BlockInfo(215, "minecraft:red_nether_brick", "Red Nether Brick");
            BoneBlock = new BlockInfo(216, "minecraft:bone_block", "Bone Block") { DataLimits = new BlockDataLimits(0, 8) };
            StructureVoid = new BlockInfo(217, "minecraft:structure_void", "Structure Void");
            Observer = new BlockInfo(218, "minecraft:observer", "Observer") { DataLimits = new BlockDataLimits(0, 13) };
            WhiteShulkerBox = new BlockInfo(219, "minecraft:white_shulker_box", "White Shulker Box") { DataLimits = new BlockDataLimits(0, 5) };

            OrangeShulkerBox = new BlockInfo(220, "minecraft:orange_shulker_box", "Orange Shulker Box") { DataLimits = new BlockDataLimits(0, 5) };
            MagentaShulkerBox = new BlockInfo(221, "minecraft:magenta_shulker_box", "Magenta Shulker Box") { DataLimits = new BlockDataLimits(0, 5) };
            LightBlueShulkerBox = new BlockInfo(222, "minecraft:light_blue_shulker_box", "Light Blue Shulker Box") { DataLimits = new BlockDataLimits(0, 5) };
            YellowShulkerBox = new BlockInfo(223, "minecraft:yellow_shulker_box", "Yellow Shulker Box") { DataLimits = new BlockDataLimits(0, 5) };
            LimeShulkerBox = new BlockInfo(224, "minecraft:lime_shulker_box", "Lime Shulker Box") { DataLimits = new BlockDataLimits(0, 5) };
            PinkShulkerBox = new BlockInfo(225, "minecraft:pink_shulker_box", "Pink Shulker Box") { DataLimits = new BlockDataLimits(0, 5) };
            GrayShulkerBox = new BlockInfo(226, "minecraft:gray_shulker_box", "Gray Shulker Box") { DataLimits = new BlockDataLimits(0, 5) };
            LightGrayShulkerBox = new BlockInfo(227, "minecraft:silver_shulker_box", "Light Gray Shulker Box") { DataLimits = new BlockDataLimits(0, 5) };
            CyanShulkerBox = new BlockInfo(228, "minecraft:cyan_shulker_box", "Cyan Shulker Box") { DataLimits = new BlockDataLimits(0, 5) };
            PurpleShulkerBox = new BlockInfo(229, "minecraft:purple_shulker_box", "Purple Shulker Box") { DataLimits = new BlockDataLimits(0, 5) };

            BlueShulkerBox = new BlockInfo(230, "minecraft:blue_shulker_box", "Blue Shulker Box") { DataLimits = new BlockDataLimits(0, 5) };
            BrownShulkerBox = new BlockInfo(231, "minecraft:brown_shulker_box", "Brown Shulker Box") { DataLimits = new BlockDataLimits(0, 5) };
            GreenShulkerBox = new BlockInfo(232, "minecraft:green_shulker_box", "Green Shulker Box") { DataLimits = new BlockDataLimits(0, 5) };
            RedShulkerBox = new BlockInfo(233, "minecraft:red_shulker_box", "Red Shulker Box") { DataLimits = new BlockDataLimits(0, 5) };
            BlackShulkerBox = new BlockInfo(234, "minecraft:black_shulker_box", "Black Shulker Box") { DataLimits = new BlockDataLimits(0, 5) };
            WhiteGlazedTerracotta = new BlockInfo(235, "minecraft:white_glazed_terracotta", "White Glazed Terracotta") { DataLimits = new BlockDataLimits(0, 3) };
            OrangeGlazedTerracotta = new BlockInfo(236, "minecraft:orange_glazed_terracotta", "Orange Glazed Terracotta") { DataLimits = new BlockDataLimits(0, 3) };
            MagentaGlazedTerracotta = new BlockInfo(237, "minecraft:magenta_glazed_terracotta", "Magenta Glazed Terracotta") { DataLimits = new BlockDataLimits(0, 3) };
            LightBlueGlazedTerracotta = new BlockInfo(238, "minecraft:light_blue_glazed_terracotta", "Light Blue Glazed Terracotta") { DataLimits = new BlockDataLimits(0, 3) };
            YellowGlazedTerracotta = new BlockInfo(239, "minecraft:yellow_glazed_terracotta", "Yellow Glazed Terracotta") { DataLimits = new BlockDataLimits(0, 3) };

            LimeGlazedTerracotta = new BlockInfo(240, "minecraft:lime_glazed_terracotta", "Lime Glazed Terracotta") { DataLimits = new BlockDataLimits(0, 3) };
            PinkGlazedTerracotta = new BlockInfo(241, "minecraft:pink_glazed_terracotta", "Pink Glazed Terracotta") { DataLimits = new BlockDataLimits(0, 3) };
            GrayGlazedTerracotta = new BlockInfo(242, "minecraft:gray_glazed_terracotta", "Gray Glazed Terracotta") { DataLimits = new BlockDataLimits(0, 3) };
            LightGrayGlazedTerracotta = new BlockInfo(243, "minecraft:silver_glazed_terracotta", "Light Gray Glazed Terracotta") { DataLimits = new BlockDataLimits(0, 3) };
            CyanGlazedTerracotta = new BlockInfo(244, "minecraft:cyan_glazed_terracotta", "Cyan Glazed Terracotta") { DataLimits = new BlockDataLimits(0, 3) };
            PurpleGlazedTerracotta = new BlockInfo(245, "minecraft:purple_glazed_terracotta", "Purple Glazed Terracotta") { DataLimits = new BlockDataLimits(0, 3) };
            BlueGlazedTerracotta = new BlockInfo(246, "minecraft:blue_glazed_terracotta", "Blue Glazed Terracotta") { DataLimits = new BlockDataLimits(0, 3) };
            BrownGlazedTerracotta = new BlockInfo(247, "minecraft:brown_glazed_terracotta", "Brown Glazed Terracotta") { DataLimits = new BlockDataLimits(0, 3) };
            GreenGlazedTerracotta = new BlockInfo(248, "minecraft:green_glazed_terracotta", "Green Glazed Terracotta") { DataLimits = new BlockDataLimits(0, 3) };
            RedGlazedTerracotta = new BlockInfo(249, "minecraft:red_glazed_terracotta", "Red Glazed Terracotta") { DataLimits = new BlockDataLimits(0, 3) };

            BlackGlazedTerracotta = new BlockInfo(250, "minecraft:minecraft:black_glazed_terracotta", "Black Glazed Terracotta") { DataLimits = new BlockDataLimits(0, 3) };
            Concrete = new BlockInfo(251, "minecraft:concrete", "Concrete") { DataLimits = new BlockDataLimits(0, 15) };
            ConcretePowder = new BlockInfo(252, "minecraft:concrete_powder", "Concrete Powder") { DataLimits = new BlockDataLimits(0, 15) };
            // Unused253 = new BlockInfo(253, "minecraft:", "");
            // Unused254 = new BlockInfo(254, "minecraft:", "");
            StructureBlock = new BlockInfo(255, "minecraft:structure_block", "Structure Block") { DataLimits = new BlockDataLimits(0, 3) };

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
