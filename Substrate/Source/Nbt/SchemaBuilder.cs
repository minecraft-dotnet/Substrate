using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Substrate.Nbt;

namespace Substrate.Source.Nbt
{
    public class SchemaBuilder
    {
        public struct PropertyDetails
        {
            public TagType TagType;
            public TagType ItemTagType;
            public Type ListType;
            public SchemaOptions SchemaOptions;
            public bool CustomType;
        }

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

                    var propertyInfo = GetTagTypeForPropertyType(property.PropertyType);

                    TagType tagType = propertyInfo.CustomType ? propertyInfo.TagType :
                        attribute.TagType != TagType.TAG_END ? attribute.TagType :
                        propertyInfo.TagType;

                    SchemaOptions schemaOptions = propertyInfo.SchemaOptions;
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
                        if (propertyInfo.ItemTagType == TagType.TAG_COMPOUND)
                        {
                            schema.Add(new SchemaNodeList(name, TagType.TAG_COMPOUND, FromClass(propertyInfo.ListType), schemaOptions));
                        }
                        else
                        {
                            schema.Add(new SchemaNodeList(name, propertyInfo.ItemTagType, schemaOptions));
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

        private static PropertyDetails GetTagTypeForPropertyType(Type type)
        {
            PropertyDetails details = new PropertyDetails();

            var attr = type.GetCustomAttributes(typeof(TagNodeTypeAttribute), true).SingleOrDefault() as TagNodeTypeAttribute;
            if (attr != null)
            {
                details.TagType = attr.TagType;
                details.CustomType = true;
                return details;
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
            {
                details.ListType = type.GetGenericArguments()[0];
                var subTagType = GetTagTypeForPropertyType(details.ListType);

                details.TagType = TagType.TAG_LIST;
                details.ItemTagType = subTagType.TagType;
                return details;
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<,>))
            {
                if (type.GetGenericArguments()[0] != typeof(int))
                {
                    throw new InvalidOperationException("Dictionary-as-list is only supported with int key type");
                }

                details.ListType = type.GetGenericArguments()[1];
                var subTagType = GetTagTypeForPropertyType(details.ListType);

                details.TagType = TagType.TAG_LIST;
                details.ItemTagType = subTagType.TagType;
                return details;
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                type = type.GetGenericArguments()[0];
                details.SchemaOptions |= SchemaOptions.OPTIONAL;
            }

            if (type.IsEnum)
            {
                type = type.GetEnumUnderlyingType();
            }

            if (type == typeof(byte)) { details.TagType = TagType.TAG_BYTE; }
            else if (type == typeof(bool)) { details.TagType = TagType.TAG_BYTE; }
            else if (type == typeof(short)) { details.TagType = TagType.TAG_SHORT; }
            else if (type == typeof(int)) { details.TagType = TagType.TAG_INT; }
            else if (type == typeof(long)) { details.TagType = TagType.TAG_LONG; }
            else if (type == typeof(float)) { details.TagType = TagType.TAG_FLOAT; }
            else if (type == typeof(double)) { details.TagType = TagType.TAG_DOUBLE; }
            else if (type == typeof(string)) { details.TagType = TagType.TAG_STRING; }
            else if (type == typeof(List<byte>)) { details.TagType = TagType.TAG_BYTE_ARRAY; }
            else if (type == typeof(List<int>)) { details.TagType = TagType.TAG_INT_ARRAY; }
            else if (type == typeof(List<short>)) { details.TagType = TagType.TAG_SHORT_ARRAY; }
            else if (type == typeof(List<long>)) { details.TagType = TagType.TAG_LONG_ARRAY; }
            else { details.TagType = TagType.TAG_COMPOUND; }

            return details;
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
                    FormatNode(atree.ItemSchema, builder, tablevel + 1);
                }
            }
        }

        public static object LoadCompound(object nbtObject, TagNodeCompound tree, SchemaNodeCompound schemaNode)
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
                    LoadCompound(subObject, treeValue as TagNodeCompound, node as SchemaNodeCompound);
                }
                else if (node.Type == TagType.TAG_LIST)
                {
                    LoadList(subObject, prop, treeValue, node as SchemaNodeList);
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

        private static void LoadList(object subObject, PropertyInfo prop, TagNode treeValue, SchemaNodeList schemeNodeList)
        {
            if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
            {
                var listNode = treeValue.ToTagList();

                var listProp = (IList)subObject;
                listProp.Clear();

                var listItemType = prop.PropertyType.GetGenericArguments()[0];

                var typeCode = Type.GetTypeCode(listItemType);
                switch (typeCode)
                {
                case TypeCode.Boolean:
                    foreach (var n in listNode)
                    {
                        listProp.Add(n.ToTagByte().Data != 0);
                    }
                    break;
                case TypeCode.Byte:
                    foreach (var n in listNode)
                    {
                        listProp.Add(n.ToTagByte().Data);
                    }
                    break;
                case TypeCode.Int16:
                    foreach (var n in listNode)
                    {
                        listProp.Add(n.ToTagShort().Data);
                    }
                    break;
                case TypeCode.Int32:
                    foreach (var n in listNode)
                    {
                        listProp.Add(n.ToTagInt().Data);
                    }
                    break;
                case TypeCode.Int64:
                    foreach (var n in listNode)
                    {
                        listProp.Add(n.ToTagLong().Data);
                    }
                    break;
                case TypeCode.String:
                    foreach (var n in listNode)
                    {
                        listProp.Add(n.ToTagString().Data);
                    }
                    break;
                case TypeCode.Single:
                    foreach (var n in listNode)
                    {
                        listProp.Add(n.ToTagFloat().Data);
                    }
                    break;
                case TypeCode.Double:
                    foreach (var n in listNode)
                    {
                        listProp.Add(n.ToTagDouble().Data);
                    }
                    break;
                default:
                    foreach (var n in listNode)
                    {
                        var itemObject = Activator.CreateInstance(listItemType);
                        LoadCompound(itemObject, n as TagNodeCompound, schemeNodeList.ItemSchema as SchemaNodeCompound);
                        listProp.Add(itemObject);
                    }
                    break;
                }

                // prop.SetValue(nbtObject, list.ToList(), null);
            }
            else if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
            {
                var list = treeValue.ToTagList();

                var dict = subObject as IDictionary;
                foreach (var val in list)
                {
                    int slot = val.ToTagCompound()["slot"].ToTagInt();
                    dict.Add(slot, val);
                }
            }
        }
    }
}
