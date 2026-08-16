using System;
using System.Collections.Generic;
using Substrate.Core;
using Substrate.Nbt;

namespace Substrate
{
    /// <summary>Represents a palette-based Anvil section (Minecraft 1.13 through 1.17).</summary>
    public class AquaticSection : INbtObject<AquaticSection>, ICopyable<AquaticSection>
    {
        public static readonly SchemaNodeCompound SectionSchema = new SchemaNodeCompound() {
            new SchemaNodeList("Palette", TagType.TAG_COMPOUND, new SchemaNodeCompound() {
                new SchemaNodeString("Name", null),
                new SchemaNodeCompound("Properties", SchemaOptions.OPTIONAL),
            }),
            new SchemaNodeLongArray("BlockStates", 0, SchemaOptions.OPTIONAL),
            new SchemaNodeArray("SkyLight", 2048, SchemaOptions.OPTIONAL),
            new SchemaNodeArray("BlockLight", 2048, SchemaOptions.OPTIONAL),
            new SchemaNodeScaler("Y", TagType.TAG_BYTE),
        };
        public static readonly SchemaNodeCompound ModernSectionSchema = new SchemaNodeCompound() {
            new SchemaNodeCompound("block_states") {
                new SchemaNodeList("palette", TagType.TAG_COMPOUND, new SchemaNodeCompound() {
                    new SchemaNodeString("Name", null),
                    new SchemaNodeCompound("Properties", SchemaOptions.OPTIONAL),
                }),
                new SchemaNodeLongArray("data", 0, SchemaOptions.OPTIONAL),
            },
            new SchemaNodeCompound("biomes", SchemaOptions.OPTIONAL),
            new SchemaNodeArray("SkyLight", 2048, SchemaOptions.OPTIONAL),
            new SchemaNodeArray("BlockLight", 2048, SchemaOptions.OPTIONAL),
            new SchemaNodeScaler("Y", TagType.TAG_BYTE),
        };

        private const int Size = 16;
        private const int BlockCount = 4096;
        private TagNodeCompound _tree;
        private byte _y;
        private YZXShortDataArray _blocks;
        private YZXNibbleArray _data;
        private YZXNibbleArray _blockLight;
        private YZXNibbleArray _skyLight;
        private YZXNibbleArray _addBlocks;
        private TagNodeByteArray _blockLightTag;
        private TagNodeByteArray _skyLightTag;
        private PaletteBlock[] _palette;
        private byte[] _originalPaletteIndices8;
        private ushort[] _originalPaletteIndices16;
        private int _dataVersion;
        private bool _modern;

        private AquaticSection() { }

        public AquaticSection(int y) : this(y, 1631, false) { }

        public AquaticSection(int y, int dataVersion) : this(y, dataVersion, false) { }

        internal AquaticSection(int y, int dataVersion, bool modern)
        {
            if (y < -128 || y > 127) throw new ArgumentOutOfRangeException("y");
            _y = unchecked((byte)(sbyte)y);
            _dataVersion = dataVersion;
            _modern = modern;
            BuildNbtTree();
        }

        public AquaticSection(TagNodeCompound tree) : this(tree, 1631) { }

        public AquaticSection(TagNodeCompound tree, int dataVersion)
        {
            _dataVersion = dataVersion;
            if (LoadTree(tree) == null) throw new ArgumentException("Invalid palette section.", "tree");
        }

        public int Y {
            get { return (sbyte)_y; }
            set {
                if (value < -128 || value > 127) throw new ArgumentOutOfRangeException("value");
                _y = unchecked((byte)(sbyte)value);
                _tree["Y"] = new TagNodeByte(_y);
            }
        }

        public YZXShortDataArray Blocks { get { return _blocks; } }
        public YZXNibbleArray Data { get { return _data; } }
        public YZXNibbleArray BlockLight { get { return _blockLight; } }
        public YZXNibbleArray SkyLight { get { return _skyLight; } }
        public YZXNibbleArray AddBlocks
        {
            get
            {
                if (_addBlocks == null)
                    _addBlocks = new YZXNibbleArray(
                        Size, Size, Size, new TagNodeByteArray(new byte[BlockCount / 2]));
                return _addBlocks;
            }
        }
        public PaletteBlock[] Palette { get { return _palette; } }

        public bool CheckEmpty()
        {
            for (int i = 0; i < _blocks.Length; i++) {
                if (_blocks[i] != 0) return false;
                if (HasOriginalPaletteIndices &&
                    IsOriginalState(i) &&
                    _palette[GetOriginalPaletteIndex(i)].Name != "minecraft:air") return false;
            }
            return true;
        }

        /// <summary>Gets the namespaced block-state name at local section coordinates.</summary>
        public string GetBlockName(int x, int y, int z)
        {
            return GetPaletteBlock(x, y, z).Name;
        }

        /// <summary>Gets the block-state properties at local section coordinates.</summary>
        public TagNodeCompound GetBlockProperties(int x, int y, int z)
        {
            return GetPaletteBlock(x, y, z).Properties;
        }

        /// <summary>Sets a namespaced block state without requiring a legacy numeric block ID.</summary>
        public void SetBlockState(int x, int y, int z, string name, TagNodeCompound properties)
        {
            int index = _blocks.GetIndex(x, y, z);
            BlockInfo blockInfo;
            ItemInfo itemInfo;
            int id;
            int data;
            if (!BlockInfo.TryGetLegacyBlockState(
                    name, properties, out id, out data)) {
                if (!BlockInfo.TryGetLegacyDefaultBlockState(
                        name, out id, out data)) {
                    id = BlockInfo.BlockNameTable.TryGetValue(
                            name, out blockInfo)
                        ? blockInfo.ID
                        : (ItemInfo.StrTable.TryGetValue(
                                name, out itemInfo)
                            ? itemInfo.ID
                            : 0);
                    data = 0;
                }
            }
            PaletteBlock state = new PaletteBlock(
                name,
                properties == null
                    ? null
                    : properties.Copy() as TagNodeCompound,
                id,
                data);
            int paletteIndex = Array.IndexOf(_palette, state);
            if (paletteIndex < 0) {
                PaletteBlock[] expanded = new PaletteBlock[_palette.Length + 1];
                _palette.CopyTo(expanded, 0);
                paletteIndex = _palette.Length;
                expanded[paletteIndex] = state;
                _palette = expanded;
            }
            _blocks[index] = id;
            _data[index] = data;
            SetOriginalPaletteIndex(index, paletteIndex);
        }

        private PaletteBlock GetPaletteBlock(int x, int y, int z)
        {
            int index = _blocks.GetIndex(x, y, z);
            if (HasOriginalPaletteIndices && IsOriginalState(index))
                return _palette[GetOriginalPaletteIndex(index)];
            return FindPaletteBlock(_blocks[index], _data[index]);
        }

        public AquaticSection LoadTree(TagNode tree)
        {
            TagNodeCompound section = tree as TagNodeCompound;
            if (section == null) return null;
            TagNodeByte y = section["Y"] as TagNodeByte;
            TagNode paletteNode;
            section.TryGetValue("Palette", out paletteNode);
            TagNodeList paletteTag = paletteNode as TagNodeList;
            TagNodeCompound blockStatesContainer = null;
            if (paletteTag == null) {
                TagNode containerNode;
                section.TryGetValue("block_states", out containerNode);
                blockStatesContainer = containerNode as TagNodeCompound;
                if (blockStatesContainer != null) {
                    blockStatesContainer.TryGetValue("palette", out paletteNode);
                    paletteTag = paletteNode as TagNodeList;
                    _modern = true;
                }
            }
            if (y == null || paletteTag == null || paletteTag.Count == 0) return null;

            _y = y.Data;
            _tree = section;
            _palette = new PaletteBlock[paletteTag.Count];
            for (int i = 0; i < paletteTag.Count; i++)
                _palette[i] = PaletteBlock.FromTree(paletteTag[i] as TagNodeCompound);

            short[,,] ids = new short[Size, Size, Size];
            TagNodeByteArray metadataTag = new TagNodeByteArray(new byte[BlockCount / 2]);
            _blocks = new YZXShortDataArray(ids);
            _data = new YZXNibbleArray(Size, Size, Size, metadataTag);
            if (_palette.Length <= byte.MaxValue + 1)
                _originalPaletteIndices8 = new byte[BlockCount];
            else
                _originalPaletteIndices16 = new ushort[BlockCount];

            TagNode statesNode;
            if (_modern) blockStatesContainer.TryGetValue("data", out statesNode);
            else section.TryGetValue("BlockStates", out statesNode);
            TagNodeLongArray states = statesNode as TagNodeLongArray;
            int bits = Math.Max(4, BitsFor(_palette.Length));
            for (int i = 0; i < BlockCount; i++) {
                int paletteIndex = _palette.Length == 1 ? 0 : ReadPacked(states == null ? null : states.Data, i, bits, UsesPaddedPacking);
                if (paletteIndex < 0 || paletteIndex >= _palette.Length) paletteIndex = 0;
                _blocks[i] = _palette[paletteIndex].ID;
                _data[i] = _palette[paletteIndex].Data;
                SetOriginalPaletteIndex(i, paletteIndex);
            }

            _skyLight = NibbleArray(section, "SkyLight", out _skyLightTag);
            _blockLight = NibbleArray(section, "BlockLight", out _blockLightTag);
            return this;
        }

        private static YZXNibbleArray NibbleArray(TagNodeCompound tree, string name, out TagNodeByteArray tag)
        {
            TagNode value;
            tree.TryGetValue(name, out value);
            tag = value as TagNodeByteArray;
            if (tag == null || tag.Data.Length != BlockCount / 2) {
                tag = new TagNodeByteArray(new byte[BlockCount / 2]);
                tree[name] = tag;
            }
            return new YZXNibbleArray(Size, Size, Size, tag);
        }

        public AquaticSection LoadTreeSafe(TagNode tree)
        {
            return ValidateTree(tree) ? LoadTree(tree) : null;
        }

        public TagNode BuildTree()
        {
            List<PaletteBlock> palette = new List<PaletteBlock>();
            int[] indices = new int[BlockCount];
            for (int i = 0; i < BlockCount; i++) {
                PaletteBlock block;
                if (HasOriginalPaletteIndices && IsOriginalState(i)) {
                    block = _palette[GetOriginalPaletteIndex(i)];
                } else {
                    block = FindPaletteBlock(_blocks[i], _data[i]);
                }
                int index = palette.IndexOf(block);
                if (index < 0) {
                    index = palette.Count;
                    palette.Add(block);
                }
                indices[i] = index;
            }

            TagNodeCompound copy = new TagNodeCompound();
            foreach (KeyValuePair<string, TagNode> node in _tree) copy[node.Key] = node.Value;
            TagNodeList paletteTag = new TagNodeList(TagType.TAG_COMPOUND);
            foreach (PaletteBlock block in palette) paletteTag.Add(block.BuildTree());
            TagNodeLongArray packed = null;
            if (palette.Count != 1) {
                int bits = Math.Max(4, BitsFor(palette.Count));
                packed = new TagNodeLongArray(WritePacked(indices, bits, UsesPaddedPacking));
            }
            if (_modern) {
                TagNodeCompound container = new TagNodeCompound();
                container["palette"] = paletteTag;
                if (packed != null) container["data"] = packed;
                copy["block_states"] = container;
                copy.Remove("Palette");
                copy.Remove("BlockStates");
            } else {
                copy["Palette"] = paletteTag;
                if (packed == null) copy.Remove("BlockStates");
                else copy["BlockStates"] = packed;
            }
            return copy;
        }

        private PaletteBlock FindPaletteBlock(int id, int data)
        {
            for (int i = 0; i < _palette.Length; i++)
                if (_palette[i].ID == id && _palette[i].Data == data) return _palette[i];

            string legacyName;
            TagNodeCompound legacyProperties;
            if (BlockInfo.TryGetLegacyBlockState(id, data, out legacyName, out legacyProperties))
                return new PaletteBlock(legacyName, legacyProperties, id, data);

            BlockInfo blockInfo = BlockInfo.BlockTable[id];
            if (blockInfo != null && blockInfo.StrID != null)
                return new PaletteBlock(blockInfo.StrID, null, id, data);
            ItemInfo itemInfo = ItemInfo.ItemTable[id];
            if (itemInfo != null && itemInfo.StringId != null)
                return new PaletteBlock(itemInfo.StringId, null, id, data);
            return new PaletteBlock("minecraft:air", null, 0, 0);
        }

        private bool HasOriginalPaletteIndices
        {
            get { return _originalPaletteIndices8 != null || _originalPaletteIndices16 != null; }
        }

        private int GetOriginalPaletteIndex(int index)
        {
            return _originalPaletteIndices16 != null
                ? _originalPaletteIndices16[index]
                : _originalPaletteIndices8[index];
        }

        private void SetOriginalPaletteIndex(int index, int paletteIndex)
        {
            if (paletteIndex < 0 || paletteIndex >= BlockCount)
                throw new ArgumentOutOfRangeException("paletteIndex");

            if (_originalPaletteIndices16 != null) {
                _originalPaletteIndices16[index] = (ushort)paletteIndex;
                return;
            }

            if (_originalPaletteIndices8 == null)
                _originalPaletteIndices8 = new byte[BlockCount];

            if (paletteIndex <= byte.MaxValue) {
                _originalPaletteIndices8[index] = (byte)paletteIndex;
                return;
            }

            _originalPaletteIndices16 = new ushort[BlockCount];
            for (int i = 0; i < BlockCount; i++)
                _originalPaletteIndices16[i] = _originalPaletteIndices8[i];
            _originalPaletteIndices8 = null;
            _originalPaletteIndices16[index] = (ushort)paletteIndex;
        }

        private bool IsOriginalState(int index)
        {
            int paletteIndex = GetOriginalPaletteIndex(index);
            if (paletteIndex < 0 || paletteIndex >= _palette.Length) return false;
            PaletteBlock original = _palette[paletteIndex];
            return _blocks[index] == original.ID && _data[index] == original.Data;
        }

        public bool ValidateTree(TagNode tree)
        {
            TagNodeCompound compound = tree as TagNodeCompound;
            return compound != null && new NbtVerifier(tree,
                compound.ContainsKey("block_states") ? ModernSectionSchema : SectionSchema).Verify();
        }

        public AquaticSection Copy()
        {
            AquaticSection copy = new AquaticSection();
            copy._dataVersion = _dataVersion;
            return copy.LoadTree(_tree.Copy());
        }

        private bool UsesPaddedPacking { get { return _modern || _dataVersion >= 2529; } }

        private static int BitsFor(int count)
        {
            int bits = 0;
            for (int value = count - 1; value > 0; value >>= 1) bits++;
            return bits;
        }

        internal static int ReadPacked(long[] values, int index, int bits, bool padded)
        {
            if (values == null || values.Length == 0) return 0;
            ulong mask = (1UL << bits) - 1;
            if (padded) {
                int perLong = 64 / bits;
                int word = index / perLong;
                return word < values.Length ? (int)(((ulong)values[word] >> ((index % perLong) * bits)) & mask) : 0;
            }
            long bitIndex = (long)index * bits;
            int first = (int)(bitIndex >> 6);
            int offset = (int)(bitIndex & 63);
            if (first >= values.Length) return 0;
            ulong result = (ulong)values[first] >> offset;
            if (offset + bits > 64 && first + 1 < values.Length)
                result |= (ulong)values[first + 1] << (64 - offset);
            return (int)(result & mask);
        }

        internal static long[] WritePacked(int[] values, int bits, bool padded)
        {
            ulong mask = (1UL << bits) - 1;
            int length = padded
                ? (values.Length + (64 / bits) - 1) / (64 / bits)
                : (values.Length * bits + 63) / 64;
            long[] result = new long[length];
            for (int i = 0; i < values.Length; i++) {
                if (padded) {
                    int perLong = 64 / bits;
                    int word = i / perLong;
                    result[word] = (long)((ulong)result[word] | (((ulong)values[i] & mask) << ((i % perLong) * bits)));
                } else {
                    long bitIndex = (long)i * bits;
                    int word = (int)(bitIndex >> 6);
                    int offset = (int)(bitIndex & 63);
                    result[word] = (long)((ulong)result[word] | (((ulong)values[i] & mask) << offset));
                    if (offset + bits > 64)
                        result[word + 1] = (long)((ulong)result[word + 1] | (((ulong)values[i] & mask) >> (64 - offset)));
                }
            }
            return result;
        }

        private void BuildNbtTree()
        {
            _blocks = new YZXShortDataArray(new short[Size, Size, Size]);
            _data = new YZXNibbleArray(Size, Size, Size, new TagNodeByteArray(new byte[BlockCount / 2]));
            _skyLightTag = new TagNodeByteArray(new byte[BlockCount / 2]);
            _blockLightTag = new TagNodeByteArray(new byte[BlockCount / 2]);
            _skyLight = new YZXNibbleArray(Size, Size, Size, _skyLightTag);
            _blockLight = new YZXNibbleArray(Size, Size, Size, _blockLightTag);
            _palette = new[] { new PaletteBlock("minecraft:air", null, 0, 0) };
            _tree = new TagNodeCompound();
            _tree["Y"] = new TagNodeByte(_y);
            TagNodeList palette = new TagNodeList(TagType.TAG_COMPOUND) { _palette[0].BuildTree() };
            if (_modern) {
                TagNodeCompound container = new TagNodeCompound();
                container["palette"] = palette;
                _tree["block_states"] = container;
            } else {
                _tree["Palette"] = palette;
            }
            _tree["SkyLight"] = _skyLightTag;
            _tree["BlockLight"] = _blockLightTag;
        }
    }

    public struct PaletteBlock : IEquatable<PaletteBlock>
    {
        public readonly string Name;
        public readonly TagNodeCompound Properties;
        public readonly int ID;
        public readonly int Data;

        public PaletteBlock(BlockInfo blockInfo, string[] properties)
            : this(blockInfo == null ? "minecraft:air" : blockInfo.StrID, null,
                   blockInfo == null ? 0 : blockInfo.ID, 0) { }

        internal PaletteBlock(string name, TagNodeCompound properties, int id, int data)
        {
            Name = String.IsNullOrEmpty(name) ? "minecraft:air" : name;
            Properties = properties;
            ID = id;
            Data = data;
        }

        internal static PaletteBlock FromTree(TagNodeCompound tree)
        {
            TagNode nameNode;
            if (tree == null || !tree.TryGetValue("Name", out nameNode)) nameNode = null;
            TagNodeString nameTag = nameNode as TagNodeString;
            string name = nameTag == null ? "minecraft:air" : nameTag.Data;
            TagNode propertiesNode;
            if (tree == null || !tree.TryGetValue("Properties", out propertiesNode)) propertiesNode = null;
            TagNodeCompound properties = propertiesNode as TagNodeCompound;
            int legacyId;
            int legacyData;
            if (BlockInfo.TryGetLegacyBlockState(name, properties, out legacyId, out legacyData))
                return new PaletteBlock(name, properties, legacyId, legacyData);
            BlockInfo blockInfo;
            if (name != null && BlockInfo.BlockNameTable.TryGetValue(name, out blockInfo))
                return new PaletteBlock(name, properties, blockInfo.ID, 0);
            ItemInfo info;
            if (name != null && ItemInfo.StrTable.TryGetValue(name, out info))
                return new PaletteBlock(name, properties, info.ID, 0);
            return new PaletteBlock(name, properties, 0, 0);
        }

        internal TagNodeCompound BuildTree()
        {
            TagNodeCompound result = new TagNodeCompound();
            result["Name"] = new TagNodeString(Name);
            if (Properties != null && Properties.Count > 0) result["Properties"] = Properties;
            return result;
        }

        public bool Equals(PaletteBlock other)
        {
            if (Name != other.Name) return false;
            if (Properties == null || Properties.Count == 0) return other.Properties == null || other.Properties.Count == 0;
            if (other.Properties == null || Properties.Count != other.Properties.Count) return false;
            foreach (KeyValuePair<string, TagNode> property in Properties) {
                TagNodeString left = property.Value as TagNodeString;
                TagNodeString right = other.Properties[property.Key] as TagNodeString;
                if (left == null || right == null || left.Data != right.Data) return false;
            }
            return true;
        }

        public override bool Equals(object obj) { return obj is PaletteBlock && Equals((PaletteBlock)obj); }
        public override int GetHashCode() { return Name.GetHashCode(); }
    }
}
