using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.Nbt
{
    public sealed class TagNodeShortArray : TagNode
    {
        private short[] _data = null;

        /// <summary>
        /// Converts the node to itself.
        /// </summary>
        /// <returns>A reference to itself.</returns>
        public override TagNodeShortArray ToTagShortArray ()
        {
            return this;
        }

        /// <summary>
        /// Gets the tag type of the node.
        /// </summary>
        /// <returns>The TAG_SHORT_ARRAY tag type.</returns>
        public override TagType GetTagType ()
        {
            return TagType.TAG_SHORT_ARRAY;
        }

        /// <summary>
        /// Gets or sets an short array of tag data.
        /// </summary>
        public short[] Data
        {
            get { return _data; }
            set { _data = value; }
        }

        /// <summary>
        /// Gets the length of the stored short array.
        /// </summary>
        public int Length
        {
            get { return _data.Length; }
        }

        /// <summary>
        /// Constructs a new short array node with a null data value.
        /// </summary>
        public TagNodeShortArray () { }

        /// <summary>
        /// Constructs a new short array node.
        /// </summary>
        /// <param name="d">The value to set the node's tag data value.</param>
        public TagNodeShortArray (short[] d)
        {
            _data = d;
        }

        /// <summary>
        /// Makes a deep copy of the node.
        /// </summary>
        /// <returns>A new int array node representing the same data.</returns>
        public override TagNode Copy ()
        {
            short[] arr = new short[_data.Length];
            _data.CopyTo(arr, 0);

            return new TagNodeShortArray(arr);
        }

        /// <summary>
        /// Gets a string representation of the node's data.
        /// </summary>
        /// <returns>String representation of the node's data.</returns>
        public override string ToString ()
        {
            return _data.ToString();
        }

        /// <summary>
        /// Gets or sets a single short at the specified index.
        /// </summary>
        /// <param name="index">Valid index within stored short array.</param>
        /// <returns>The short value at the given index of the stored short array.</returns>
        public short this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        /// <summary>
        /// Converts a system short array to a short array node representing the same data.
        /// </summary>
        /// <param name="i">A short array.</param>
        /// <returns>A new short array node containing the given value.</returns>
        public static implicit operator TagNodeShortArray (short[] i)
        {
            return new TagNodeShortArray(i);
        }

        /// <summary>
        /// Converts an short array node to a system short array representing the same data.
        /// </summary>
        /// <param name="i">A short array node.</param>
        /// <returns>A system short array set to the node's data.</returns>
        public static implicit operator short[] (TagNodeShortArray i)
        {
            return i._data;
        }
    }
}
