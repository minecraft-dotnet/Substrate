using Substrate.Nbt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.Source.Nbt
{
    public class SchemaBuilder
    {
        public static SchemaNodeCompound FromClass(Type type, string enclosingName = null, SchemaOptions enclosingOptions = 0)
        {
            SchemaNodeCompound schema = new SchemaNodeCompound(enclosingName, enclosingOptions);

            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var untypedAttributes = property.GetCustomAttributes(typeof(TagNodeAttribute), false);

                if (untypedAttributes.Length > 0 && untypedAttributes[0] is TagNodeAttribute)
                {
                    var attribute = (TagNodeAttribute)untypedAttributes[0];

                    var name = attribute.Name ?? property.Name;
                    TagType tagType = attribute.Type ?? GetTagTypeForProperty(property);
                    SchemaOptions options = 0;
                    if (attribute.Optional) { options |= SchemaOptions.OPTIONAL; }
                    if (attribute.CreateOnMissing) { options |= SchemaOptions.CREATE_ON_MISSING; }

                    switch (tagType)
                    {
                    case TagType.TAG_BYTE:
                    case TagType.TAG_SHORT:
                    case TagType.TAG_INT:
                    case TagType.TAG_LONG:
                    case TagType.TAG_FLOAT:
                    case TagType.TAG_DOUBLE:
                        schema.Add(new SchemaNodeScaler(name, tagType, options));
                        break;

                    case TagType.TAG_STRING:
                        schema.Add(new SchemaNodeString(name, options));
                        break;

                    case TagType.TAG_BYTE_ARRAY:
                        schema.Add(new SchemaNodeArray(name, options));
                        break;

                    case TagType.TAG_INT_ARRAY:
                        schema.Add(new SchemaNodeIntArray(name, options));
                        break;

                    case TagType.TAG_SHORT_ARRAY:
                        schema.Add(new SchemaNodeShortArray(name, options));
                        break;

                    case TagType.TAG_LIST:
                        schema.Add(new SchemaNodeList(name, TagType.TAG_COMPOUND, FromClass(property.PropertyType.GetGenericArguments()[0]), options));
                        break;

                    case TagType.TAG_COMPOUND:
                        schema.Add(FromClass(property.PropertyType, name, options));
                        break;
                    }
                }
            }

            return schema;
        }

        private static TagType GetTagTypeForProperty(System.Reflection.PropertyInfo property)
        {
            var type = property.PropertyType;
            if (type == typeof(byte)) { return TagType.TAG_BYTE; }
            if (type == typeof(short)) { return TagType.TAG_SHORT; }
            if (type == typeof(int)) { return TagType.TAG_INT; }
            if (type == typeof(long)) { return TagType.TAG_LONG; }
            if (type == typeof(float)) { return TagType.TAG_FLOAT; }
            if (type == typeof(double)) { return TagType.TAG_DOUBLE; }
            if (type == typeof(string)) { return TagType.TAG_STRING; }

            if (type == typeof(List<byte>)) { return TagType.TAG_BYTE_ARRAY; }
            if (type == typeof(List<int>)) { return TagType.TAG_INT_ARRAY; }
            if (type == typeof(List<short>)) { return TagType.TAG_SHORT_ARRAY; }


            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
            {
                return TagType.TAG_LIST;
            }


            // check for tagnode attributes on members?
            return TagType.TAG_COMPOUND;
        }

        public static string FormatTree(SchemaNode root)
        {
            StringBuilder builder = new StringBuilder();

            FormatNode(root, builder, 0);

            return builder.ToString();
        }

        public static void FormatNode(SchemaNode node, StringBuilder builder, int tablevel)
        {
            builder.Append(new string('\t', tablevel));
            builder.AppendFormat("'{0}', {1}", node.Name, node.Options.ToString());
            builder.AppendLine();

            if (node is SchemaNodeCompound)
            {
                var ctree = node as SchemaNodeCompound;

                foreach (var subnode in ctree)
                {
                    FormatNode(subnode, builder, tablevel + 1);
                }
            }
            else if (node is SchemaNodeList)
            {
                var atree = node as SchemaNodeList;

                FormatNode(atree.SubSchema, builder, tablevel + 1);
            }
        }
    }
}
