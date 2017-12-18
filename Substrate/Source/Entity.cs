using System;
using System.Collections.Generic;
using System.Text;
using Substrate.Core;
using Substrate.Nbt;

namespace Substrate
{
    /// <summary>
    /// The base Entity type for Minecraft Entities, providing access to data common to all Minecraft Entities.
    /// </summary>
    public class Entity : INbtObject<Entity>, ICopyable<Entity>
    {
        private static readonly SchemaNodeCompound _schema = new SchemaNodeCompound("")
        {
            new SchemaNodeList("Pos", TagType.TAG_DOUBLE, 3),
            new SchemaNodeList("Motion", TagType.TAG_DOUBLE, 3),
            new SchemaNodeList("Rotation", TagType.TAG_FLOAT, 2),
            new SchemaNodeScalar("FallDistance", TagType.TAG_FLOAT),
            new SchemaNodeScalar("Fire", TagType.TAG_SHORT),
            new SchemaNodeScalar("Air", TagType.TAG_SHORT),
            new SchemaNodeScalar("OnGround", TagType.TAG_BYTE),
        };

        private TagNodeCompound _source;

        /// <summary>
        /// Gets or sets the global position of the entity in fractional block coordinates.
        /// </summary>
        [TagNode(Name = "Pos")]
        public Vector3 Position { get; set; }

        /// <summary>
        /// Gets or sets the velocity of the entity.
        /// </summary>
        [TagNode]
        public Vector3 Motion { get; set; }

        /// <summary>
        /// Gets or sets the orientation of the entity.
        /// </summary>
        [TagNode]
        public Orientation Rotation { get; set; }

        /// <summary>
        /// Gets or sets the distance that the entity has fallen, if it is falling.
        /// </summary>
        [TagNode]
        public float FallDistance { get; set; }

        /// <summary>
        /// Gets or sets the fire counter of the entity.
        /// </summary>
        [TagNode(TagType = TagType.TAG_SHORT)]
        public int Fire { get; set; }

        /// <summary>
        /// Gets or sets the remaining air availale to the entity.
        /// </summary>
        [TagNode(TagType = TagType.TAG_SHORT)]
        public int Air { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is currently touch the ground.
        /// </summary>
        [TagNode(Name = "OnGround")]
        public bool IsOnGround { get; set; }

        /// <summary>
        /// Gets the source <see cref="TagNodeCompound"/> used to create this <see cref="Entity"/> if it exists.
        /// </summary>
        public TagNodeCompound Source
        {
            get { return _source; }
        }

        /// <summary>
        /// Constructs a new generic <see cref="Entity"/> with default values.
        /// </summary>
        public Entity()
        {
            Position = new Vector3();
            Motion = new Vector3();
            Rotation = new Orientation();

            _source = new TagNodeCompound();
        }

        /// <summary>
        /// Constructs a new generic <see cref="Entity"/> by copying fields from another <see cref="Entity"/> object.
        /// </summary>
        /// <param name="e">An <see cref="Entity"/> to copy fields from.</param>
        protected Entity(Entity e)
        {
            Position = new Vector3();
            Position.X = e.Position.X;
            Position.Y = e.Position.Y;
            Position.Z = e.Position.Z;

            Motion = new Vector3();
            Motion.X = e.Motion.X;
            Motion.Y = e.Motion.Y;
            Motion.Z = e.Motion.Z;

            Rotation = new Orientation();
            Rotation.Pitch = e.Rotation.Pitch;
            Rotation.Yaw = e.Rotation.Yaw;

            FallDistance = e.FallDistance;
            Fire = e.Fire;
            Air = e.Air;
            IsOnGround = e.IsOnGround;

            if (e._source != null)
            {
                _source = e._source.Copy() as TagNodeCompound;
            }
        }

        /// <summary>
        /// Moves the <see cref="Entity"/> by given block offsets.
        /// </summary>
        /// <param name="diffX">The X-offset to move by, in blocks.</param>
        /// <param name="diffY">The Y-offset to move by, in blocks.</param>
        /// <param name="diffZ">The Z-offset to move by, in blocks.</param>
        public virtual void MoveBy(int diffX, int diffY, int diffZ)
        {
            Position.X += diffX;
            Position.Y += diffY;
            Position.Z += diffZ;
        }


        #region INBTObject<Entity> Members

        /// <summary>
        /// Gets a <see cref="SchemaNode"/> representing the basic schema of an Entity.
        /// </summary>
        public static SchemaNodeCompound Schema
        {
            get { return _schema; }
        }

        /// <summary>
        /// Attempt to load an Entity subtree into the <see cref="Entity"/> without validation.
        /// </summary>
        /// <param name="tree">The root node of an Entity subtree.</param>
        /// <returns>The <see cref="Entity"/> returns itself on success, or null if the tree was unparsable.</returns>
        public Entity LoadTree(TagNode tree)
        {
            TagNodeCompound ctree = tree as TagNodeCompound;
            if (ctree == null)
            {
                return null;
            }

            TagNodeList pos = ctree["Pos"].ToTagList();
            Position = new Vector3();
            Position.X = pos[0].ToTagDouble();
            Position.Y = pos[1].ToTagDouble();
            Position.Z = pos[2].ToTagDouble();

            TagNodeList motion = ctree["Motion"].ToTagList();
            Motion = new Vector3();
            Motion.X = motion[0].ToTagDouble();
            Motion.Y = motion[1].ToTagDouble();
            Motion.Z = motion[2].ToTagDouble();

            TagNodeList rotation = ctree["Rotation"].ToTagList();
            Rotation = new Orientation();
            Rotation.Yaw = rotation[0].ToTagFloat();
            Rotation.Pitch = rotation[1].ToTagFloat();

            Fire = ctree["Fire"].ToTagShort();
            Air = ctree["Air"].ToTagShort();
            IsOnGround = ctree["OnGround"].ToTagByte() != 0;

            _source = ctree.Copy() as TagNodeCompound;

            return this;
        }

        /// <summary>
        /// Attempt to load an Entity subtree into the <see cref="Entity"/> with validation.
        /// </summary>
        /// <param name="tree">The root node of an Entity subtree.</param>
        /// <returns>The <see cref="Entity"/> returns itself on success, or null if the tree failed validation.</returns>
        public Entity LoadTreeSafe(TagNode tree)
        {
            if (!ValidateTree(tree))
            {
                return null;
            }

            return LoadTree(tree);
        }

        /// <summary>
        /// Builds an Entity subtree from the current data.
        /// </summary>
        /// <returns>The root node of an Entity subtree representing the current data.</returns>
        public TagNode BuildTree()
        {
            TagNodeCompound tree = new TagNodeCompound();

            TagNodeList pos = new TagNodeList(TagType.TAG_DOUBLE);
            pos.Add(new TagNodeDouble(Position.X));
            pos.Add(new TagNodeDouble(Position.Y));
            pos.Add(new TagNodeDouble(Position.Z));
            tree["Pos"] = pos;

            TagNodeList motion = new TagNodeList(TagType.TAG_DOUBLE);
            motion.Add(new TagNodeDouble(Motion.X));
            motion.Add(new TagNodeDouble(Motion.Y));
            motion.Add(new TagNodeDouble(Motion.Z));
            tree["Motion"] = motion;

            TagNodeList rotation = new TagNodeList(TagType.TAG_FLOAT);
            rotation.Add(new TagNodeFloat((float)Rotation.Yaw));
            rotation.Add(new TagNodeFloat((float)Rotation.Pitch));
            tree["Rotation"] = rotation;

            tree["FallDistance"] = new TagNodeFloat(FallDistance);
            tree["Fire"] = new TagNodeShort((short)Fire);
            tree["Air"] = new TagNodeShort((short)Air);
            tree["OnGround"] = new TagNodeByte(IsOnGround);

            if (_source != null)
            {
                tree.MergeFrom(_source);
            }

            return tree;
        }

        /// <summary>
        /// Validate an Entity subtree against a basic schema.
        /// </summary>
        /// <param name="tree">The root node of an Entity subtree.</param>
        /// <returns>Status indicating whether the tree was valid against the internal schema.</returns>
        public bool ValidateTree(TagNode tree)
        {
            return new NbtVerifier(tree, _schema).Verify();
        }

        #endregion


        #region ICopyable<Entity> Members

        /// <summary>
        /// Creates a deep-copy of the <see cref="Entity"/>.
        /// </summary>
        /// <returns>A deep-copy of the <see cref="Entity"/>.</returns>
        public Entity Copy()
        {
            return new Entity(this);
        }

        #endregion
    }

    /// <summary>
    /// A base entity type for all entities except <see cref="Player"/> entities.
    /// </summary>
    /// <remarks>Generally, this class should be subtyped into new concrete Entity types, as this generic type is unable to
    /// capture any of the custom data fields.  It is however still possible to create instances of <see cref="Entity"/> objects, 
    /// which may allow for graceful handling of unknown Entity types.</remarks>
    public class TypedEntity : Entity, INbtObject<TypedEntity>, ICopyable<TypedEntity>
    {
        private static readonly SchemaNodeCompound _schema = Entity.Schema.MergeInto(new SchemaNodeCompound("")
        {
            new SchemaNodeScalar("id", TagType.TAG_STRING),
        });

        private string _id;

        /// <summary>
        /// Gets the id (type) of the entity.
        /// </summary>
        public string ID
        {
            get { return _id; }
        }

        /// <summary>
        /// Creates a new generic <see cref="TypedEntity"/> with the given id.
        /// </summary>
        /// <param name="id">The id (name) of the Entity.</param>
        public TypedEntity(string id)
            : base()
        {
            _id = id;
        }

        /// <summary>
        /// Constructs a new <see cref="TypedEntity"/> by copying an existing one.
        /// </summary>
        /// <param name="e">The <see cref="TypedEntity"/> to copy.</param>
        protected TypedEntity(TypedEntity e)
            : base(e)
        {
            _id = e._id;
        }


        #region INBTObject<Entity> Members

        /// <summary>
        /// Gets a <see cref="SchemaNode"/> representing the basic schema of an Entity.
        /// </summary>
        public static new SchemaNodeCompound Schema
        {
            get { return _schema; }
        }

        /// <summary>
        /// Attempt to load an Entity subtree into the <see cref="TypedEntity"/> without validation.
        /// </summary>
        /// <param name="tree">The root node of an Entity subtree.</param>
        /// <returns>The <see cref="TypedEntity"/> returns itself on success, or null if the tree was unparsable.</returns>
        public virtual new TypedEntity LoadTree(TagNode tree)
        {
            TagNodeCompound ctree = tree as TagNodeCompound;
            if (ctree == null || base.LoadTree(tree) == null)
            {
                return null;
            }

            _id = ctree["id"].ToTagString();

            return this;
        }

        /// <summary>
        /// Attempt to load an Entity subtree into the <see cref="TypedEntity"/> with validation.
        /// </summary>
        /// <param name="tree">The root node of an Entity subtree.</param>
        /// <returns>The <see cref="TypedEntity"/> returns itself on success, or null if the tree failed validation.</returns>
        public virtual new TypedEntity LoadTreeSafe(TagNode tree)
        {
            if (!ValidateTree(tree))
            {
                return null;
            }

            return LoadTree(tree);
        }

        /// <summary>
        /// Builds an Entity subtree from the current data.
        /// </summary>
        /// <returns>The root node of an Entity subtree representing the current data.</returns>
        public virtual new TagNode BuildTree()
        {
            TagNodeCompound tree = base.BuildTree() as TagNodeCompound;
            tree["id"] = new TagNodeString(_id);

            return tree;
        }

        /// <summary>
        /// Validate an Entity subtree against a basic schema.
        /// </summary>
        /// <param name="tree">The root node of an Entity subtree.</param>
        /// <returns>Status indicating whether the tree was valid against the internal schema.</returns>
        public virtual new bool ValidateTree(TagNode tree)
        {
            return new NbtVerifier(tree, _schema).Verify();
        }

        #endregion


        #region ICopyable<Entity> Members

        /// <summary>
        /// Creates a deep-copy of the <see cref="TypedEntity"/>.
        /// </summary>
        /// <returns>A deep-copy of the <see cref="TypedEntity"/>.</returns>
        public virtual new TypedEntity Copy()
        {
            return new TypedEntity(this);
        }

        #endregion
    }

}