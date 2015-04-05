using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.Nbt
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TagNodeAttribute : Attribute
    {
        string _name = null;

        public string Name { get { return _name; } set { _name = value; } }

        public TagType? Type { get; set; }

        public bool Optional { get; set; }

        public bool CreateOnMissing { get; set; }

        public TagNodeAttribute()
        {
        }

        public TagNodeAttribute(string name)
        {
            _name = name;
        }
    }
}
