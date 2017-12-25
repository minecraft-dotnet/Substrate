using System;
using System.Diagnostics;

namespace Substrate.Nbt
{
    /// <summary>
    /// A concrete <see cref="SchemaNode"/> representing a scalar-type <see cref="TagNode"/>.
    /// </summary>
    [DebuggerDisplay("Name = {Name}, Options = {Options}, Scalar Type={Type}")]
    public sealed class SchemaNodeScalar : SchemaNode
    {
        /// <summary>
        /// Constructs a new <see cref="SchemaNodeScalar"/> representing a <see cref="TagNode"/> named <paramref name="name"/> and of type <paramref name="type"/>.
        /// </summary>
        /// <param name="name">The name of the corresponding <see cref="TagNode"/>.</param>
        /// <param name="type">The type of the corresponding <see cref="TagNode"/>, restricted to scalar types.</param>
        public SchemaNodeScalar(string name, TagType type)
            : base(name, type)
        {
        }

        /// <summary>
        /// Constructs a new <see cref="SchemaNodeScalar"/> with additional options.
        /// </summary>
        /// <param name="name">The name of the corresponding <see cref="TagNode"/>.</param>
        /// <param name="type">The type of the corresponding <see cref="TagNode"/>, restricted to scalar types.</param>
        /// <param name="options">One or more option flags modifying the processing of this node.</param>
        public SchemaNodeScalar(string name, TagType type, SchemaOptions options)
            : base(name, type, options)
        {
        }

        /// <summary>
        /// Constructs a default <see cref="TagNode"/> according to the <see cref="TagType"/> this node represents.
        /// </summary>
        /// <returns>A <see cref="TagNode"/> with a sensible default value.</returns>
        public override TagNode BuildDefaultTree()
        {
            switch (Type)
            {
            case TagType.TAG_STRING:
                return new TagNodeString();

            case TagType.TAG_BYTE:
                return new TagNodeByte();

            case TagType.TAG_SHORT:
                return new TagNodeShort();

            case TagType.TAG_INT:
                return new TagNodeInt();

            case TagType.TAG_LONG:
                return new TagNodeLong();

            case TagType.TAG_FLOAT:
                return new TagNodeFloat();

            case TagType.TAG_DOUBLE:
                return new TagNodeDouble();
            }

            return null;
        }
    }
}
