using System;
using System.Collections.Generic;
using System.Text;
using Substrate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
namespace Substrate.Tests
{
    [TestClass]
    public class BlockTests
    {
        static class DebugWorld
        {
            public const int Y = 70;
            public const int MinX = 1;
            public const int MaxX = 180;
            public const int MinZ = 1;
            public const int MaxZ = 180;
        }
        
        [TestMethod]
        public void BlockTest_1_8_3_debug()
        {
            NbtWorld world = NbtWorld.Open(@"..\..\Data\1_8_3-debug\");
            Assert.IsNotNull(world);

            for (int x = DebugWorld.MinX; x < DebugWorld.MaxX; x += 2)
            {
                for (int z = DebugWorld.MinZ; z < DebugWorld.MaxZ; z += 2)
                {
                    var blockRef = world.GetBlockManager().GetBlockRef(x, DebugWorld.Y, z);
                    var blockInfo = BlockInfo.BlockTable[blockRef.ID];

                    Debug.WriteLine(string.Format("ID:{0} ({1}), Data:{2}", blockRef.ID, blockInfo.Name, blockRef.Data));

                    Assert.IsTrue(blockInfo.Registered, "Block ID {0} has not been registered", blockRef.ID);
                    Assert.IsTrue(blockInfo.TestData(blockRef.Data), "Data value '0x{0:X4}' not recognised for block '{1}' at {2},{3}", blockRef.Data, blockInfo.Name, x, z);
                }
            }
        }

        [TestMethod]
        public void BlockTest_1_9_2_debug()
        {
            NbtWorld world = NbtWorld.Open(@"..\..\Data\1_9_2-debug\");
            Assert.IsNotNull(world);

            bool dataError = false;

            for (int x = DebugWorld.MinX; x < DebugWorld.MaxX; x += 2)
            {
                for (int z = DebugWorld.MinZ; z < DebugWorld.MaxZ; z += 2)
                {
                    var blockRef = world.GetBlockManager().GetBlockRef(x, DebugWorld.Y, z);
                    var blockInfo = BlockInfo.BlockTable[blockRef.ID];

                    Debug.WriteLine(string.Format("ID:{0} ({1}), Data:{2}", blockRef.ID, blockInfo.Name, blockRef.Data));

                    Assert.IsTrue(blockInfo.Registered, "Block ID {0} has not been registered", blockRef.ID);
                    if (!blockInfo.TestData(blockRef.Data))
                    {
                        dataError = true;
                        Debug.WriteLine("Data value '0x{0:X4}' not recognised for block '{1}' at {2},{3}", blockRef.Data, blockInfo.Name, x, z);
                    }
                }
            }
        }
    }
}
