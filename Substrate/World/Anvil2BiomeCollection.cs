using Substrate.Core;

namespace Substrate.World
{
    public class Anvil2BiomeCollection : IBiomeCollection
    {
        AnvilSection2[] _sections;
        private readonly int _xdim;
        private readonly int _zdim;

        public Anvil2BiomeCollection(AnvilSection2[] sections, int xDim, int zDim)
        {
            _sections = sections;

            _xdim = xDim;
            _zdim = zDim;
        }

        public int GetBiome(int x, int z)
        {
            return BiomeType.Plains;
            //return _sections[z * _xdim + x].Y;
        }

        public void SetBiome(int x, int z, int newBiome)
        {
            //_sections[z * _xdim + x].Y = newBiome;
        }
    }
}
