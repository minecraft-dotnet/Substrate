using System;
using System.Collections.Generic;
using Substrate.Core;
using Substrate.Nbt;

namespace Substrate.World
{
    public class AnvilSection2 : INbtObject<AnvilSection2>, ICopyable<AnvilSection2>
    {
        public static SchemaNodeCompound Section2Schema = new SchemaNodeCompound()
        {
                new SchemaNodeCompound("biomes") {
                    new SchemaNodeList("palette", TagType.TAG_STRING),
                    new SchemaNodeLongArray("data", SchemaOptions.OPTIONAL),
                },
                new SchemaNodeCompound("block_states") {
                    new SchemaNodeList("palette", TagType.TAG_COMPOUND, new SchemaNodeCompound(){
                        new SchemaNodeResourceLocation("Name"),
                        new SchemaNodeCompound("Properties", SchemaOptions.OPTIONAL) {
                            new SchemaNodeString("thickness", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("vertical_direction", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("waterlogged", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("up", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("down", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("north", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("east", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("south", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("west", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("axis", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("distance", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("persistent", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("note", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("powered", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("instrument", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("snowy", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("stage", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("hanging", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("age", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("triggered", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("facing", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("level", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("dusted", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("part", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("occupied", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("shape", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("extended", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("half", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("short", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("type", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("power", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("natural", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("active", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("slot_0_occupied", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("slot_1_occupied", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("slot_2_occupied", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("slot_3_occupied", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("slot_4_occupied", SchemaOptions.OPTIONAL),
                            new SchemaNodeString("slot_5_occupied", SchemaOptions.OPTIONAL),
                        },
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

        private List<string> _biomePalette = new List<string>(1);
        private List<string> _blockStatesPallete = new List<string>(1);

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
                _blockStatesPallete.Add(name);
                if (blockState.TryGetValue<TagNodeCompound>("Properties", out var properties))
                {
                    var thickness = properties.TryGetValue("thickness", out var thicknessNode) ? thicknessNode.ToTagString().Data : null;
                    var verticalDirection = properties.TryGetValue("vertical_direction", out var verticalDirectionNode) ? verticalDirectionNode.ToTagString().Data : null;
                    var waterlogged = properties.TryGetValue("waterlogged", out var waterloggedNode) ? waterloggedNode.ToTagString().Data : null;
                    var up = properties.TryGetValue("up", out var upNode) ? upNode.ToTagString().Data : null;
                    var down = properties.TryGetValue("down", out var downNode) ? downNode.ToTagString().Data : null;
                    var north = properties.TryGetValue("north", out var northNode) ? northNode.ToTagString().Data : null;
                    var east = properties.TryGetValue("east", out var eastNode) ? eastNode.ToTagString().Data : null;
                    var south = properties.TryGetValue("south", out var southNode) ? southNode.ToTagString().Data : null;
                    var west = properties.TryGetValue("west", out var westNode) ? westNode.ToTagString().Data : null;
                    var lit = properties.TryGetValue("lit", out var litNode) ? litNode.ToTagString().Data : null;
                    var axis = properties.TryGetValue("axis", out var axisNode) ? axisNode.ToTagString().Data : null;
                }
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
            NbtVerifier v = new NbtVerifier(tree, Section2Schema);
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
