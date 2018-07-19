﻿using System;
using System.Collections.Generic;
using System.Text;
using Substrate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Substrate.Nbt;
using System.IO;

namespace Substrate.Tests
{
    [TestClass]
    public class WorldTests
    {
        [TestMethod]
        public void OpenTest_1_6_4_survival()
        {
            NbtWorld world = NbtWorld.Open(@"..\..\..\Data\1_6_4-survival\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_7_2_survival()
        {
            NbtWorld world = NbtWorld.Open(@"..\..\..\Data\1_7_2-survival\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_7_10_survival()
        {
            NbtWorld world = NbtWorld.Open(@"..\..\..\Data\1_7_10-survival\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_8_3_survival()
        {
            NbtWorld world = NbtWorld.Open(@"..\..\..\Data\1_8_3-survival\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_8_3_debug()
        {
            NbtWorld world = NbtWorld.Open(@"..\..\..\Data\1_8_3-debug\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_8_7_debug()
        {
            NbtWorld world = NbtWorld.Open(@"..\..\..\Data\1_8_7-debug\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_8_7_survival()
        {
            NbtWorld world = NbtWorld.Open(@"..\..\..\Data\1_8_7-survival\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_9_2_debug()
        {
            NbtWorld world = NbtWorld.Open(@"..\..\..\Data\1_9_2-debug\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_9_2_survival()
        {
            NbtWorld world = NbtWorld.Open(@"..\..\..\Data\1_9_2-survival\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_12_2_debug()
        {
            NbtWorld world = NbtWorld.Open(@"..\..\..\Data\1_12_2-debug\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_1_12_2_survival()
        {
            NbtWorld world = NbtWorld.Open(@"..\..\..\Data\1_12_2-survival\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_Colors_survival()
        {
            if (!Directory.Exists(@"..\..\..\Data\Colors of the Rainbow SURVIVAL\"))
            {
                Assert.Inconclusive("Level not found, skipping test");
            }

            NbtWorld world = NbtWorld.Open(@"..\..\..\Data\Colors of the Rainbow SURVIVAL\");
            Assert.IsNotNull(world);
        }

        [TestMethod]
        public void OpenTest_Climatic_Islands_survival()
        {
            if (!Directory.Exists(@"..\..\..\Data\Climatic Islands [ENG]\"))
            {
                Assert.Inconclusive("Level not found, skipping test");
            }

            NbtWorld world = NbtWorld.Open(@"..\..\..\Data\Climatic Islands [ENG]\");
            Assert.IsNotNull(world);
        }
    }
}
