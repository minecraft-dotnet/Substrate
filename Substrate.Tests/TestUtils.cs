using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Substrate.Tests
{
    public static class TestUtils
    {
        public static void TestWorld(NbtWorld world)
        {
            var chunkManager = world.GetChunkManager();

            foreach (var chunk in chunkManager)
            {
                Assert.IsNotNull(chunk);
                Debug.WriteLine($"Loading Chunk: {chunk.X}, {chunk.Z}");
                
                var chunkRef = chunk.GetChunkRef();
                Assert.IsNotNull(chunkRef);
            }
        }
    }
}
