using System;
using System.Collections.Generic;
using Substrate.Core;
using Substrate.Nbt;

namespace Substrate
{
    public class AnvilBiomeCollection
    {
        public const int OCEAN = 0;
        public const int PLAINS = 1;
        public const int DESERT = 2;
        public const int EXTREME_HILLS = 3;
        public const int FOREST = 4;
        public const int TAIGA = 5;
        public const int SWAMPLAND = 6;
        public const int RIVER = 7;
        public const int HELL = 8;
        public const int SKY = 9;
        public const int FROZEN_OCEAN = 10;
        public const int FROZEN_RIVER = 11;
        public const int ICE_PLAINS = 12;
        public const int ICE_MOUNTAINS = 13;
        public const int MUSHROOM_ISLAND = 14;
        public const int MUSHROOM_ISLAND_SHORE = 15;
        public const int BEACH = 16;
        public const int DESERT_HILLS = 17;
        public const int FOREST_HILLS = 18;
        public const int TAIGA_HILLS = 19;
        public const int EXTREME_HILLS_EDGE = 20;
        public const int JUNGLE = 21;
        public const int JUNGLE_HILLS = 22;

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
