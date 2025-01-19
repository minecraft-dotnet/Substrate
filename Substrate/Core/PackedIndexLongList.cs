using System;
using System.Collections.Generic;
using System.Text;

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

        public PackedIndexLongList(int indexCount, long[] data)
        {
            Length = indexCount;
            DataWidth = (int)Math.Log(indexCount - 1, 2) + 1;
            _indexesPerLong = BitsPerLong / DataWidth;
            _data = data;
        }
        public int this[int i]
        {
            get
            {
                var index = GetDataIndex(i);
                var offset = GetDataOffset(i);
                var mask = (1 << DataWidth) - 1;
                var shift = BitsPerLong - (offset + DataWidth);

                return (int)((_data[index] >> shift) & mask);
            }
            set
            {
                var index = GetDataIndex(i);
                var offset = GetDataOffset(i);
                var mask = (1 << DataWidth) - 1;
                var shift = BitsPerLong - (offset + DataWidth);

                _data[index] = (_data[index] & ~((long)mask << shift)) | ((long)(value & mask) << shift);
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
