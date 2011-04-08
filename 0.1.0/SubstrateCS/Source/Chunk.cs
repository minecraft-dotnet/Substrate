﻿using System;
using System.IO;

namespace Substrate
{
    using NBT;
    using Utility;
    using System.Collections.Generic;

    public class Chunk : IChunk, INBTObject<Chunk>, ICopyable<Chunk>
    {
        public static NBTCompoundNode LevelSchema = new NBTCompoundNode()
        {
            new NBTCompoundNode("Level")
            {
                new NBTArrayNode("Blocks", 32768),
                new NBTArrayNode("Data", 16384),
                new NBTArrayNode("SkyLight", 16384),
                new NBTArrayNode("BlockLight", 16384),
                new NBTArrayNode("HeightMap", 256),
                new NBTListNode("Entities", NBT_Type.TAG_COMPOUND),
                new NBTListNode("TileEntities", NBT_Type.TAG_COMPOUND, TileEntity.BaseSchema),
                new NBTScalerNode("LastUpdate", NBT_Type.TAG_LONG),
                new NBTScalerNode("xPos", NBT_Type.TAG_INT),
                new NBTScalerNode("zPos", NBT_Type.TAG_INT),
                new NBTScalerNode("TerrainPopulated", NBT_Type.TAG_BYTE),
            },
        };

        private NBT_Tree _tree;

        private int _cx;
        private int _cz;

        protected NBT_ByteArray _blocks;
        protected NibbleArray _data;
        protected NibbleArray _blockLight;
        protected NibbleArray _skyLight;
        protected NBT_ByteArray _heightMap;

        protected NBT_List _entities;
        protected NBT_List _tileEntities;

        protected Dictionary<BlockKey, NBT_Compound> _tileEntityTable;

        public int X
        {
            get { return _cx; }
        }

        public int Z
        {
            get { return _cz; }
        }

        public NBT_Tree Tree
        {
            get { return _tree; }
        }

        public bool IsTerrainPopulated
        {
            get { return _tree.Root["Level"].ToNBTCompound()["TerrainPopulated"].ToNBTByte() == 1; }
            set { _tree.Root["Level"].ToNBTCompound()["TerrainPopulated"].ToNBTByte().Data = (byte)(value ? 1 : 0); }
        }

        public Chunk (int x, int z)
        {
            _cx = x;
            _cz = z;

            BuildNBTTree();

            BuildTileEntityCache();
        }

        public Chunk (NBT_Tree tree)
        {
            if (LoadTreeSafe(tree.Root) == null) {
                throw new InvalidNBTObjectException();
            }
        }

        private void BuildNBTTree ()
        {
            int elements2 = XDim * ZDim;
            int elements3 = elements2 *YDim;

            _blocks = new NBT_ByteArray(new byte[elements3]);
            NBT_ByteArray data = new NBT_ByteArray(new byte[elements3 >> 1]);
            NBT_ByteArray blocklight = new NBT_ByteArray(new byte[elements3 >> 1]);
            NBT_ByteArray skylight = new NBT_ByteArray(new byte[elements3 >> 1]);
            _heightMap = new NBT_ByteArray(new byte[elements2]);
            _entities = new NBT_List(NBT_Type.TAG_COMPOUND);
            _tileEntities = new NBT_List(NBT_Type.TAG_COMPOUND);

            _data = new NibbleArray(data.Data);
            _blockLight = new NibbleArray(blocklight.Data);
            _skyLight = new NibbleArray(skylight.Data);

            NBT_Compound level = new NBT_Compound();
            level.Add("Blocks", _blocks);
            level.Add("Data", data);
            level.Add("SkyLight", blocklight);
            level.Add("BlockLight", skylight);
            level.Add("HeightMap", _heightMap);
            level.Add("Entities", _entities);
            level.Add("TileEntities", _tileEntities);
            level.Add("LastUpdate", new NBT_Long());
            level.Add("xPos", new NBT_Int());
            level.Add("zPos", new NBT_Int());
            level.Add("TerrainPopulated", new NBT_Byte());

            _tree = new NBT_Tree();
            _tree.Root.Add("Level", level);
        }

        public int BlockGlobalX (int x)
        {
            return _cx * XDim + x;
        }

        public int BlockGlobalY (int y)
        {
            return y;
        }

        public int BlockGlobalZ (int z)
        {
            return _cz * XDim + z;
        }

        public int BlockLocalX (int x)
        {
            return x;
        }

        public int BlockLocalY (int y)
        {
            return y;
        }

        public int BlockLocalZ (int z)
        {
            return z;
        }

        public bool Save (Stream outStream)
        {
            if (outStream == null || !outStream.CanWrite) {
                return false;
            }

            _tree.WriteTo(outStream);
            outStream.Close();

            return true;
        }

        public Block GetBlock (int lx, int ly, int lz)
        {
            return new Block(this, lx, ly, lz);
        }

        public BlockRef GetBlockRef (int lx, int ly, int lz)
        {
            return new BlockRef(this, lx, ly, lz);
        }

        public void SetBlock (int lx, int ly, int lz, Block block)
        {
            int index = lx << 11 | lz << 7 | ly;

            SetBlockID(lx, ly, lz, block.ID);
            SetBlockData(lx, ly, lz, block.Data);

            SetTileEntity(lx, ly, lz, block.GetTileEntity().Copy());
        }

        public int CountBlockID (int id)
        {
            int c = 0;
            for (int i = 0; i < _blocks.Length; i++) {
                if (_blocks[i] == id) {
                    c++;
                }
            }

            return c;
        }

        public int CountBlockData (int id, int data)
        {
            int c = 0;
            for (int i = 0; i < _blocks.Length; i++) {
                if (_blocks[i] == id && _data[i] == data) {
                    c++;
                }
            }

            return c;
        }

        public int CountEntities ()
        {
            return _entities.Count;
        }

        public int GetHeight (int lx, int lz)
        {
            return _heightMap[lz << 4 | lx];
        }

        private void CreateTileEntity (int lx, int ly, int lz)
        {
            BlockInfoEx info = GetBlockInfo(lx, ly, lz) as BlockInfoEx;
            if (info == null) {
                return;
            }

            TileEntity te = TileEntityFactory.Create(info.TileEntityName);
            if (te == null) {
                return;
            }

            te.X = BlockGlobalX(lx);
            te.Y = BlockGlobalY(ly);
            te.Z = BlockGlobalZ(lz);

            _tileEntities.Add(te.BuildTree());
        }

        public virtual void SetLocation (int x, int z)
        {
            int diffx = x - _cx;
            int diffz = z - _cz;

            _cx = x;
            _cz = z;

            BuildTileEntityCache();
        }

        private void BuildTileEntityCache ()
        {
            _tileEntityTable = new Dictionary<BlockKey, NBT_Compound>();

            foreach (NBT_Compound te in _tileEntities) {
                int tex = te["x"].ToNBTInt();
                int tey = te["y"].ToNBTInt();
                int tez = te["z"].ToNBTInt();

                BlockKey key = new BlockKey(tex, tey, tez);
                _tileEntityTable[key] = te;
            }
        }


        #region IBoundedBlockContainer Members

        public int XDim
        {
            get { return 16; }
        }

        public int YDim
        {
            get { return 128; }
        }

        public int ZDim
        {
            get { return 16; }
        }

        #endregion


        #region IBlockContainer Members

        IBlock IBlockContainer.GetBlock (int lx, int ly, int lz)
        {
            return GetBlock(lx, ly, lz);
        }

        IBlock IBlockContainer.GetBlockRef (int lx, int ly, int lz)
        {
            return GetBlockRef(lx, ly, lz);
        }

        public void SetBlock (int lx, int ly, int lz, IBlock block)
        {
            int index = lx << 11 | lz << 7 | ly;
            int oldid = _blocks.Data[index];

            SetBlockID(lx, ly, lz, block.ID);
            SetBlockData(lx, ly, lz, block.Data);

            // Update tile entities

            BlockInfoEx info1 = BlockInfo.BlockTable[oldid] as BlockInfoEx;
            BlockInfoEx info2 = BlockInfo.BlockTable[block.ID] as BlockInfoEx;

            if (info1 != info2) {
                if (info1 != null) {
                    ClearTileEntity(lx, ly, lz);
                }

                if (info2 != null) {
                    CreateTileEntity(lx, ly, lz);
                }
            }
        }

        public BlockInfo GetBlockInfo (int lx, int ly, int lz)
        {
            return BlockInfo.BlockTable[GetBlockID(lx, ly, lz)];
        }

        public int GetBlockID (int lx, int ly, int lz)
        {
            return _blocks.Data[lx << 11 | lz << 7 | ly];
        }

        public int GetBlockData (int lx, int ly, int lz)
        {
            return _data[lx << 11 | lz << 7 | ly];
        }

        public bool SetBlockID (int lx, int ly, int lz, int id)
        {
            int index = lx << 11 | lz << 7 | ly;
            int oldid = _blocks.Data[index];

            if (oldid == id) {
                return false;
            }

            // Update value

            _blocks.Data[index] = (byte)id;

            // Update tile entities

            BlockInfoEx info1 = BlockInfo.BlockTable[oldid] as BlockInfoEx;
            BlockInfoEx info2 = BlockInfo.BlockTable[id] as BlockInfoEx;

            if (info1 != info2) {
                if (info1 != null) {
                    ClearTileEntity(lx, ly, lz);
                }

                if (info2 != null) {
                    CreateTileEntity(lx, ly, lz);
                }
            }

            // Update height map

            if (BlockInfo.BlockTable[id] != null) {
                int tileHeight = GetHeight(lx, lz);
                int newOpacity = BlockInfo.BlockTable[id].Opacity;

                if (ly > tileHeight && newOpacity > BlockInfo.MIN_OPACITY) {
                    _heightMap[lz << 4 | lx] = (byte)ly;
                }
                else if (ly == tileHeight && newOpacity == BlockInfo.MIN_OPACITY) {
                    for (int i = ly - 1; i >= 0; i--) {
                        if (BlockInfo.BlockTable[GetBlockID(lx, i, lz)].Opacity > BlockInfo.MIN_OPACITY) {
                            _heightMap[lz << 4 | lx] = (byte)i;
                            break;
                        }
                    }
                }
            }

            return true;
        }

        public bool SetBlockData (int lx, int ly, int lz, int data)
        {
            int index = lx << 11 | lz << 7 | ly;
            if (_data[index] == data) {
                return false;
            }

            /*if (BlockManager.EnforceDataLimits && BlockInfo.BlockTable[_blocks[index]] != null) {
                if (!BlockInfo.BlockTable[_blocks[index]].TestData(data)) {
                    return false;
                }
            }*/

            _data[index] = data;
            return true;
        }

        #endregion


        #region ILitBlockContainer Members

        ILitBlock ILitBlockContainer.GetBlock (int lx, int ly, int lz)
        {
            throw new NotImplementedException();
        }

        ILitBlock ILitBlockContainer.GetBlockRef (int lx, int ly, int lz)
        {
            return GetBlockRef(lx, ly, lz);
        }

        public void SetBlock (int lx, int ly, int lz, ILitBlock block)
        {
            int index = lx << 11 | lz << 7 | ly;
            int oldid = _blocks.Data[index];

            SetBlockID(lx, ly, lz, block.ID);
            SetBlockData(lx, ly, lz, block.Data);

            // Update tile entities

            BlockInfoEx info1 = BlockInfo.BlockTable[oldid] as BlockInfoEx;
            BlockInfoEx info2 = BlockInfo.BlockTable[block.ID] as BlockInfoEx;

            if (info1 != info2) {
                if (info1 != null) {
                    ClearTileEntity(lx, ly, lz);
                }

                if (info2 != null) {
                    CreateTileEntity(lx, ly, lz);
                }
            }
        }

        public int GetBlockLight (int lx, int ly, int lz)
        {
            return _blockLight[lx << 11 | lz << 7 | ly];
        }

        public int GetBlockSkyLight (int lx, int ly, int lz)
        {
            return _skyLight[lx << 11 | lz << 7 | ly];
        }

        public bool SetBlockLight (int lx, int ly, int lz, int light)
        {
            int index = lx << 11 | lz << 7 | ly;
            if (_blockLight[index] == light) {
                return false;
            }

            _blockLight[index] = light;
            return true;
        }

        public bool SetBlockSkyLight (int lx, int ly, int lz, int light)
        {
            int index = lx << 11 | lz << 7 | ly;
            if (_skyLight[index] == light) {
                return false;
            }

            _skyLight[index] = light;
            return true;
        }

        #endregion


        #region IPropertyBlockContainer Members

        IPropertyBlock IPropertyBlockContainer.GetBlock (int lx, int ly, int lz)
        {
            return GetBlock(lx, ly, lz);
        }

        IPropertyBlock IPropertyBlockContainer.GetBlockRef (int lx, int ly, int lz)
        {
            return GetBlockRef(lx, ly, lz);
        }

        public void SetBlock (int lx, int ly, int lz, IPropertyBlock block)
        {
            int index = lx << 11 | lz << 7 | ly;

            SetBlockID(lx, ly, lz, block.ID);
            SetBlockData(lx, ly, lz, block.Data);

            SetTileEntity(lx, ly, lz, block.GetTileEntity().Copy());
        }

        public TileEntity GetTileEntity (int lx, int ly, int lz)
        {
            int x = BlockGlobalX(lx);
            int y = BlockGlobalY(ly);
            int z = BlockGlobalZ(lz);

            BlockKey key = new BlockKey(x, y, z);
            NBT_Compound te;

            if (!_tileEntityTable.TryGetValue(key, out te)) {
                return null;
            }

            return TileEntityFactory.Create(te);
        }

        public bool SetTileEntity (int lx, int ly, int lz, TileEntity te)
        {
            BlockInfoEx info = GetBlockInfo(lx, ly, lz) as BlockInfoEx;
            if (info == null) {
                return false;
            }

            if (te.GetType() != TileEntityFactory.Lookup(info.TileEntityName)) {
                return false;
            }

            int x = BlockGlobalX(lx);
            int y = BlockGlobalY(ly);
            int z = BlockGlobalZ(lz);

            BlockKey key = new BlockKey(x, y, z);
            NBT_Compound oldte;

            if (_tileEntityTable.TryGetValue(key, out oldte)) {
                _tileEntities.Remove(oldte);
            }

            te.X = x;
            te.Y = y;
            te.Z = z;

            NBT_Compound tree = te.BuildTree() as NBT_Compound;

            _tileEntities.Add(tree);
            _tileEntityTable[key] = tree;

            return true;
        }

        public bool ClearTileEntity (int lx, int ly, int lz)
        {
            int x = BlockGlobalX(lx);
            int y = BlockGlobalY(ly);
            int z = BlockGlobalZ(lz);

            BlockKey key = new BlockKey(x, y, z);
            NBT_Compound te;

            if (!_tileEntityTable.TryGetValue(key, out te)) {
                return false;
            }

            _tileEntities.Remove(te);
            _tileEntityTable.Remove(key);

            return true;
        }

        #endregion


        #region ICopyable<Chunk> Members

        public Chunk Copy ()
        {
            return new Chunk(_tree.Copy());
        }

        #endregion


        #region INBTObject<Chunk> Members

        public Chunk LoadTree (NBT_Value tree)
        {
            NBT_Compound ctree = tree as NBT_Compound;
            if (ctree == null) {
                return null;
            }

            _tree = new NBT_Tree(ctree);
 
            NBT_Compound level = _tree.Root["Level"] as NBT_Compound;

            _blocks = level["Blocks"] as NBT_ByteArray;
            _data = new NibbleArray(level["Data"].ToNBTByteArray().Data);
            _blockLight = new NibbleArray(level["BlockLight"].ToNBTByteArray().Data);
            _skyLight = new NibbleArray(level["SkyLight"].ToNBTByteArray().Data);
            _heightMap = level["HeightMap"] as NBT_ByteArray;

            _entities = level["Entities"] as NBT_List;
            _tileEntities = level["TileEntities"] as NBT_List;

            // List-type patch up
            if (_entities.Count == 0) {
                level["Entities"] = new NBT_List(NBT_Type.TAG_COMPOUND);
                _entities = level["Entities"] as NBT_List;
            }

            if (_tileEntities.Count == 0) {
                level["TileEntities"] = new NBT_List(NBT_Type.TAG_COMPOUND);
                _tileEntities = level["TileEntities"] as NBT_List;
            }

            _cx = level["xPos"].ToNBTInt();
            _cz = level["zPos"].ToNBTInt();

            BuildTileEntityCache();

            return this;
        }

        public Chunk LoadTreeSafe (NBT_Value tree)
        {
            if (!ValidateTree(tree)) {
                return null;
            }

            return LoadTree(tree);
        }

        public NBT_Value BuildTree ()
        {
            return _tree.Root;
        }

        public bool ValidateTree (NBT_Value tree)
        {
            return new NBTVerifier(tree, LevelSchema).Verify();
        }

        #endregion


        #region IEntityContainer Members

        public List<Entity> FindEntities (string id)
        {
            List<Entity> set = new List<Entity>();

            foreach (NBT_Compound ent in _entities) {
                NBT_Value eid;
                if (!ent.TryGetValue("id", out eid)) {
                    continue;
                }

                if (eid.ToNBTString().Data != id) {
                    continue;
                }

                Entity obj = EntityFactory.Create(ent);
                if (obj != null) {
                    set.Add(obj);
                }
            }

            return set;
        }

        public List<Entity> FindEntities (Predicate<Entity> match)
        {
            List<Entity> set = new List<Entity>();

            foreach (NBT_Compound ent in _entities) {
                Entity obj = EntityFactory.Create(ent);
                if (obj == null) {
                    continue;
                }

                if (match(obj)) {
                    set.Add(obj);
                }
            }

            return set;
        }

        public bool AddEntity (Entity ent)
        {
            double xlow = _cx * XDim;
            double xhigh = xlow + XDim;
            double zlow = _cz * ZDim;
            double zhigh = zlow + ZDim;

            Entity.Vector3 pos = ent.Position;
            if (!(pos.X >= xlow && pos.X < xhigh && pos.Z >= zlow && pos.Z < zhigh)) {
                return false;
            }

            _entities.Add(ent.BuildTree());
            return true;
        }

        public int RemoveEntities (string id)
        {
            return _entities.RemoveAll(val => {
                NBT_Compound cval = val as NBT_Compound;
                if (cval == null) {
                    return false;
                }

                NBT_Value sval;
                if (!cval.TryGetValue("id", out sval)) {
                    return false;
                }

                return (sval.ToNBTString().Data == id);
            });
        }

        public int RemoveEntities (Predicate<Entity> match)
        {
            return _entities.RemoveAll(val => {
                NBT_Compound cval = val as NBT_Compound;
                if (cval == null) {
                    return false;
                }

                Entity obj = EntityFactory.Create(cval);
                if (obj == null) {
                    return false;
                }

                return match(obj);
            });
        }

        #endregion
    }
}
