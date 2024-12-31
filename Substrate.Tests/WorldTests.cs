using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Substrate.Nbt;
using System.IO;
using System.Diagnostics;
using Substrate.World;

namespace Substrate.Tests
{
    [TestClass]
    public class WorldTests
    {
        [TestInitialize]
        public void Initialize()
        {
            NbtVerifier.MissingTag += NbtVerifier_LogMissingTagEvent;
            NbtVerifier.UnexpectedTag += NbtVerifier_LogUnexpectedTagEvent;
            NbtVerifier.InvalidTagValue += NbtVerifier_LogInvalidTagValueEvent;
            NbtVerifier.InvalidTagType += NbtVerifier_LogInvalidTagTypeEvent;
        }

        public void Cleanup()
        {
            NbtVerifier.MissingTag -= NbtVerifier_LogMissingTagEvent;
            NbtVerifier.UnexpectedTag -= NbtVerifier_LogUnexpectedTagEvent;
            NbtVerifier.InvalidTagValue -= NbtVerifier_LogInvalidTagValueEvent;
            NbtVerifier.InvalidTagType -= NbtVerifier_LogInvalidTagTypeEvent;
        }

        private TagEventCode NbtVerifier_LogMissingTagEvent(TagEventArgs e)
        {
            Debug.WriteLine($"Missing {e.TagName} in {e.Schema.Name} {e.SchemaPath}");
            return TagEventCode.NEXT;
        }

        private TagEventCode NbtVerifier_LogUnexpectedTagEvent(TagEventArgs e)
        {
            Debug.WriteLine($"Unexpected tag {e.TagName} for {e.Schema.Name} in {e.SchemaPath}");
            return TagEventCode.NEXT;
        }

        private TagEventCode NbtVerifier_LogInvalidTagValueEvent(TagEventArgs e)
        {
            Debug.WriteLine($"Invalid value {e.Tag} for {e.Schema.Name} in {e.SchemaPath}");
            return TagEventCode.NEXT;
        }

        private TagEventCode NbtVerifier_LogInvalidTagTypeEvent(TagEventArgs e)
        {
            Debug.WriteLine($"{e.Tag} invalid type {e.Tag.GetTagType()} in {e.Schema.Name} {e.SchemaPath}");
            return TagEventCode.NEXT;
        }

        [TestMethod]
        public void OpenTest_1_6_4_survival()
        {
            NbtWorld world = AnvilWorld.Open(@"..\..\..\Data\1_6_4-survival\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_7_2_survival()
        {
            NbtWorld world = AnvilWorld.Open(@"..\..\..\Data\1_7_2-survival\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_7_10_survival()
        {
            NbtWorld world = AnvilWorld.Open(@"..\..\..\Data\1_7_10-survival\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_8_3_survival()
        {
            NbtWorld world = AnvilWorld.Open(@"..\..\..\Data\1_8_3-survival\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_8_3_debug()
        {
            NbtWorld world = AnvilWorld.Open(@"..\..\..\Data\1_8_3-debug\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_8_7_debug()
        {
            NbtWorld world = AnvilWorld.Open(@"..\..\..\Data\1_8_7-debug\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_8_7_survival()
        {
            NbtWorld world = AnvilWorld.Open(@"..\..\..\Data\1_8_7-survival\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_9_2_debug()
        {
            NbtWorld world = AnvilWorld.Open(@"..\..\..\Data\1_9_2-debug\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_9_2_survival()
        {
            NbtWorld world = AnvilWorld.Open(@"..\..\..\Data\1_9_2-survival\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_12_2_debug()
        {
            NbtWorld world = AnvilWorld.Open(@"..\..\..\Data\1_12_2-debug\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_12_2_survival()
        {
            NbtWorld world = AnvilWorld.Open(@"..\..\..\Data\1_12_2-survival\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_21_4_debug()
        {
            NbtWorld world = AnvilWorld.Open(@"..\..\..\Data\1_21_4-debug\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_21_4_survival()
        {
            NbtWorld world = AnvilWorld.Open(@"..\..\..\Data\1_21_4-survival\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_Colors_survival()
        {
            if (!Directory.Exists(@"..\..\..\Data\Colors of the Rainbow SURVIVAL\"))
            {
                Assert.Inconclusive("Level not found, skipping test");
            }

            NbtWorld world = AnvilWorld.Open(@"..\..\..\Data\Colors of the Rainbow SURVIVAL\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_Climatic_Islands_survival()
        {
            if (!Directory.Exists(@"..\..\..\Data\Climatic Islands [ENG]\"))
            {
                Assert.Inconclusive("Level not found, skipping test");
            }

            NbtWorld world = AnvilWorld.Open(@"..\..\..\Data\Climatic Islands [ENG]\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_Gothic_German_Castle()
        {
            if (!Directory.Exists(@"..\..\..\Data\gothic german castle\"))
            {
                Assert.Inconclusive("Level not found, skipping test");
            }

            NbtWorld world = AnvilWorld.Open(@"..\..\..\Data\gothic german castle\");
            Assert.IsNotNull(world);

            //TestUtils.TestWorld(world);
        }
    }
}
