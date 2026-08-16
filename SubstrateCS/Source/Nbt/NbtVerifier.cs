using System;
using System.Collections.Generic;
using Substrate.Core;

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
        private string _tagName;
        private TagNode _parent;
        private TagNode _tag;
        private SchemaNode _schema;

        /// <summary>
        /// Gets the expected name of the <see cref="TagNode"/> referenced by this event.
        /// </summary>
        public string TagName
        {
            get { return _tagName; }
        }

        /// <summary>
        /// Gets the parent  <see cref="TagNode"/> of the <see cref="TagNode"/> referenced by this event, if it exists.
        /// </summary>
        public TagNode Parent
        {
            get { return _parent; }
        }

        /// <summary>
        /// Gets the <see cref="TagNode"/> referenced by this event.
        /// </summary>
        public TagNode Tag
        {
            get { return _tag; }
        }

        /// <summary>
        /// Gets the <see cref="SchemaNode"/> corresponding to the <see cref="TagNode"/> referenced by this event.
        /// </summary>
        public SchemaNode Schema
        {
            get { return _schema; }
        }

        /// <summary>
        /// Constructs a    event argument set.
        /// </summary>
        /// <param name="tagName">The expected name of a <see cref="TagNode"/>.</param>
        public TagEventArgs (string tagName)
            : base()
        {
            _tagName = tagName;
        }

        /// <summary>
        /// Constructs a new event argument set.
        /// </summary>
        /// <param name="tagName">The expected name of a <see cref="TagNode"/>.</param>
        /// <param name="tag">The <see cref="TagNode"/> involved in this event.</param>
        public TagEventArgs (string tagName, TagNode tag)
            : base()
        {
            _tag = tag;
            _tagName = tagName;
        }

        /// <summary>
        /// Constructs a new event argument set.
        /// </summary>
        /// <param name="schema">The <see cref="SchemaNode"/> corresponding to the <see cref="TagNode"/> involved in this event.</param>
        /// <param name="tag">The <see cref="TagNode"/> involved in this event.</param>
        public TagEventArgs (SchemaNode schema, TagNode tag)
            : base()
        {
            _tag = tag;
            _schema = schema;
        }
    }

    /// <summary>
    /// An event handler for intercepting and responding to verification failures of NBT trees.
    /// </summary>
    /// <param name="eventArgs">Information relating to a verification event.</param>
    /// <returns>A <see cref="TagEventCode"/> determining how the event processor should respond.</returns>
    public delegate TagEventCode VerifierEventHandler (TagEventArgs eventArgs);

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
        public NbtVerifier (TagNode root, SchemaNode schema)
        {
            _root = root;
            _schema = schema;
        }

        /// <summary>
        /// Invokes the verifier.
        /// </summary>
        /// <returns>Status indicating whether the NBT tree is valid for the given schema.</returns>
        public virtual bool Verify ()
        {
            return Verify(null, _root, _schema);
        }

        private bool Verify (TagNode parent, TagNode tag, SchemaNode schema)
        {
            if (tag == null) {
                return OnMissingTag(new TagEventArgs(schema.Name));
            }

            return schema.Verify(this, tag);
        }

        #region Event Handlers

        /// <summary>
        /// Processes registered events for <see cref="MissingTag"/> whenever an expected <see cref="TagNode"/> is not found.
        /// </summary>
        /// <param name="e">Arguments for this event.</param>
        /// <returns>Status indicating whether this event can be ignored.</returns>
        protected virtual bool OnMissingTag (TagEventArgs e)
            {
                if (MissingTag != null) {
                    foreach (VerifierEventHandler func in MissingTag.GetInvocationList()) {
                        TagEventCode code = func(e);
                        switch (code) {
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
            /// Processes registered events for <see cref="InvalidTagType"/> whenever an expected <see cref="TagNode"/> is of the wrong type and cannot be cast.
            /// </summary>
            /// <param name="e">Arguments for this event.</param>
            /// <returns>Status indicating whether this event can be ignored.</returns>
            public virtual bool OnInvalidTagType (TagEventArgs e)
            {
                if (InvalidTagType != null) {
                    foreach (VerifierEventHandler func in InvalidTagType.GetInvocationList()) {
                        TagEventCode code = func(e);
                        switch (code) {
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
            public virtual bool OnInvalidTagValue (TagEventArgs e)
            {
                if (InvalidTagValue != null) {
                    foreach (VerifierEventHandler func in InvalidTagValue.GetInvocationList()) {
                        TagEventCode code = func(e);
                        switch (code) {
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
