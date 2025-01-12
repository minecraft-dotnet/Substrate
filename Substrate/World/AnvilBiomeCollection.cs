using Substrate.Core;

namespace Substrate.World
{
    public class AnvilBiomeCollection : IBiomeCollection
    {
        private readonly int _xdim;
        private readonly int _zdim;

        private IDataArray2 _biomeMap;

        public AnvilBiomeCollection(IDataArray2 biomeMap)
        {
            _biomeMap = biomeMap;

            _xdim = _biomeMap.XDim;
            _zdim = _biomeMap.ZDim;
        }

        public int GetBiome(int x, int z)
        {
            return _biomeMap[x, z];
        }

        public void SetBiome(int x, int z, int newBiome)
        {
            _biomeMap[x, z] = newBiome;
        }
    }
}
