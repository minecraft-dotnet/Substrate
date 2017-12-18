using System;
using Substrate.Nbt;

namespace Substrate
{
    public class Vector3 : INbtObject2
    {
        public double X { get; set; }
        
        public double Y { get; set; }
        
        public double Z { get; set; }

        public TagNode BuildTree()
        {
            var list = new TagNodeList(TagType.TAG_DOUBLE);
            list.Add(new TagNodeDouble(X));
            list.Add(new TagNodeDouble(Y));
            list.Add(new TagNodeDouble(Z));
            return list;
        }

        public void LoadTree(TagNode tree)
        {
            var list = tree.ToTagList();
            X = list[0].ToTagDouble();
            Y = list[1].ToTagDouble();
            Z = list[2].ToTagDouble();
        }
    }
}
