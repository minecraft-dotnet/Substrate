using System;
using System.Collections.Generic;

namespace Substrate.Nbt
{
    /// <summary>
    /// Indicates how an <see cref="NbtVerifier"/> event processor should respond to returning event handler.
    /// </summary>
    public enum TagEventCode
    {
        /// <summary>
        /// The event processor should process the next event in the chian.
        /// </summary>
        NEXT,

        /// <summary>
        /// The event processor should ignore the verification failure and stop processing any remaining events.
        /// </summary>
        PASS,

        /// <summary>
        /// The event processor should fail and stop processing any remaining events.
        /// </summary>
        FAIL,
    }

    /// <summary>
    /// Event arguments for <see cref="NbtVerifier"/> failure events.
    /// </summary>
    public class TagEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the expected name of the <see cref="TagNode"/> referenced by this event.
        /// </summary>
        public string TagName { get; private set; }

        /// <summary>
        /// Gets the parent  <see cref="TagNode"/> of the <see cref="TagNode"/> referenced by this event, if it exists.
        /// </summary>
        public TagNode Parent { get; private set; }

        /// <summary>
        /// Gets the <see cref="TagNode"/> referenced by this event.
        /// </summary>
        public TagNode Tag { get; private set; }

        /// <summary>
        /// Gets the <see cref="SchemaNode"/> corresponding to the <see cref="TagNode"/> referenced by this event.
        /// </summary>
        public SchemaNode Schema { get; private set; }

        public string SchemaPath { get; private set; }

        /// <summary>
        /// Constructs a new event argument set.
        /// </summary>
        /// <param name="tagName">The expected name of a <see cref="TagNode"/>.</param>
        public TagEventArgs(string tagName)
            : base()
        {
            TagName = tagName;
        }

        /// <summary>
        /// Constructs a new event argument set.
        /// </summary>
        /// <param name="tagName">The expected name of a <see cref="TagNode"/>.</param>
        /// <param name="tag">The <see cref="TagNode"/> involved in this event.</param>
        /// <param name="schemaPath">Path in the schema.</param>
        /// <param name="parent">The optional parent of tag.</param>
        public TagEventArgs(string tagName, TagNode tag, string schemaPath = null, TagNode parent = null)
            : base()
        {
            TagName = tagName;
            Tag = tag;
            SchemaPath = schemaPath;
            Parent = parent;
        }

        /// <summary>
        /// Constructs a new event argument set.
        /// </summary>
        /// <param name="schema">The <see cref="SchemaNode"/> corresponding to the <see cref="TagNode"/> involved in this event.</param>
        /// <param name="tag">The <see cref="TagNode"/> involved in this event.</param>
        /// <param name="schemaPath">Path in the schema.</param>
        public TagEventArgs(SchemaNode schema, TagNode tag, string schemaPath = null)
            : base()
        {
            Tag = tag;
            Schema = schema;
            SchemaPath = schemaPath;
        }

        /// <summary>
        /// Constructs a new event argument set.
        /// </summary>
        /// <param name="tagName">The unexpected name of a <see cref="TagNode"/>.</param>
        /// <param name="schema">The <see cref="SchemaNode"/> corresponding to the <see cref="TagNode"/> involved in this event.</param>
        /// <param name="tag">The <see cref="TagNode"/> involved in this event.</param>
        /// <param name="schemaPath">Path in the schema.</param>
        /// <param name="parent">The optional parent of tag.</param>
        public TagEventArgs(string tagName, SchemaNode schema, TagNode tag = null, string schemaPath = null, TagNode parent = null)
            : base()
        {
            TagName = tagName;
            Schema = schema;
            Tag = tag;
            SchemaPath = schemaPath;
            Parent = parent;
        }
    }

    /// <summary>
    /// An event handler for intercepting and responding to verification failures of NBT trees.
    /// </summary>
    /// <param name="eventArgs">Information relating to a verification event.</param>
    /// <returns>A <see cref="TagEventCode"/> determining how the event processor should respond.</returns>
    public delegate TagEventCode VerifierEventHandler(TagEventArgs eventArgs);

    /// <summary>
    /// Verifies the integrity of an NBT tree against a schema definition.
    /// </summary>
    public class NbtVerifier
    {
        private TagNode _root;
        private SchemaNode _schema;

        /// <summary>
        /// An event that gets fired whenever an expected <see cref="TagNode"/> is not found.
        /// </summary>
        public static event VerifierEventHandler MissingTag;

        /// <summary>
        /// An event that gets fired whenever an unexpected <see cref="TagNode"/> is found.
        /// </summary>
        public static event VerifierEventHandler UnexpectedTag;

        /// <summary>
        /// An event that gets fired whenever an expected <see cref="TagNode"/> is of the wrong type and cannot be cast.
        /// </summary>
        public static event VerifierEventHandler InvalidTagType;

        /// <summary>
        /// An event that gets fired whenever an expected <see cref="TagNode"/> has a value that violates the schema.
        /// </summary>
        public static event VerifierEventHandler InvalidTagValue;

        /// <summary>
        /// Constructs a new <see cref="NbtVerifier"/> object for a given NBT tree and schema.
        /// </summary>
        /// <param name="root">A <see cref="TagNode"/> representing the root of an NBT tree.</param>
        /// <param name="schema">A <see cref="SchemaNode"/> representing the root of a schema definition for the NBT tree.</param>
        public NbtVerifier(TagNode root, SchemaNode schema)
        {
            _root = root;
            _schema = schema;
        }

        /// <summary>
        /// Invokes the verifier.
        /// </summary>
        /// <returns>Status indicating whether the NBT tree is valid for the given schema.</returns>
        public virtual bool Verify()
        {
            return Verify(null, _root, _schema, "\\");
        }

        private bool Verify(TagNode parent, TagNode tag, SchemaNode schema, string schemaPath)
        {
            if (tag == null)
            {
                return OnMissingTag(new TagEventArgs($"{schemaPath}\\{schema.Name}", schema, schemaPath: schemaPath));
            }

            SchemaNodeScalar scalar = schema as SchemaNodeScalar;
            if (scalar != null)
            {
                return VerifyScalar(tag, scalar, schemaPath);
            }

            SchemaNodeString str = schema as SchemaNodeString;
            if (str != null)
            {
                return VerifyString(tag, str, schemaPath);
            }

            SchemaNodeResourceLocation res = schema as SchemaNodeResourceLocation;
            if (res != null)
            {
                return VerifyResourceLocation(tag, res, schemaPath);
            }

            SchemaNodeByteArray array = schema as SchemaNodeByteArray;
            if (array != null)
            {
                return VerifyArray(tag, array, schemaPath);
            }

            SchemaNodeIntArray intarray = schema as SchemaNodeIntArray;
            if (intarray != null)
            {
                return VerifyIntArray(tag, intarray, schemaPath);
            }

            SchemaNodeLongArray longarray = schema as SchemaNodeLongArray;
            if (longarray != null)
            {
                return VerifyLongArray(tag, longarray, schemaPath);
            }

            SchemaNodeShortArray shortarray = schema as SchemaNodeShortArray;
            if (shortarray != null)
            {
                return VerifyShortArray(tag, shortarray, schemaPath);
            }

            SchemaNodeList list = schema as SchemaNodeList;
            if (list != null)
            {
                return VerifyList(tag, list, schemaPath);
            }

            SchemaNodeCompound compound = schema as SchemaNodeCompound;
            if (compound != null)
            {
                return VerifyCompound(tag, compound, schemaPath);
            }

            return OnInvalidTagType(new TagEventArgs(schema.Name, tag, schemaPath, parent));
        }

        private bool VerifyScalar(TagNode tag, SchemaNodeScalar schema, string schemaPath)
        {
            if (!tag.IsCastableTo(schema.Type))
            {
                if (!OnInvalidTagType(new TagEventArgs(schema.Name, schema, tag: tag, schemaPath: schemaPath)))
                {
                    return false;
                }
            }

            return true;
        }

        private bool VerifyString(TagNode tag, SchemaNodeString schema, string schemaPath)
        {
            TagNodeString stag = tag as TagNodeString;
            if (stag == null)
            {
                if (!OnInvalidTagType(new TagEventArgs(schema, tag, schemaPath: schemaPath)))
                {
                    return false;
                }
            }
            if (schema.Length > 0 && stag.Length > schema.Length)
            {
                if (!OnInvalidTagValue(new TagEventArgs(schema, tag, schemaPath: schemaPath)))
                {
                    return false;
                }
            }
            if (schema.Value != null && stag.Data != schema.Value)
            {
                if (!OnInvalidTagValue(new TagEventArgs(schema, tag, schemaPath: schemaPath)))
                {
                    return false;
                }
            }

            return true;
        }

        private bool VerifyResourceLocation(TagNode tag, SchemaNodeResourceLocation schema, string schemaPath)
        {
            
            if (tag is TagNodeString stag)
            {
                return true;
            }
            else if (tag is TagNodeInt itag)
            {
                return true;
            }

            if (!OnInvalidTagType(new TagEventArgs(schema, tag, schemaPath: schemaPath)))
            {
                return false;
            }

            return true;
        }

        private bool VerifyArray(TagNode tag, SchemaNodeByteArray schema, string schemaPath)
        {
            TagNodeByteArray atag = tag as TagNodeByteArray;
            if (atag == null)
            {
                if (!OnInvalidTagType(new TagEventArgs(schema, tag, schemaPath: schemaPath)))
                {
                    return false;
                }
            }
            if (schema.Length > 0 && atag.Length != schema.Length)
            {
                if (!OnInvalidTagValue(new TagEventArgs(schema, tag, schemaPath: schemaPath)))
                {
                    return false;
                }
            }

            return true;
        }

        private bool VerifyIntArray(TagNode tag, SchemaNodeIntArray schema, string schemaPath)
        {
            TagNodeIntArray atag = tag as TagNodeIntArray;
            if (atag == null)
            {
                if (tag is TagNodeList list)
                {
                    if (list.ValueType == TagType.TAG_INT)
                    {
                        return true;
                    }
                }

                if (!OnInvalidTagType(new TagEventArgs(schema, tag, schemaPath: schemaPath)))
                {
                    return false;
                }
            }
            if (schema.Length > 0 && atag.Length != schema.Length)
            {
                if (!OnInvalidTagValue(new TagEventArgs(schema, tag, schemaPath: schemaPath)))
                {
                    return false;
                }
            }

            return true;
        }

        private bool VerifyLongArray(TagNode tag, SchemaNodeLongArray schema, string schemaPath)
        {
            TagNodeLongArray atag = tag as TagNodeLongArray;
            if (atag == null)
            {
                if (tag is TagNodeList list)
                {
                    if (list.ValueType == TagType.TAG_LONG)
                    {
                        return true;
                    }
                }

                if (!OnInvalidTagType(new TagEventArgs(schema, tag, schemaPath: schemaPath)))
                {
                    return false;
                }
            }
            if (schema.Length > 0 && atag.Length != schema.Length)
            {
                if (!OnInvalidTagValue(new TagEventArgs(schema, tag, schemaPath: schemaPath)))
                {
                    return false;
                }
            }

            return true;
        }

        private bool VerifyShortArray(TagNode tag, SchemaNodeShortArray schema, string schemaPath)
        {
            TagNodeShortArray atag = tag as TagNodeShortArray;
            if (atag == null)
            {
                if (tag is TagNodeList list)
                {
                    if (list.ValueType == TagType.TAG_SHORT)
                    {
                        return true;
                    }
                }

                if (!OnInvalidTagType(new TagEventArgs(schema, tag, schemaPath: schemaPath)))
                {
                    return false;
                }
            }
            if (schema.Length > 0 && atag.Length != schema.Length)
            {
                if (!OnInvalidTagValue(new TagEventArgs(schema, tag, schemaPath: schemaPath)))
                {
                    return false;
                }
            }

            return true;
        }

        private bool VerifyList(TagNode tag, SchemaNodeList schema, string schemaPath)
        {
            TagNodeList ltag = tag as TagNodeList;
            if (ltag == null)
            {
                if (!OnInvalidTagType(new TagEventArgs(schema, tag, schemaPath: schemaPath)))
                {
                    return false;
                }
            }
            if (ltag.Count > 0 && ltag.ValueType != schema.ItemType)
            {
                if (!OnInvalidTagValue(new TagEventArgs(schema, tag, schemaPath: schemaPath)))
                {
                    return false;
                }
            }
            if (schema.Length > 0 && ltag.Count != schema.Length)
            {
                if (!OnInvalidTagValue(new TagEventArgs(schema, tag, schemaPath: schemaPath)))
                {
                    return false;
                }
            }

            // Patch up empty lists
            //if (schema.Length == 0) {
            //    tag = new NBT_List(schema.Type);
            //}

            bool pass = true;

            // If a subschema is set, test all items in list against it

            if (schema.ItemSchema != null)
            {
                foreach (TagNode v in ltag)
                {
                    pass = Verify(tag, v, schema.ItemSchema, $"{schemaPath}[]") && pass;
                }
            }

            return pass;
        }

        private bool VerifyCompound(TagNode tag, SchemaNodeCompound schema, string schemaPath)
        {
            TagNodeCompound ctag = tag as TagNodeCompound;
            if (ctag == null)
            {
                if (!OnInvalidTagType(new TagEventArgs(schema, tag, schemaPath: schemaPath)))
                {
                    return false;
                }
            }

            bool pass = true;

            Dictionary<string, TagNode> _scratch = new Dictionary<string, TagNode>();
            var foundNames = new HashSet<string>();

            foreach (SchemaNode node in schema)
            {
                TagNode value;
                bool found = ctag.TryGetValue(node.Name, out value);

                if (found)
                {
                    foundNames.Add(node.Name.ToLower());
                }

                if (value == null)
                {
                    if ((node.Options & SchemaOptions.CREATE_ON_MISSING) == SchemaOptions.CREATE_ON_MISSING)
                    {
                        _scratch[node.Name] = node.BuildDefaultTree();
                        continue;
                    }
                    else if ((node.Options & SchemaOptions.OPTIONAL) == SchemaOptions.OPTIONAL)
                    {
                        continue;
                    }
                }

                pass = Verify(tag, value, node, $"{schemaPath}\\{node.Name}") && pass;
            }

            foreach (var tagName in ctag.Keys)
            {
                if (!foundNames.Contains(tagName.ToLower()))
                {
                    if (!OnUnexpectedTag(new TagEventArgs(tagName, schema, schemaPath: schemaPath, parent: ctag)))
                    {
                        return false;
                    }
                }
            }

            foreach (KeyValuePair<string, TagNode> item in _scratch)
            {
                ctag[item.Key] = item.Value;
            }

            _scratch.Clear();

            return pass;
        }

        #region Event Handlers

        /// <summary>
        /// Processes registered events for <see cref="MissingTag"/> whenever an expected <see cref="TagNode"/> is not found.
        /// </summary>
        /// <param name="e">Arguments for this event.</param>
        /// <returns>Status indicating whether this event can be ignored.</returns>
        protected virtual bool OnMissingTag(TagEventArgs e)
        {
            if (MissingTag != null)
            {
                foreach (VerifierEventHandler func in MissingTag.GetInvocationList())
                {
                    TagEventCode code = func(e);
                    switch (code)
                    {
                    case TagEventCode.FAIL:
                        return false;
                    case TagEventCode.PASS:
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Processes registered events for <see cref="UnexpectedTag"/> whenever an unexpected <see cref="TagNode"/> is found.
        /// </summary>
        /// <param name="e">Arguments for this event.</param>
        /// <returns>Status indicating whether this event can be ignored.</returns>
        protected virtual bool OnUnexpectedTag(TagEventArgs e)
        {
            if (UnexpectedTag != null)
            {
                foreach (VerifierEventHandler func in UnexpectedTag.GetInvocationList())
                {
                    TagEventCode code = func(e);
                    switch (code)
                    {
                    case TagEventCode.FAIL:
                        return false;
                    case TagEventCode.PASS:
                        return true;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Processes registered events for <see cref="InvalidTagType"/> whenever an expected <see cref="TagNode"/> is of the wrong type and cannot be cast.
        /// </summary>
        /// <param name="e">Arguments for this event.</param>
        /// <returns>Status indicating whether this event can be ignored.</returns>
        protected virtual bool OnInvalidTagType(TagEventArgs e)
        {
            if (InvalidTagType != null)
            {
                foreach (VerifierEventHandler func in InvalidTagType.GetInvocationList())
                {
                    TagEventCode code = func(e);
                    switch (code)
                    {
                    case TagEventCode.FAIL:
                        return false;
                    case TagEventCode.PASS:
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Processes registered events for <see cref="InvalidTagValue"/> whenever an expected <see cref="TagNode"/> has a value that violates the schema.
        /// </summary>
        /// <param name="e">Arguments for this event.</param>
        /// <returns>Status indicating whether this event can be ignored.</returns>
        protected virtual bool OnInvalidTagValue(TagEventArgs e)
        {
            if (InvalidTagValue != null)
            {
                foreach (VerifierEventHandler func in InvalidTagValue.GetInvocationList())
                {
                    TagEventCode code = func(e);
                    switch (code)
                    {
                    case TagEventCode.FAIL:
                        return false;
                    case TagEventCode.PASS:
                        return true;
                    }
                }
            }

            return false;
        }

        #endregion
    }
}
