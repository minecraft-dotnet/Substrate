using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.Nbt
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TagNodeTypeAttribute : Attribute
    {
        public TagType TagType { get; set; } = TagType.TAG_END;

        public TagType ListItemTagType { get; set; } = TagType.TAG_END;

        public Type ListItemType { get; set; }

        public TagNodeTypeAttribute(TagType tagType)
        {
            TagType = tagType;
        }
    }
}
