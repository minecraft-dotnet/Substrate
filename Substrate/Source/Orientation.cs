using System;
using Substrate.Nbt;

namespace Substrate
{
    public class Orientation : INbtObject2
    {
        public double Pitch { get; set; }

        public double Yaw { get; set; }

        public TagNode BuildTree()
        {
            var list = new TagNodeList(TagType.TAG_DOUBLE);
            list.Add(new TagNodeDouble(Yaw));
            list.Add(new TagNodeDouble(Pitch));
            return list;
        }

        public void LoadTree(TagNode tree)
        {
            var list = tree.ToTagList();
            Yaw = list[0].ToTagDouble();
            Pitch = list[1].ToTagDouble();
        }
    }
}
