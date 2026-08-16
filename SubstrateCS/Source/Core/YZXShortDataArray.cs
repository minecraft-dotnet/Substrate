using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.Core
{
    public class YZXShortDataArray : IDataArray3
    {
        private readonly short[,,] _dataArray;
        public YZXShortDataArray(short[,,] dataArray)
        {
            _dataArray = dataArray; 
        }

        public int this[int x, int y, int z]
        {
            get { return _dataArray[y, z, x]; }
            set
            {
                _dataArray[y, z, x] = (short)value;
            }
        }

        public int XDim
        {
            get { return _dataArray.GetLength(2);  }
        }

        public int YDim
        {
            get { return _dataArray.GetLength(0); }
        }

        public int ZDim
        {
            get { return _dataArray.GetLength(1); }
        }

        public int GetIndex (int x, int y, int z)
        {
            return XDim * (y * ZDim + z) + x;
        }

        public void GetMultiIndex (int index, out int x, out int y, out int z)
        {
            int xzdim = XDim * ZDim;
            y = index / xzdim;

            int zx = index - (y * xzdim);
            z = zx / XDim;
            x = zx - (z * XDim);
        }

        public int this[int i]
        {
            get {
                int x, y, z;
                GetMultiIndex(i, out x, out y, out z);
                return _dataArray[y, z, x];
            }
            set
            {
                int x, y, z;
                GetMultiIndex(i, out x, out y, out z);
                _dataArray[y, z, x] = (short)value;
            }
        }

        public int Length
        {
            get { return XDim * YDim * ZDim; }
        }

        public int DataWidth
        {
            get { return 16; }
        }

        public void Clear ()
        {
            for (int y = 0; y < YDim; y++) {
                for (int z = 0; z < ZDim; z++) {
                    for (int x = 0; x < XDim; x++) {
                        _dataArray[y, z, x] = 0;
                    }
                }
            }
        }
    }
}
