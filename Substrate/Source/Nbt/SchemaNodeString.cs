using System;

namespace Substrate.Nbt
{
    /// <summary>
    /// A concrete <see cref="SchemaNode"/> representing a <see cref="TagNodeString"/>.
    /// </summary>
    public sealed class SchemaNodeString : SchemaNode
    {
        /// <summary>
        /// Gets the maximum length of a valid string.
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Gets the expected value of a valid string.
        /// </summary>
        /// <remarks>A <see cref="TagNodeString"/> must be set to this value to be considered valid.</remarks>
        public string Value { get; private set; } = "";

        /// <summary>
        /// Indicates whether there is a maximum-length constraint on strings in this node.
        /// </summary>
        public bool HasMaxLength
        {
            get { return Length > 0; }
        }

        /// <summary>
        /// Constructs a new <see cref="SchemaNodeString"/> representing a <see cref="TagNodeString"/> named <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the corresponding <see cref="TagNodeString"/>.</param>
        public SchemaNodeString(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Constructs a new <see cref="SchemaNodeString"/> with additional options.
        /// </summary>
        /// <param name="name">The name of the corresponding <see cref="TagNodeString"/>.</param>
        /// <param name="options">One or more option flags modifying the processing of this node.</param>
        public SchemaNodeString(string name, SchemaOptions options)
            : base(name, options)
        {
        }

        /// <summary>
        /// Constructs a new <see cref="SchemaNodeString"/> representing a <see cref="TagNodeString"/> named <paramref name="name"/> set to <paramref name="value"/>.
        /// </summary>
        /// <param name="name">The name of the corresponding <see cref="TagNodeString"/>.</param>
        /// <param name="value">The value that the corresponding <see cref="TagNodeString"/> must be set to.</param>
        public SchemaNodeString(string name, string value)
            : base(name)
        {
            Value = value;
        }

        /// <summary>
        /// Constructs a new <see cref="SchemaNodeString"/> with additional options.
        /// </summary>
        /// <param name="name">The name of the corresponding <see cref="TagNodeString"/>.</param>
        /// <param name="value">The value that the corresponding <see cref="TagNodeString"/> must be set to.</param>
        /// <param name="options">One or more option flags modifying the processing of this node.</param>
        public SchemaNodeString(string name, string value, SchemaOptions options)
            : base(name, options)
        {
            Value = value;
        }

        /// <summary>
        /// Constructs a new <see cref="SchemaNodeString"/> representing a <see cref="TagNodeString"/> named <paramref name="name"/> with maximum length <paramref name="length"/>.
        /// </summary>
        /// <param name="name">The name of the corresponding <see cref="TagNodeString"/>.</param>
        /// <param name="length">The maximum length of strings in the corresponding <see cref="TagNodeString"/>.</param>
        public SchemaNodeString(string name, int length)
            : base(name)
        {
            Length = length;
        }

        /// <summary>
        /// Constructs a new <see cref="SchemaNodeString"/> with additional options.
        /// </summary>
        /// <param name="name">The name of the corresponding <see cref="TagNodeString"/>.</param>
        /// <param name="length">The maximum length of strings in the corresponding <see cref="TagNodeString"/>.</param>
        /// <param name="options">One or more option flags modifying the processing of this node.</param>
        public SchemaNodeString(string name, int length, SchemaOptions options)
            : base(name, options)
        {
            Length = length;
        }

        /// <summary>
        /// Constructs a default <see cref="TagNodeString"/> satisfying the constraints of this node.
        /// </summary>
        /// <returns>A <see cref="TagNodeString"/> with a sensible default value.  If this node represents a particular string, the <see cref="TagNodeString"/> constructed will be set to that string.</returns>
        public override TagNode BuildDefaultTree()
        {
            if (Value.Length > 0)
            {
                return new TagNodeString(Value);
            }

            return new TagNodeString();
        }
    }
}
