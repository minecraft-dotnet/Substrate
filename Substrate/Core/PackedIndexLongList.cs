using System;
using System.Collections.Generic;

namespace Substrate.Core
{
    /// <summary>
    /// A list of indicies packed wholey within single long values (ie data doesn't span long boundaries)
    /// </summary>
    public class PackedIndexLongList : IDataArray
    {
        const int BitsPerLong = sizeof(long) * 8;

        public int Length { get; private set; }

        /// <summary> How many bits a single index takes up in the data array </summary>
        public int DataWidth { get; private set; }

        int _indexesPerLong;

        long[] _data;

        public PackedIndexLongList(int indexCount, long[] data, int minDataWidth = 1)
        {
            DataWidth = Math.Max((int)Math.Ceiling(Math.Log(indexCount, 2)), minDataWidth);
            _indexesPerLong = BitsPerLong / DataWidth;
            Length = _indexesPerLong * data.Length;
            _data = data;
        }
        public int this[int i]
        {
            get
            {
                var index = GetDataIndex(i);
                var offset = GetDataOffset(i);
                var mask = (1 << DataWidth) - 1;

                return (int)((_data[index] >> offset) & mask);
            }
            set
            {
                var index = GetDataIndex(i);
                var offset = GetDataOffset(i);
                var mask = (1 << DataWidth) - 1;

                _data[index] = (_data[index] & ~((long)mask << offset)) | ((long)(value & mask) << offset);
            }
        }

        public void Clear()
        {
            Array.Clear(_data, 0, _data.Length);
        }

        public int GetDataIndex(int i)
        {
            return i / _indexesPerLong;
        }

        public int GetDataOffset(int i)
        {
            return (i % _indexesPerLong) * DataWidth;
        }
    }
}
