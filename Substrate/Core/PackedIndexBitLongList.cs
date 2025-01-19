using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.Core
{
    /// <summary>
    /// A list of indicies packed bitwise in a long array
    /// </summary>
    public class PackedIndexBitLongList : IDataArray
    {

        public int Length { get; private set; }
        public int DataWidth { get; private set; }

        long[] _data;

        public PackedIndexBitLongList(int indexCount, long[] data)
        {
            Length = indexCount;
            DataWidth = (int)Math.Log(indexCount, 2) + 1;
            _data = data;
        }
        public int this[int i]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Clear()
        {
            Array.Clear(_data, 0, _data.Length);
        }
    }
}
