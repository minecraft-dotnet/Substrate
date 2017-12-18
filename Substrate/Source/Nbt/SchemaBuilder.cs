using Substrate.Nbt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
                    SchemaOptions schemaOptions = 0;
                    TagType tagType = attribute.TagType != TagType.TAG_END ? attribute.TagType : GetTagTypeForPropertyType(property.PropertyType, ref schemaOptions);
                    if (attribute.Optional) { schemaOptions |= SchemaOptions.OPTIONAL; }
                    if (attribute.CreateOnMissing) { schemaOptions |= SchemaOptions.CREATE_ON_MISSING; }

                    switch (tagType)
                    {
                    case TagType.TAG_BYTE:
                    case TagType.TAG_SHORT:
                    case TagType.TAG_INT:
                    case TagType.TAG_LONG:
                    case TagType.TAG_FLOAT:
                    case TagType.TAG_DOUBLE:
                        schema.Add(new SchemaNodeScalar(name, tagType, schemaOptions));
                        break;

                    case TagType.TAG_STRING:
                        schema.Add(new SchemaNodeString(name, schemaOptions));
                        break;

                    case TagType.TAG_BYTE_ARRAY:
                        schema.Add(new SchemaNodeByteArray(name, schemaOptions));
                        break;

                    case TagType.TAG_INT_ARRAY:
                        schema.Add(new SchemaNodeIntArray(name, schemaOptions));
                        break;

                    case TagType.TAG_SHORT_ARRAY:
                        schema.Add(new SchemaNodeShortArray(name, schemaOptions));
                        break;

                    case TagType.TAG_LIST:
                        var listType = property.PropertyType.GetGenericArguments()[0];
                        SchemaOptions schemaOptionsTemp = 0;
                        var subTagType = GetTagTypeForPropertyType(listType, ref schemaOptionsTemp);
                        if (subTagType == TagType.TAG_COMPOUND)
                        {
                            schema.Add(new SchemaNodeList(name, TagType.TAG_COMPOUND, FromClass(listType), schemaOptions));
                        }
                        else
                        {
                            schema.Add(new SchemaNodeList(name, subTagType, schemaOptions));
                        }
                        break;

                    case TagType.TAG_COMPOUND:
                        schema.Add(FromClass(property.PropertyType, name, schemaOptions));
                        break;
                    }
                }
            }

            return schema;
        }

        private static TagType GetTagTypeForPropertyType(Type type, ref SchemaOptions options)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                type = type.GetGenericArguments()[0];
                options |= SchemaOptions.OPTIONAL;
            }

            if (type.IsEnum)
            {
                type = type.GetEnumUnderlyingType();
            }

            if (type == typeof(byte)) { return TagType.TAG_BYTE; }
            if (type == typeof(bool)) { return TagType.TAG_BYTE; }
            if (type == typeof(short)) { return TagType.TAG_SHORT; }
            if (type == typeof(int)) { return TagType.TAG_INT; }
            if (type == typeof(long)) { return TagType.TAG_LONG; }
            if (type == typeof(float)) { return TagType.TAG_FLOAT; }
            if (type == typeof(double)) { return TagType.TAG_DOUBLE; }
            if (type == typeof(string)) { return TagType.TAG_STRING; }

            if (type == typeof(List<byte>)) { return TagType.TAG_BYTE_ARRAY; }
            if (type == typeof(List<int>)) { return TagType.TAG_INT_ARRAY; }
            if (type == typeof(List<short>)) { return TagType.TAG_SHORT_ARRAY; }
            if (type == typeof(List<long>)) { return TagType.TAG_LONG_ARRAY; }


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
            for (int i = 0; i < tablevel; ++i)
            {
                builder.Append("\t|");
            }
            builder.AppendFormat($"'{node.Name}', {node.Type} ({node.GetType().Name}), {node.Options}");
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

                if (atree.ItemType == TagType.TAG_COMPOUND)
                {
                    FormatNode(atree.SubSchema, builder, tablevel + 1);
                }
            }
        }

        public static object LoadTree(object nbtObject, TagNodeCompound tree, SchemaNodeCompound schemaNode)
        {
            var properties = nbtObject.GetType().GetProperties();

            foreach (var node in schemaNode)
            {
                tree.TryGetValue(node.Name, out var treeValue);

                if (treeValue == null) { continue; }

                var prop = properties.SingleOrDefault(p =>
                {
                    var attr = p.GetCustomAttributes(typeof(TagNodeAttribute), false).SingleOrDefault() as TagNodeAttribute;
                    return attr != null && (attr.Name != null ? attr.Name == node.Name : p.Name == node.Name);
                });

                if (prop == null || !prop.CanWrite)
                {
                    continue;
                }

                var subObject = prop.GetValue(nbtObject, null);
                if (subObject == null)
                {
                    subObject = Activator.CreateInstance(prop.PropertyType);
                    prop.SetValue(nbtObject, subObject, null);
                }

                var nbtObject2 = subObject as INbtObject2;
                if (nbtObject2 != null)
                {
                    nbtObject2.LoadTree(treeValue);
                }
                else if (node.Type == TagType.TAG_COMPOUND)
                {
                    LoadTree(subObject, treeValue as TagNodeCompound, node as SchemaNodeCompound);
                }
                else if (node.Type == TagType.TAG_LIST)
                {
                    if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                    {
                        var list = treeValue.ToTagList();

                        prop.SetValue(nbtObject, list.ToList(), null);
                    }
                }
                else
                {
                    var baseType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                    var typeCode = Type.GetTypeCode(baseType);

                    object propVal = null;
                    switch (typeCode)
                    {
                    case TypeCode.Boolean:
                        propVal = treeValue.ToTagByte().Data != 0 ? true : false;
                        break;
                    case TypeCode.Byte:
                        propVal = treeValue.ToTagByte().Data;
                        break;
                    case TypeCode.Int16:
                        propVal = treeValue.ToTagShort().Data;
                        break;
                    case TypeCode.Int32:
                        propVal = treeValue.ToTagInt().Data;
                        break;
                    case TypeCode.Int64:
                        propVal = treeValue.ToTagLong().Data;
                        break;
                    case TypeCode.String:
                        propVal = treeValue.ToTagString().Data;
                        break;
                    case TypeCode.Single:
                        propVal = treeValue.ToTagFloat().Data;
                        break;
                    case TypeCode.Double:
                        propVal = treeValue.ToTagDouble().Data;
                        break;
                    default:
                        break;
                    }

                    if (baseType.IsEnum)
                    {
                        propVal = Enum.ToObject(baseType, propVal);
                    }

                    prop.SetValue(nbtObject, propVal, null);

                }
            }

            return nbtObject;
        }
    }
}
