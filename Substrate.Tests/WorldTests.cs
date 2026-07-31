using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Substrate;
using Substrate.Nbt;
using Substrate.TileEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using System.Security.Policy;
namespace Substrate.Tests
{
    [TestClass]
    public class WorldTests
    {
        [TestMethod]
        public void TallGrassHeight()
        {
            NbtWorld world = NbtWorld.Open(@"..\..\Data\26_2-missing-heightmaps\");
            var bm = world.GetBlockManager() as AnvilBlockManager;
            var height = bm.GetHeight(2939, 504);
            var block = bm.GetBlock(2939, 111, 504);
            Assert.AreEqual("minecraft:tall_grass", bm.GetStringID(2939, 111, 504));
            Assert.IsFalse(block.Info.ObscuresLight);
            Assert.AreEqual(BlockState.NONSOLID, block.Info.State);
            Assert.AreEqual(111, height);
        }

        [TestMethod]
        public void OpenTest_262_missing_heightmaps()
        {
            NbtWorld world = NbtWorld.Open(@"..\..\Data\26_2-missing-heightmaps\");
            var bm = world.GetBlockManager() as AnvilBlockManager;
            var height = bm.GetHeight(2431, 1911);
            Assert.AreEqual(111, height);
        }
        [TestMethod]
        public void LegacyBrickBlockSavesWithModernName()
        {
            string source = Path.GetFullPath(@"..\..\Data\26_2-missing-heightmaps\");
            string copy = Path.Combine(Path.GetTempPath(), "Substrate-" + Guid.NewGuid().ToString("N"));
            CopyDirectory(source, copy);
            try {
                NbtWorld world = NbtWorld.Open(copy);
                AnvilBlockManager blocks = world.GetBlockManager() as AnvilBlockManager;
                blocks.SetID(2431, 111, 1911, BlockInfo.BrickBlock.ID);
                blocks.SetData(2431, 111, 1911, 0);
                world.Save();

                world = NbtWorld.Open(copy);
                blocks = world.GetBlockManager() as AnvilBlockManager;
                Assert.AreEqual(BlockInfo.BrickBlock.ID, blocks.GetID(2431, 111, 1911));
                Assert.AreEqual("minecraft:bricks", blocks.GetStringID(2431, 111, 1911));
                blocks = null;
                world = null;
            }
            finally {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Directory.Delete(copy, true);
            }
        }

        [TestMethod]
        public void GlassPaneConnectionsAreSavedFromNeighboringWalls()
        {
            string source = Path.GetFullPath(@"..\..\Data\26_2-missing-heightmaps\");
            string copy = Path.Combine(Path.GetTempPath(), "Substrate-" + Guid.NewGuid().ToString("N"));
            CopyDirectory(source, copy);
            try {
                NbtWorld world = NbtWorld.Open(copy);
                AnvilBlockManager blocks = world.GetBlockManager() as AnvilBlockManager;
                const int x = 2430;
                const int y = 112;
                const int z = 1911;
                blocks.SetID(x, y, z - 1, BlockType.STONE);
                blocks.SetID(x, y, z + 1, BlockType.STONE);
                blocks.SetID(x - 1, y, z, BlockType.AIR);
                blocks.SetID(x + 1, y, z, BlockType.AIR);
                blocks.SetID(x, y, z, BlockType.GLASS_PANE);
                blocks.SetData(x, y, z, 0);
                world.Save();

                world = NbtWorld.Open(copy);
                blocks = world.GetBlockManager() as AnvilBlockManager;
                Assert.AreEqual("true", blocks.GetBlockProperty(x, y, z, BlockProperties.North));
                Assert.AreEqual("false", blocks.GetBlockProperty(x, y, z, BlockProperties.East));
                Assert.AreEqual("true", blocks.GetBlockProperty(x, y, z, BlockProperties.South));
                Assert.AreEqual("false", blocks.GetBlockProperty(x, y, z, BlockProperties.West));
                blocks = null;
                world = null;
            }
            finally {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Directory.Delete(copy, true);
            }
        }

        [TestMethod]
        public void LegacyConnectedBlocksSaveModernNeighborStates()
        {
            string source = Path.GetFullPath(@"..\..\Data\26_2-missing-heightmaps\");
            string copy = Path.Combine(Path.GetTempPath(), "Substrate-" + Guid.NewGuid().ToString("N"));
            CopyDirectory(source, copy);
            try {
                NbtWorld world = NbtWorld.Open(copy);
                AnvilBlockManager blocks = world.GetBlockManager() as AnvilBlockManager;
                const int y = 112;

                blocks.SetID(2418, y, 1905, BlockType.STONE);
                blocks.SetID(2418, y, 1907, BlockType.STONE);
                blocks.SetID(2418, y, 1906, BlockType.IRON_BARS);

                blocks.SetID(2421, y, 1906, BlockType.STONE);
                blocks.SetID(2423, y, 1906, BlockType.STONE);
                blocks.SetID(2422, y, 1906, BlockType.FENCE);

                blocks.SetID(2426, y, 1905, BlockType.STONE);
                blocks.SetID(2426, y, 1906, BlockType.COBBLESTONE_WALL);

                blocks.SetID(2418, y, 1911, BlockType.REDSTONE_WIRE);
                blocks.SetID(2418, y, 1912, BlockType.REDSTONE_WIRE);
                blocks.SetID(2418, y, 1913, BlockType.REDSTONE_WIRE);

                blocks.SetID(2421, y, 1912, BlockType.TRIPWIRE_HOOK);
                blocks.SetID(2423, y, 1912, BlockType.TRIPWIRE_HOOK);
                blocks.SetID(2422, y, 1912, BlockType.TRIPWIRE);

                blocks.SetID(2426, y - 1, 1912, BlockType.END_STONE);
                blocks.SetID(2426, y, 1911, 200); // chorus flower
                blocks.SetID(2426, y, 1912, 199); // chorus plant
                world.Save();

                world = NbtWorld.Open(copy);
                blocks = world.GetBlockManager() as AnvilBlockManager;
                Assert.AreEqual("true", blocks.GetBlockProperty(2418, y, 1906, BlockProperties.North));
                Assert.AreEqual("true", blocks.GetBlockProperty(2418, y, 1906, BlockProperties.South));
                Assert.AreEqual("true", blocks.GetBlockProperty(2422, y, 1906, BlockProperties.East));
                Assert.AreEqual("true", blocks.GetBlockProperty(2422, y, 1906, BlockProperties.West));
                Assert.AreEqual("low", blocks.GetBlockProperty(2426, y, 1906, BlockProperties.North));
                Assert.AreEqual("none", blocks.GetBlockProperty(2426, y, 1906, BlockProperties.South));
                Assert.AreEqual("side", blocks.GetBlockProperty(2418, y, 1912, BlockProperties.North));
                Assert.AreEqual("side", blocks.GetBlockProperty(2418, y, 1912, BlockProperties.South));
                Assert.AreEqual("true", blocks.GetBlockProperty(2422, y, 1912, BlockProperties.East));
                Assert.AreEqual("true", blocks.GetBlockProperty(2422, y, 1912, BlockProperties.West));
                Assert.AreEqual("true", blocks.GetBlockProperty(2426, y, 1912, BlockProperties.North));
                Assert.AreEqual("true", blocks.GetBlockProperty(2426, y, 1912, BlockProperties.Down));
                blocks = null;
                world = null;
            }
            finally {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Directory.Delete(copy, true);
            }
        }

        [TestMethod]
        public void SignTextSurvivesModernWorldSave()
        {
            string source = Path.GetFullPath(@"..\..\Data\26_2-missing-heightmaps\");
            string copy = Path.Combine(Path.GetTempPath(), "Substrate-" + Guid.NewGuid().ToString("N"));
            CopyDirectory(source, copy);
            try {
                NbtWorld world = NbtWorld.Open(copy);
                AnvilBlockManager blocks = world.GetBlockManager() as AnvilBlockManager;
                const int x = 2430;
                const int y = 112;
                const int z = 1911;
                AlphaBlock block = new AlphaBlock(BlockType.SIGN_POST);
                TileEntitySign sign = block.GetTileEntity() as TileEntitySign;
                Assert.IsNotNull(sign);
                sign.Text1 = "{\"text\":\"Duwamish\"}";
                sign.Text2 = "{\"text\":\"Avenue\"}";
                blocks.SetBlock(x, y, z, block);
                blocks.SetData(x, y, z, 0);
                world.Save();

                world = NbtWorld.Open(copy);
                blocks = world.GetBlockManager() as AnvilBlockManager;
                sign = blocks.GetTileEntity(x, y, z) as TileEntitySign;
                Assert.IsNotNull(sign);
                Assert.AreEqual(x, sign.X);
                Assert.AreEqual(y, sign.Y);
                Assert.AreEqual(z, sign.Z);
                Assert.AreEqual("{\"text\":\"Duwamish\"}", sign.Text1);
                Assert.AreEqual("{\"text\":\"Avenue\"}", sign.Text2);
                TagNodeCompound front = sign.Source["front_text"].ToTagCompound();
                TagNodeList messages = front["messages"].ToTagList();
                Assert.AreEqual(4, messages.Count);
                Assert.AreEqual(TagType.TAG_STRING, messages.ValueType);
                Assert.AreEqual("Duwamish", messages[0].ToTagString().Data);
                Assert.AreEqual("Avenue", messages[1].ToTagString().Data);
                blocks = null;
                world = null;
            }
            finally {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Directory.Delete(copy, true);
            }
        }

        private static void CopyDirectory(string source, string destination)
        {
            Directory.CreateDirectory(destination);
            foreach (string file in Directory.GetFiles(source))
                File.Copy(file, Path.Combine(destination, Path.GetFileName(file)));
            foreach (string directory in Directory.GetDirectories(source))
                CopyDirectory(directory, Path.Combine(destination, Path.GetFileName(directory)));
        }
        [TestMethod]
        public void OpenTest_262_creative()
        {
            NbtWorld world = NbtWorld.Open(@"..\..\Data\26_2-creative\");
            Assert.IsNotNull(world);
            Assert.AreEqual(80, world.Level.Spawn.X);
            Assert.AreEqual(63, world.Level.Spawn.Y);
            Assert.AreEqual(240, world.Level.Spawn.Z);

            AnvilWorld anvil = world as AnvilWorld;
            var block = anvil.GetBlockManager().GetBlock(79, 62, 249);
            Assert.AreEqual("minecraft:sand", block.Info.StrID);
            Assert.AreSame(BlockInfo.Sand, block.Info);
            Assert.AreEqual(12, block.Info.ID);
            block = anvil.GetBlockManager().GetBlock(79, 63, 249);
            var height = anvil.GetBlockManager().GetHeight(79, 249);
            Assert.AreEqual(63, height);
            Assert.AreEqual(AcquaticBlocks.LeafLitter, block.Info.StrID);
            Assert.AreEqual("2", anvil.GetBlockManager().GetBlockProperty(79, 63, 249, BlockProperties.SegmentAmount));
            Assert.AreEqual("north", anvil.GetBlockManager().GetBlockProperty(79, 63, 249, BlockProperties.Facing));
            anvil.GetBlockManager().SetID(79, 63, 249, BlockType.SIGN_POST);
            Assert.IsInstanceOfType(
                anvil.GetBlockManager().GetTileEntity(79, 63, 249),
                typeof(TileEntitySign));
            Assert.IsNotNull(anvil);
            Assert.IsTrue(anvil.GetRegionManager().GetRegionPath().EndsWith(
                Path.Combine("dimensions", "minecraft", "overworld", "region")));
            Assert.IsTrue(anvil.GetChunkManager().ChunkExists(-22, -11));
        }

        [TestMethod]
        public void OpenTest_1_6_4_survival()
        {
            NbtWorld world = NbtWorld.Open(@"..\..\Data\1_6_4-survival\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_7_2_survival()
        {
            NbtWorld world = NbtWorld.Open(@"..\..\Data\1_7_2-survival\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_7_10_survival()
        {
            NbtWorld world = NbtWorld.Open(@"..\..\Data\1_7_10-survival\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void SetBlockByNameUsesPaletteOrLegacyIdAndData()
        {
            NbtWorld modernWorld = NbtWorld.Open(@"..\..\Data\26_2-creative\");
            BlockManager modern = modernWorld.GetBlockManager() as BlockManager;
            Assert.IsNotNull(modern);
            modern.SetBlock(79, 63, 249, AcquaticBlocks.LeafLitter);
            Assert.AreEqual(
                AcquaticBlocks.LeafLitter, modern.GetStringID(79, 63, 249));
            modern.SetBlock(
                79, 64, 249, AcquaticBlocks.OakWallSign,
                facing: BlockFacing.East);
            Assert.AreEqual(
                AcquaticBlocks.OakWallSign, modern.GetStringID(79, 64, 249));
            Assert.AreEqual("east",
                modern.GetBlockProperty(
                    79, 64, 249, BlockProperties.Facing));
            Assert.IsNull(modern.GetBlockProperty(
                79, 64, 249, BlockProperties.Waterlogged));

            modern.SetBlock(
                80, 64, 249, AcquaticBlocks.BlueStainedGlassPane,
                north: false,
                east: false,
                south: false,
                west: false,
                waterlogged: false);
            Assert.AreEqual(
                AcquaticBlocks.BlueStainedGlassPane,
                modern.GetStringID(80, 64, 249));
            Assert.AreEqual(BlockType.STAINED_GLASS_PANE,
                modern.GetID(80, 64, 249));
            Assert.AreEqual(11, modern.GetData(80, 64, 249));

            NbtWorld legacyWorld = NbtWorld.Open(@"..\..\Data\1_7_10-creative\");
            BlockManager legacy = legacyWorld.GetBlockManager() as BlockManager;
            Assert.IsNotNull(legacy);
            int x = legacyWorld.Level.Spawn.X;
            int y = legacyWorld.Level.Spawn.Y;
            int z = legacyWorld.Level.Spawn.Z;
            legacy.SetBlock(x, y, z, AcquaticBlocks.BlueStainedGlass);
            Assert.AreEqual(BlockType.STAINED_GLASS, legacy.GetID(x, y, z));
            Assert.AreEqual(11, legacy.GetData(x, y, z));

            legacy.SetBlock(
                x, y + 1, z, AcquaticBlocks.AcaciaLog,
                axis: BlockAxis.X);
            Assert.AreEqual(
                BlockInfo.AcaciaWood.ID, legacy.GetID(x, y + 1, z));
            Assert.AreEqual(4, legacy.GetData(x, y + 1, z));

            bool threw = false;
            try {
                legacy.SetBlock(x, y, z, AcquaticBlocks.LeafLitter);
            }
            catch (ArgumentException) {
                threw = true;
            }
            Assert.IsTrue(threw);
        }

        [TestMethod]
        public void OpenTest_1_8_3_survival()
        {
            NbtWorld world = NbtWorld.Open(@"..\..\Data\1_8_3-survival\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_8_3_debug()
        {
            NbtWorld world = NbtWorld.Open(@"..\..\Data\1_8_3-debug\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_8_7_debug()
        {
            NbtWorld world = NbtWorld.Open(@"..\..\Data\1_8_7-debug\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_8_7_survival()
        {
            NbtWorld world = NbtWorld.Open(@"..\..\Data\1_8_7-survival\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_9_2_debug()
        {
            NbtWorld world = NbtWorld.Open(@"..\..\Data\1_9_2-debug\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void AnvilWorldUsesLegacyOverworldRegionLocation()
        {
            string directory = Path.Combine(Path.GetTempPath(), "Substrate-World-" + Guid.NewGuid().ToString("N"));
            try {
                AnvilWorld.Create(directory).Save();

                AnvilWorld world = AnvilWorld.Open(directory);
                string expected = Path.Combine(directory, "region");
                Assert.AreEqual(expected, world.GetRegionManager().GetRegionPath());

                world.GetRegionManager().CreateRegion(0, 0);
                Assert.IsTrue(File.Exists(Path.Combine(expected, "r.0.0.mca")));
            }
            finally {
                if (Directory.Exists(directory))
                    Directory.Delete(directory, true);
            }
        }

        [TestMethod]
        public void AnvilWorldUsesNamespacedOverworldRegionLocation()
        {
            string directory = Path.Combine(Path.GetTempPath(), "Substrate-World-" + Guid.NewGuid().ToString("N"));
            try {
                AnvilWorld.Create(directory).Save();

                string legacy = Path.Combine(directory, "region");
                string modern = Path.Combine(directory, "dimensions", "minecraft", "overworld", "region");
                Directory.CreateDirectory(Path.GetDirectoryName(modern));
                Directory.Move(legacy, modern);

                AnvilWorld world = NbtWorld.Open(directory) as AnvilWorld;
                Assert.IsNotNull(world);
                Assert.AreEqual(modern, world.GetRegionManager().GetRegionPath());

                world.GetRegionManager().CreateRegion(0, 0);
                Assert.IsTrue(File.Exists(Path.Combine(modern, "r.0.0.mca")));
                Assert.IsFalse(Directory.Exists(legacy));
            }
            finally {
                if (Directory.Exists(directory))
                    Directory.Delete(directory, true);
            }
        }
    }
}
