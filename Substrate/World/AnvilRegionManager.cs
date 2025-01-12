using System;
using System.IO;
using Substrate.Core;

namespace Substrate.World
{
    public class AnvilRegionManager : RegionManager
    {
        int _dataVersion;

        public AnvilRegionManager(string regionDir, ChunkCache cache, int dataVersion)
            : base(regionDir, cache)
        {
            _dataVersion = dataVersion;
        }

        protected override IRegion CreateRegionCore(int rx, int rz)
        {
            return new AnvilRegion(this, _chunkCache, rx, rz, _dataVersion);
        }

        protected override RegionFile CreateRegionFileCore(int rx, int rz)
        {
            string fp = $"r.{rx}.{rz}.mca";
            return new RegionFile(Path.Combine(GetRegionPath(), fp));
        }

        protected override void DeleteRegionCore(IRegion region)
        {
            var r = region as IDisposable;
            r?.Dispose();
        }

        public override IRegion GetRegion(string filename)
        {
            if (!AnvilRegion.ParseFileName(filename, out var rx, out var rz))
            {
                throw new ArgumentException($"Malformed region file name: {filename}", "filename");
            }

            return GetRegion(rx, rz);
        }
    }
}
