using System;

namespace Substrate.Nbt
{
    /// <summary>
    /// A concrete <see cref="SchemaNode"/> representing a <see cref="TagNodeList"/>.
    /// </summary>
    public sealed class SchemaNodeList : SchemaNode
    {
        /// <summary>
        /// Gets the expected number of items contained in the corresponding <see cref="TagNodeList"/>.
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Gets the expected <see cref="TagType"/> of the items contained in the corresponding <see cref="TagNodeList"/>.
        /// </summary>
        public TagType ItemType { get; private set; }

        /// <summary>
        /// Gets a <see cref="SchemaNode"/> representing a schema that items contained in the corresponding <see cref="TagNodeList"/> should be verified against.
        /// </summary>
        public SchemaNode ItemSchema { get; private set; }

        /// <summary>
        /// Indicates whether there is an expected number of items of the corresponding <see cref="TagNodeList"/>.
        /// </summary>
        public bool HasExpectedLength
        {
            get { return Length > 0; }
        }

        /// <summary>
        /// Constructs a new <see cref="SchemaNodeList"/> representing a <see cref="TagNodeList"/> named <paramref name="name"/> containing items of type <paramref name="type"/>.
        /// </summary>
        /// <param name="name">The name of the corresponding <see cref="TagNodeList"/>.</param>
        /// <param name="type">The type of items contained in the corresponding <see cref="TagNodeList"/>.</param>
        public SchemaNodeList(string name, TagType type)
            : base(name, TagType.TAG_LIST)
        {
            ItemType = type;
        }

        /// <summary>
        /// Constructs a new <see cref="SchemaNodeList"/> with additional options.
        /// </summary>
        /// <param name="name">The name of the corresponding <see cref="TagNodeList"/>.</param>
        /// <param name="type">The type of items contained in the corresponding <see cref="TagNodeList"/>.</param>
        /// <param name="options">One or more option flags modifying the processing of this node.</param>
        public SchemaNodeList(string name, TagType type, SchemaOptions options)
            : base(name, TagType.TAG_LIST, options)
        {
            ItemType = type;
        }

        /// <summary>
        /// Constructs a new <see cref="SchemaNodeList"/> representing a <see cref="TagNodeList"/> named <paramref name="name"/> containing <paramref name="length"/> items of type <paramref name="type"/>.
        /// </summary>
        /// <param name="name">The name of the corresponding <see cref="TagNodeList"/>.</param>
        /// <param name="type">The type of items contained in the corresponding <see cref="TagNodeList"/>.</param>
        /// <param name="length">The number of items contained in the corresponding <see cref="TagNodeList"/>.</param>
        public SchemaNodeList(string name, TagType type, int length)
            : base(name, TagType.TAG_LIST)
        {
            ItemType = type;
            Length = length;
        }

        /// <summary>
        /// Constructs a new <see cref="SchemaNodeList"/> with additional options.
        /// </summary>
        /// <param name="name">The name of the corresponding <see cref="TagNodeList"/>.</param>
        /// <param name="type">The type of items contained in the corresponding <see cref="TagNodeList"/>.</param>
        /// <param name="length">The number of items contained in the corresponding <see cref="TagNodeList"/>.</param>
        /// <param name="options">One or more option flags modifying the processing of this node.</param>
        public SchemaNodeList(string name, TagType type, int length, SchemaOptions options)
            : base(name, TagType.TAG_LIST, options)
        {
            ItemType = type;
            Length = length;
        }

        /// <summary>
        /// Constructs a new <see cref="SchemaNodeList"/> representing a <see cref="TagNodeList"/> named <paramref name="name"/> containing items of type <paramref name="type"/> matching the given schema.
        /// </summary>
        /// <param name="name">The name of the corresponding <see cref="TagNodeList"/>.</param>
        /// <param name="type">The type of items contained in the corresponding <see cref="TagNodeList"/>.</param>
        /// <param name="subschema">A <see cref="SchemaNode"/> representing a schema to verify against items contained in the corresponding <see cref="TagNodeList"/>.</param>
        public SchemaNodeList(string name, TagType type, SchemaNode subschema)
            : base(name, TagType.TAG_LIST)
        {
            ItemType = type;
            ItemSchema = subschema;
        }

        /// <summary>
        /// Constructs a new <see cref="SchemaNodeList"/> with additional options.
        /// </summary>
        /// <param name="name">The name of the corresponding <see cref="TagNodeList"/>.</param>
        /// <param name="type">The type of items contained in the corresponding <see cref="TagNodeList"/>.</param>
        /// <param name="subschema">A <see cref="SchemaNode"/> representing a schema to verify against items contained in the corresponding <see cref="TagNodeList"/>.</param>
        /// <param name="options">One or more option flags modifying the processing of this node.</param>
        public SchemaNodeList(string name, TagType type, SchemaNode subschema, SchemaOptions options)
            : base(name, TagType.TAG_LIST, options)
        {
            ItemType = type;
            ItemSchema = subschema;
        }

        /// <summary>
        /// Constructs a new <see cref="SchemaNodeList"/> representing a <see cref="TagNodeList"/> named <paramref name="name"/> containing <paramref name="length"/> items of type <paramref name="type"/> matching the given schema.
        /// </summary>
        /// <param name="name">The name of the corresponding <see cref="TagNodeList"/>.</param>
        /// <param name="type">The type of items contained in the corresponding <see cref="TagNodeList"/>.</param>
        /// <param name="length">The number of items contained in the corresponding <see cref="TagNodeList"/>.</param>
        /// <param name="subschema">A <see cref="SchemaNode"/> representing a schema to verify against items contained in the corresponding <see cref="TagNodeList"/>.</param>
        public SchemaNodeList(string name, TagType type, int length, SchemaNode subschema)
            : base(name, TagType.TAG_LIST)
        {
            ItemType = type;
            Length = length;
            ItemSchema = subschema;
        }

        /// <summary>
        /// Constructs a new <see cref="SchemaNodeList"/> with additional options.
        /// </summary>
        /// <param name="name">The name of the corresponding <see cref="TagNodeList"/>.</param>
        /// <param name="type">The type of items contained in the corresponding <see cref="TagNodeList"/>.</param>
        /// <param name="length">The number of items contained in the corresponding <see cref="TagNodeList"/>.</param>
        /// <param name="subschema">A <see cref="SchemaNode"/> representing a schema to verify against items contained in the corresponding <see cref="TagNodeList"/>.</param>
        /// <param name="options">One or more option flags modifying the processing of this node.</param>
        public SchemaNodeList(string name, TagType type, int length, SchemaNode subschema, SchemaOptions options)
            : base(name, TagType.TAG_LIST, options)
        {
            ItemType = type;
            Length = length;
            ItemSchema = subschema;
        }

        /// <summary>
        /// Constructs a default <see cref="TagNodeList"/> satisfying the constraints of this node.
        /// </summary>
        /// <returns>A <see cref="TagNodeList"/> with a sensible default value.  If a length is specified, default child <see cref="TagNode"/> objects of the necessary type will be created and added to the <see cref="TagNodeList"/>.</returns>
        public override TagNode BuildDefaultTree()
        {
            if (Length == 0)
            {
                return new TagNodeList(ItemType);
            }

            TagNodeList list = new TagNodeList(ItemType);
            for (int i = 0; i < Length; i++)
            {
                list.Add(ItemSchema.BuildDefaultTree());
            }

            return list;
        }
    }
}
