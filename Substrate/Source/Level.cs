using System;
using System.IO;
using Substrate.Core;
using Substrate.Nbt;

namespace Substrate
{
    /// <summary>
    /// Encompases data to specify game rules.
    /// </summary>
    public class GameRules : ICopyable<GameRules>
    {
        private bool _commandBlockOutput = true;
        private bool _doFireTick = true;
        private bool _doMobLoot = true;
        private bool _doMobSpawning = true;
        private bool _doTileDrops = true;
        private bool _keepInventory = false;
        private bool _mobGriefing = true;
        private bool _doDaylightCycle = true;
        private bool _logAdminCommands = true;
        private bool _naturalRegeneration = true;
        private int _randomTickSpeed = 3;
        private bool _sendCommandFeedback = true;
        private bool _showDeathMessages = true;

        /// <summary>
        /// Gets or sets whether or not actions performed by command blocks are displayed in the chat.
        /// </summary>
        public bool CommandBlockOutput
        {
            get { return _commandBlockOutput; }
            set { _commandBlockOutput = value; }
        }

        /// <summary>
        /// Gets or sets whether to spread or remove fire.
        /// </summary>
        public bool DoFireTick
        {
            get { return _doFireTick; }
            set { _doFireTick = value; }
        }

        /// <summary>
        /// Gets or sets whether mobs should drop loot when killed.
        /// </summary>
        public bool DoMobLoot
        {
            get { return _doMobLoot; }
            set { _doMobLoot = value; }
        }

        /// <summary>
        /// Gets or sets whether mobs should spawn naturally.
        /// </summary>
        public bool DoMobSpawning
        {
            get { return _doMobSpawning; }
            set { _doMobSpawning = value; }
        }

        /// <summary>
        /// Gets or sets whether breaking blocks should drop the block's item drop.
        /// </summary>
        public bool DoTileDrops
        {
            get { return _doTileDrops; }
            set { _doTileDrops = value; }
        }

        /// <summary>
        /// Gets or sets whether players keep their inventory after they die.
        /// </summary>
        public bool KeepInventory
        {
            get { return _keepInventory; }
            set { _keepInventory = value; }
        }

        /// <summary>
        /// Gets or sets whether mobs can destroy blocks (creeper explosions, zombies breaking doors, etc.).
        /// </summary>
        public bool MobGriefing
        {
            get { return _mobGriefing; }
            set { _mobGriefing = value; }
        }

        /// <summary>
        /// Whether to do the Daylight Cycle or not. True by default.
        /// </summary>
        public bool DoDaylightCycle
        {
            get { return _doDaylightCycle; }
            set { _doDaylightCycle = value; }
        }

        /// <summary>
        /// Whether to log admin commands to server log. True by default.
        /// </summary>
        public bool LogAdminCommands
        {
            get { return _logAdminCommands; }
            set { _logAdminCommands = value; }
        }

        /// <summary>
        /// Whether the player naturally regenerates health if hunger is high enough. True by default.
        /// </summary>
        public bool NaturalRegeneration
        {
            get { return _naturalRegeneration; }
            set { _naturalRegeneration = value; }
        }

        /// <summary>
        /// How often a random tick occurs, such as plant growth, leaf decay, etc. 3 by default.
        /// </summary>
        public int RandomTickSpeed
        {
            get { return _randomTickSpeed; }
            set { _randomTickSpeed = value; }
        }

        /// <summary>
        /// Whether the feedback from commands executed by a player should show up in chat. True by default.
        /// </summary>
        public bool SendCommandFeedback
        {
            get { return _sendCommandFeedback; }
            set { _sendCommandFeedback = value; }
        }

        /// <summary>
        /// Whether a message appears in chat when a player dies. True by default.
        /// </summary>
        public bool ShowDeathMessages
        {
            get { return _showDeathMessages; }
            set { _showDeathMessages = value; }
        }

        #region ICopyable<GameRules> Members

        /// <inheritdoc />
        public GameRules Copy ()
        {
            GameRules gr = new GameRules();
            gr._commandBlockOutput = _commandBlockOutput;
            gr._doFireTick = _doFireTick;
            gr._doMobLoot = _doMobLoot;
            gr._doMobSpawning = _doMobSpawning;
            gr._doTileDrops = _doTileDrops;
            gr._keepInventory = _keepInventory;
            gr._mobGriefing = _mobGriefing;
            gr._doDaylightCycle = _doDaylightCycle;
            gr._logAdminCommands = _logAdminCommands;
            gr._naturalRegeneration = _naturalRegeneration;
            gr._randomTickSpeed = _randomTickSpeed;
            gr._sendCommandFeedback = _sendCommandFeedback;
            gr._showDeathMessages = _showDeathMessages;

            return gr;
        }

        #endregion
    }

    /// <summary>
    /// Specifies the type of gameplay associated with a world.
    /// </summary>
    public enum GameType
    {
        /// <summary>
        /// The world will be played in Survival mode.
        /// </summary>
        SURVIVAL = 0,

        /// <summary>
        /// The world will be played in Creative mode.
        /// </summary>
        CREATIVE = 1,

        /// <summary>
        /// The world will be played in Adventure mode.
        /// </summary>
        ADVENTURE = 2,

        /// <summary>
        /// The world will be played in Spectator mode.
        /// </summary>
        SPECTATOR = 3,
    }

    public enum Difficulty
    {
        Peaceful = 0,
        Easy = 1,
        Normal = 2,
        Hard = 3,
    }

    public enum TimeOfDay
    {
        Daytime = 0,
        Noon = 6000,
        Sunset = 12000,
        Nighttime = 13800,
        Midnight = 18000,
        Sunrise = 22200,
    }

    public class LevelData
    {
        [TagNode]
        public long Time { get; set; }

        [TagNode]
        public Player Player { get; set; }
    }

    /// <summary>
    /// Represents general data and metadata of a single world.
    /// </summary>
    public class Level : INbtObject<Level>, ICopyable<Level>
    {
        private static SchemaNodeCompound _schema = new SchemaNodeCompound()
        {
            new SchemaNodeCompound("Data")
            {
                new SchemaNodeScalar("Time", TagType.TAG_LONG),
                new SchemaNodeScalar("LastPlayed", TagType.TAG_LONG, SchemaOptions.CREATE_ON_MISSING),
                new SchemaNodeCompound("Player", Player.Schema, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("SpawnX", TagType.TAG_INT),
                new SchemaNodeScalar("SpawnY", TagType.TAG_INT),
                new SchemaNodeScalar("SpawnZ", TagType.TAG_INT),
                new SchemaNodeScalar("SizeOnDisk", TagType.TAG_LONG, SchemaOptions.CREATE_ON_MISSING),
                new SchemaNodeScalar("RandomSeed", TagType.TAG_LONG),
                new SchemaNodeScalar("version", TagType.TAG_INT, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("LevelName", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("generatorName", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("raining", TagType.TAG_BYTE, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("thundering", TagType.TAG_BYTE, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("rainTime", TagType.TAG_INT, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("thunderTime", TagType.TAG_INT, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("GameType", TagType.TAG_INT, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("MapFeatures", TagType.TAG_BYTE, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("hardcore", TagType.TAG_BYTE, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("generatorVersion", TagType.TAG_INT, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("generatorOptions", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("initialized", TagType.TAG_BYTE, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("allowCommands", TagType.TAG_BYTE, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("DayTime", TagType.TAG_LONG, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("Difficulty", TagType.TAG_BYTE, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("DifficultyLocked", TagType.TAG_BYTE, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("BorderCenterX", TagType.TAG_DOUBLE, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("BorderCenterZ", TagType.TAG_DOUBLE, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("BorderSize", TagType.TAG_DOUBLE, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("BorderSafeZone", TagType.TAG_DOUBLE, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("BorderWarningBlocks", TagType.TAG_DOUBLE, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("BorderWarningTime", TagType.TAG_DOUBLE, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("BorderSizeLerpTarget", TagType.TAG_DOUBLE, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("BorderSizeLerpTime", TagType.TAG_LONG, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("BorderDamagePerBlock", TagType.TAG_DOUBLE, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("clearWeatherTime", TagType.TAG_INT, SchemaOptions.OPTIONAL),
                new	SchemaNodeCompound("GameRules", SchemaOptions.OPTIONAL)
			    {
				    new	SchemaNodeScalar("commandBlockOutput", TagType.TAG_STRING),
				    new	SchemaNodeScalar("doFireTick", TagType.TAG_STRING),
				    new	SchemaNodeScalar("doMobLoot", TagType.TAG_STRING),
				    new	SchemaNodeScalar("doMobSpawning", TagType.TAG_STRING),
				    new	SchemaNodeScalar("doTileDrops", TagType.TAG_STRING),
				    new	SchemaNodeScalar("keepInventory", TagType.TAG_STRING),
				    new	SchemaNodeScalar("mobGriefing", TagType.TAG_STRING),
				    new	SchemaNodeScalar("doDaylightCycle", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
				    new	SchemaNodeScalar("logAdminCommands", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
				    new	SchemaNodeScalar("naturalRegeneration", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
				    new	SchemaNodeScalar("randomTickSpeed", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
				    new	SchemaNodeScalar("sendCommandFeedback", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
				    new	SchemaNodeScalar("showDeathMessages", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
			    },
            },
        };

        private TagNodeCompound _source;

        private NbtWorld _world;

        private long _time;
        private long _lastPlayed;

        private Player _player;

        private int _spawnX;
        private int _spawnY;
        private int _spawnZ;

        private long _sizeOnDisk;
        private long _randomSeed;
        private int? _version;
        private string _name;
        private string _generator;

        private byte? _raining;
        private byte? _thundering;
        private int? _rainTime;
        private int? _thunderTime;

        private int? _gameType;
        private byte? _mapFeatures;
        private byte? _hardcore;

        private int? _generatorVersion;
        private string _generatorOptions;
        private byte? _initialized;
        private byte? _allowCommands;
        private long? _DayTime;

        private byte? _difficulty;
        private byte? _difficultyLocked;
        private double? _borderCenterX;
        private double? _borderCenterZ;
        private double? _borderSize;
        private double? _borderSafeZone;
        private double? _borderWarningBlocks;
        private double? _borderWarningTime;
        private double? _borderSizeLerpTarget;
        private long? _borderSizeLerpTime;
        private double? _borderDamagePerBlock;
        private int? _clearWeatherTime;


        private GameRules _gameRules;

        [TagNode]
        public LevelData Data { get; set; }

        /// <summary>
        /// Gets or sets the creation time of the world as a long timestamp.
        /// </summary>
        public long Time
        {
            get { return _time; }
            set { _time = value; }
        }

        /// <summary>
        /// Gets or sets the time that the world was last played as a long timestamp.
        /// </summary>
        public long LastPlayed
        {
            get { return _lastPlayed; }
            set { _lastPlayed = value; }
        }

        /// <summary>
        /// Gets or sets the player for single-player worlds.
        /// </summary>
        public Player Player
        {
            get { return _player; }
            set
            {
                _player = value;
                _player.World = _name;
            }
        }

        /// <summary>
        /// Gets or sets the world's spawn point.
        /// </summary>
        public SpawnPoint Spawn
        {
            get { return new SpawnPoint(_spawnX, _spawnY, _spawnZ); }
            set
            {
                _spawnX = value.X;
                _spawnY = value.Y;
                _spawnZ = value.Z;
            }
        }

        /// <summary>
        /// Gets the estimated size of the world in bytes.
        /// </summary>
        public long SizeOnDisk
        {
            get { return _sizeOnDisk; }
        }

        /// <summary>
        /// Gets or sets the world's random seed.
        /// </summary>
        public long RandomSeed
        {
            get { return _randomSeed; }
            set { _randomSeed = value; }
        }

        /// <summary>
        /// Gets or sets the world's version number.
        /// </summary>
        public int Version
        {
            get { return _version ?? 0; }
            set { _version = value; }
        }

        /// <summary>
        /// Gets or sets the name of the world.
        /// </summary>
        /// <remarks>If there is a <see cref="Player"/> object attached to this world, the player's world field 
        /// will also be updated.</remarks>
        public string LevelName
        {
            get { return _name; }
            set
            {
                _name = value;
                if (_player != null) {
                    _player.World = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the name of the world generator.
        /// </summary>
        /// <remarks>This should be 'default', 'flat', or 'largeBiomes'.</remarks>
        public string GeneratorName
        {
            get { return _generator; }
            set { _generator = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating that it is raining in the world.
        /// </summary>
        public bool IsRaining
        {
            get { return (_raining ?? 0) == 1; }
            set { _raining = value ? (byte)1 : (byte)0; }
        }

        /// <summary>
        /// Gets or sets a value indicating that it is thunderstorming in the world.
        /// </summary>
        public bool IsThundering
        {
            get { return (_thundering ?? 0) == 1; }
            set { _thundering = value ? (byte)1 : (byte)0; }
        }

        /// <summary>
        /// Gets or sets the timer value for controlling rain.
        /// </summary>
        public int RainTime
        {
            get { return _rainTime ?? 0; }
            set { _rainTime = value; }
        }

        /// <summary>
        /// Gets or sets the timer value for controlling thunderstorms.
        /// </summary>
        public int ThunderTime
        {
            get { return _thunderTime ?? 0; }
            set { _thunderTime = value; }
        }

        /// <summary>
        /// Gets or sets the game type associated with this world.
        /// </summary>
        public GameType GameType
        {
            get { return (GameType)(_gameType ?? 0); }
            set { _gameType = (int)value; }
        }

        /// <summary>
        /// Gets or sets a value indicating that structures (dungeons, villages, ...) will be generated.
        /// </summary>
        public bool UseMapFeatures
        {
            get { return (_mapFeatures ?? 0) == 1; }
            set { _mapFeatures = value ? (byte)1 : (byte)0; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the map is hardcore mode
        /// </summary>
        public bool Hardcore
        {
            get { return (_hardcore ?? 0) == 1; }
            set { _hardcore = value ? (byte)1 : (byte)0; }
        }

        /// <summary>
        /// Gets or sets a value indicating the version of the level generator
        /// </summary>
        public int GeneratorVersion
        {
            get { return _generatorVersion ?? 0; }
            set { _generatorVersion = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating controls options for the generator, 
        /// currently only the Superflat generator. The format is a comma separated 
        /// list of block IDs from the bottom of the map up, and each block ID may 
        /// optionally be preceded by the number of layers and an x. 
        /// Damage values are not supported.
        /// </summary>
        public string GeneratorOptions
        {
            get { return _generatorOptions ?? ""; }
            set { _generatorOptions = value; }
        }

        /// <summary>
        /// Gets or sets a value, normally true, indicating whether a world has been 
        /// initialized properly after creation. If the initial simulation was canceled 
        /// somehow, this can be false and the world will be re-initialized on next load.
        /// </summary>
        public bool Initialized
        {
            get { return (_initialized ?? 0) == 1; }
            set { _initialized = value ? (byte)1 : (byte)0; }
        }

        /// <summary>
        /// Gets or sets a value indicating if cheats are enabled.
        /// </summary>
        public bool AllowCommands
        {
            get { return (_allowCommands ?? 0) == 1; }
            set { _allowCommands = value ? (byte)1 : (byte)0; }
        }

        /// <summary>
        /// Gets or sets a value indicating the time of day. 
        /// 0 is sunrise, 6000 is midday, 12000 is sunset, 
        /// 18000 is midnight, 24000 is the next day's 0. 
        /// This value keeps counting past 24000 and does not reset to 0
        /// </summary>
        public long DayTime
        {
            get { return _DayTime ?? 0; }
            set { _DayTime = value; }
        }

        public Difficulty Difficulty
        {
            get { return (Difficulty)(_difficulty ?? (int)Difficulty.Normal); }
            set { _difficulty = (byte)value; }
        }

        public byte DifficultyLocked
        {
            get { return _difficultyLocked ?? 0; }
            set { _difficultyLocked = value; }
        }

        public double BorderCenterX
        {
            get { return _borderCenterX ?? 0; }
            set { _borderCenterX = value; }
        }

        public double BorderCenterZ
        {
            get { return _borderCenterZ ?? 0; }
            set { _borderCenterZ = value; }
        }

        public double BorderSize
        {
            get { return _borderSize ?? 60000000; }
            set { _borderSize = value; }
        }

        public double BorderSafeZone
        {
            get { return _borderSafeZone ?? 5; }
            set { _borderSafeZone = value; }
        }

        public double BorderWarningBlocks
        {
            get { return _borderWarningBlocks ?? 5; }
            set { _borderWarningBlocks = value; }
        }

        public double BorderWarningTime
        {
            get { return _borderWarningTime ?? 15; }
            set { _borderWarningTime = value; }
        }

        public double BorderSizeLerpTarget
        {
            get { return _borderSizeLerpTarget ?? 60000000; }
            set { _borderSizeLerpTarget = value; }
        }

        public long BorderSizeLerpTime
        {
            get { return _borderSizeLerpTime ?? 0; }
            set { _borderSizeLerpTime = value; }
        }

        public double BorderDamagePerBlock
        {
            get { return _borderDamagePerBlock ?? 5; }
            set { _borderDamagePerBlock = value; }
        }

        public int ClearWeatherTime
        {
            get { return _clearWeatherTime ?? 0; }
            set { _clearWeatherTime = value; }
        }

        /// <summary>
        /// Gets the level's game rules.
        /// </summary>
        public GameRules GameRules
        {
            get { return _gameRules; }
        }

        /// <summary>
        /// Gets the source <see cref="TagNodeCompound"/> used to create this <see cref="Level"/> if it exists.
        /// </summary>
        public TagNodeCompound Source
        {
            get { return _source; }
        }

        /// <summary>
        /// Gets a <see cref="SchemaNode"/> representing the schema of a level.
        /// </summary>
        public static SchemaNodeCompound Schema
        {
            get { return _schema; }
        }

        /// <summary>
        /// Creates a new <see cref="Level"/> object with reasonable defaults tied to the given world.
        /// </summary>
        /// <param name="world">The world that the <see cref="Level"/> should be tied to.</param>
        public Level (NbtWorld world)
        {
            _world = world;

            // Sane defaults
            _time = 0;
            _lastPlayed = 0;
            _spawnX = 0;
            _spawnY = 64;
            _spawnZ = 0;
            _sizeOnDisk = 0;
            _randomSeed = new Random().Next();
            //_version = 19132;
            _version = 19133;
            _name = "Untitled";
            _generator = "default";
            _hardcore = 0;

            _generatorOptions = "";
            _generatorVersion = 1;
            _initialized = 0;
            _allowCommands = 0;
            _DayTime = 0;
            _gameRules = new GameRules();

            GameType = GameType.SURVIVAL;
            UseMapFeatures = true;

            _source = new TagNodeCompound();
        }

        /// <summary>
        /// Creates a copy of an existing <see cref="Level"/> object.
        /// </summary>
        /// <param name="p">The <see cref="Level"/> object to copy.</param>
        protected Level (Level p)
        {
            _world = p._world;

            _time = p._time;
            _lastPlayed = p._lastPlayed;
            _spawnX = p._spawnX;
            _spawnY = p._spawnY;
            _spawnZ = p._spawnZ;
            _sizeOnDisk = p._sizeOnDisk;
            _randomSeed = p._randomSeed;
            _version = p._version;
            _name = p._name;
            _generator = p._generator;

            _raining = p._raining;
            _thundering = p._thundering;
            _rainTime = p._rainTime;
            _thunderTime = p._thunderTime;

            _gameType = p._gameType;
            _mapFeatures = p._mapFeatures;
            _hardcore = p._hardcore;

            _generatorVersion = p._generatorVersion;
            _generatorOptions = p._generatorOptions;
            _initialized = p._initialized;
            _allowCommands = p._allowCommands;
            _DayTime = p._DayTime;
            _gameRules = p._gameRules.Copy();


            _difficulty = p._difficulty;
            _difficultyLocked = p._difficultyLocked;
            _borderCenterX = p._borderCenterX;
            _borderCenterZ = p._borderCenterZ;
            _borderSize = p._borderSize;
            _borderSafeZone = p._borderSafeZone;
            _borderWarningBlocks = p._borderWarningBlocks;
            _borderWarningTime = p._borderWarningTime;
            _borderSizeLerpTarget = p._borderSizeLerpTarget;
            _borderSizeLerpTime = p._borderSizeLerpTime;
            _borderDamagePerBlock = p._borderDamagePerBlock;
            _clearWeatherTime = p._clearWeatherTime;

            if (p._player != null) {
                _player = p._player.Copy();
            }

            if (p._source != null) {
                _source = p._source.Copy() as TagNodeCompound;
            }
        }

        /// <summary>
        /// Creates a default player entry for this world.
        /// </summary>
        public void SetDefaultPlayer ()
        {
            _player = new Player();
            _player.World = _name;

            _player.Position.X = _spawnX;
            _player.Position.Y = _spawnY + 1.7;
            _player.Position.Z = _spawnZ;
        }

        /// <summary>
        /// Saves a <see cref="Level"/> object to disk as a standard compressed NBT stream.
        /// </summary>
        /// <returns>True if the level was saved; false otherwise.</returns>
        /// <exception cref="LevelIOException">Thrown when an error is encountered writing out the level.</exception>
        public bool Save ()
        {
            if (_world == null) {
                return false;
            }

            try {
                NBTFile nf = new NBTFile(Path.Combine(_world.Path, "level.dat"));
                using (Stream zipstr = nf.GetDataOutputStream())
                {
                    if (zipstr == null)
                    {
                        NbtIOException nex = new NbtIOException("Failed to initialize compressed NBT stream for output");
                        nex.Data["Level"] = this;
                        throw nex;
                    }

                    new NbtTree(BuildTree() as TagNodeCompound).WriteTo(zipstr);
                }

                return true;
            }
            catch (Exception ex) {
                LevelIOException lex = new LevelIOException("Could not save level file.", ex);
                lex.Data["Level"] = this;
                throw lex;
            }
        }


        #region INBTObject<Player> Members

        /// <summary>
        /// Attempt to load a Level subtree into the <see cref="Level"/> without validation.
        /// </summary>
        /// <param name="tree">The root node of a Level subtree.</param>
        /// <returns>The <see cref="Level"/> returns itself on success, or null if the tree was unparsable.</returns>
        public virtual Level LoadTree (TagNode tree)
        {
            TagNodeCompound dtree = tree as TagNodeCompound;
            if (dtree == null) {
                return null;
            }

            _version = null;
            _raining = null;
            _rainTime = null;
            _thundering = null;
            _thunderTime = null;
            _gameType = null;
            _mapFeatures = null;
            _generatorOptions = null;
            _generatorVersion = null;
            _allowCommands = null;
            _initialized = null;
            _DayTime = null;

            TagNodeCompound ctree = dtree["Data"].ToTagCompound();

            _time = ctree["Time"].ToTagLong();
            _lastPlayed = ctree["LastPlayed"].ToTagLong();

            if (ctree.ContainsKey("Player")) {
                _player = new Player().LoadTree(ctree["Player"]);
            }

            _spawnX = ctree["SpawnX"].ToTagInt();
            _spawnY = ctree["SpawnY"].ToTagInt();
            _spawnZ = ctree["SpawnZ"].ToTagInt();

            _sizeOnDisk = ctree["SizeOnDisk"].ToTagLong();
            _randomSeed = ctree["RandomSeed"].ToTagLong();

            if (ctree.ContainsKey("version")) {
                _version = ctree["version"].ToTagInt();
            }
            if (ctree.ContainsKey("LevelName")) {
                _name = ctree["LevelName"].ToTagString();
            }

            if (ctree.ContainsKey("generatorName")) {
                _generator = ctree["generatorName"].ToTagString();
            }

            if (ctree.ContainsKey("raining")) {
                _raining = ctree["raining"].ToTagByte();
            }
            if (ctree.ContainsKey("thundering")) {
                _thundering = ctree["thundering"].ToTagByte();
            }
            if (ctree.ContainsKey("rainTime")) {
                _rainTime = ctree["rainTime"].ToTagInt();
            }
            if (ctree.ContainsKey("thunderTime")) {
                _thunderTime = ctree["thunderTime"].ToTagInt();
            }

            if (ctree.ContainsKey("GameType")) {
                _gameType = ctree["GameType"].ToTagInt();
            }
            if (ctree.ContainsKey("MapFeatures")) {
                _mapFeatures = ctree["MapFeatures"].ToTagByte();
            }
            if (ctree.ContainsKey("hardcore")) {
                _hardcore = ctree["hardcore"].ToTagByte();
            }

            if (ctree.ContainsKey("generatorVersion")) {
                _generatorVersion = ctree["generatorVersion"].ToTagInt();
            }
            if (ctree.ContainsKey("generatorOptions")) {
                _generatorOptions = ctree["generatorOptions"].ToTagString();
            }
            if (ctree.ContainsKey("allowCommands")) {
                _allowCommands = ctree["allowCommands"].ToTagByte();
            }
            if (ctree.ContainsKey("initialized")) {
                _initialized = ctree["initialized"].ToTagByte();
            }
            if (ctree.ContainsKey("DayTime")) {
                _DayTime = ctree["DayTime"].ToTagLong();
            }
            if (ctree.ContainsKey("Difficulty"))
            {
                _difficulty = ctree["Difficulty"].ToTagByte();
            }
            if (ctree.ContainsKey("DifficultyLocked"))
            {
                _difficultyLocked = ctree["DifficultyLocked"].ToTagByte();
            }
            if (ctree.ContainsKey("BorderCenterX"))
            {
                _borderCenterX = ctree["BorderCenterX"].ToTagDouble();
            }
            if (ctree.ContainsKey("BorderCenterZ"))
            {
                _borderCenterZ = ctree["BorderCenterZ"].ToTagDouble();
            }
            if (ctree.ContainsKey("BorderSize"))
            {
                _borderSize = ctree["BorderSize"].ToTagDouble();
            }
            if (ctree.ContainsKey("BorderSafeZone"))
            {
                _borderSafeZone = ctree["BorderSafeZone"].ToTagDouble();
            }
            if (ctree.ContainsKey("BorderWarningBlocks"))
            {
                _borderWarningBlocks = ctree["BorderWarningBlocks"].ToTagDouble();
            }
            if (ctree.ContainsKey("BorderWarningTime"))
            {
                _borderWarningTime = ctree["BorderWarningTime"].ToTagDouble();
            }
            if (ctree.ContainsKey("BorderSizeLerpTarget"))
            {
                _borderSizeLerpTarget = ctree["BorderSizeLerpTarget"].ToTagDouble();
            }
            if (ctree.ContainsKey("BorderSizeLerpTime"))
            {
                _borderSizeLerpTime = ctree["BorderSizeLerpTime"].ToTagLong();
            }
            if (ctree.ContainsKey("BorderDamagePerBlock"))
            {
                _borderDamagePerBlock = ctree["BorderDamagePerBlock"].ToTagDouble();
            }
            if (ctree.ContainsKey("clearWeatherTime"))
            {
                _clearWeatherTime = ctree["clearWeatherTime"].ToTagInt();
            }

            if (ctree.ContainsKey("GameRules"))
            {
                TagNodeCompound gr = ctree["GameRules"].ToTagCompound();

                _gameRules = new GameRules();
                _gameRules.CommandBlockOutput = gr["commandBlockOutput"].ToTagString().Data == "true";
                _gameRules.DoFireTick = gr["doFireTick"].ToTagString().Data == "true";
                _gameRules.DoMobLoot = gr["doMobLoot"].ToTagString().Data == "true";
                _gameRules.DoMobSpawning = gr["doMobSpawning"].ToTagString().Data == "true";
                _gameRules.DoTileDrops = gr["doTileDrops"].ToTagString().Data == "true";
                _gameRules.KeepInventory = gr["keepInventory"].ToTagString().Data == "true";
                _gameRules.MobGriefing = gr["mobGriefing"].ToTagString().Data == "true";

                if (gr.ContainsKey("doDaylightCycle"))
                {
                    _gameRules.DoDaylightCycle = gr["doDaylightCycle"].ToTagString().Data == "true";
                }

                if (gr.ContainsKey("logAdminCommands"))
                {
                    _gameRules.LogAdminCommands = gr["logAdminCommands"].ToTagString().Data == "true";
                }

                if (gr.ContainsKey("naturalRegeneration"))
                {
                    _gameRules.NaturalRegeneration = gr["naturalRegeneration"].ToTagString().Data == "true";
                }

                if (gr.ContainsKey("randomTickSpeed"))
                {
                    int temp = 3;
                    int.TryParse(gr["randomTickSpeed"].ToTagString().Data, out temp);
                    _gameRules.RandomTickSpeed = temp;
                }

                if (gr.ContainsKey("sendCommandFeedback"))
                {
                    _gameRules.SendCommandFeedback = gr["sendCommandFeedback"].ToTagString().Data == "true";
                }

                if (gr.ContainsKey("showDeathMessages"))
                {
                    _gameRules.ShowDeathMessages = gr["showDeathMessages"].ToTagString().Data == "true";
                }
            }

            _source = ctree.Copy() as TagNodeCompound;

            return this;
        }

        /// <summary>
        /// Attempt to load a Level subtree into the <see cref="Level"/> with validation.
        /// </summary>
        /// <param name="tree">The root node of a Level subtree.</param>
        /// <returns>The <see cref="Level"/> returns itself on success, or null if the tree failed validation.</returns>
        public virtual Level LoadTreeSafe (TagNode tree)
        {
            if (!ValidateTree(tree)) {
                return null;
            }

            return LoadTree(tree);
        }

        /// <summary>
        /// Builds a Level subtree from the current data.
        /// </summary>
        /// <returns>The root node of a Level subtree representing the current data.</returns>
        public virtual TagNode BuildTree ()
        {
            TagNodeCompound data = new TagNodeCompound();
            data["Time"] = new TagNodeLong(_time);
            data["LastPlayed"] = new TagNodeLong(_lastPlayed);

            if (_player != null) {
                data["Player"] = _player.BuildTree();
            }

            data["SpawnX"] = new TagNodeInt(_spawnX);
            data["SpawnY"] = new TagNodeInt(_spawnY);
            data["SpawnZ"] = new TagNodeInt(_spawnZ);
            data["SizeOnDisk"] = new TagNodeLong(_sizeOnDisk);
            data["RandomSeed"] = new TagNodeLong(_randomSeed);

            if (_version != null && _version != 0) {
                data["version"] = new TagNodeInt(_version ?? 0);
            }

            if (_name != null) {
                data["LevelName"] = new TagNodeString(_name);
            }

            if (_generator != null) {
                data["generatorName"] = new TagNodeString(_generator);
            }

            if (_raining != null) {
                data["raining"] = new TagNodeByte(_raining ?? 0);
            }
            if (_thundering != null) {
                data["thundering"] = new TagNodeByte(_thundering ?? 0);
            }
            if (_rainTime != null) {
                data["rainTime"] = new TagNodeInt(_rainTime ?? 0);
            }
            if (_thunderTime != null) {
                data["thunderTime"] = new TagNodeInt(_thunderTime ?? 0);
            }

            if (_gameType != null) {
                data["GameType"] = new TagNodeInt(_gameType ?? 0);
            }
            if (_mapFeatures != null) {
                data["MapFeatures"] = new TagNodeByte(_mapFeatures ?? 0);
            }
            if (_hardcore != null) {
                data["hardcore"] = new TagNodeByte(_hardcore ?? 0);
            }

            if (_generatorOptions != null) {
                data["generatorOptions"] = new TagNodeString(_generatorOptions);
            }
            if (_generatorVersion != null) {
                data["generatorVersion"] = new TagNodeInt(_generatorVersion ?? 0);
            }
            if (_allowCommands != null) {
                data["allowCommands"] = new TagNodeByte(_allowCommands ?? 0);
            }
            if (_initialized != null) {
                data["initialized"] = new TagNodeByte(_initialized ?? 0);
            }
            if (_DayTime != null) {
                data["DayTime"] = new TagNodeLong(_DayTime ?? 0);
            }


            if (_difficulty != null)
            {
                data["Difficulty"] = new TagNodeByte(_difficulty ?? 2);
            }
            if (_difficultyLocked != null)
            {
                data["DifficultyLocked"] = new TagNodeByte(_difficultyLocked ?? 0);
            }
            if (_borderCenterX != null)
            {
                data["BorderCenterX"] = new TagNodeDouble(_borderCenterX ?? 0);
            }
            if (_borderCenterZ != null)
            {
                data["BorderCenterZ"] = new TagNodeDouble(_borderCenterZ ?? 0);
            }
            if (_borderSize != null)
            {
                data["BorderSize"] = new TagNodeDouble(_borderSize ?? 60000000);
            }
            if (_borderSafeZone != null)
            {
                data["BorderSafeZone"] = new TagNodeDouble(_borderSafeZone ?? 5);
            }
            if (_borderWarningBlocks != null)
            {
                data["BorderWarningBlocks"] = new TagNodeDouble(_borderWarningBlocks ?? 5);
            }
            if (_borderWarningTime != null)
            {
                data["BorderWarningTime"] = new TagNodeDouble(_borderWarningTime ?? 15);
            }
            if (_borderSizeLerpTarget != null)
            {
                data["BorderSizeLerpTarget"] = new TagNodeDouble(_borderSizeLerpTarget ?? 60000000);
            }
            if (_borderSizeLerpTime != null)
            {
                data["BorderSizeLerpTime"] = new TagNodeLong(_borderSizeLerpTime ?? 0);
            }
            if (_borderDamagePerBlock != null)
            {
                data["BorderDamagePerBlock"] = new TagNodeDouble(_borderDamagePerBlock ?? 0.2);
            }
            if (_clearWeatherTime != null)
            {
                data["clearWeatherTime"] = new TagNodeInt(_clearWeatherTime ?? 0);
            }
            

            TagNodeCompound gr = new TagNodeCompound();
            gr["commandBlockOutput"] = new TagNodeString(_gameRules.CommandBlockOutput ? "true" : "false");
            gr["doFireTick"] = new TagNodeString(_gameRules.DoFireTick ? "true" : "false");
            gr["doMobLoot"] = new TagNodeString(_gameRules.DoMobLoot ? "true" : "false");
            gr["doMobSpawning"] = new TagNodeString(_gameRules.DoMobSpawning ? "true" : "false");
            gr["doTileDrops"] = new TagNodeString(_gameRules.DoTileDrops ? "true" : "false");
            gr["keepInventory"] = new TagNodeString(_gameRules.KeepInventory ? "true" : "false");
            gr["mobGriefing"] = new TagNodeString(_gameRules.MobGriefing ? "true" : "false");
            gr["doDaylightCycle"] = new TagNodeString(_gameRules.DoDaylightCycle ? "true" : "false");
            gr["logAdminCommands"] = new TagNodeString(_gameRules.LogAdminCommands ? "true" : "false");
            gr["naturalRegeneration"] = new TagNodeString(_gameRules.NaturalRegeneration ? "true" : "false");
            gr["randomTickSpeed"] = new TagNodeString(_gameRules.RandomTickSpeed.ToString());
            gr["sendCommandFeedback"] = new TagNodeString(_gameRules.SendCommandFeedback ? "true" : "false");
            gr["showDeathMessages"] = new TagNodeString(_gameRules.ShowDeathMessages ? "true" : "false");
            data["GameRules"] = gr;

            if (_source != null) {
                data.MergeFrom(_source);
            }

            TagNodeCompound tree = new TagNodeCompound();
            tree.Add("Data", data);

            return tree;
        }

        /// <summary>
        /// Validate a Level subtree against a schema defintion.
        /// </summary>
        /// <param name="tree">The root node of a Level subtree.</param>
        /// <returns>Status indicating whether the tree was valid against the internal schema.</returns>
        public virtual bool ValidateTree (TagNode tree)
        {
            return new NbtVerifier(tree, _schema).Verify();
        }

        #endregion


        #region ICopyable<Entity> Members

        /// <summary>
        /// Creates a deep-copy of the <see cref="Level"/>.
        /// </summary>
        /// <returns>A deep-copy of the <see cref="Level"/>, including a copy of the <see cref="Player"/>, if one is attached.</returns>
        public virtual Level Copy ()
        {
            return new Level(this);
        }

        #endregion
    }
}
