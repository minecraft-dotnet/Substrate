﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate
{

    public class BlockManager : IBlockManager
    {
        public const int MIN_X = -32000000;
        public const int MAX_X = 32000000;
        public const int MIN_Y = 0;
        public const int MAX_Y = 128;
        public const int MIN_Z = -32000000;
        public const int MAX_Z = 32000000;

        protected int _chunkXDim;
        protected int _chunkYDim;
        protected int _chunkZDim;
        protected int _chunkXMask;
        protected int _chunkYMask;
        protected int _chunkZMask;
        protected int _chunkXLog;
        protected int _chunkYLog;
        protected int _chunkZLog;

        protected IChunkManager _chunkMan;

        protected ChunkRef _cache;

        public BlockManager (IChunkManager cm)
        {
            _chunkMan = cm;

            Chunk c = new Chunk(0, 0);

            _chunkXDim = c.XDim;
            _chunkYDim = c.YDim;
            _chunkZDim = c.ZDim;
            _chunkXMask = _chunkXDim - 1;
            _chunkYMask = _chunkYDim - 1;
            _chunkZMask = _chunkZDim - 1;
            _chunkXLog = Log2(_chunkXDim);
            _chunkYLog = Log2(_chunkYDim);
            _chunkZLog = Log2(_chunkZDim);
        }

        public Block GetBlock (int x, int y, int z)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null || !Check(x, y, z)) {
                return null;
            }

            return _cache.GetBlock(x & _chunkXMask, y & _chunkYMask, z & _chunkZMask);
        }

        public BlockRef GetBlockRef (int x, int y, int z)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null || !Check(x, y, z)) {
                return null;
            }

            return _cache.GetBlockRef(x & _chunkXMask, y & _chunkYMask, z & _chunkZMask);
        }

        public void SetBlock (int x, int y, int z, Block block)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null || !Check(x, y, z)) {
                return;
            }

            _cache.SetBlock(x & _chunkXMask, y & _chunkYMask, z & _chunkZMask, block);
        }

        protected ChunkRef GetChunk (int x, int y, int z)
        {
            x >>= _chunkXLog;
            z >>= _chunkZLog;
            return _chunkMan.GetChunkRef(x, z);
        }

        private int Log2 (int x)
        {
            int c = 0;
            while (x > 1) {
                x >>= 1;
                c++;
            }
            return c;
        }

        /// <summary>
        /// Called by other block-specific 'get' and 'set' functions to filter
        /// out operations on some blocks.  Override this method in derrived
        /// classes to filter the entire BlockManager.
        /// </summary>
        protected virtual bool Check (int x, int y, int z)
        {
            return (x >= MIN_X) && (x < MAX_X) &&
                (y >= MIN_Y) && (y < MAX_Y) &&
                (z >= MIN_Z) && (z < MAX_Z);
        }

        #region IBlockContainer Members

        IBlock IBlockContainer.GetBlock (int x, int y, int z)
        {
            return GetBlock(x, y, z);
        }

        IBlock IBlockContainer.GetBlockRef (int x, int y, int z)
        {
            return GetBlockRef(x, y, z);
        }

        public void SetBlock (int x, int y, int z, IBlock block)
        {
            _cache.SetBlock(x, y, z, block);
        }

        public BlockInfo GetBlockInfo (int x, int y, int z)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null || !Check(x, y, z)) {
                return null;
            }

            return _cache.GetBlockInfo(x & _chunkXMask, y & _chunkYMask, z & _chunkZMask);
        }

        public int GetBlockID (int x, int y, int z)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null) {
                return 0;
            }

            return _cache.GetBlockID(x & _chunkXMask, y & _chunkYMask, z & _chunkZMask);
        }

        public int GetBlockData (int x, int y, int z)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null) {
                return 0;
            }

            return _cache.GetBlockData(x & _chunkXMask, y & _chunkYMask, z & _chunkZMask);
        }

        public bool SetBlockID (int x, int y, int z, int id)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null || !Check(x, y, z)) {
                return false;
            }

            return _cache.SetBlockID(x & _chunkXMask, y & _chunkYMask, z & _chunkZMask, id);
        }

        public bool SetBlockData (int x, int y, int z, int data)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null || !Check(x, y, z)) {
                return false;
            }

            return _cache.SetBlockData(x & _chunkXMask, y & _chunkYMask, z & _chunkZMask, data);
        }

        #endregion


        #region ILitBlockContainer Members

        ILitBlock ILitBlockContainer.GetBlock (int x, int y, int z)
        {
            throw new NotImplementedException();
        }

        ILitBlock ILitBlockContainer.GetBlockRef (int x, int y, int z)
        {
            return GetBlockRef(x, y, z);
        }

        public void SetBlock (int x, int y, int z, ILitBlock block)
        {
            _cache.SetBlock(x, y, z, block);
        }

        public int GetBlockLight (int x, int y, int z)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null) {
                return 0;
            }

            return _cache.GetBlockLight(x & _chunkXMask, y & _chunkYMask, z & _chunkZMask);
        }

        public int GetBlockSkyLight (int x, int y, int z)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null) {
                return 0;
            }

            return _cache.GetBlockSkyLight(x & _chunkXMask, y & _chunkYMask, z & _chunkZMask);
        }

        public bool SetBlockLight (int x, int y, int z, int light)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null || !Check(x, y, z)) {
                return false;
            }

            return _cache.SetBlockID(x & _chunkXMask, y & _chunkYMask, z & _chunkZMask, light);
        }

        public bool SetBlockSkyLight (int x, int y, int z, int light)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null || !Check(x, y, z)) {
                return false;
            }

            return _cache.SetBlockSkyLight(x & _chunkXMask, y & _chunkYMask, z & _chunkZMask, light);
        }

        #endregion


        #region IPropertyBlockContainer Members

        IPropertyBlock IPropertyBlockContainer.GetBlock (int x, int y, int z)
        {
            return GetBlock(x, y, z);
        }

        IPropertyBlock IPropertyBlockContainer.GetBlockRef (int x, int y, int z)
        {
            return GetBlockRef(x, y, z);
        }

        public void SetBlock (int x, int y, int z, IPropertyBlock block)
        {
            _cache.SetBlock(x, y, z, block);
        }

        public TileEntity GetTileEntity (int x, int y, int z)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null || !Check(x, y, z)) {
                return null;
            }

            return _cache.GetTileEntity(x & _chunkXMask, y & _chunkYMask, z & _chunkZMask);
        }

        public bool SetTileEntity (int x, int y, int z, TileEntity te)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null || !Check(x, y, z)) {
                return false;
            }

            return _cache.SetTileEntity(x & _chunkXMask, y & _chunkYMask, z & _chunkZMask, te);
        }

        public bool ClearTileEntity (int x, int y, int z)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null || !Check(x, y, z)) {
                return false;
            }

            return _cache.ClearTileEntity(x & _chunkXMask, y & _chunkYMask, z & _chunkZMask);
        }

        #endregion
    }

    /*public interface IBlockManager : IBlockContainer
    {
        Block GetBlock (int x, int y, int z);
        BlockRef GetBlockRef (int x, int y, int z);
        BlockInfo GetBlockInfo (int x, int y, int z);

        bool SetBlock (int x, int y, int z, Block block);
    }*/

    /*public class BlockManager : IBlockManager
    {
        public const int MIN_X = -32000000;
        public const int MAX_X = 32000000;
        public const int MIN_Y = 0;
        public const int MAX_Y = 128;
        public const int MIN_Z = -32000000;
        public const int MAX_Z = 32000000;

        public const int CHUNK_XLEN = 16;
        public const int CHUNK_YLEN = 128;
        public const int CHUNK_ZLEN = 16;

        public const int CHUNK_XLOG = 4;
        public const int CHUNK_YLOG = 7;
        public const int CHUNK_ZLOG = 4;

        public const int CHUNK_XMASK = 0xF;
        public const int CHUNK_YMASK = 0x7F;
        public const int CHUNK_ZMASK = 0xF;

        public static bool EnforceDataLimits = true;

        protected IChunkManager _chunkMan;

        protected ChunkRef _cache;

        public BlockManager (IChunkManager cm)
        {
            _chunkMan = cm;
        }

        public BlockManager (BlockManager bm)
        {
            _chunkMan = bm._chunkMan;
        }

        public int BlockGlobalX (int x)
        {
            return x;
        }

        public int BlockGlobalY (int y)
        {
            return y;
        }

        public int BlockGlobalZ (int z)
        {
            return z;
        }

        public int BlockLocalX (int x)
        {
            return x & CHUNK_XMASK;
        }

        public int BlockLocalY (int y)
        {
            return y & CHUNK_YMASK;
        }

        public int BlockLocalZ (int z)
        {
            return z & CHUNK_ZMASK;
        }

        public virtual Block GetBlock (int x, int y, int z)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null || !Check(x, y, z)) {
                return null;
            }

            return _cache.GetBlock(x & CHUNK_XMASK, y, z & CHUNK_ZMASK);
        }

        public virtual BlockRef GetBlockRef (int x, int y, int z)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null || !Check(x, y, z)) {
                return null;
            }

            return _cache.GetBlockRef(x & CHUNK_XMASK, y, z & CHUNK_ZMASK);
        }

        public virtual BlockInfo GetBlockInfo (int x, int y, int z)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null || !Check(x, y, z)) {
                return null;
            }

            return _cache.GetBlockInfo(x & CHUNK_XMASK, y, z & CHUNK_ZMASK);
        }

        public virtual int GetBlockID (int x, int y, int z)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null) {
                return 0;
            }

            return _cache.GetBlockID(x & CHUNK_XMASK, y, z & CHUNK_ZMASK);
        }

        public virtual int GetBlockData (int x, int y, int z)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null) {
                return 0;
            }

            return _cache.GetBlockData(x & CHUNK_XMASK, y, z & CHUNK_ZMASK);
        }

        public virtual int GetBlockLight (int x, int y, int z)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null) {
                return 0;
            }

            return _cache.GetBlockLight(x & CHUNK_XMASK, y, z & CHUNK_ZMASK);
        }

        public virtual int GetBlockSkyLight (int x, int y, int z)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null) {
                return 0;
            }

            return _cache.GetBlockSkyLight(x & CHUNK_XMASK, y, z & CHUNK_ZMASK);
        }

        public virtual void SetBlock (int x, int y, int z, Block block)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null || !Check(x, y, z)) {
                return;
            }

            _cache.SetBlock(x & CHUNK_XMASK, y, z & CHUNK_ZMASK, block);
        }

        public virtual bool SetBlockID (int x, int y, int z, int id)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null || !Check(x, y, z)) {
                return false;
            }

            return _cache.SetBlockID(x & CHUNK_XMASK, y, z & CHUNK_ZMASK, id);
        }

        public virtual bool SetBlockData (int x, int y, int z, int data)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null || !Check(x, y, z)) {
                return false;
            }

            return _cache.SetBlockData(x & CHUNK_XMASK, y, z & CHUNK_ZMASK, data);
        }

        public bool SetBlockLight (int x, int y, int z, int light)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null || !Check(x, y, z)) {
                return false;
            }

            return _cache.SetBlockID(x & CHUNK_XMASK, y, z & CHUNK_ZMASK, light);
        }

        public bool SetBlockSkyLight (int x, int y, int z, int light)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null || !Check(x, y, z)) {
                return false;
            }

            return _cache.SetBlockSkyLight(x & CHUNK_XMASK, y, z & CHUNK_ZMASK, light);
        }

        public virtual TileEntity GetTileEntity (int x, int y, int z)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null || !Check(x, y, z)) {
                return null;
            }

            return _cache.GetTileEntity(x & CHUNK_XMASK, y, z & CHUNK_ZMASK);
        }

        public virtual bool SetTileEntity (int x, int y, int z, TileEntity te)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null || !Check(x, y, z)) {
                return false;
            }

            return _cache.SetTileEntity(x & CHUNK_XMASK, y, z & CHUNK_ZMASK, te);
        }

        public virtual bool ClearTileEntity (int x, int y, int z)
        {
            _cache = GetChunk(x, y, z);
            if (_cache == null || !Check(x, y, z)) {
                return false;
            }

            return _cache.ClearTileEntity(x & CHUNK_XMASK, y, z & CHUNK_ZMASK);
        }

        protected ChunkRef GetChunk (int x, int y, int z)
        {
            x >>= CHUNK_XLOG;
            z >>= CHUNK_ZLOG;
            return _chunkMan.GetChunkRef(x, z);
        }

        /// <summary>
        /// Called by other block-specific 'get' and 'set' functions to filter
        /// out operations on some blocks.  Override this method in derrived
        /// classes to filter the entire BlockManager.
        /// </summary>
        protected virtual bool Check (int x, int y, int z) {
            return (x >= MIN_X) && (x < MAX_X) &&
                (y >= MIN_Y) && (y < MAX_Y) &&
                (z >= MIN_Z) && (z < MAX_Z);
        }
    }*/
}
