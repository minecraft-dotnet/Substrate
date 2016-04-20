using System;
using System.Collections.Generic;
using System.Text;
using Substrate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Substrate.Nbt;
using Substrate.Core;

namespace Substrate.Tests
{
    [TestClass]
    public class LevelTests
    {
        NbtTree LoadLevelTree(string path)
        {
            NBTFile nf = new NBTFile(path);
            NbtTree tree = null;

            using (Stream nbtstr = nf.GetDataInputStream())
            {
                if (nbtstr == null)
                {
                    return null;
                }

                tree = new NbtTree(nbtstr);
            }

            return tree;
        }

        [TestMethod]
        public void LoadTreeTest_1_6_4_survival()
        {
            NbtTree levelTree = LoadLevelTree(@"..\..\Data\1_6_4-survival\level.dat");

            Level level = new Level(null);
            level = level.LoadTreeSafe(levelTree.Root);
            Assert.IsNotNull(level);
        }

        [TestMethod]
        public void LoadTreeTest_1_7_2_survival()
        {
            NbtTree levelTree = LoadLevelTree(@"..\..\Data\1_7_2-survival\level.dat");

            Level level = new Level(null);
            level = level.LoadTreeSafe(levelTree.Root);
            Assert.IsNotNull(level);
        }

        [TestMethod]
        public void LoadTreeTest_1_7_10_survival()
        {
            NbtTree levelTree = LoadLevelTree(@"..\..\Data\1_7_10-survival\level.dat");

            Level level = new Level(null);
            level = level.LoadTreeSafe(levelTree.Root);
            Assert.IsNotNull(level);
        }

        [TestMethod]
        public void LoadTreeTest_1_8_3_survival()
        {
            NbtTree levelTree = LoadLevelTree(@"..\..\Data\1_8_3-survival\level.dat");

            Level level = new Level(null);
            level = level.LoadTreeSafe(levelTree.Root);
            Assert.IsNotNull(level);
        }
    }
}
