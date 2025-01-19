using Microsoft.VisualStudio.TestTools.UnitTesting;
using Substrate.Core;
using System;
using System.Collections.Generic;

namespace Substrate.Core.Tests
{
    [TestClass]
    public class PackedIndexLongListTests
    {
        [TestMethod]
        public void PackedIndexLongListTest()
        {
            var data = new long[] { 0x0123456789012345 };
            var x = new PackedIndexLongList(15, data);

            Assert.AreEqual(4, x.DataWidth);

            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(i % 10, x[i]);
            }
        }


        [TestMethod]
        public void PackedIndexLongList_GetDataIndexTest()
        {
            var data = new long[] { 0x00010203_04050607 };
            var x = new PackedIndexLongList(255, data);

            Assert.AreEqual(8, x.DataWidth);

            Assert.AreEqual(0, x.GetDataIndex(0), "0");
            Assert.AreEqual(0, x.GetDataIndex(1), "1");
            Assert.AreEqual(0, x.GetDataIndex(2), "2");
            Assert.AreEqual(0, x.GetDataIndex(3), "3");
            Assert.AreEqual(0, x.GetDataIndex(4), "4");
            Assert.AreEqual(0, x.GetDataIndex(5), "5");
            Assert.AreEqual(0, x.GetDataIndex(6), "6");
            Assert.AreEqual(0, x.GetDataIndex(7), "7");
            Assert.AreEqual(1, x.GetDataIndex(8), "8");
            Assert.AreEqual(1, x.GetDataIndex(9), "9");

            Assert.AreEqual(0, x.GetDataOffset(0), "0");
            Assert.AreEqual(8, x.GetDataOffset(1), "1");
            Assert.AreEqual(16, x.GetDataOffset(2), "2");
            Assert.AreEqual(24, x.GetDataOffset(3), "3");
            Assert.AreEqual(32, x.GetDataOffset(4), "4");
            Assert.AreEqual(40, x.GetDataOffset(5), "5");
            Assert.AreEqual(48, x.GetDataOffset(6), "6");
            Assert.AreEqual(56, x.GetDataOffset(7), "7");
            Assert.AreEqual(0, x.GetDataOffset(8), "8");
            Assert.AreEqual(8, x.GetDataOffset(9), "9");
        }
    }
}