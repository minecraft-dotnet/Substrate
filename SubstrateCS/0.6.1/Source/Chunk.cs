﻿using System;
using System.IO;
using System.Collections.Generic;

namespace Substrate
{
    using NBT;
    using Utility;

    /// <summary>
    /// A Minecraft Alpha-compatible chunk data structure.
    /// </summary>
    /// <remarks>
    /// A Chunk internally wraps an NBT_Tree of raw chunk data.  Modifying the chunk will update the tree, and vice-versa.
    /// </remarks>
    public class Chunk : IChunk, INBTObject<Chunk>, ICopyable<Chunk>
    {
        private const int XDIM = 16;
        private const int YDIM = 128;
        private const int ZDIM = 16;

        /// <summary>
        /// An NBT Schema definition for valid chunk data.
        /// </summary>
        public static NBTCompoundNode LevelSchema = new NBTCompoundNode()
        {
            new NBTCompoundNode("Level")
            {
                new NBTArrayNode("Blocks", 32768),
                new NBTArrayNode("Data", 16384),
                new NBTArrayNode("SkyLight", 16384),
                new NBTArrayNode("BlockLight", 16384),
                new NBTArrayNode("HeightMap", 256),
                new NBTListNode("Entities", TagType.TAG_COMPOUND, 0, NBTOptions.CREATE_ON_MISSING),
                new NBTListNode("TileEntities", TagType.TAG_COMPOUND, TileEntity.BaseSchema, NBTOptions.CREATE_ON_MISSING),
                new NBTScalerNode("LastUpdate", TagType.TAG_LONG, NBTOptions.CREATE_ON_MISSING),
                new NBTScalerNode("xPos", TagType.TAG_INT),
                new NBTScalerNode("zPos", TagType.TAG_INT),
                new NBTScalerNode("TerrainPopulated", TagType.TAG_BYTE, NBTOptions.CREATE_ON_MISSING),
            },
        };

        private NBT_Tree _tree;

        private int _cx;
        private int _cz;

        private XZYByteArray _blocks;
        private XZYNibbleArray _data;
        private XZYNibbleArray _blockLight;
        private XZYNibbleArray _skyLight;
        private ZXByteArray _heightMap;

        private TagList _entities;
        private TagList _tileEntities;

        private AlphaBlockCollection _blockManager;
        private EntityCollection _entityManager;

        /// <summary>
        /// Gets the global X-coordinate of the chunk.
        /// </summary>
        public int X
        {
            get { return _cx; }
        }

        /// <summary>
        /// Gets the global Z-coordinate of the chunk.
        /// </summary>
        public int Z
        {
            get { return _cz; }
        }

        /// <summary>
        /// Gets the collection of all blocks and their data stored in the chunk.
        /// </summary>
        public AlphaBlockCollection Blocks
        {
            get { return _blockManager; }
        }

        /// <summary>
        /// Gets the collection of all entities stored in the chunk.
        /// </summary>
        public EntityCollection Entities
        {
            get { return _entityManager; }
        }

        /// <summary>
        /// Provides raw access to the underlying NBT_Tree.
        /// </summary>
        public NBT_Tree Tree
        {
            get { return _tree; }
        }

        /// <summary>
        /// Gets or sets the chunk's TerrainPopulated status.
        /// </summary>
        public bool IsTerrainPopulated
        {
            get { return _tree.Root["Level"].ToTagCompound()["TerrainPopulated"].ToTagByte() == 1; }
            set { _tree.Root["Level"].ToTagCompound()["TerrainPopulated"].ToTagByte().Data = (byte)(value ? 1 : 0); }
        }


        private Chunk ()
        {
        }

        /// <summary>
        /// Creates a default (empty) chunk.
        /// </summary>
        /// <param name="x">Global X-coordinate of the chunk.</param>
        /// <param name="z">Global Z-coordinate of the chunk.</param>
        /// <returns>A new Chunk object.</returns>
        public static Chunk Create (int x, int z)
        {
            Chunk c = new Chunk();

            c._cx = x;
            c._cz = z;

            c.BuildNBTTree();

            return c;
        }

        /// <summary>
        /// Creates a chunk object from an existing NBT_Tree.
        /// </summary>
        /// <param name="tree">An NBT_Tree conforming to the chunk schema definition.</param>
        /// <returns>A new Chunk object wrapping an existing NBT_Tree.</returns>
        public static Chunk Create (NBT_Tree tree)
        {
            Chunk c = new Chunk();

            return c.LoadTree(tree.Root);
        }

        /// <summary>
        /// Creates a chunk object from a verified NBT_Tree.
        /// </summary>
        /// <param name="tree">An NBT_Tree conforming to the chunk schema definition.</param>
        /// <returns>A new Chunk object wrapping an existing NBT_Tree, or null on verification failure.</returns>
        public static Chunk CreateVerified (NBT_Tree tree)
        {
            Chunk c = new Chunk();

            return c.LoadTreeSafe(tree.Root);
        }

        /// <summary>
        /// Updates the chunk's global world coordinates.
        /// </summary>
        /// <param name="x">Global X-coordinate.</param>
        /// <param name="z">Global Z-coordinate.</param>
        public virtual void SetLocation (int x, int z)
        {
            _cx = x;
            _cz = z;
        }

        /// <summary>
        /// Saves a Chunk's underlying NBT_Tree to an output stream.
        /// </summary>
        /// <param name="outStream">An open, writable output stream.</param>
        /// <returns>True if the data is written out to the stream.</returns>
        public bool Save (Stream outStream)
        {
            if (outStream == null || !outStream.CanWrite) {
                return false;
            }

            _tree.WriteTo(outStream);
            outStream.Close();

            return true;
        }


        #region INBTObject<Chunk> Members

        /// <summary>
        /// Loads the Chunk from an NBT tree rooted at the given TagValue node.
        /// </summary>
        /// <param name="tree">Root node of an NBT tree.</param>
        /// <returns>A reference to the current Chunk, or null if the tree is unparsable.</returns>
        public Chunk LoadTree (TagValue tree)
        {
            TagCompound ctree = tree as TagCompound;
            if (ctree == null) {
                return null;
            }

            _tree = new NBT_Tree(ctree);

            TagCompound level = _tree.Root["Level"] as TagCompound;

            _blocks = new XZYByteArray(XDIM, YDIM, ZDIM, level["Blocks"] as TagByteArray);
            _data = new XZYNibbleArray(XDIM, YDIM, ZDIM, level["Data"] as TagByteArray);
            _blockLight = new XZYNibbleArray(XDIM, YDIM, ZDIM, level["BlockLight"] as TagByteArray);
            _skyLight = new XZYNibbleArray(XDIM, YDIM, ZDIM, level["SkyLight"] as TagByteArray);
            _heightMap = new ZXByteArray(XDIM, ZDIM, level["HeightMap"] as TagByteArray);

            _entities = level["Entities"] as TagList;
            _tileEntities = level["TileEntities"] as TagList;

            // List-type patch up
            if (_entities.Count == 0) {
                level["Entities"] = new TagList(TagType.TAG_COMPOUND);
                _entities = level["Entities"] as TagList;
            }

            if (_tileEntities.Count == 0) {
                level["TileEntities"] = new TagList(TagType.TAG_COMPOUND);
                _tileEntities = level["TileEntities"] as TagList;
            }

            _cx = level["xPos"].ToTagInt();
            _cz = level["zPos"].ToTagInt();

            _blockManager = new AlphaBlockCollection(
                new BlockData(_blocks),
                new BlockDataData(_data),
                new BlockLightData(_blockLight, _skyLight, _heightMap),
                new BlockPropertyData(_tileEntities)
                );

            _entityManager = new EntityCollection(_entities);

            return this;
        }

        /// <summary>
        /// Loads the Chunk from a validated NBT tree rooted at the given TagValue node.
        /// </summary>
        /// <param name="tree">Root node of an NBT tree.</param>
        /// <returns>A reference to the current Chunk, or null if the tree does not conform to the chunk's NBT Schema definition.</returns>
        public Chunk LoadTreeSafe (TagValue tree)
        {
            if (!ValidateTree(tree)) {
                return null;
            }

            return LoadTree(tree);
        }

        /// <summary>
        /// Gets a valid NBT tree representing the Chunk.
        /// </summary>
        /// <returns>The root node of the Chunk's NBT tree.</returns>
        public TagValue BuildTree ()
        {
            return _tree.Root;
        }

        /// <summary>
        /// Validates an NBT tree against the chunk's NBT schema definition.
        /// </summary>
        /// <param name="tree">The root node of the NBT tree to verify.</param>
        /// <returns>Status indicating if the tree represents a valid chunk.</returns>
        public bool ValidateTree (TagValue tree)
        {
            NBTVerifier v = new NBTVerifier(tree, LevelSchema);
            return v.Verify();
        }

        #endregion


        #region ICopyable<Chunk> Members

        /// <summary>
        /// Creates a deep copy of the Chunk and its underlying NBT tree.
        /// </summary>
        /// <returns>A new Chunk with copied data.</returns>
        public Chunk Copy ()
        {
            return Chunk.Create(_tree.Copy());
        }

        #endregion


        private void BuildNBTTree ()
        {
            int elements2 = XDIM * ZDIM;
            int elements3 = elements2 * YDIM;

            TagByteArray blocks = new TagByteArray(new byte[elements3]);
            TagByteArray data = new TagByteArray(new byte[elements3 >> 1]);
            TagByteArray blocklight = new TagByteArray(new byte[elements3 >> 1]);
            TagByteArray skylight = new TagByteArray(new byte[elements3 >> 1]);
            TagByteArray heightMap = new TagByteArray(new byte[elements2]);

            _blocks = new XZYByteArray(XDIM, YDIM, ZDIM, blocks);
            _data = new XZYNibbleArray(XDIM, YDIM, ZDIM, data);
            _blockLight = new XZYNibbleArray(XDIM, YDIM, ZDIM, blocklight);
            _skyLight = new XZYNibbleArray(XDIM, YDIM, ZDIM, skylight);
            _heightMap = new ZXByteArray(XDIM, ZDIM, heightMap);

            _entities = new TagList(TagType.TAG_COMPOUND);
            _tileEntities = new TagList(TagType.TAG_COMPOUND);

            TagCompound level = new TagCompound();
            level.Add("Blocks", blocks);
            level.Add("Data", data);
            level.Add("SkyLight", blocklight);
            level.Add("BlockLight", skylight);
            level.Add("HeightMap", heightMap);
            level.Add("Entities", _entities);
            level.Add("TileEntities", _tileEntities);
            level.Add("LastUpdate", new TagLong(Timestamp()));
            level.Add("xPos", new TagInt(_cx));
            level.Add("zPos", new TagInt(_cz));
            level.Add("TerrainPopulated", new TagByte());

            _tree = new NBT_Tree();
            _tree.Root.Add("Level", level);

            _blockManager = new AlphaBlockCollection(
                new BlockData(_blocks),
                new BlockDataData(_data),
                new BlockLightData(_blockLight, _skyLight, _heightMap),
                new BlockPropertyData(_tileEntities)
                );

            _entityManager = new EntityCollection(_entities);
        }

        private int Timestamp ()
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return (int)((DateTime.UtcNow - epoch).Ticks / (10000L * 1000L));
        }
    }
}
