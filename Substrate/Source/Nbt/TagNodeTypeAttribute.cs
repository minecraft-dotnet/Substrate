using System;

namespace Substrate.Nbt
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TagNodeTypeAttribute : Attribute
    {
        public TagType TagType { get; set; } = TagType.TAG_END;

        public TagType ListItemTagType { get; set; } = TagType.TAG_END;

        public Type ListItemType { get; set; }

        /// <summary>
        /// A custom schema type that will be used when building a schema tree.
        /// </summary>
        public Type SchemaType { get; set; }

        public TagNodeTypeAttribute(TagType tagType)
        {
            TagType = tagType;
        }
    }
}
