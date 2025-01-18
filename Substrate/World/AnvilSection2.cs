using System;
using System.Collections.Generic;
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

        private byte _y;
        private ConstantDataArray3 _blocks;
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

        public AnvilSection2(TagNodeCompound tree)
        {
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

        public IDataArray3 Blocks => _blocks;

        public YZXNibbleArray Data => _data;

        public IDataArray3 BlockLight => _blockLightEmpty ?? _blockLight;

        public IDataArray3 SkyLight => _skyLightEmpty ?? _skyLight;

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

            _blocks = new ConstantDataArray3(XDIM, YDIM, ZDIM, 0);

            if (blockStates.TryGetValue<TagNodeByteArray>("SkyLight", out var blockStatesdata))
            {
                _data = new YZXNibbleArray(XDIM, YDIM, ZDIM, blockStatesdata);
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

            return this;
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
            _blocks = new ConstantDataArray3(XDIM, YDIM, ZDIM, 0);

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
