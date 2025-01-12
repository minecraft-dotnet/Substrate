using System;
using System.Collections.Generic;
using System.IO;
using Substrate.Core;
using Substrate.Nbt;

namespace Substrate.World
{
    /// <summary>
    /// New chunk format used in Minecraft 1.18 and later.
    /// </summary>
    public class AnvilChunk2 : IChunk, INbtObject<AnvilChunk2>, ICopyable<AnvilChunk2>
    {
        public static SchemaNodeCompound ChunkSchema = new SchemaNodeCompound()
        {
            new SchemaNodeCompound("Heightmaps") {
                new SchemaNodeLongArray("MOTION_BLOCKING", SchemaOptions.OPTIONAL),
                new SchemaNodeLongArray("MOTION_BLOCKING_NO_LEAVES", SchemaOptions.OPTIONAL),
                new SchemaNodeLongArray("OCEAN_FLOOR", SchemaOptions.OPTIONAL),
                new SchemaNodeLongArray("WORLD_SURFACE", SchemaOptions.OPTIONAL),
            },
            new SchemaNodeCompound("structures") {
                new SchemaNodeCompound("References"),
                new SchemaNodeCompound("starts"),
            },
            new SchemaNodeList("block_entities", TagType.TAG_COMPOUND, new SchemaNodeCompound() {
                new SchemaNodeCompound("listener", SchemaOptions.OPTIONAL) {
                    new SchemaNodeCompound("selector")
                    {
                        new SchemaNodeScalar("tick", TagType.TAG_LONG)
                    },
                    new SchemaNodeScalar("event_delay", TagType.TAG_INT)
                },
                new SchemaNodeList("cursors", TagType.TAG_COMPOUND, SchemaOptions.OPTIONAL),
                new SchemaNodeResourceLocation("id"),
                new SchemaNodeScalar("keepPacked", TagType.TAG_BYTE, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("last_vibration_frequency", TagType.TAG_INT, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("x", TagType.TAG_INT),
                new SchemaNodeScalar("y", TagType.TAG_INT),
                new SchemaNodeScalar("z", TagType.TAG_INT),
                new SchemaNodeList("Items", TagType.TAG_COMPOUND, Item.Schema, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("last_interacted_slot", TagType.TAG_INT, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("is_waxed", TagType.TAG_INT, SchemaOptions.OPTIONAL),
                new SchemaNodeCompound("front_text", SchemaOptions.OPTIONAL),
                new SchemaNodeCompound("back_text", SchemaOptions.OPTIONAL),
            }),
            new SchemaNodeList("block_ticks", TagType.TAG_COMPOUND, new SchemaNodeCompound() {
         
            }),
            new SchemaNodeList("fluid_ticks", TagType.TAG_COMPOUND, new SchemaNodeCompound() {
         
            }),
            new SchemaNodeList("PostProcessing", TagType.TAG_LIST,
                new SchemaNodeList("", TagType.TAG_SHORT)),
            new SchemaNodeList("sections", TagType.TAG_COMPOUND, AnvilSection2.Section2Schema, SchemaOptions.OPTIONAL),
            new SchemaNodeList("entities", TagType.TAG_COMPOUND, new SchemaNodeCompound() {
         
            }, SchemaOptions.OPTIONAL),
            new SchemaNodeList("Lights", TagType.TAG_LIST,
                new SchemaNodeList("", TagType.TAG_COMPOUND,
                    new SchemaNodeCompound() {
            }), SchemaOptions.OPTIONAL),
            new SchemaNodeCompound("CarvingMasks", SchemaOptions.OPTIONAL) {

            },
            new SchemaNodeScalar("DataVersion", TagType.TAG_INT),
            new SchemaNodeScalar("InhabitedTime", TagType.TAG_LONG),
            new SchemaNodeScalar("isLightOn", TagType.TAG_BYTE, SchemaOptions.OPTIONAL),
            new SchemaNodeScalar("LastUpdate", TagType.TAG_LONG),
            new SchemaNodeResourceLocation("Status"),
            new SchemaNodeScalar("xPos", TagType.TAG_INT),
            new SchemaNodeScalar("yPos", TagType.TAG_INT),
            new SchemaNodeScalar("zPos", TagType.TAG_INT),
        };

        private const int XDIM = 16;
        private const int YDIM = 256;
        private const int ZDIM = 16;

        private NbtTree _tree;

        private AnvilSection2[] _sections;

        private IDataArray3 _blocks;
        private IDataArray3 _data;
        private IDataArray3 _blockLight;
        private IDataArray3 _skyLight;

        private ZXIntArray _heightMap;
        //private ZXByteArray _biomes;

        private TagNodeList _entities;
        private TagNodeList _blockEntities;
        private TagNodeList _tileTicks;

        private AlphaBlockCollection _blockManager;
        private EntityCollection _entityManager;
        private Anvil2BiomeCollection _biomeManager;


        private AnvilChunk2()
        {
            _sections = new AnvilSection2[16];
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        public int Z { get; private set; }

        public int DataVersion { get; private set; }

        public AnvilSection2[] Sections
        {
            get { return _sections; }
        }

        public AlphaBlockCollection Blocks
        {
            get { return _blockManager; }
        }

        public IBiomeCollection Biomes
        {
            get { return _biomeManager; }
        }

        public EntityCollection Entities
        {
            get { return _entityManager; }
        }

        public NbtTree Tree
        {
            get { return _tree; }
        }

        public bool IsTerrainPopulated
        {
            get { return _tree.Root["Level"].ToTagCompound()["TerrainPopulated"].ToTagByte() == 1; }
            set { _tree.Root["Level"].ToTagCompound()["TerrainPopulated"].ToTagByte().Data = (byte)(value ? 1 : 0); }
        }

        public static AnvilChunk2 Create(int x, int z, int dataVersion)
        {
            AnvilChunk2 c = new AnvilChunk2();

            c.X = x;
            c.Z = z;
            c.DataVersion = dataVersion;

            c.BuildNBTTree();
            return c;
        }

        public static AnvilChunk2 Create(NbtTree tree)
        {
            AnvilChunk2 c = new AnvilChunk2();

            return c.LoadTree(tree.Root);
        }

        public static AnvilChunk2 CreateVerified(NbtTree tree)
        {
            AnvilChunk2 c = new AnvilChunk2();

            return c.LoadTreeSafe(tree.Root);
        }

        /// <summary>
        /// Updates the chunk's global world coordinates.
        /// </summary>
        /// <param name="x">Global X-coordinate.</param>
        /// <param name="z">Global Z-coordinate.</param>
        public virtual void SetLocation(int x, int z)
        {
            int diffx = (x - X) * XDIM;
            int diffz = (z - Z) * ZDIM;

            // Update chunk position

            X = x;
            Z = z;

            _tree.Root["Level"].ToTagCompound()["xPos"].ToTagInt().Data = x;
            _tree.Root["Level"].ToTagCompound()["zPos"].ToTagInt().Data = z;

            // Update tile entity coordinates

            List<TileEntity> tileEntites = new List<TileEntity>();
            foreach (TagNodeCompound tag in _blockEntities)
            {
                TileEntity te = TileEntityFactory.Create(tag);
                if (te == null)
                {
                    te = TileEntity.FromTreeSafe(tag);
                }

                if (te != null)
                {
                    te.MoveBy(diffx, 0, diffz);
                    tileEntites.Add(te);
                }
            }

            _blockEntities.Clear();
            foreach (TileEntity te in tileEntites)
            {
                _blockEntities.Add(te.BuildTree());
            }

            // Update tile tick coordinates

            if (_tileTicks != null)
            {
                List<TileTick> tileTicks = new List<TileTick>();
                foreach (TagNodeCompound tag in _tileTicks)
                {
                    TileTick tt = TileTick.FromTreeSafe(tag);

                    if (tt != null)
                    {
                        tt.MoveBy(diffx, 0, diffz);
                        tileTicks.Add(tt);
                    }
                }

                _tileTicks.Clear();
                foreach (TileTick tt in tileTicks)
                {
                    _tileTicks.Add(tt.BuildTree());
                }
            }

            // Update entity coordinates

            List<TypedEntity> entities = new List<TypedEntity>();
            foreach (TypedEntity entity in _entityManager)
            {
                entity.MoveBy(diffx, 0, diffz);
                entities.Add(entity);
            }

            _entities.Clear();
            foreach (TypedEntity entity in entities)
            {
                _entityManager.Add(entity);
            }
        }

        public bool Save(Stream outStream)
        {
            if (outStream == null || !outStream.CanWrite)
            {
                return false;
            }

            BuildConditional();

            NbtTree tree = new NbtTree();
            tree.Root["Level"] = BuildTree();

            tree.WriteTo(outStream);

            return true;
        }

        #region INbtObject<AnvilChunk2> Members

        public AnvilChunk2 LoadTree(TagNode tree)
        {
            TagNodeCompound ctree = tree as TagNodeCompound;
            if (ctree == null)
            {
                return null;
            }

            _tree = new NbtTree(ctree);

            TagNodeCompound root = _tree.Root;

            DataVersion = root["DataVersion"].ToTagInt();

            TagNodeList sections = root["sections"] as TagNodeList;
            foreach (TagNodeCompound section in sections)
            {
                AnvilSection2 anvilSection = new AnvilSection2(section);
                if (anvilSection.Y < 0 || anvilSection.Y >= _sections.Length)
                    continue;
                _sections[anvilSection.Y] = anvilSection;
            }

            IDataArray3[] blocksBA = new IDataArray3[_sections.Length];
            YZXNibbleArray[] dataBA = new YZXNibbleArray[_sections.Length];
            IDataArray3[] skyLightBA = new IDataArray3[_sections.Length];
            IDataArray3[] blockLightBA = new IDataArray3[_sections.Length];

            for (int i = 0; i < _sections.Length; i++)
            {
                if (_sections[i] == null)
                    _sections[i] = new AnvilSection2(i);

                blocksBA[i] = _sections[i].Blocks;
                dataBA[i] = _sections[i].Data;
                skyLightBA[i] = _sections[i].SkyLight;
                blockLightBA[i] = _sections[i].BlockLight;
            }

            _blocks = new CompositeDataArray3(blocksBA);
            //_data = new CompositeDataArray3(dataBA);
            _skyLight = new CompositeDataArray3(skyLightBA);
            _blockLight = new CompositeDataArray3(blockLightBA);

            //_heightMap = new ZXIntArray(XDIM, ZDIM, root["HeightMap"] as TagNodeIntArray);

            //if (root.ContainsKey("Biomes"))
            //    _biomes = new ZXByteArray(XDIM, ZDIM, root["Biomes"] as TagNodeByteArray);
            //else
            //{
            //    root["Biomes"] = new TagNodeByteArray(new byte[256]);
            //    _biomes = new ZXByteArray(XDIM, ZDIM, root["Biomes"] as TagNodeByteArray);
            //    for (int x = 0; x < XDIM; x++)
            //        for (int z = 0; z < ZDIM; z++)
            //            _biomes[x, z] = BiomeType.Default;
            //}

            //_entities = root["Entities"] as TagNodeList;
            //_tileEntities = root["TileEntities"] as TagNodeList;
            _blockEntities = root["block_entities"] as TagNodeList;

            //if (root.ContainsKey("TileTicks"))
            //    _tileTicks = root["TileTicks"] as TagNodeList;
            //else
            //    _tileTicks = new TagNodeList(TagType.TAG_COMPOUND);

            //// List-type patch up
            //if (_entities.Count == 0)
            //{
            //    root["Entities"] = new TagNodeList(TagType.TAG_COMPOUND);
            //    _entities = root["Entities"] as TagNodeList;
            //}

            //if (_tileEntities.Count == 0)
            //{
            //    root["TileEntities"] = new TagNodeList(TagType.TAG_COMPOUND);
            //    _tileEntities = root["TileEntities"] as TagNodeList;
            //}

            //if (_tileTicks.Count == 0)
            //{
            //    root["TileTicks"] = new TagNodeList(TagType.TAG_COMPOUND);
            //    _tileTicks = root["TileTicks"] as TagNodeList;
            //}

            X = root["xPos"].ToTagInt();
            Y = root["yPos"].ToTagInt();
            Z = root["zPos"].ToTagInt();

            _blockManager = new AlphaBlockCollection(_blocks, _data, _blockLight, _skyLight, _heightMap, _blockEntities, _tileTicks);
            _entityManager = new EntityCollection(_entities);
            _biomeManager = new Anvil2BiomeCollection(_sections, 4, 4);

            return this;
        }

        public AnvilChunk2 LoadTreeSafe(TagNode tree)
        {
            if (!ValidateTree(tree))
            {
                return null;
            }

            return LoadTree(tree);
        }

        private bool ShouldIncludeSection(AnvilSection2 section)
        {
            int y = (section.Y + 1) * section.Blocks.YDim;
            for (int i = 0; i < _heightMap.Length; i++)
                if (_heightMap[i] > y)
                    return true;

            return !section.CheckEmpty();
        }

        public TagNode BuildTree()
        {
            TagNodeCompound level = _tree.Root as TagNodeCompound;
            TagNodeCompound levelCopy = new TagNodeCompound();
            foreach (KeyValuePair<string, TagNode> node in level)
                levelCopy.Add(node.Key, node.Value);

            TagNodeList sections = new TagNodeList(TagType.TAG_COMPOUND);
            for (int i = 0; i < _sections.Length; i++)
                if (ShouldIncludeSection(_sections[i]))
                    sections.Add(_sections[i].BuildTree());

            levelCopy["Sections"] = sections;

            if (_tileTicks.Count == 0)
                levelCopy.Remove("TileTicks");

            return levelCopy;
        }

        public bool ValidateTree(TagNode tree)
        {
            NbtVerifier v = new NbtVerifier(tree, ChunkSchema);
            return v.Verify();
        }

        #endregion

        #region ICopyable<AnvilChunk2> Members

        public AnvilChunk2 Copy()
        {
            return Create(_tree.Copy());
        }

        #endregion

        private void BuildConditional()
        {
            TagNodeCompound level = _tree.Root["Level"] as TagNodeCompound;
            if (_tileTicks != _blockManager.TileTicks && _blockManager.TileTicks.Count > 0)
            {
                _tileTicks = _blockManager.TileTicks;
                level["TileTicks"] = _tileTicks;
            }
        }

        private void BuildNBTTree()
        {
            int elements2 = XDIM * ZDIM;

            _sections = new AnvilSection2[16];
            TagNodeList sections = new TagNodeList(TagType.TAG_COMPOUND);

            for (int i = 0; i < _sections.Length; i++)
            {
                _sections[i] = new AnvilSection2(i);
                sections.Add(_sections[i].BuildTree());
            }

            IDataArray3[] blocksBA = new IDataArray3[_sections.Length];
            YZXNibbleArray[] dataBA = new YZXNibbleArray[_sections.Length];
            IDataArray3[] skyLightBA = new IDataArray3[_sections.Length];
            IDataArray3[] blockLightBA = new IDataArray3[_sections.Length];

            for (int i = 0; i < _sections.Length; i++)
            {
                blocksBA[i] = _sections[i].Blocks;
                dataBA[i] = _sections[i].Data;
                skyLightBA[i] = _sections[i].SkyLight;
                blockLightBA[i] = _sections[i].BlockLight;
            }

            _blocks = new CompositeDataArray3(blocksBA);
            _data = new CompositeDataArray3(dataBA);
            _skyLight = new CompositeDataArray3(skyLightBA);
            _blockLight = new CompositeDataArray3(blockLightBA);

            TagNodeIntArray heightMap = new TagNodeIntArray(new int[elements2]);
            _heightMap = new ZXIntArray(XDIM, ZDIM, heightMap);

            //TagNodeByteArray biomes = new TagNodeByteArray(new byte[elements2]);
            //_biomes = new ZXByteArray(XDIM, ZDIM, biomes);
            //for (int x = 0; x < XDIM; x++)
            //    for (int z = 0; z < ZDIM; z++)
            //        _biomes[x, z] = BiomeType.Default;

            _entities = new TagNodeList(TagType.TAG_COMPOUND);
            _blockEntities = new TagNodeList(TagType.TAG_COMPOUND);
            _tileTicks = new TagNodeList(TagType.TAG_COMPOUND);

            _tree = new NbtTree();
            var root = _tree.Root;

            //root.Add("Sections", sections);
            //root.Add("HeightMap", heightMap);
            //root.Add("Biomes", biomes);
            //root.Add("Entities", _entities);
            //root.Add("TileEntities", _blockEntities);
            //root.Add("TileTicks", _tileTicks);
            //root.Add("LastUpdate", new TagNodeLong(Timestamp()));
            //root.Add("xPos", new TagNodeInt(X));
            //root.Add("yPos", new TagNodeInt(Y));
            //root.Add("zPos", new TagNodeInt(Z));
            //root.Add("TerrainPopulated", new TagNodeByte());

            _blockManager = new AlphaBlockCollection(_blocks, _data, _blockLight, _skyLight, _heightMap, _blockEntities);
            _entityManager = new EntityCollection(_entities);
        }

        private int Timestamp()
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return (int)((DateTime.UtcNow - epoch).Ticks / (10000L * 1000L));
        }
    }
}
