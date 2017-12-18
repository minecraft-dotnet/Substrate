using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.Nbt
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class TagNodeAttribute : Attribute
    {
        public string Name { get; set; }

        public TagType TagType { get; set; }

        public bool Optional { get; set; }

        public bool CreateOnMissing { get; set; }

        public TagNodeAttribute()
        {
        }

        public TagNodeAttribute(string name)
        {
            Name = name;
        }
    }
}
