using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Substrate.Core;
using Substrate.Nbt;
using Substrate.TileEntities;

namespace Substrate.Tests
{
    [TestClass]
    public class AnvilTests
    {
        [TestMethod]
        public void PaletteSectionReadsAndWritesPre116PackedStates()
        {
            AssertSectionRoundTrip(2230, false);
        }

        [TestMethod]
        public void PaletteSectionReadsAndWrites116PaddedStates()
        {
            AssertSectionRoundTrip(2586, true);
        }

        [TestMethod]
        public void AquaticChunkSavePreservesDataVersionAndBlockChanges()
        {
            AquaticChunk chunk = AquaticChunk.Create(3, -2);
            chunk.Blocks.SetID(4, 65, 7, BlockType.STONE);

            MemoryStream stream = new MemoryStream();
            Assert.IsTrue(chunk.Save(stream));
            stream.Position = 0;

            NbtTree saved = new NbtTree(stream);
            Assert.AreEqual(1631, saved.Root["DataVersion"].ToTagInt().Data);
            AquaticChunk reloaded = AquaticChunk.CreateVerified(saved);
            Assert.IsNotNull(reloaded);
            Assert.AreEqual(3, reloaded.X);
            Assert.AreEqual(-2, reloaded.Z);
            Assert.AreEqual(BlockType.STONE, reloaded.Blocks.GetID(4, 65, 7));
        }

        [TestMethod]
        public void PalettePropertiesSurviveAnUnmodifiedRoundTrip()
        {
            TagNodeList palette = new TagNodeList(TagType.TAG_COMPOUND);
            palette.Add(PaletteEntry("minecraft:air"));
            TagNodeCompound north = PaletteEntry("minecraft:oak_stairs");
            north["Properties"] = Properties("facing", "north");
            TagNodeCompound south = PaletteEntry("minecraft:oak_stairs");
            south["Properties"] = Properties("facing", "south");
            palette.Add(north);
            palette.Add(south);

            int[] states = new int[4096];
            states[0] = 1;
            states[1] = 2;
            TagNodeCompound tree = BuildSection(states, false);
            tree["Palette"] = palette;

            TagNodeList rebuilt = new AquaticSection(tree, 2230).BuildTree().ToTagCompound()["Palette"].ToTagList();
            Assert.AreEqual(3, rebuilt.Count);
            Assert.AreEqual("north", rebuilt[0].ToTagCompound()["Properties"].ToTagCompound()["facing"].ToTagString().Data);
            Assert.AreEqual("south", rebuilt[1].ToTagCompound()["Properties"].ToTagCompound()["facing"].ToTagString().Data);
        }

        [TestMethod]
        public void ModernChunkReadsNegativeSectionsAndPreservesModernTags()
        {
            int[] states = new int[4096];
            states[0] = 1;
            TagNodeCompound section = BuildModernSection(-4, states);
            TagNodeList sections = new TagNodeList(TagType.TAG_COMPOUND);
            sections.Add(section);

            TagNodeCompound root = new TagNodeCompound();
            root["DataVersion"] = new TagNodeInt(5000);
            root["xPos"] = new TagNodeInt(8);
            root["zPos"] = new TagNodeInt(-9);
            root["Status"] = new TagNodeString("full");
            root["sections"] = sections;
            root["block_entities"] = new TagNodeList(TagType.TAG_COMPOUND);

            AquaticChunk chunk = AquaticChunk.CreateVerified(new NbtTree(root));
            Assert.IsNotNull(chunk);
            Assert.AreEqual(-64, chunk.MinimumY);
            Assert.AreEqual(384, chunk.Blocks.YDim);
            Assert.AreEqual(BlockType.STONE, chunk.Blocks.GetID(0, 0, 0));
            Assert.AreEqual(BlockType.STONE, chunk.GetBlockID(0, -64, 0));
            Assert.IsTrue(chunk.IsTerrainPopulated);
            TagNodeCompound properties = Properties("variant", "potent");
            chunk.SetBlockState(1, 319, 2, "minecraft:potent_sulfur", properties);

            MemoryStream stream = new MemoryStream();
            Assert.IsTrue(chunk.Save(stream));
            stream.Position = 0;
            NbtTree saved = new NbtTree(stream);
            Assert.IsFalse(saved.Root.ContainsKey("Level"));
            Assert.AreEqual(5000, saved.Root["DataVersion"].ToTagInt().Data);
            Assert.IsTrue(saved.Root.ContainsKey("sections"));
            Assert.IsFalse(saved.Root.ContainsKey("Biomes"));
            Assert.AreEqual(0, saved.Root["isLightOn"].ToTagByte().Data);

            TagNodeCompound savedSection = saved.Root["sections"].ToTagList()[0].ToTagCompound();
            Assert.IsTrue(savedSection.ContainsKey("block_states"));
            Assert.IsTrue(savedSection.ContainsKey("biomes"));
            Assert.IsFalse(savedSection.ContainsKey("SkyLight"));
            Assert.IsFalse(savedSection.ContainsKey("BlockLight"));

            AquaticChunk reloaded = AquaticChunk.CreateVerified(saved);
            Assert.AreEqual("minecraft:potent_sulfur", reloaded.GetBlockName(1, 319, 2));
        }

        [TestMethod]
        public void MissingHeightMapUsesMotionBlockingBlocksAndFluids()
        {
            int[] states = new int[4096];
            states[(10 * 16 + 0) * 16 + 0] = 1; // glass
            states[(12 * 16 + 0) * 16 + 1] = 2; // water
            states[(9 * 16 + 0) * 16 + 2] = 3;  // stone below leaves
            states[(14 * 16 + 0) * 16 + 2] = 4; // leaves
            states[(8 * 16 + 0) * 16 + 3] = 3;  // stone below tall grass
            states[(15 * 16 + 0) * 16 + 3] = 5; // tall grass
            states[(7 * 16 + 0) * 16 + 4] = 3;  // stone below leaf litter
            states[(13 * 16 + 0) * 16 + 4] = 6; // leaf litter

            TagNodeCompound section = BuildModernSection(0, states);
            TagNodeList palette = section["block_states"].ToTagCompound()["palette"].ToTagList();
            palette.Clear();
            palette.Add(PaletteEntry("minecraft:air"));
            palette.Add(PaletteEntry("minecraft:glass"));
            palette.Add(PaletteEntry("minecraft:water"));
            palette.Add(PaletteEntry("minecraft:stone"));
            palette.Add(PaletteEntry("minecraft:oak_leaves"));
            palette.Add(PaletteEntry("minecraft:tall_grass"));
            palette.Add(PaletteEntry("minecraft:leaf_litter"));

            TagNodeList sections = new TagNodeList(TagType.TAG_COMPOUND);
            sections.Add(section);
            TagNodeCompound root = new TagNodeCompound();
            root["DataVersion"] = new TagNodeInt(5000);
            root["xPos"] = new TagNodeInt(0);
            root["zPos"] = new TagNodeInt(0);
            root["Status"] = new TagNodeString("full");
            root["sections"] = sections;
            root["block_entities"] = new TagNodeList(TagType.TAG_COMPOUND);

            AquaticChunk chunk = AquaticChunk.CreateVerified(new NbtTree(root));
            Assert.AreEqual(11, chunk.Blocks.GetHeight(0, 0));
            Assert.AreEqual(13, chunk.Blocks.GetHeight(1, 0));
            Assert.AreEqual(10, chunk.Blocks.GetHeight(2, 0));
            Assert.AreEqual(9, chunk.Blocks.GetHeight(3, 0));
            Assert.AreEqual(8, chunk.Blocks.GetHeight(4, 0));
        }

        [TestMethod]
        public void RegionFileRoundTripsOversizedExternalChunkStreams()
        {
            string directory = Path.Combine(Path.GetTempPath(), "Substrate-Anvil-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(directory);
            try {
                string regionPath = Path.Combine(directory, "r.-2.3.mca");
                byte[] data = new byte[1100 * 1024];
                new Random(12345).NextBytes(data);

                using (RegionFile region = new RegionFile(regionPath)) {
                    using (Stream output = region.GetChunkDataOutputStream(2, 4))
                        output.Write(data, 0, data.Length);

                    Assert.IsTrue(File.Exists(Path.Combine(directory, "c.-62.100.mcc")));
                    using (Stream input = region.GetChunkDataInputStream(2, 4)) {
                        MemoryStream copy = new MemoryStream();
                        input.CopyTo(copy);
                        CollectionAssert.AreEqual(data, copy.ToArray());
                    }
                }
            } finally {
                Directory.Delete(directory, true);
            }
        }

        [TestMethod]
        public void BlockInfoRegistersEveryUpdateAquaticBlock()
        {
            const string names =
                "blue_ice carved_pumpkin dried_kelp_block oak_wood spruce_wood birch_wood jungle_wood acacia_wood dark_oak_wood " +
                "stripped_oak_log stripped_spruce_log stripped_birch_log stripped_jungle_log stripped_acacia_log stripped_dark_oak_log " +
                "stripped_oak_wood stripped_spruce_wood stripped_birch_wood stripped_jungle_wood stripped_acacia_wood stripped_dark_oak_wood " +
                "tube_coral_block brain_coral_block bubble_coral_block fire_coral_block horn_coral_block " +
                "dead_tube_coral_block dead_brain_coral_block dead_bubble_coral_block dead_fire_coral_block dead_horn_coral_block " +
                "prismarine_slab prismarine_stairs prismarine_brick_slab prismarine_brick_stairs dark_prismarine_slab dark_prismarine_stairs petrified_oak_slab " +
                "acacia_trapdoor birch_trapdoor dark_oak_trapdoor jungle_trapdoor spruce_trapdoor " +
                "cave_air void_air kelp kelp_plant seagrass tall_seagrass turtle_egg " +
                "tube_coral brain_coral bubble_coral fire_coral horn_coral " +
                "tube_coral_fan brain_coral_fan bubble_coral_fan fire_coral_fan horn_coral_fan " +
                "dead_tube_coral_fan dead_brain_coral_fan dead_bubble_coral_fan dead_fire_coral_fan dead_horn_coral_fan " +
                "tube_coral_wall_fan brain_coral_wall_fan bubble_coral_wall_fan fire_coral_wall_fan horn_coral_wall_fan " +
                "dead_tube_coral_wall_fan dead_brain_coral_wall_fan dead_bubble_coral_wall_fan dead_fire_coral_wall_fan dead_horn_coral_wall_fan " +
                "acacia_button birch_button dark_oak_button jungle_button spruce_button " +
                "acacia_pressure_plate birch_pressure_plate dark_oak_pressure_plate jungle_pressure_plate spruce_pressure_plate " +
                "bubble_column conduit sea_pickle";

            string[] expected = names.Split(' ');
            Assert.AreEqual(88, expected.Length);
            Assert.AreEqual(expected.Length, BlockInfo.AquaticBlocks.Count);
            foreach (string name in expected) {
                BlockInfo info;
                Assert.IsTrue(BlockInfo.BlockNameTable.TryGetValue("minecraft:" + name, out info), name);
                Assert.IsTrue(info.Registered, name);
                Assert.AreEqual("minecraft:" + name, info.StrID);
            }

            Assert.AreEqual(BlockState.FLUID, BlockInfo.BlockNameTable["minecraft:bubble_column"].State);
            Assert.AreEqual(BlockInfo.MAX_LUMINANCE, BlockInfo.BlockNameTable["minecraft:conduit"].Luminance);
        }

        [TestMethod]
        public void BlockInfoRegistersCompleteMinecraft262Registry()
        {
            Assert.AreEqual("26.2", BlockInfo.ModernBlockRegistryVersion);
            Assert.AreEqual(1196, BlockInfo.ModernBlocks.Count);

            HashSet<BlockInfo> registrations = new HashSet<BlockInfo>();
            foreach (BlockInfo info in BlockInfo.ModernBlocks) {
                Assert.IsTrue(info.Registered);
                registrations.Add(info);
            }

            Assert.AreSame(BlockInfo.Stone, BlockInfo.BlockNameTable["minecraft:stone"]);
            Assert.IsTrue(BlockInfo.BlockNameTable.ContainsKey("minecraft:blue_ice"));
            Assert.IsTrue(BlockInfo.BlockNameTable.ContainsKey("minecraft:trial_spawner"));
            Assert.IsTrue(BlockInfo.BlockNameTable.ContainsKey("minecraft:creaking_heart"));
            Assert.IsTrue(BlockInfo.BlockNameTable.ContainsKey("minecraft:potent_sulfur"));
            Assert.IsTrue(BlockInfo.BlockNameTable.ContainsKey("minecraft:chiseled_cinnabar"));
        }

        [TestMethod]
        public void ModernRegistryPreservesLegacyBlockIds()
        {
            foreach (KeyValuePair<string, ItemInfo> item in ItemInfo.StrTable) {
                BlockInfo block;
                if (item.Key == "minecraft:grass")
                    continue;
                if (item.Value.ID < 256 && BlockInfo.BlockNameTable.TryGetValue(item.Key, out block))
                    Assert.AreEqual(item.Value.ID, block.ID, item.Key);
            }

            BlockInfo oldNameShortGrass = BlockInfo.BlockNameTable["minecraft:grass"];
            Assert.AreEqual(BlockInfo.TallGrass.ID, oldNameShortGrass.ID);
            Assert.AreEqual(BlockState.NONSOLID, oldNameShortGrass.State);
            int grassId;
            int grassData;
            BlockInfo.GetLegacyBlockState(
                "minecraft:grass", out grassId, out grassData);
            Assert.AreEqual(BlockInfo.TallGrass.ID, grassId);
            Assert.AreEqual(1, grassData);

            Assert.AreEqual(BlockType.WOOD_PLANK, BlockInfo.BlockNameTable["minecraft:oak_planks"].ID);
            Assert.AreEqual(BlockType.WOOD_PLANK, BlockInfo.BlockNameTable["minecraft:spruce_planks"].ID);
            Assert.AreEqual(BlockType.WOOD, BlockInfo.BlockNameTable["minecraft:birch_log"].ID);
            Assert.AreEqual(BlockType.WOOL, BlockInfo.BlockNameTable["minecraft:red_wool"].ID);
            Assert.AreEqual(BlockType.BRICK_BLOCK, BlockInfo.BlockNameTable["minecraft:bricks"].ID);
            Assert.AreEqual(BlockType.SIGN_POST, BlockInfo.BlockNameTable["minecraft:oak_sign"].ID);
        }

        [TestMethod]
        public void LegacyIdsAndDataSerializeAsModernBlockStates()
        {
            AquaticSection section = new AquaticSection(0);
            section.Blocks[0, 0, 0] = BlockType.WOOD_PLANK;
            section.Data[0, 0, 0] = 1;
            section.Blocks[1, 0, 0] = BlockType.WOOL;
            section.Data[1, 0, 0] = 14;
            section.Blocks[2, 0, 0] = BlockType.WOOD;
            section.Data[2, 0, 0] = 6;
            section.Blocks[3, 0, 0] = BlockType.SIGN_POST;
            section.Data[3, 0, 0] = 4;
            section.Blocks[4, 0, 0] = BlockType.BRICK_BLOCK;

            AquaticSection roundTrip = new AquaticSection(section.BuildTree().ToTagCompound());
            Assert.AreEqual("minecraft:spruce_planks", roundTrip.GetBlockName(0, 0, 0));
            Assert.AreEqual("minecraft:red_wool", roundTrip.GetBlockName(1, 0, 0));
            Assert.AreEqual("minecraft:birch_log", roundTrip.GetBlockName(2, 0, 0));
            Assert.AreEqual("x", roundTrip.GetBlockProperties(2, 0, 0)["axis"].ToTagString().Data);
            Assert.AreEqual("minecraft:oak_sign", roundTrip.GetBlockName(3, 0, 0));
            Assert.AreEqual("4", roundTrip.GetBlockProperties(3, 0, 0)["rotation"].ToTagString().Data);
            Assert.AreEqual("minecraft:bricks", roundTrip.GetBlockName(4, 0, 0));
        }

        [TestMethod]
        public void SetIdAndDataWritesModernStatesAndRetainsLegacyValues()
        {
            AquaticChunk chunk = AquaticChunk.Create(0, 0);
            chunk.Blocks.SetID(0, 64, 0, BlockType.STAINED_GLASS, 11);
            chunk.Blocks.SetID(1, 64, 0, BlockInfo.AcaciaWood.ID, 12);

            MemoryStream stream = new MemoryStream();
            Assert.IsTrue(chunk.Save(stream));
            stream.Position = 0;
            AquaticChunk roundTrip = AquaticChunk.CreateVerified(new NbtTree(stream));

            Assert.AreEqual("minecraft:blue_stained_glass",
                roundTrip.GetBlockName(0, 64, 0));
            Assert.AreEqual("minecraft:acacia_wood",
                roundTrip.GetBlockName(1, 64, 0));
            Assert.AreEqual(BlockType.STAINED_GLASS,
                roundTrip.Blocks.GetID(0, 64, 0));
            Assert.AreEqual(11, roundTrip.Blocks.GetData(0, 64, 0));
            Assert.AreEqual(BlockInfo.AcaciaWood.ID,
                roundTrip.Blocks.GetID(1, 64, 0));
            Assert.AreEqual(12, roundTrip.Blocks.GetData(1, 64, 0));

#pragma warning disable 612, 618
            AlphaBlockCollection legacy = new AlphaBlockCollection(16, 128, 16);
#pragma warning restore 612, 618
            legacy.SetID(2, 65, 3, BlockType.STAINED_GLASS, 11);
            Assert.AreEqual(BlockType.STAINED_GLASS, legacy.GetID(2, 65, 3));
            Assert.AreEqual(11, legacy.GetData(2, 65, 3));
        }

        [TestMethod]
        public void PublicLegacyBlockStateConversionReturnsIdAndDataOrThrows()
        {
            int id;
            int data;
            BlockInfo.GetLegacyBlockState(
                AcquaticBlocks.BlueStainedGlass, out id, out data);
            Assert.AreEqual(BlockType.STAINED_GLASS, id);
            Assert.AreEqual(11, data);

            BlockInfo.GetLegacyBlockState(
                AcquaticBlocks.AcaciaWood, out id, out data);
            Assert.AreEqual(BlockInfo.AcaciaWood.ID, id);
            Assert.AreEqual(12, data);

            TagNodeCompound properties = new TagNodeCompound();
            properties[BlockProperties.Axis] = new TagNodeString("y");
            BlockInfo.GetLegacyBlockState(
                AcquaticBlocks.AcaciaLog, properties, out id, out data);
            Assert.AreEqual(BlockInfo.AcaciaWood.ID, id);
            Assert.AreEqual(0, data);

            bool threw = false;
            try {
                BlockInfo.GetLegacyBlockState(
                    AcquaticBlocks.LeafLitter, out id, out data);
            }
            catch (ArgumentException) {
                threw = true;
            }
            Assert.IsTrue(threw);
        }

        [TestMethod]
        public void SignTextReadsAndWritesModernFrontText()
        {
            TileEntitySign sign = new TileEntitySign();
            sign.X = 12;
            sign.Y = 64;
            sign.Z = 34;
            sign.Text1 = "{\"text\":\"First\"}";
            sign.Text2 = "{\"text\":\"Second\"}";
            TagNodeCompound tree = sign.BuildTree().ToTagCompound();

            TagNodeCompound front = tree["front_text"].ToTagCompound();
            TagNodeList messages = front["messages"].ToTagList();
            Assert.AreEqual(4, messages.Count);
            Assert.AreEqual(TagType.TAG_STRING, messages.ValueType);
            Assert.AreEqual("First", messages[0].ToTagString().Data);
            Assert.AreEqual("Second", messages[1].ToTagString().Data);
            Assert.AreEqual("black", front["color"].ToTagString().Data);
            Assert.AreEqual(0, front["has_glowing_text"].ToTagByte().Data);
            Assert.IsInstanceOfType(tree["components"], typeof(TagNodeCompound));
            Assert.AreEqual(0, tree["keepPacked"].ToTagByte().Data);

            tree.Remove("Text1");
            tree.Remove("Text2");
            tree.Remove("Text3");
            tree.Remove("Text4");
            front["color"] = new TagNodeString("blue");
            TileEntitySign loaded = TileEntityFactory.Create(tree) as TileEntitySign;
            Assert.IsNotNull(loaded);
            Assert.AreEqual(sign.Text1, loaded.Text1);
            Assert.AreEqual(sign.Text2, loaded.Text2);
            Assert.AreEqual("blue",
                loaded.BuildTree().ToTagCompound()["front_text"].ToTagCompound()["color"].ToTagString().Data);
        }

        [TestMethod]
        public void SignTextReadsLegacyStringComponents()
        {
            TileEntitySign sign = new TileEntitySign();
            TagNodeCompound tree = sign.BuildTree().ToTagCompound();
            TagNodeList messages = new TagNodeList(TagType.TAG_STRING);
            messages.Add(new TagNodeString("{\"text\":\"Legacy\"}"));
            messages.Add(new TagNodeString("{\"text\":\"Second\"}"));
            messages.Add(new TagNodeString("{\"text\":\"\"}"));
            messages.Add(new TagNodeString("{\"text\":\"\"}"));
            tree["front_text"].ToTagCompound()["messages"] = messages;

            TileEntitySign loaded = TileEntityFactory.Create(tree) as TileEntitySign;

            Assert.IsNotNull(loaded);
            Assert.AreEqual("{\"text\":\"Legacy\"}", loaded.Text1);
            Assert.AreEqual("{\"text\":\"Second\"}", loaded.Text2);
        }

        [TestMethod]
        public void SignTextReadsNativeMinecraft262PlainStrings()
        {
            TileEntitySign sign = new TileEntitySign();
            sign.X = 80;
            sign.Y = 63;
            sign.Z = 243;
            TagNodeCompound tree = sign.BuildTree().ToTagCompound();
            tree.Remove("Text1");
            tree.Remove("Text2");
            tree.Remove("Text3");
            tree.Remove("Text4");
            TagNodeList messages = new TagNodeList(TagType.TAG_STRING);
            messages.Add(new TagNodeString("This"));
            messages.Add(new TagNodeString("Is"));
            messages.Add(new TagNodeString("A"));
            messages.Add(new TagNodeString("Message"));
            tree["front_text"].ToTagCompound()["messages"] = messages;

            TileEntitySign loaded = TileEntityFactory.Create(tree) as TileEntitySign;

            Assert.IsNotNull(loaded);
            Assert.AreEqual("{\"text\":\"This\"}", loaded.Text1);
            Assert.AreEqual("{\"text\":\"Is\"}", loaded.Text2);
            Assert.AreEqual("{\"text\":\"A\"}", loaded.Text3);
            Assert.AreEqual("{\"text\":\"Message\"}", loaded.Text4);
        }

        [TestMethod]
        public void Minecraft262ConstantsCoverBlocksAndProperties()
        {
            Assert.AreEqual(1196, typeof(AcquaticBlocks).GetFields().Length);
            Assert.AreEqual("minecraft:air", AcquaticBlocks.Air);
            Assert.AreEqual("minecraft:leaf_litter", AcquaticBlocks.LeafLitter);
            Assert.AreEqual("minecraft:potent_sulfur", AcquaticBlocks.PotentSulfur);

            Assert.AreEqual(93, typeof(BlockProperties).GetFields().Length);
            Assert.AreEqual("facing", BlockProperties.Facing);
            Assert.AreEqual("segment_amount", BlockProperties.SegmentAmount);
            Assert.AreEqual("waterlogged", BlockProperties.Waterlogged);
        }

        [TestMethod]
        public void AquaticPaletteUsesRegisteredBlockInfo()
        {
            int[] states = new int[4096];
            states[0] = 1;
            TagNodeCompound sectionTree = BuildSection(states, false);
            sectionTree["Palette"].ToTagList()[1].ToTagCompound()["Name"] = new TagNodeString("minecraft:blue_ice");

            AquaticSection section = new AquaticSection(sectionTree, 1631);
            BlockInfo blueIce = BlockInfo.BlockNameTable["minecraft:blue_ice"];
            Assert.AreEqual(blueIce.ID, section.Blocks[0, 0, 0]);
            Assert.AreEqual("minecraft:blue_ice", section.GetBlockName(0, 0, 0));
        }

        private static void AssertSectionRoundTrip(int dataVersion, bool padded)
        {
            int[] states = new int[4096];
            for (int i = 0; i < states.Length; i++) states[i] = (i % 17 == 0) ? 1 : 0;

            TagNodeCompound sectionTree = BuildSection(states, padded);
            AquaticSection section = new AquaticSection(sectionTree, dataVersion);
            Assert.AreEqual(BlockType.STONE, section.Blocks[0, 0, 0]);
            Assert.AreEqual(BlockType.AIR, section.Blocks[1, 0, 0]);
            Assert.AreEqual(BlockType.STONE, section.Blocks[1, 0, 1]);

            section.Blocks[2, 3, 4] = BlockType.STONE;
            TagNodeCompound rebuilt = section.BuildTree().ToTagCompound();
            AquaticSection roundTrip = new AquaticSection(rebuilt, dataVersion);
            Assert.AreEqual(BlockType.STONE, roundTrip.Blocks[2, 3, 4]);
            Assert.AreEqual(BlockType.STONE, roundTrip.Blocks[0, 0, 0]);
        }

        private static TagNodeCompound BuildSection(int[] states, bool padded)
        {
            TagNodeList palette = new TagNodeList(TagType.TAG_COMPOUND);
            palette.Add(PaletteEntry("minecraft:air"));
            palette.Add(PaletteEntry("minecraft:stone"));

            TagNodeCompound section = new TagNodeCompound();
            section["Y"] = new TagNodeByte(0);
            section["Palette"] = palette;
            section["BlockStates"] = new TagNodeLongArray(Pack(states, 4, padded));
            section["SkyLight"] = new TagNodeByteArray(new byte[2048]);
            section["BlockLight"] = new TagNodeByteArray(new byte[2048]);
            return section;
        }

        private static TagNodeCompound BuildModernSection(int y, int[] states)
        {
            TagNodeList palette = new TagNodeList(TagType.TAG_COMPOUND);
            palette.Add(PaletteEntry("minecraft:air"));
            palette.Add(PaletteEntry("minecraft:stone"));
            TagNodeCompound blockStates = new TagNodeCompound();
            blockStates["palette"] = palette;
            blockStates["data"] = new TagNodeLongArray(Pack(states, 4, true));

            TagNodeList biomePalette = new TagNodeList(TagType.TAG_STRING);
            biomePalette.Add(new TagNodeString("minecraft:plains"));
            TagNodeCompound biomes = new TagNodeCompound();
            biomes["palette"] = biomePalette;

            TagNodeCompound section = new TagNodeCompound();
            section["Y"] = new TagNodeByte(unchecked((byte)(sbyte)y));
            section["block_states"] = blockStates;
            section["biomes"] = biomes;
            return section;
        }

        private static TagNodeCompound PaletteEntry(string name)
        {
            TagNodeCompound entry = new TagNodeCompound();
            entry["Name"] = new TagNodeString(name);
            return entry;
        }

        private static TagNodeCompound Properties(string name, string value)
        {
            TagNodeCompound properties = new TagNodeCompound();
            properties[name] = new TagNodeString(value);
            return properties;
        }

        private static long[] Pack(int[] values, int bits, bool padded)
        {
            int perLong = 64 / bits;
            int length = padded ? (values.Length + perLong - 1) / perLong : (values.Length * bits + 63) / 64;
            long[] result = new long[length];
            for (int i = 0; i < values.Length; i++) {
                if (padded) {
                    int word = i / perLong;
                    result[word] |= (long)((ulong)values[i] << ((i % perLong) * bits));
                } else {
                    int bit = i * bits;
                    int word = bit / 64;
                    int offset = bit % 64;
                    result[word] |= (long)((ulong)values[i] << offset);
                    if (offset + bits > 64) result[word + 1] |= (long)((ulong)values[i] >> (64 - offset));
                }
            }
            return result;
        }
    }
}
