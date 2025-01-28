using System;
using System.Collections.Generic;
using System.Linq;
using Substrate.Core;
using Substrate.Nbt;

namespace Substrate.World
{
    public class AnvilSection2 : INbtObject<AnvilSection2>, ICopyable<AnvilSection2>
    {
        public static SchemaNodeCompound Schema = new SchemaNodeCompound()
        {
                new SchemaNodeCompound("biomes") {
                    new SchemaNodeList("palette", TagType.TAG_STRING),
                    new SchemaNodeLongArray("data", SchemaOptions.OPTIONAL),
                },
                new SchemaNodeCompound("block_states") {
                    new SchemaNodeList("palette", TagType.TAG_COMPOUND, new SchemaNodeCompound(){
                        new SchemaNodeResourceLocation("Name"),
                        new SchemaNodeCompound("Properties", Properties.Schema, SchemaOptions.OPTIONAL),
                    }),
                    new SchemaNodeLongArray("data", SchemaOptions.OPTIONAL),
                },
                new SchemaNodeScalar("Y", TagType.TAG_BYTE),
                new SchemaNodeByteArray("BlockLight", 2048, SchemaOptions.OPTIONAL),
                new SchemaNodeByteArray("SkyLight", 2048, SchemaOptions.OPTIONAL),
        };

        private const int XDIM = 16;
        private const int YDIM = 16;
        private const int ZDIM = 16;

        private const int MIN_Y = 0;
        private const int MAX_Y = 15;

        private TagNodeCompound _tree;

        private int _dataVersion;
        private byte _y;
        private IDataArray3 _blocks;
        private ConstantDataArray3 _blocksEmpty;
        private IDataArray _blockIndices;
        private YZXNibbleArray _data;
        private ConstantDataArray3 _blockLightEmpty;
        private IDataArray3 _blockLight;
        private ConstantDataArray3 _skyLightEmpty;
        private IDataArray3 _skyLight;

        private List<string> _biomePalette = new(1);
        private List<(string, Properties)> _blockStatesPallete = new(1);

        private AnvilSection2()
        {
        }

        public AnvilSection2(int y)
        {
            if (y < MIN_Y || y > MAX_Y)
                throw new ArgumentOutOfRangeException();

            _y = (byte)y;
            BuildNbtTree();
        }

        public AnvilSection2(TagNodeCompound tree, int dataVersion)
        {
            _dataVersion = dataVersion;
            LoadTree(tree);
        }

        public int Y
        {
            get { return _y; }
            set
            {
                if (value < MIN_Y || value > MAX_Y)
                    throw new ArgumentOutOfRangeException();

                _y = (byte)value;
                _tree["Y"].ToTagByte().Data = _y;
            }
        }

        public IDataArray3 Blocks => _blocks??_blocksEmpty;

        public YZXNibbleArray Data => _data;

        public IDataArray3 BlockLight => _blockLight ?? _blockLightEmpty;

        public IDataArray3 SkyLight => _skyLight ?? _skyLightEmpty;

        public List<string> BiomePalette => _biomePalette;

        public bool CheckEmpty()
        {
            return CheckBlocksEmpty();
        }

        private bool CheckBlocksEmpty()
        {
            for (int i = 0; i < _blocks.Length; i++)
                if (_blocks[i] != 0)
                    return false;
            return true;
        }

        #region INbtObject<AnvilSection> Members

        public AnvilSection2 LoadTree(TagNode tree)
        {
            TagNodeCompound ctree = tree as TagNodeCompound;
            if (ctree == null)
            {
                return null;
            }

            _y = ctree["Y"] as TagNodeByte;

            var biomes = ctree["biomes"] as TagNodeCompound;
            var pallete = biomes["palette"] as TagNodeList;
            foreach (var item in pallete)
            {
                _biomePalette.Add(item.ToTagString().Data);
            }
            if (biomes.TryGetValue("data", out var biomeData))
            {
                var dataArray = biomeData.ToTagLongArray().Data;
            }

            var blockStates = ctree["block_states"] as TagNodeCompound;
            var blockStatesPallete = blockStates["palette"] as TagNodeList;
            foreach (var item in blockStatesPallete)
            {
                var blockState = item.ToTagCompound();
                var name = blockState["Name"].ToTagString().Data;

                Properties properties = null;

                if (blockState.TryGetValue<TagNodeCompound>("Properties", out var propertiesNode))
                {
                    properties = new Properties(propertiesNode);
                }

                _blockStatesPallete.Add((name, properties));
            }

            _blocksEmpty = new ConstantDataArray3(XDIM, YDIM, ZDIM, 0);

            if (blockStates.TryGetValue("data", out var blockStatesdata))
            {
                if (VersionUtils.UsesWholeIndexes(_dataVersion))
                {
                    var dataArray = blockStatesdata.ToTagLongArray().Data;
                    _blockIndices = new PackedIndexLongList(_blockStatesPallete.Count, dataArray, 4);
                }
                else
                {
                    var dataArray = blockStatesdata.ToTagLongArray().Data;
                    _blockIndices = new PackedIndexBitLongList(_blockStatesPallete.Count, dataArray);
                }
            }
            else
            {
                _blockIndices = null;
            }

            if (blockStates.TryGetValue<TagNodeByteArray>("SkyLight", out var blockStatesSkylight))
            {
                _skyLight = new YZXNibbleArray(XDIM, YDIM, ZDIM, blockStatesSkylight);
            }
            if (ctree.TryGetValue<TagNodeByteArray>("SkyLight", out var skylight))
            {
                _skyLight = new YZXNibbleArray(XDIM, YDIM, ZDIM, skylight);
            }
            else
            {
                _skyLightEmpty = new ConstantDataArray3(XDIM, YDIM, ZDIM, 0);
            }

            if (ctree.TryGetValue<TagNodeByteArray>("BlockLight", out var blockLight))
            {
                _blockLight = new YZXNibbleArray(XDIM, YDIM, ZDIM, blockLight);
            }
            else
            {
                _blockLightEmpty = new ConstantDataArray3(XDIM, YDIM, ZDIM, 0);
            }

            _tree = ctree;

            if (_blockIndices != null)
                _blocks = UnpackBlocks(_blockStatesPallete, _blockIndices);
            else
                _blocks = _blocksEmpty;

            return this;
        }

        private static IDataArray3 UnpackBlocks(List<(string, Properties)> blockPalette, IDataArray blockIndices)
        {
            var indices = blockIndices as PackedIndexLongList;

            var blockIds = blockPalette.Select(x => BlockInfo.GetBlockByNameId(x.Item1)).ToArray();

            int i = 0;
            var buffer = new int[XDIM * YDIM * ZDIM];
            for (int x = 0; x < XDIM; x++)
            {
                for (int z = 0; z < ZDIM; z++)
                {
                    for (int y = 0; y < YDIM; y++)
                    {
                        int index = indices[i];
                        //if (blockIds[index] == null)
                        //{
                        //    Console.WriteLine($"Missing {blockPalette[index].Item1}");
                        //}
                        buffer[i] = blockIds[index]?.ID ?? 0;
                        ++i;
                    }
                }
            }

            return new XZYIntArray3(XDIM, YDIM, ZDIM, buffer);
        }

        public AnvilSection2 LoadTreeSafe(TagNode tree)
        {
            if (!ValidateTree(tree))
            {
                return null;
            }

            return LoadTree(tree);
        }

        public TagNode BuildTree()
        {
            TagNodeCompound copy = new TagNodeCompound();
            foreach (KeyValuePair<string, TagNode> node in _tree)
            {
                copy.Add(node.Key, node.Value);
            }

            return copy;
        }

        public bool ValidateTree(TagNode tree)
        {
            NbtVerifier v = new NbtVerifier(tree, Schema);
            return v.Verify();
        }

        #endregion

        #region ICopyable<AnvilSection> Members

        public AnvilSection2 Copy()
        {
            return new AnvilSection2().LoadTree(_tree.Copy());
        }

        #endregion

        private void BuildNbtTree()
        {
            _blocksEmpty = new ConstantDataArray3(XDIM, YDIM, ZDIM, 0);
            _blockIndices = null;

            TagNodeCompound tree = new TagNodeCompound
            {
                { "Y", new TagNodeByte(_y) },
                { "biomes", new TagNodeCompound() {
                    { "palette", new TagNodeList(TagType.TAG_STRING) {
                        new TagNodeString("minecraft:plains")
                    }}
                }},
                { "block_states", new TagNodeCompound() {
                    { "palette", new TagNodeList(TagType.TAG_STRING) {
                        new TagNodeCompound() {
                            { "Name", new TagNodeString( "minecraft:air") }
                        }
                    }}
                }},
            };

            _tree = tree;
        }
    }
}
