using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.TileEntities
{
    using Substrate.Nbt;

    public class TileEntitySign : TileEntity
    {
        public static readonly SchemaNodeCompound SignSchema = TileEntity.Schema.MergeInto(new SchemaNodeCompound("")
        {
            new SchemaNodeString("id", TypeId),
            new SchemaNodeScaler("Text1", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
            new SchemaNodeScaler("Text2", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
            new SchemaNodeScaler("Text3", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
            new SchemaNodeScaler("Text4", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
        });

        public static string TypeId
        {
            get { return "minecraft:sign"; }
        }

        private string _text1 = "";
        private string _text2 = "";
        private string _text3 = "";
        private string _text4 = "";

        public string Text1
        {
            get { return _text1; }
            set { _text1 = value; }
        }

        public string Text2
        {
            get { return _text2; }
            set { _text2 = value; }
        }

        public string Text3
        {
            get { return _text3; }
            set { _text3 = value; }
        }

        public string Text4
        {
            get { return _text4; }
            set { _text4 = value; }
        }

        protected TileEntitySign (string id)
            : base(id)
        {
            Text1 = Text2 = Text3 = Text4 = "{\"text\":\"\"}";
        }

        public TileEntitySign ()
            : this(TypeId)
        {
        }

        public TileEntitySign (TileEntity te)
            : base(te)
        {
            TileEntitySign tes = te as TileEntitySign;
            if (tes != null) {
                _text1 = tes._text1;
                _text2 = tes._text2;
                _text3 = tes._text3;
                _text4 = tes._text4;
            }
        }


        #region ICopyable<TileEntity> Members

        public override TileEntity Copy ()
        {
            return new TileEntitySign(this);
        }

        #endregion


        #region INBTObject<TileEntity> Members

        public override TileEntity LoadTree (TagNode tree)
        {
            TagNodeCompound ctree = tree as TagNodeCompound;
            if (ctree == null || base.LoadTree(tree) == null) {
                return null;
            }

            TagNode frontNode;
            TagNodeCompound front;
            TagNode messagesNode;
            TagNodeList messages;
            if (ctree.TryGetValue("front_text", out frontNode)
                    && (front = frontNode as TagNodeCompound) != null
                    && front.TryGetValue("messages", out messagesNode)
                    && (messages = messagesNode as TagNodeList) != null) {
                _text1 = GetMessage(messages, 0);
                _text2 = GetMessage(messages, 1);
                _text3 = GetMessage(messages, 2);
                _text4 = GetMessage(messages, 3);
            }
            else {
                _text1 = GetLegacyText(ctree, "Text1");
                _text2 = GetLegacyText(ctree, "Text2");
                _text3 = GetLegacyText(ctree, "Text3");
                _text4 = GetLegacyText(ctree, "Text4");
            }

            return this;
        }

        public override TagNode BuildTree ()
        {
            TagNodeCompound tree = base.BuildTree() as TagNodeCompound;
            tree["Text1"] = new TagNodeString(_text1);
            tree["Text2"] = new TagNodeString(_text2);
            tree["Text3"] = new TagNodeString(_text3);
            tree["Text4"] = new TagNodeString(_text4);
            tree["front_text"] = BuildTextCompound(tree, "front_text",
                new string[] { _text1, _text2, _text3, _text4 });
            if (!tree.ContainsKey("back_text"))
                tree["back_text"] = BuildTextCompound(tree, "back_text",
                    new string[] { EmptyText, EmptyText, EmptyText, EmptyText });
            if (!tree.ContainsKey("is_waxed"))
                tree["is_waxed"] = new TagNodeByte(0);
            if (!tree.ContainsKey("components"))
                tree["components"] = new TagNodeCompound();
            if (!tree.ContainsKey("keepPacked"))
                tree["keepPacked"] = new TagNodeByte(0);

            return tree;
        }

        public override bool ValidateTree (TagNode tree)
        {
            TagNodeCompound compound = tree as TagNodeCompound;
            if (compound == null || !base.ValidateTree(tree)) return false;
            TagNode frontNode;
            TagNode messagesNode;
            TagNodeCompound front;
            TagNodeList messages;
            if (compound.TryGetValue("front_text", out frontNode)
                    && (front = frontNode as TagNodeCompound) != null
                    && front.TryGetValue("messages", out messagesNode)
                    && (messages = messagesNode as TagNodeList) != null)
                return messages.Count >= 4
                    && (messages.ValueType == TagType.TAG_STRING
                        || messages.ValueType == TagType.TAG_COMPOUND);
            return HasString(compound, "Text1") && HasString(compound, "Text2")
                && HasString(compound, "Text3") && HasString(compound, "Text4");
        }

        private const string EmptyText = "{\"text\":\"\"}";

        private static string GetMessage(TagNodeList messages, int index)
        {
            if (index >= messages.Count)
                return EmptyText;

            TagNodeString value = messages[index] as TagNodeString;
            if (value != null) {
                string data = value.Data;
                if (String.IsNullOrEmpty(data))
                    return EmptyText;
                char first = data[0];
                return first == '{' || first == '[' || first == '"'
                    ? data
                    : "{\"text\":\"" + EscapeJson(data) + "\"}";
            }

            TagNodeCompound component = messages[index] as TagNodeCompound;
            TagNode textNode;
            TagNodeString text;
            if (component != null
                    && component.TryGetValue("text", out textNode)
                    && (text = textNode as TagNodeString) != null)
                return "{\"text\":\"" + EscapeJson(text.Data) + "\"}";

            return EmptyText;
        }

        private static string GetLegacyText(TagNodeCompound tree, string name)
        {
            TagNode node;
            return tree.TryGetValue(name, out node) && node is TagNodeString
                ? node.ToTagString().Data
                : EmptyText;
        }

        private static bool HasString(TagNodeCompound tree, string name)
        {
            TagNode node;
            return tree.TryGetValue(name, out node) && node is TagNodeString;
        }

        private static TagNodeCompound BuildTextCompound(
            TagNodeCompound tree, string name, string[] values)
        {
            TagNode existingNode;
            TagNodeCompound existing = tree.TryGetValue(name, out existingNode)
                ? existingNode as TagNodeCompound
                : null;
            TagNodeCompound text = existing == null
                ? new TagNodeCompound()
                : existing.Copy() as TagNodeCompound;
            // Minecraft 26.2 stores each sign line as a plain NBT string.
            // Older releases stored a JSON text component in the same string.
            // Keep accepting the public JSON form, but write its visible text
            // using the native 26.2 representation.
            TagNodeList messages = new TagNodeList(TagType.TAG_STRING);
            foreach (string value in values)
                messages.Add(new TagNodeString(GetJsonText(value)));
            text["messages"] = messages;
            if (text.ContainsKey("filtered_messages"))
                text["filtered_messages"] = messages.Copy();
            if (!text.ContainsKey("color"))
                text["color"] = new TagNodeString("black");
            if (!text.ContainsKey("has_glowing_text"))
                text["has_glowing_text"] = new TagNodeByte(0);
            return text;
        }

        private static string GetJsonText(string value)
        {
            if (String.IsNullOrEmpty(value))
                return "";

            string source = value.Trim();
            int name = source.IndexOf("\"text\"", StringComparison.Ordinal);
            if (name < 0)
                return UnquoteJson(source);

            int colon = source.IndexOf(':', name + 6);
            if (colon < 0)
                return source;

            int quote = colon + 1;
            while (quote < source.Length && Char.IsWhiteSpace(source[quote]))
                quote++;
            if (quote >= source.Length || source[quote] != '"')
                return source;

            return ReadJsonString(source, quote);
        }

        private static string UnquoteJson(string value)
        {
            return value.Length >= 2 && value[0] == '"'
                    && value[value.Length - 1] == '"'
                ? ReadJsonString(value, 0)
                : value;
        }

        private static string ReadJsonString(string source, int quote)
        {
            StringBuilder result = new StringBuilder();
            for (int i = quote + 1; i < source.Length; i++) {
                char c = source[i];
                if (c == '"')
                    break;
                if (c != '\\' || ++i >= source.Length) {
                    result.Append(c);
                    continue;
                }

                c = source[i];
                switch (c) {
                    case '"': result.Append('"'); break;
                    case '\\': result.Append('\\'); break;
                    case '/': result.Append('/'); break;
                    case 'b': result.Append('\b'); break;
                    case 'f': result.Append('\f'); break;
                    case 'n': result.Append('\n'); break;
                    case 'r': result.Append('\r'); break;
                    case 't': result.Append('\t'); break;
                    case 'u':
                        if (i + 4 < source.Length) {
                            int code;
                            if (Int32.TryParse(source.Substring(i + 1, 4),
                                    System.Globalization.NumberStyles.HexNumber,
                                    System.Globalization.CultureInfo.InvariantCulture,
                                    out code)) {
                                result.Append((char)code);
                                i += 4;
                            }
                        }
                        break;
                    default: result.Append(c); break;
                }
            }
            return result.ToString();
        }

        private static string EscapeJson(string value)
        {
            if (value == null)
                return "";
            return value.Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\r", "\\r")
                .Replace("\n", "\\n")
                .Replace("\t", "\\t");
        }

        #endregion
    }
}
