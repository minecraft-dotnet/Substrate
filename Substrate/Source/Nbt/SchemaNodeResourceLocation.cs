using System;
using System.IO;

namespace Substrate.Nbt
{
    /// <summary>
    /// A concrete <see cref="SchemaNode"/> representing a <see cref="TagNodeString"/> that contains a Resource Location or namespaced string.
    /// </summary>
    public sealed class SchemaNodeResourceLocation : SchemaNode
    {
        /// <summary>
        /// Constructs a new <see cref="SchemaNodeString"/> representing a <see cref="TagNodeString"/> named <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the corresponding <see cref="TagNodeString"/>.</param>
        public SchemaNodeResourceLocation(string name)
            : base(name, TagType.TAG_STRING)
        {
        }

        /// <summary>
        /// Constructs a new <see cref="SchemaNodeString"/> with additional options.
        /// </summary>
        /// <param name="name">The name of the corresponding <see cref="TagNodeString"/>.</param>
        /// <param name="options">One or more option flags modifying the processing of this node.</param>
        public SchemaNodeResourceLocation(string name, SchemaOptions options)
            : base(name, TagType.TAG_STRING, options)
        {
        }

        /// <summary>
        /// Constructs a default <see cref="TagNodeString"/> satisfying the constraints of this node.
        /// </summary>
        /// <returns>A <see cref="TagNodeString"/> with a sensible default value.  If this node represents a particular string, the <see cref="TagNodeString"/> constructed will be set to that string.</returns>
        public override TagNode BuildDefaultTree()
        {
            return new TagNodeString();
        }
    }
}
