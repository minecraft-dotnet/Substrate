using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.Nbt
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TagNodeTypeAttribute : Attribute
    {
        public TagType TagType { get; set; }

        public TagType ItemTagType { get; set; }

        public TagNodeTypeAttribute(TagType tagType, TagType itemTagType = TagType.TAG_END)
        {
            TagType = tagType;
            ItemTagType = itemTagType;
        }
    }
}
