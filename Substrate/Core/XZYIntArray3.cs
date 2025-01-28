using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.Core
{
    public class XZYIntArray3 : IDataArray3
    {
        private int[] _data;

        public int this[int i] { get { return _data[i]; } set { _data[i] = value; } }
        public int this[int x, int y, int z] { get { return _data[GetIndex(x, y, x)]; } set { _data[GetIndex(x, y, x)] = value; } }

        public int XDim { get; }
        public int YDim { get; }
        public int ZDim { get; }
        public int Length { get; }
        public int DataWidth { get; }

        public XZYIntArray3(int xdim, int ydim, int zdim, int[] data)
        {
            XDim = xdim;
            YDim = ydim;
            ZDim = zdim;
            Length = xdim * ydim * zdim;
            DataWidth = 32;
            _data = data;
        }

        public void Clear()
        {
            Array.Clear(_data, 0, _data.Length);
        }

        public int GetIndex(int x, int y, int z)
        {
            return (y * XDim * ZDim) + (z * XDim) + x;
        }

        public void GetMultiIndex(int index, out int x, out int y, out int z)
        {
            var ysize = XDim * ZDim;
            y = index / ysize;
            var yrem = index % ysize;
            z = yrem / XDim;
            x = yrem % XDim;
        }
    }
}
