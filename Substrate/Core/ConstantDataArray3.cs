namespace Substrate.Core
{
    public class ConstantDataArray3 : IDataArray3
    {
        int constantValue;

        public int this[int i] { get => constantValue; set { } }
        public int this[int x, int y, int z] { get => constantValue; set { } }

        public int XDim { get; private set;  }
        public int YDim { get; private set; }
        public int ZDim { get; private set; }
        public int Length { get; private set; }
        public int DataWidth { get => 0; }

        public ConstantDataArray3(int xdim, int ydim, int zdim, int value)
        {
            XDim = xdim;
            YDim = ydim;
            ZDim = zdim;
            Length = xdim * ydim * zdim;
            constantValue = value;
        }

        public void Clear()
        {
        }

        public int GetIndex(int x, int y, int z)
        {
            return 0;
        }

        public void GetMultiIndex(int index, out int x, out int y, out int z)
        {
            x = 0;
            y = 0;
            z = 0;
        }
    }
}
