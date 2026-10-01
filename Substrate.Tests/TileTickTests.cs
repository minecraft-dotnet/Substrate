using Microsoft.VisualStudio.TestTools.UnitTesting;
using Substrate.Nbt;

namespace Substrate.Tests
{
    [TestClass]
    public class TileTickTests
    {
        [TestMethod]
        public void StringBlockIdLoadsAndRoundTrips()
        {
            TagNodeCompound tree = CreateTick(new TagNodeString("minecraft:flowing_lava"));

            TileTick tick = TileTick.FromTreeSafe(tree);

            Assert.IsNotNull(tick);
            Assert.AreEqual(BlockType.LAVA, tick.ID);
            Assert.AreEqual("minecraft:flowing_lava", tick.StringID);
            TagNodeCompound result = tick.BuildTree().ToTagCompound();
            Assert.AreEqual(TagType.TAG_STRING, result["i"].GetTagType());
            Assert.AreEqual("minecraft:flowing_lava", result["i"].ToTagString().Data);
        }

        [TestMethod]
        public void NumericBlockIdRemainsSupported()
        {
            TagNodeCompound tree = CreateTick(new TagNodeInt(BlockType.LAVA));

            TileTick tick = TileTick.FromTreeSafe(tree);

            Assert.IsNotNull(tick);
            Assert.AreEqual(BlockType.LAVA, tick.ID);
            Assert.IsNull(tick.StringID);
            Assert.AreEqual(TagType.TAG_INT, tick.BuildTree().ToTagCompound()["i"].GetTagType());
        }

        private static TagNodeCompound CreateTick(TagNode id)
        {
            TagNodeCompound tree = new TagNodeCompound();
            tree["i"] = id;
            tree["t"] = new TagNodeInt(5);
            tree["p"] = new TagNodeInt(0);
            tree["x"] = new TagNodeInt(1);
            tree["y"] = new TagNodeInt(2);
            tree["z"] = new TagNodeInt(3);
            return tree;
        }
    }
}
