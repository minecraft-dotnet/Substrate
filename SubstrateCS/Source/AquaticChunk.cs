using System;
using System.Collections.Generic;
using System.Text;
using Substrate.Nbt;
using Substrate.Core;
using System.IO;

namespace Substrate
{
    public class AquaticChunk : IChunk, INbtObject<AquaticChunk>, ICopyable<AquaticChunk>
    {
        public static SchemaNodeCompound LevelSchema = new SchemaNodeCompound()
        {
            new SchemaNodeCompound("Level")
            {
                new SchemaNodeList("Sections", TagType.TAG_COMPOUND, AquaticSection.SectionSchema),
                new SchemaNodeList("Lights", TagType.TAG_LIST, SchemaOptions.OPTIONAL),
                new SchemaNodeList("PostProcessing", TagType.TAG_LIST, SchemaOptions.OPTIONAL),
                new SchemaNodeIntArray("Biomes", 256, SchemaOptions.OPTIONAL),
                new SchemaNodeCompound("Heightmaps", SchemaOptions.OPTIONAL) {
                    new SchemaNodeLongArray("OCEAN_FLOOR", 36, SchemaOptions.OPTIONAL),
                    new SchemaNodeLongArray("MOTION_BLOCKING_NO_LEAVES", 36, SchemaOptions.OPTIONAL),
                    new SchemaNodeLongArray("MOTION_BLOCKING", 36, SchemaOptions.OPTIONAL),
                    new SchemaNodeLongArray("WORLD_SURFACE", 36, SchemaOptions.OPTIONAL),
                    new SchemaNodeLongArray("LIGHT_BLOCKING", 36, SchemaOptions.OPTIONAL),
                },
                new SchemaNodeList("Entities", TagType.TAG_COMPOUND, SchemaOptions.CREATE_ON_MISSING),
                new SchemaNodeList("TileEntities", TagType.TAG_COMPOUND, TileEntity.Schema, SchemaOptions.CREATE_ON_MISSING),
                new SchemaNodeList("TileTicks", TagType.TAG_COMPOUND, TileTick.Schema, SchemaOptions.OPTIONAL),
                new SchemaNodeScaler("LastUpdate", TagType.TAG_LONG, SchemaOptions.CREATE_ON_MISSING),
                new SchemaNodeScaler("xPos", TagType.TAG_INT),
                new SchemaNodeScaler("zPos", TagType.TAG_INT),
                new SchemaNodeScaler("TerrainPopulated", TagType.TAG_BYTE, SchemaOptions.CREATE_ON_MISSING),
            },
        };

        private const int XDIM = 16;
        private const int YDIM = 256;
        private const int ZDIM = 16;

        private NbtTree _tree;

        private int _cx;
        private int _cz;

        private AquaticSection[] _sections;

        private IDataArray3 _blocks;
        private IDataArray3 _data;
        private IDataArray3 _blockLight;
        private IDataArray3 _skyLight;

        private ZXIntArray _heightMap;
        private IDataArray2 _biomes;
        private int _dataVersion;
        private bool _modern;
        private int _minimumSectionY;

        private TagNodeList _entities;
        private TagNodeList _tileEntities;
        private TagNodeList _tileTicks;

        private AlphaBlockCollection _blockManager;
        private EntityCollection _entityManager;
        private AquaticBiomeCollection _biomeManager;


        private AquaticChunk()
        {
            _sections = new AquaticSection[16];
        }

        public int X
        {
            get { return _cx; }
        }

        public int Z
        {
            get { return _cz; }
        }
        
        public AquaticSection[] Sections
        {
            get { return _sections; }
        }

        public AlphaBlockCollection Blocks
        {
            get { return _blockManager; }
        }

        public AquaticBiomeCollection Biomes
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
            get {
                TagNodeCompound chunk = ChunkTag;
                if (_modern) {
                    TagNode statusNode;
                    chunk.TryGetValue("Status", out statusNode);
                    TagNodeString status = statusNode as TagNodeString;
                    return status != null && status.Data == "full";
                }
                TagNode valueNode;
                chunk.TryGetValue("TerrainPopulated", out valueNode);
                TagNodeByte value = valueNode as TagNodeByte;
                return value != null && value.Data != 0;
            }
            set {
                if (_modern) ChunkTag["Status"] = new TagNodeString(value ? "full" : "empty");
                else ChunkTag["TerrainPopulated"] = new TagNodeByte((byte)(value ? 1 : 0));
            }
        }

        /// <summary>The lowest world block Y represented by <see cref="Blocks"/>.</summary>
        public int MinimumY { get { return _minimumSectionY * 16; } }

        /// <summary>Gets a numeric block ID using a world Y coordinate.</summary>
        public int GetBlockID(int x, int y, int z)
        {
            return _blockManager.GetID(x, y - MinimumY, z);
        }

        /// <summary>Sets a numeric block ID using a world Y coordinate.</summary>
        public void SetBlockID(int x, int y, int z, int id)
        {
            _blockManager.SetID(x, y - MinimumY, z, id);
        }

        /// <summary>Gets a namespaced block name using a world Y coordinate.</summary>
        public string GetBlockName(int x, int y, int z)
        {
            AquaticSection section = GetSectionForWorldY(y);
            return section.GetBlockName(x, y & 15, z);
        }

        /// <summary>Gets a copy of the block-state properties at a world Y coordinate.</summary>
        public TagNodeCompound GetBlockProperties(int x, int y, int z)
        {
            AquaticSection section = GetSectionForWorldY(y);
            TagNodeCompound properties = section.GetBlockProperties(x, y & 15, z);
            return properties == null ? null : properties.Copy() as TagNodeCompound;
        }

        /// <summary>Sets a namespaced block state using a world Y coordinate.</summary>
        public void SetBlockState(int x, int y, int z, string name, TagNodeCompound properties)
        {
            AquaticSection section = GetSectionForWorldY(y);
            section.SetBlockState(x, y & 15, z, name, properties);
            _blockManager.IsDirty = true;
        }

        private AquaticSection GetSectionForWorldY(int y)
        {
            int sectionY = (int)Math.Floor(y / 16.0);
            int index = sectionY - _minimumSectionY;
            if (index < 0 || index >= _sections.Length) throw new ArgumentOutOfRangeException("y");
            return _sections[index];
        }

        private TagNodeCompound ChunkTag {
            get {
                TagNode level;
                return _tree.Root.TryGetValue("Level", out level)
                    ? level as TagNodeCompound
                    : _tree.Root;
            }
        }

        public static AquaticChunk Create (int x, int z)
        {
            AquaticChunk c = new AquaticChunk();

            c._cx = x;
            c._cz = z;

            c.BuildNBTTree();
            return c;
        }

        public static AquaticChunk Create (NbtTree tree)
        {
            AquaticChunk c = new AquaticChunk();

            return c.LoadTree(tree.Root);
        }

        public static AquaticChunk CreateVerified (NbtTree tree)
        {
            AquaticChunk c = new AquaticChunk();

            return c.LoadTreeSafe(tree.Root);
        }

        /// <summary>
        /// Updates the chunk's global world coordinates.
        /// </summary>
        /// <param name="x">Global X-coordinate.</param>
        /// <param name="z">Global Z-coordinate.</param>
        public virtual void SetLocation (int x, int z)
        {
            int diffx = (x - _cx) * XDIM;
            int diffz = (z - _cz) * ZDIM;

            // Update chunk position

            _cx = x;
            _cz = z;

            ChunkTag["xPos"].ToTagInt().Data = x;
            ChunkTag["zPos"].ToTagInt().Data = z;

            // Update tile entity coordinates

            List<TileEntity> tileEntites = new List<TileEntity>();
            foreach (TagNodeCompound tag in _tileEntities) {
                TileEntity te = TileEntityFactory.Create(tag);
                if (te == null) {
                    te = TileEntity.FromTreeSafe(tag);
                }

                if (te != null) {
                    te.MoveBy(diffx, 0, diffz);
                    tileEntites.Add(te);
                }
            }

            _tileEntities.Clear();
            foreach (TileEntity te in tileEntites) {
                _tileEntities.Add(te.BuildTree());
            }

            // Update tile tick coordinates

            if (_tileTicks != null) {
                List<TileTick> tileTicks = new List<TileTick>();
                foreach (TagNodeCompound tag in _tileTicks) {
                    TileTick tt = TileTick.FromTreeSafe(tag);

                    if (tt != null) {
                        tt.MoveBy(diffx, 0, diffz);
                        tileTicks.Add(tt);
                    }
                }

                _tileTicks.Clear();
                foreach (TileTick tt in tileTicks) {
                    _tileTicks.Add(tt.BuildTree());
                }
            }

            // Update entity coordinates

            List<TypedEntity> entities = new List<TypedEntity>();
            foreach (TypedEntity entity in _entityManager) {
                entity.MoveBy(diffx, 0, diffz);
                entities.Add(entity);
            }

            _entities.Clear();
            foreach (TypedEntity entity in entities) {
                _entityManager.Add(entity);
            }
        }

        public bool Save (Stream outStream)
        {
            if (outStream == null || !outStream.CanWrite) {
                return false;
            }

            BuildConditional();

            NbtTree tree;
            if (_modern) {
                tree = new NbtTree(BuildTree().ToTagCompound(), _tree.Name);
            } else {
                tree = _tree.Copy();
                tree.Root["Level"] = BuildTree();
            }

            tree.WriteTo(outStream);

            return true;
        }

        #region INbtObject<AquaticChunk> Members

        public AquaticChunk LoadTree (TagNode tree)
        {
            TagNodeCompound ctree = tree as TagNodeCompound;
            if (ctree == null) {
                return null;
            }

            _tree = new NbtTree(ctree);
            TagNodeInt version = _tree.Root["DataVersion"] as TagNodeInt;
            _dataVersion = version == null ? 1631 : version.Data;

            TagNodeCompound level;
            TagNode levelNode;
            _modern = !_tree.Root.TryGetValue("Level", out levelNode);
            level = _modern ? _tree.Root : levelNode as TagNodeCompound;

            string sectionsKey = _modern ? "sections" : "Sections";
            TagNodeList sections = level[sectionsKey] as TagNodeList;
            _minimumSectionY = _modern ? -4 : 0;
            int maximumSectionY = _modern ? 19 : 15;
            _sections = new AquaticSection[maximumSectionY - _minimumSectionY + 1];
            foreach (TagNodeCompound section in sections) {
                AquaticSection aquaticSection = new AquaticSection(section, _dataVersion);
                int sectionIndex = aquaticSection.Y - _minimumSectionY;
                if (sectionIndex < 0 || sectionIndex >= _sections.Length)
                    continue;
                _sections[sectionIndex] = aquaticSection;
            }

            IDataArray3[] blocksBA = new IDataArray3[_sections.Length];
            YZXNibbleArray[] dataBA = new YZXNibbleArray[_sections.Length];
            YZXNibbleArray[] skyLightBA = new YZXNibbleArray[_sections.Length];
            YZXNibbleArray[] blockLightBA = new YZXNibbleArray[_sections.Length];

            for (int i = 0; i < _sections.Length; i++) {
                if (_sections[i] == null)
                    _sections[i] = new AquaticSection(i + _minimumSectionY, _dataVersion, _modern);

                blocksBA[i] = _sections[i].Blocks;
                dataBA[i] = _sections[i].Data;
                skyLightBA[i] = _sections[i].SkyLight;
                blockLightBA[i] = _sections[i].BlockLight;
            }

            _blocks = new CompositeDataArray3(blocksBA);
            _data = new CompositeDataArray3(dataBA);
            _skyLight = new CompositeDataArray3(skyLightBA);
            _blockLight = new CompositeDataArray3(blockLightBA);
            
            TagNode optionalNode;
            bool rebuildHeightMap = false;
            level.TryGetValue("HeightMap", out optionalNode);
            TagNodeIntArray legacyHeight = optionalNode as TagNodeIntArray;
            if (legacyHeight == null) {
                level.TryGetValue("Heightmaps", out optionalNode);
                int[] modernHeight = ReadHeightMap(
                    optionalNode as TagNodeCompound, _minimumSectionY * 16);
                rebuildHeightMap = modernHeight == null;
                legacyHeight = new TagNodeIntArray(modernHeight ?? new int[XDIM * ZDIM]);
            }
            _heightMap = new ZXIntArray(XDIM, ZDIM, legacyHeight);

            level.TryGetValue("Biomes", out optionalNode);
            if (optionalNode is TagNodeIntArray)
                _biomes = new ZXIntArray(XDIM, ZDIM, optionalNode as TagNodeIntArray);
            else if (optionalNode is TagNodeByteArray)
                _biomes = new ZXByteArray(XDIM, ZDIM, optionalNode as TagNodeByteArray);
            else {
                TagNodeIntArray defaultBiomes = new TagNodeIntArray(new int[256]);
                if (!_modern) level["Biomes"] = defaultBiomes;
                _biomes = new ZXIntArray(XDIM, ZDIM, defaultBiomes);
                for (int x = 0; x < XDIM; x++)
                    for (int z = 0; z < ZDIM; z++)
                        _biomes[x, z] = BiomeType.Default;
            }

            string entitiesKey = _modern ? "entities" : "Entities";
            string tileEntitiesKey = _modern ? "block_entities" : "TileEntities";
            level.TryGetValue(entitiesKey, out optionalNode);
            _entities = optionalNode as TagNodeList;
            if (_entities == null) _entities = new TagNodeList(TagType.TAG_COMPOUND);
            level.TryGetValue(tileEntitiesKey, out optionalNode);
            _tileEntities = optionalNode as TagNodeList;
            if (_tileEntities == null) _tileEntities = new TagNodeList(TagType.TAG_COMPOUND);

            if (!_modern && level.ContainsKey("TileTicks"))
                _tileTicks = level["TileTicks"] as TagNodeList;
            else
                _tileTicks = new TagNodeList(TagType.TAG_COMPOUND);

            // List-type patch up
            if (_entities.Count == 0 && _entities.ValueType != TagType.TAG_COMPOUND) {
                level[entitiesKey] = new TagNodeList(TagType.TAG_COMPOUND);
                _entities = level[entitiesKey] as TagNodeList;
            }

            if (_tileEntities.Count == 0 && _tileEntities.ValueType != TagType.TAG_COMPOUND) {
                level[tileEntitiesKey] = new TagNodeList(TagType.TAG_COMPOUND);
                _tileEntities = level[tileEntitiesKey] as TagNodeList;
            }

            if (_tileTicks.Count == 0 && _tileTicks.ValueType != TagType.TAG_COMPOUND) {
                if (!_modern) level["TileTicks"] = new TagNodeList(TagType.TAG_COMPOUND);
                _tileTicks = !_modern
                    ? level["TileTicks"] as TagNodeList
                    : new TagNodeList(TagType.TAG_COMPOUND);
            }

            _cx = level["xPos"].ToTagInt();
            _cz = level["zPos"].ToTagInt();

            _blockManager = new AlphaBlockCollection(_blocks, _data, _blockLight, _skyLight, _heightMap, _tileEntities, _tileTicks);
            if (rebuildHeightMap)
                RebuildHeightMap();
            _entityManager = new EntityCollection(_entities);
            _biomeManager = new AquaticBiomeCollection(_biomes);

            return this;
        }

        public AquaticChunk LoadTreeSafe(TagNode tree) {
            if (!ValidateTree(tree)) {
                return null;
            }

            return LoadTree(tree);
        }

        private bool ShouldIncludeSection (AquaticSection section)
        {
            int y = (section.Y + 1) * section.Blocks.YDim;
            for (int i = 0; i < _heightMap.Length; i++)
                if (_heightMap[i] > y)
                    return true;

            return !section.CheckEmpty();
        }

        public TagNode BuildTree ()
        {
            TagNodeCompound level = ChunkTag;
            TagNodeCompound levelCopy = new TagNodeCompound();
            foreach (KeyValuePair<string, TagNode> node in level)
                levelCopy.Add(node.Key, node.Value);

            // The legacy incremental light engine uses zero-based Y values,
            // while modern chunks keep heightmaps in world coordinates
            // starting at -64.  Its results are therefore not reliable after
            // editing a modern chunk.  Ask Minecraft's light engine to rebuild
            // the affected chunk instead of saving stale arrays as valid.
            bool requiresRelight = _modern && _blockManager.IsDirty;
            TagNodeList sections = new TagNodeList(TagType.TAG_COMPOUND);
            for (int i = 0; i < _sections.Length; i++) {
                if (!ShouldIncludeSection(_sections[i]))
                    continue;
                TagNodeCompound section = _sections[i].BuildTree().ToTagCompound();
                if (requiresRelight) {
                    section.Remove("SkyLight");
                    section.Remove("BlockLight");
                }
                sections.Add(section);
            }

            levelCopy[_modern ? "sections" : "Sections"] = sections;
            if (requiresRelight)
                levelCopy["isLightOn"] = new TagNodeByte(0);

            if (!_modern && _tileTicks.Count == 0)
                levelCopy.Remove("TileTicks");

            return levelCopy;
        }

        public bool ValidateTree (TagNode tree)
        {
            TagNodeCompound root = tree as TagNodeCompound;
            if (root != null && !root.ContainsKey("Level")) {
                TagNode sections, x, z;
                return root.TryGetValue("sections", out sections) && sections is TagNodeList &&
                    root.TryGetValue("xPos", out x) && x is TagNodeInt &&
                    root.TryGetValue("zPos", out z) && z is TagNodeInt;
            }
            NbtVerifier v = new NbtVerifier(tree, LevelSchema);
            return v.Verify();
        }

        private static int[] ReadHeightMap(TagNodeCompound heightmaps, int minimumY)
        {
            if (heightmaps == null) return null;
            TagNode node;
            heightmaps.TryGetValue("MOTION_BLOCKING_NO_LEAVES", out node);
            TagNodeLongArray source = node as TagNodeLongArray;
            if (source == null) {
                heightmaps.TryGetValue("MOTION_BLOCKING", out node);
                source = node as TagNodeLongArray;
            }
            if (source == null) {
                heightmaps.TryGetValue("WORLD_SURFACE", out node);
                source = node as TagNodeLongArray;
            }
            if (source == null) return null;

            int[] result = new int[XDIM * ZDIM];
            const int bits = 9;
            int valuesPerLong = 64 / bits;
            int paddedLength = (result.Length + valuesPerLong - 1) / valuesPerLong;
            bool padded = source.Data.Length >= paddedLength;
            for (int i = 0; i < result.Length; i++)
                result[i] = AquaticSection.ReadPacked(source.Data, i, bits, padded) + minimumY;
            return result;
        }

        private void RebuildHeightMap()
        {
            int minimumY = _minimumSectionY * 16;
            for (int x = 0; x < XDIM; x++) {
                for (int z = 0; z < ZDIM; z++) {
                    for (int y = _blocks.YDim - 1; y >= 0; y--) {
                        BlockInfo info = _blockManager.GetInfo(x, y, z);
                        string name = _sections[y / 16].GetBlockName(x, y & 15, z);
                        if (IsMotionBlocking(info, name)) {
                            _heightMap[x, z] = minimumY + y + 1;
                            break;
                        }
                    }
                }
            }
        }

        private static bool IsMotionBlocking(BlockInfo info, string name)
        {
            if (info == null || info.State == BlockState.NONSOLID)
                return false;
            if (name == "minecraft:leaf_litter")
                return false;
            return name == null || !name.EndsWith("_leaves", StringComparison.Ordinal);
        }

        #endregion

        #region ICopyable<AquaticChunk> Members

        public AquaticChunk Copy ()
        {
            return AquaticChunk.Create(_tree.Copy());
        }

        #endregion

        private void BuildConditional ()
        {
            TagNodeCompound level = ChunkTag;
            if (_tileTicks != _blockManager.TileTicks && _blockManager.TileTicks.Count > 0) {
                _tileTicks = _blockManager.TileTicks;
                level["TileTicks"] = _tileTicks;
            }
        }

        private void BuildNBTTree ()
        {
            _dataVersion = 1631;
            int elements2 = XDIM * ZDIM;

            _sections = new AquaticSection[16];
            TagNodeList sections = new TagNodeList(TagType.TAG_COMPOUND);

            for (int i = 0; i < _sections.Length; i++) {
                _sections[i] = new AquaticSection(i, _dataVersion);
                sections.Add(_sections[i].BuildTree());
            }

            FusedDataArray3[] blocksBA = new FusedDataArray3[_sections.Length];
            YZXNibbleArray[] dataBA = new YZXNibbleArray[_sections.Length];
            YZXNibbleArray[] skyLightBA = new YZXNibbleArray[_sections.Length];
            YZXNibbleArray[] blockLightBA = new YZXNibbleArray[_sections.Length];

            for (int i = 0; i < _sections.Length; i++) {
                blocksBA[i] = new FusedDataArray3(_sections[i].AddBlocks, _sections[i].Blocks);
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

            TagNodeIntArray biomes = new TagNodeIntArray(new int[elements2]);
            _biomes = new ZXIntArray(XDIM, ZDIM, biomes);
            for (int x = 0; x < XDIM; x++)
                for (int z = 0; z < ZDIM; z++)
                    _biomes[x, z] = BiomeType.Default;

            _entities = new TagNodeList(TagType.TAG_COMPOUND);
            _tileEntities = new TagNodeList(TagType.TAG_COMPOUND);
            _tileTicks = new TagNodeList(TagType.TAG_COMPOUND);

            TagNodeCompound level = new TagNodeCompound();
            level.Add("Sections", sections);
            level.Add("HeightMap", heightMap);
            level.Add("Biomes", biomes);
            level.Add("Entities", _entities);
            level.Add("TileEntities", _tileEntities);
            level.Add("TileTicks", _tileTicks);
            level.Add("LastUpdate", new TagNodeLong(Timestamp()));
            level.Add("xPos", new TagNodeInt(_cx));
            level.Add("zPos", new TagNodeInt(_cz));
            level.Add("TerrainPopulated", new TagNodeByte());

            _tree = new NbtTree();
            _tree.Root.Add("DataVersion", new TagNodeInt(_dataVersion));
            _tree.Root.Add("Level", level);

            _blockManager = new AlphaBlockCollection(_blocks, _data, _blockLight, _skyLight, _heightMap, _tileEntities);
            _entityManager = new EntityCollection(_entities);
            _biomeManager = new AquaticBiomeCollection(_biomes);
        }

        private int Timestamp ()
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return (int)((DateTime.UtcNow - epoch).Ticks / (10000L * 1000L));
        }
    }
}
