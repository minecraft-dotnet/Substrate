﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Substrate
{
    public class RegionManager
    {
        protected string _regionPath;

        protected Dictionary<RegionKey, Region> _cache;

        public RegionManager (string regionDir)
        {
            _regionPath = regionDir;
            _cache = new Dictionary<RegionKey, Region>();
        }

        public Region GetRegion (int rx, int rz)
        {
            RegionKey k = new RegionKey(rx, rz);
            Region r;

            try {
                if (_cache.TryGetValue(k, out r) == false) {
                    r = new Region(this, rx, rz);
                    _cache.Add(k, r);
                }
                return r;
            }
            catch (FileNotFoundException) {
                _cache.Add(k, null);
                return null;
            }
        }

        public Region GetRegion (string filename)
        {
            int rx, rz;
            if (!Region.ParseFileName(filename, out rx, out rz)) {
                throw new ArgumentException("Malformed region file name: " + filename, "filename");
            }

            return GetRegion(rx, rz);
        }

        public string GetRegionPath ()
        {
            return _regionPath;
        }

        public bool DeleteRegion (int rx, int rz)
        {
            Region r = GetRegion(rx, rz);
            if (r == null) {
                return false;
            }

            RegionKey k = new RegionKey(rx, rz);
            _cache.Remove(k);

            r.Dispose();

            try {
                File.Delete(r.GetFilePath());
            }
            catch (Exception e) {
                Console.WriteLine("NOTICE: " + e.Message);
                return false;
            }

            return true;
        }
    }
}
