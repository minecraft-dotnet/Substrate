using System;
using System.Collections.Generic;
using System.Text;
using Substrate.Nbt;

namespace Substrate.Source.Core
{
    [TagNodeType(TagType.TAG_STRING, SchemaType = typeof(SchemaNodeResourceLocation))]
    public class ResourceLocation : INbtObject2
    {
        public string Namespace { get; set; }

        public string Path { get; set; }

        public ResourceLocation()
        {
        }

        public ResourceLocation(string value)
        {
            Init(value);
        }

        private void Init(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            int index = value.IndexOf(':');
            if (index == -1)
            {
                Namespace = null;
                Path = value;
            }
            else
            {
                Namespace = value.Substring(0, index);
                Path = value.Substring(index + 1);
            }
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Namespace))
            {
                return Path;
            }

            return $"{Namespace}:{Path}";
        }

        public TagNode BuildTree()
        {
            return new TagNodeString(ToString());
        }

        public void LoadTree(TagNode tree)
        {
            Init(tree.ToTagString());
        }
    }
}
