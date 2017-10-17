using System;
using System.Collections.Generic;
using Substrate.Nbt;
using Substrate.Core;

namespace Substrate
{
    /// <summary>
    /// Represents an enchantment that can be applied to some <see cref="Item"/>s.
    /// </summary>
    public class Enchantment : INbtObject<Enchantment>, ICopyable<Enchantment>
    {
        private static readonly SchemaNodeCompound _schema = new SchemaNodeCompound("")
        {
            new SchemaNodeScalar("id", TagType.TAG_SHORT),
            new SchemaNodeScalar("lvl", TagType.TAG_SHORT),
        };

        private TagNodeCompound _source;
        
        /// <summary>
        /// Constructs a blank <see cref="Enchantment"/>.
        /// </summary>
        public Enchantment()
        {
        }

        /// <summary>
        /// Constructs an <see cref="Enchantment"/> from a given id and level.
        /// </summary>
        /// <param name="id">The id (type) of the enchantment.</param>
        /// <param name="level">The level of the enchantment.</param>
        public Enchantment(int id, int level)
        {
            Id = id;
            Level = level;
        }

        #region Properties

        /// <summary>
        /// Gets an <see cref="EnchantmentInfo"/> entry for this enchantment's type.
        /// </summary>
        public EnchantmentInfo Info
        {
            get { return EnchantmentInfo.EnchantmentTable[Id]; }
        }

        /// <summary>
        /// Gets or sets the current type (id) of the enchantment.
        /// </summary>
        [TagNode("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the level of the enchantment.
        /// </summary>
        [TagNode("lvl")]
        public int Level { get; set; }

        /// <summary>
        /// Gets a <see cref="SchemaNode"/> representing the schema of an enchantment.
        /// </summary>
        public static SchemaNodeCompound Schema
        {
            get { return _schema; }
        }

        #endregion

        #region INbtObject<Enchantment> Members

        /// <inheritdoc />
        public Enchantment LoadTree(TagNode tree)
        {
            TagNodeCompound ctree = tree as TagNodeCompound;
            if (ctree == null)
            {
                return null;
            }

            Id = ctree["id"].ToTagShort();
            Level = ctree["lvl"].ToTagShort();

            _source = ctree.Copy() as TagNodeCompound;

            return this;
        }

        /// <inheritdoc />
        public Enchantment LoadTreeSafe(TagNode tree)
        {
            if (!ValidateTree(tree))
            {
                return null;
            }

            return LoadTree(tree);
        }

        /// <inheritdoc />
        public TagNode BuildTree()
        {
            TagNodeCompound tree = new TagNodeCompound();
            tree["id"] = new TagNodeShort((short)Id);
            tree["lvl"] = new TagNodeShort((short)Level);

            if (_source != null)
            {
                tree.MergeFrom(_source);
            }

            return tree;
        }

        /// <inheritdoc />
        public bool ValidateTree(TagNode tree)
        {
            return new NbtVerifier(tree, _schema).Verify();
        }

        #endregion

        #region ICopyable<Enchantment> Members

        /// <inheritdoc />
        public Enchantment Copy()
        {
            Enchantment ench = new Enchantment(Id, Level);

            if (_source != null)
            {
                ench._source = _source.Copy() as TagNodeCompound;
            }

            return ench;
        }

        #endregion
    }
}
