using System;
using System.Collections.Generic;
using System.Text;
using Substrate.Core;
using Substrate.Nbt;

namespace Substrate
{
    /// <summary>
    /// Encompases data to specify player abilities, especially mode-dependent abilities.
    /// </summary>
    /// <remarks>Whether or not any of these values are respected by the game client is dependent upon the active game mode.</remarks>
    public class PlayerAbilities : ICopyable<PlayerAbilities>
    {
        /// <summary>
        /// Gets or sets whether the player is currently flying.
        /// </summary>
        [TagNode("flying")]
        public bool Flying { get; set; }

        /// <summary>
        /// Gets or sets whether the player can instantly build or mine.
        /// </summary>
        [TagNode("instabuild")]
        public bool InstantBuild { get; set; }

        /// <summary>
        /// Gets or sets whether the player is allowed to fly.
        /// </summary>
        [TagNode("mayfly")]
        public bool MayFly { get; set; }

        /// <summary>
        /// Gets or sets whether the player can take damage.
        /// </summary>
        [TagNode("invulnerable")]
        public bool Invulnerable { get; set; }

        /// <summary>
        /// Gets or sets whether the player can create or destroy blocks.
        /// </summary>
        [TagNode("mayBuild")]
        public bool? MayBuild { get; set; }

        /// <summary>
        /// Gets or sets the player's flying speed.  Always 0.05.
        /// </summary>
        [TagNode("walkSpeed")]
        public float? WalkSpeed { get; set; } = 0.05f;

        /// <summary>
        /// Gets or sets the player's walking speed.  Always 0.1.
        /// </summary>
        [TagNode("flySpeed")]
        public float? FlySpeed { get; set; } = 0.1f;

        #region ICopyable<PlayerAbilities> Members

        /// <inheritdoc />
        public PlayerAbilities Copy()
        {
            PlayerAbilities pa = new PlayerAbilities
            {
                Flying = Flying,
                InstantBuild = InstantBuild,
                MayFly = MayFly,
                Invulnerable = Invulnerable,
                MayBuild = MayBuild,
                WalkSpeed = WalkSpeed,
                FlySpeed = FlySpeed,
            };
            return pa;
        }

        #endregion
    }

    public enum PlayerGameType
    {
        Survival = 0,
        Creative = 1,
        Adventure = 2,
    }

    /// <summary>
    /// Represents a Player from either single- or multi-player Minecraft.
    /// </summary>
    /// <remarks>Unlike <see cref="TypedEntity"/> objects, <see cref="Player"/> objects do not need to be added to chunks.  They
    /// are stored individually or within level data.</remarks>
    public class Player : Entity, INbtObject<Player>, ICopyable<Player>, IItemContainer
    {
        private static readonly SchemaNodeCompound _schema = Entity.Schema.MergeInto(new SchemaNodeCompound("")
        {
            new SchemaNodeScalar("AttackTime", TagType.TAG_SHORT, SchemaOptions.CREATE_ON_MISSING),
            new SchemaNodeScalar("DeathTime", TagType.TAG_SHORT),
            new SchemaNodeScalar("Health", TagType.TAG_FLOAT),
            new SchemaNodeScalar("HurtTime", TagType.TAG_SHORT),
            new SchemaNodeScalar("Dimension", TagType.TAG_INT),
            new SchemaNodeList("Inventory", TagType.TAG_COMPOUND, ItemCollection.ItemSchema),
            //new SchemaNodeList("EnderItems", TagType.TAG_COMPOUND, ItemCollection.Schema, SchemaOptions.OPTIONAL),
            new SchemaNodeScalar("World", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
            new SchemaNodeScalar("Sleeping", TagType.TAG_BYTE, SchemaOptions.CREATE_ON_MISSING),
            new SchemaNodeScalar("SleepTimer", TagType.TAG_SHORT, SchemaOptions.CREATE_ON_MISSING),
            new SchemaNodeScalar("SpawnX", TagType.TAG_INT, SchemaOptions.OPTIONAL),
            new SchemaNodeScalar("SpawnY", TagType.TAG_INT, SchemaOptions.OPTIONAL),
            new SchemaNodeScalar("SpawnZ", TagType.TAG_INT, SchemaOptions.OPTIONAL),
            new SchemaNodeScalar("foodLevel", TagType.TAG_INT, SchemaOptions.OPTIONAL),
            new SchemaNodeScalar("foodTickTimer", TagType.TAG_INT, SchemaOptions.OPTIONAL),
            new SchemaNodeScalar("foodExhaustionLevel", TagType.TAG_FLOAT, SchemaOptions.OPTIONAL),
            new SchemaNodeScalar("foodSaturationLevel", TagType.TAG_FLOAT, SchemaOptions.OPTIONAL),
            new SchemaNodeScalar("XpP", TagType.TAG_FLOAT, SchemaOptions.OPTIONAL),
            new SchemaNodeScalar("XpLevel", TagType.TAG_INT, SchemaOptions.OPTIONAL),
            new SchemaNodeScalar("XpTotal", TagType.TAG_INT, SchemaOptions.OPTIONAL),
            new SchemaNodeScalar("Score", TagType.TAG_INT, SchemaOptions.OPTIONAL),
            new SchemaNodeScalar("playerGameType", TagType.TAG_INT, SchemaOptions.OPTIONAL),
            new SchemaNodeCompound("abilities", new SchemaNodeCompound("") {
                new SchemaNodeScalar("flying", TagType.TAG_BYTE),
                new SchemaNodeScalar("instabuild", TagType.TAG_BYTE),
                new SchemaNodeScalar("mayfly", TagType.TAG_BYTE),
                new SchemaNodeScalar("invulnerable", TagType.TAG_BYTE),
                new SchemaNodeScalar("mayBuild", TagType.TAG_BYTE, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("walkSpeed", TagType.TAG_FLOAT, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("flySpeed", TagType.TAG_FLOAT, SchemaOptions.OPTIONAL),
            }, SchemaOptions.OPTIONAL),
        });

        private const int _CAPACITY = 105;
        private const int _ENDER_CAPACITY = 27;

        private ItemCollection _inventory;
        private ItemCollection _enderItems;

        /// <summary>
        /// Gets or sets the number of ticks left in the player's "invincibility shield" after last struck.
        /// </summary>
        [TagNode(CreateOnMissing = true)]
        public short AttackTime { get; set; }

        /// <summary>
        /// Gets or sets the number of ticks that the player has been dead for.
        /// </summary>
        [TagNode]
        public short DeathTime { get; set; }

        /// <summary>
        /// Gets or sets the amount of the player's health.
        /// </summary>
        [TagNode]
        public float Health { get; set; }

        /// <summary>
        /// Gets or sets the player's Hurt Time value.
        /// </summary>
        [TagNode]
        public short HurtTime { get; set; }

        /// <summary>
        /// Gets or sets the dimension that the player is currently in.
        /// </summary>
        [TagNode]
        public int Dimension { get; set; }

        [TagNode]
        public ItemCollection Inventory { get; } = new ItemCollection(_CAPACITY);

        /// <summary>
        /// Gets or sets the name of the world that the player is currently within.
        /// </summary>
        [TagNode(Optional = true)]
        public string World { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the player is sleeping in a bed.
        /// </summary>
        [TagNode(Name = "Sleeping", CreateOnMissing = true)]
        public bool IsSleeping { get; set; }

        /// <summary>
        /// Gets or sets the player's Sleep Timer value.
        /// </summary>
        [TagNode(CreateOnMissing = true)]
        public short SleepTimer { get; set; }


        [TagNode(Optional = true)]
        public int? SpawnX { get; set; }

        [TagNode(Optional = true)]
        public int? SpawnY { get; set; }

        [TagNode(Optional = true)]
        public int? SpawnZ { get; set; }

        /// <summary>
        /// Gets or sets the player's personal spawn point, set by sleeping in beds.
        /// </summary>
        public SpawnPoint Spawn
        {
            get { return new SpawnPoint(SpawnX ?? 0, SpawnY ?? 0, SpawnZ ?? 0); }
            set
            {
                SpawnX = value.X;
                SpawnY = value.Y;
                SpawnZ = value.Z;
            }
        }

        /// <summary>
        /// Tests if the player currently has a personal spawn point.
        /// </summary>
        public bool HasSpawn
        {
            get { return SpawnX != null && SpawnY != null && SpawnZ != null; }
        }

        /// <summary>
        /// Gets or sets the hunger level of the player.  Valid values range 0 - 20.
        /// </summary>
        [TagNode(Name = "foodLevel", Optional = true)]
        public int? HungerLevel { get; set; }

        /// <summary>
        /// Gets or sets the timer used to periodically heal or damage the player based on <see cref="HungerLevel"/>.  Valid values range 0 - 80.
        /// </summary>
        [TagNode(Name = "foodTickTimer", Optional = true)]
        public int? HungerTimer { get; set; }

        /// <summary>
        /// Gets or sets the counter towards the next hunger point decrement.  Valid values range 0.0 - 4.0.
        /// </summary>
        [TagNode(Name = "foodExhaustionLevel", Optional = true)]
        public float? HungerExhaustionLevel { get; set; }

        /// <summary>
        /// Gets or sets the player's hunger saturation level, which is reserve food capacity above <see cref="HungerLevel"/>.
        /// </summary>
        [TagNode(Name = "foodSaturationLevel", Optional = true)]
        public float? HungerSaturationLevel { get; set; }

        /// <summary>
        /// Gets or sets the name that is used when the player is read or written from a <see cref="PlayerManager"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the player's XP Level.
        /// </summary>
        [TagNode(Name = "XpP", Optional = true)]
        public float? XpP { get; set; }

        /// <summary>
        /// Gets or sets the player's XP Level.
        /// </summary>
        [TagNode(Optional = true)]
        public int? XpLevel { get; set; }

        /// <summary>
        /// Gets or sets the amount of the player's XP points.
        /// </summary>
        [TagNode(Optional = true)]
        public int? XpTotal { get; set; }

        /// <summary>
        /// Gets or sets the player's score.
        /// </summary>
        [TagNode(Optional = true)]
        public int? Score { get; set; }

        [TagNode(Name = "playerGameType", Optional = true)]
        public PlayerGameType? GameType { get; set; }

        /// <summary>
        /// Gets the state of the player's abilities.
        /// </summary>
        [TagNode("abilities", Optional = true)]
        public PlayerAbilities Abilities { get; private set; } = new PlayerAbilities();

        /// <summary>
        /// Creates a new <see cref="Player"/> object with reasonable default values.
        /// </summary>
        public Player()
            : base()
        {
            _inventory = new ItemCollection(_CAPACITY);
            _enderItems = new ItemCollection(_ENDER_CAPACITY);

            Air = 300;
            Health = 20.0f;
            Fire = -20;
        }

        /// <summary>
        /// Creates a copy of a <see cref="Player"/> object.
        /// </summary>
        /// <param name="p">The <see cref="Player"/> to copy fields from.</param>
        protected Player(Player p)
            : base(p)
        {
            AttackTime = p.AttackTime;
            DeathTime = p.DeathTime;
            Health = p.Health;
            HurtTime = p.HurtTime;

            Dimension = p.Dimension;
            GameType = p.GameType;
            IsSleeping = p.IsSleeping;
            SleepTimer = p.SleepTimer;
            SpawnX = p.SpawnX;
            SpawnY = p.SpawnY;
            SpawnZ = p.SpawnZ;
            World = p.World;
            _inventory = p._inventory.Copy();
            _enderItems = p._enderItems.Copy();

            HungerLevel = p.HungerLevel;
            HungerTimer = p.HungerTimer;
            HungerSaturationLevel = p.HungerSaturationLevel;
            HungerExhaustionLevel = p.HungerExhaustionLevel;
            XpP = p.XpP;
            XpLevel = p.XpLevel;
            XpTotal = p.XpTotal;
            Abilities = p.Abilities.Copy();
        }

        /// <summary>
        /// Clears the player's personal spawn point.
        /// </summary>
        public void ClearSpawn()
        {
            SpawnX = null;
            SpawnY = null;
            SpawnZ = null;
        }

        private bool AbilitiesSet()
        {
            return Abilities.Flying
                || Abilities.InstantBuild
                || Abilities.MayFly
                || Abilities.Invulnerable;
        }


        #region INBTObject<Player> Members

        /// <summary>
        /// Gets a <see cref="SchemaNode"/> representing the schema of a Player.
        /// </summary>
        public static new SchemaNodeCompound Schema
        {
            get { return _schema; }
        }

        /// <summary>
        /// Attempt to load a Player subtree into the <see cref="Player"/> without validation.
        /// </summary>
        /// <param name="tree">The root node of a Player subtree.</param>
        /// <returns>The <see cref="Player"/> returns itself on success, or null if the tree was unparsable.</returns>
        public virtual new Player LoadTree(TagNode tree)
        {
            TagNodeCompound ctree = tree as TagNodeCompound;
            if (ctree == null || base.LoadTree(tree) == null)
            {
                return null;
            }

            AttackTime = ctree["AttackTime"].ToTagShort();
            DeathTime = ctree["DeathTime"].ToTagShort();
            Health = ctree["Health"].ToTagFloat();
            HurtTime = ctree["HurtTime"].ToTagShort();

            Dimension = ctree["Dimension"].ToTagInt();
            IsSleeping = ctree["Sleeping"].ToTagByte();
            SleepTimer = ctree["SleepTimer"].ToTagShort();

            if (ctree.ContainsKey("SpawnX"))
            {
                SpawnX = ctree["SpawnX"].ToTagInt();
            }
            if (ctree.ContainsKey("SpawnY"))
            {
                SpawnY = ctree["SpawnY"].ToTagInt();
            }
            if (ctree.ContainsKey("SpawnZ"))
            {
                SpawnZ = ctree["SpawnZ"].ToTagInt();
            }

            if (ctree.ContainsKey("World"))
            {
                World = ctree["World"].ToTagString();
            }

            if (ctree.ContainsKey("foodLevel"))
            {
                HungerLevel = ctree["foodLevel"].ToTagInt();
            }
            if (ctree.ContainsKey("foodTickTimer"))
            {
                HungerTimer = ctree["foodTickTimer"].ToTagInt();
            }
            if (ctree.ContainsKey("foodExhaustionLevel"))
            {
                HungerExhaustionLevel = ctree["foodExhaustionLevel"].ToTagFloat();
            }
            if (ctree.ContainsKey("foodSaturationLevel"))
            {
                HungerSaturationLevel = ctree["foodSaturationLevel"].ToTagFloat();
            }
            if (ctree.ContainsKey("XpP"))
            {
                XpP = ctree["XpP"].ToTagFloat();
            }
            if (ctree.ContainsKey("XpLevel"))
            {
                XpLevel = ctree["XpLevel"].ToTagInt();
            }
            if (ctree.ContainsKey("XpTotal"))
            {
                XpTotal = ctree["XpTotal"].ToTagInt();
            }
            if (ctree.ContainsKey("Score"))
            {
                Score = ctree["Score"].ToTagInt();
            }

            if (ctree.ContainsKey("abilities"))
            {
                TagNodeCompound pb = ctree["abilities"].ToTagCompound();

                Abilities = new PlayerAbilities();
                Abilities.Flying = pb["flying"].ToTagByte().Data == 1;
                Abilities.InstantBuild = pb["instabuild"].ToTagByte().Data == 1;
                Abilities.MayFly = pb["mayfly"].ToTagByte().Data == 1;
                Abilities.Invulnerable = pb["invulnerable"].ToTagByte().Data == 1;

                if (pb.ContainsKey("mayBuild"))
                    Abilities.MayBuild = pb["mayBuild"].ToTagByte().Data == 1;
                if (pb.ContainsKey("walkSpeed"))
                    Abilities.WalkSpeed = pb["walkSpeed"].ToTagFloat();
                if (pb.ContainsKey("flySpeed"))
                    Abilities.FlySpeed = pb["flySpeed"].ToTagFloat();
            }

            if (ctree.ContainsKey("PlayerGameType"))
            {
                GameType = (PlayerGameType)ctree["PlayerGameType"].ToTagInt().Data;
            }

            _inventory.LoadTree(ctree["Inventory"].ToTagList());

            if (ctree.ContainsKey("EnderItems"))
            {
                if (ctree["EnderItems"].ToTagList().Count > 0)
                    _enderItems.LoadTree(ctree["EnderItems"].ToTagList());
            }

            return this;
        }

        /// <summary>
        /// Attempt to load a Player subtree into the <see cref="Player"/> with validation.
        /// </summary>
        /// <param name="tree">The root node of a Player subtree.</param>
        /// <returns>The <see cref="Player"/> returns itself on success, or null if the tree failed validation.</returns>
        public virtual new Player LoadTreeSafe(TagNode tree)
        {
            if (!ValidateTree(tree))
            {
                return null;
            }

            return LoadTree(tree);
        }

        /// <summary>
        /// Builds a Player subtree from the current data.
        /// </summary>
        /// <returns>The root node of a Player subtree representing the current data.</returns>
        public virtual new TagNode BuildTree()
        {
            TagNodeCompound tree = base.BuildTree() as TagNodeCompound;
            tree["AttackTime"] = new TagNodeShort(AttackTime);
            tree["DeathTime"] = new TagNodeShort(DeathTime);
            tree["Health"] = new TagNodeFloat(Health);
            tree["HurtTime"] = new TagNodeShort(HurtTime);

            tree["Dimension"] = new TagNodeInt(Dimension);
            tree["Sleeping"] = new TagNodeByte(IsSleeping);
            tree["SleepTimer"] = new TagNodeShort(SleepTimer);

            if (SpawnX != null && SpawnY != null && SpawnZ != null)
            {
                tree["SpawnX"] = new TagNodeInt(SpawnX.Value);
                tree["SpawnY"] = new TagNodeInt(SpawnY.Value);
                tree["SpawnZ"] = new TagNodeInt(SpawnZ.Value);
            }
            else
            {
                tree.Remove("SpawnX");
                tree.Remove("SpawnY");
                tree.Remove("SpawnZ");
            }

            if (World != null)
            {
                tree["World"] = new TagNodeString(World);
            }

            if (HungerLevel != null)
                tree["foodLevel"] = new TagNodeInt(HungerLevel.Value);
            if (HungerTimer != null)
                tree["foodTickTimer"] = new TagNodeInt(HungerTimer.Value);
            if (HungerExhaustionLevel != null)
                tree["foodExhaustionLevel"] = new TagNodeFloat(HungerExhaustionLevel.Value);
            if (HungerSaturationLevel != null)
                tree["foodSaturation"] = new TagNodeFloat(HungerSaturationLevel.Value);
            if (XpP != null)
                tree["XpP"] = new TagNodeFloat(XpP.Value);
            if (XpLevel != null)
                tree["XpLevel"] = new TagNodeInt(XpLevel.Value);
            if (XpTotal != null)
                tree["XpTotal"] = new TagNodeInt(XpTotal.Value);
            if (Score != null)
                tree["Score"] = new TagNodeInt(Score.Value);

            if (GameType != null)
                tree["playerGameType"] = new TagNodeInt((int)(GameType.Value));

            if (AbilitiesSet())
            {
                TagNodeCompound pb = new TagNodeCompound();
                pb["flying"] = new TagNodeByte(Abilities.Flying);
                pb["instabuild"] = new TagNodeByte(Abilities.InstantBuild);
                pb["mayfly"] = new TagNodeByte(Abilities.MayFly);
                pb["invulnerable"] = new TagNodeByte(Abilities.Invulnerable);

                if (Abilities.MayBuild != null)
                    pb["mayBuild"] = new TagNodeByte(Abilities.MayBuild.Value);

                if (Abilities.WalkSpeed != null)
                    pb["walkSpeed"] = new TagNodeFloat(Abilities.WalkSpeed.Value);


                if (Abilities.FlySpeed != null)
                    pb["flySpeed"] = new TagNodeFloat(Abilities.FlySpeed.Value);

                tree["abilities"] = pb;
            }

            tree["Inventory"] = _inventory.BuildTree();
            tree["EnderItems"] = _enderItems.BuildTree();

            return tree;
        }

        /// <summary>
        /// Validate a Player subtree against a schema defintion.
        /// </summary>
        /// <param name="tree">The root node of a Player subtree.</param>
        /// <returns>Status indicating whether the tree was valid against the internal schema.</returns>
        public virtual new bool ValidateTree(TagNode tree)
        {
            return new NbtVerifier(tree, _schema).Verify();
        }

        #endregion


        #region ICopyable<Entity> Members

        /// <summary>
        /// Creates a deep-copy of the <see cref="Player"/>.
        /// </summary>
        /// <returns>A deep-copy of the <see cref="Player"/>.</returns>
        public virtual new Player Copy()
        {
            return new Player(this);
        }

        #endregion


        #region IItemContainer Members

        /// <summary>
        /// Gets access to an <see cref="ItemCollection"/> representing the player's equipment and inventory.
        /// </summary>
        public ItemCollection Items
        {
            get { return _inventory; }
        }

        #endregion

        public ItemCollection EnderItems
        {
            get { return _enderItems; }
        }
    }
}