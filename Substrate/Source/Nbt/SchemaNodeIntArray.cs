using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.Nbt
{
    /// <summary>
    /// A concrete <see cref="SchemaNode"/> representing a <see cref="TagNodeIntArray"/>.
    /// </summary>
    public sealed class SchemaNodeIntArray : SchemaNode
    {
        /// <summary>
        /// Gets the expected length of the corresponding int array.
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Indicates whether there is an expected length of the corresponding int array.
        /// </summary>
        public bool HasExpectedLength
        {
            get { return Length > 0; }
        }

        /// <summary>
        /// Constructs a new <see cref="SchemaNodeIntArray"/> representing a <see cref="TagNodeIntArray"/> named <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the corresponding <see cref="TagNodeIntArray"/>.</param>
        public SchemaNodeIntArray(string name)
            : base(name)
        {
            Length = 0;
        }

        /// <summary>
        /// Constructs a new <see cref="SchemaNodeIntArray"/> with additional options.
        /// </summary>
        /// <param name="name">The name of the corresponding <see cref="TagNodeIntArray"/>.</param>
        /// <param name="options">One or more option flags modifying the processing of this node.</param>
        public SchemaNodeIntArray(string name, SchemaOptions options)
            : base(name, options)
        {
            Length = 0;
        }

        /// <summary>
        /// Constructs a new <see cref="SchemaNodeIntArray"/> representing a <see cref="TagNodeIntArray"/> named <paramref name="name"/> with expected length <paramref name="length"/>.
        /// </summary>
        /// <param name="name">The name of the corresponding <see cref="TagNodeIntArray"/>.</param>
        /// <param name="length">The expected length of corresponding byte array.</param>
        public SchemaNodeIntArray(string name, int length)
            : base(name)
        {
            Length = length;
        }

        /// <summary>
        /// Constructs a new <see cref="SchemaNodeIntArray"/> with additional options.
        /// </summary>
        /// <param name="name">The name of the corresponding <see cref="TagNodeIntArray"/>.</param>
        /// <param name="length">The expected length of corresponding byte array.</param>
        /// <param name="options">One or more option flags modifying the processing of this node.</param>
        public SchemaNodeIntArray(string name, int length, SchemaOptions options)
            : base(name, options)
        {
            Length = length;
        }

        /// <summary>
        /// Constructs a default <see cref="TagNodeIntArray"/> satisfying the constraints of this node.
        /// </summary>
        /// <returns>A <see cref="TagNodeString"/> with a sensible default value.</returns>
        public override TagNode BuildDefaultTree()
        {
            return new TagNodeIntArray(new int[Length]);
        }
    }
}
