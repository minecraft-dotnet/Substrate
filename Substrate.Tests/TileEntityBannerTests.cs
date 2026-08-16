using Microsoft.VisualStudio.TestTools.UnitTesting;
using Substrate.Nbt;
using Substrate.TileEntities;

namespace Substrate.Tests
{
    [TestClass]
    public class TileEntityBannerTests
    {
        [TestMethod]
        public void CompoundPatternEntriesValidateAndLoad()
        {
            TagNodeCompound tree = new TagNodeCompound();
            tree["id"] = new TagNodeString(TileEntityBanner.TypeId);
            tree["x"] = new TagNodeInt(1);
            tree["y"] = new TagNodeInt(2);
            tree["z"] = new TagNodeInt(3);
            tree["Base"] = new TagNodeInt(0);

            TagNodeList patterns = new TagNodeList(TagType.TAG_COMPOUND);
            for (int i = 0; i < 5; i++) {
                TagNodeCompound pattern = new TagNodeCompound();
                pattern["Color"] = new TagNodeInt(i);
                pattern["Pattern"] = new TagNodeString("bs");
                patterns.Add(pattern);
            }
            tree["Patterns"] = patterns;

            TileEntityBanner banner = new TileEntityBanner();

            Assert.IsTrue(banner.ValidateTree(tree));
            Assert.IsNotNull(banner.LoadTreeSafe(tree));
            Assert.AreEqual(5, banner.Patterns.Length);
        }
    }
}
