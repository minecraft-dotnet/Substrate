using System;
using System.Collections.Generic;
using Substrate.Core;
using Substrate.Nbt;

namespace Substrate
{
    public class ItemTag : ICopyable<ItemTag>
    {

        /// <summary>
        /// Gets the list of <see cref="Enchantment"/>s applied to this item.
        /// </summary>
        [TagNode(Name = "ench", Optional = true)]
        public List<Enchantment> Enchantments { get; } = new List<Enchantment>();

        [TagNode(Name = "title", Optional = true)]
        public string Title { get; set; }

        [TagNode(Name = "author", Optional = true)]
        public string Author { get; set; }

        [TagNode(Name = "pages", Optional = true)]
        public List<string> Pages { get; } = new List<string>();



        #region ICopyable<Item> Members

        /// <inheritdoc/>
        public virtual ItemTag Copy()
        {
            ItemTag itemTag = new ItemTag();
            itemTag.Title = Title;
            itemTag.Author = Author;

            foreach (var e in Enchantments)
            {
                itemTag.Enchantments.Add(e.Copy());
            }

            foreach (var e in Pages)
            {
                itemTag.Pages.Add(e);
            }

            return itemTag;
        }

        #endregion

    }

    /// <summary>
    /// Represents an item (or item stack) within an item slot.
    /// </summary>
    public class Item : INbtObject<Item>, ICopyable<Item>
    {
        private static readonly SchemaNodeCompound _schema = new SchemaNodeCompound("")
        {
            new SchemaNodeString("id"),
            new SchemaNodeScalar("Damage", TagType.TAG_SHORT),
            new SchemaNodeScalar("Count", TagType.TAG_BYTE),
            new SchemaNodeScalar("Slot", TagType.TAG_BYTE, SchemaOptions.OPTIONAL),
            new SchemaNodeCompound("tag", new SchemaNodeCompound("") {
                new SchemaNodeList("ench", TagType.TAG_COMPOUND, Enchantment.Schema, SchemaOptions.OPTIONAL),
                new SchemaNodeString("title", SchemaOptions.OPTIONAL),
                new SchemaNodeString("author", SchemaOptions.OPTIONAL),
                new SchemaNodeList("pages", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
            }, SchemaOptions.OPTIONAL),
        };

        protected TagNodeCompound _source;

        private List<Enchantment> _enchantments;

        /// <summary>
        /// Constructs an empty <see cref="Item"/> instance.
        /// </summary>
        public Item()
        {
            _enchantments = new List<Enchantment>();
            _source = new TagNodeCompound();
        }

        /// <summary>
        /// Constructs an <see cref="Item"/> instance representing the given item id.
        /// </summary>
        /// <param name="id">An item id.</param>
        public Item(int id)
            : this()
        {
            ID = ItemInfo.ItemTable[id].NameID;
        }

        #region Properties

        ///// <summary>
        ///// Gets an <see cref="ItemInfo"/> entry for this item's type.
        ///// </summary>
        //public ItemInfo Info
        //{
        //    get { return ItemInfo.ItemTable[ID]; }
        //}

        /// <summary>
        /// Gets or sets the current type (id) of the item.
        /// </summary>
        [TagNode("id", TagType = TagType.TAG_STRING)]
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the damage value of the item.
        /// </summary>
        /// <remarks>The damage value may represent a generic data value for some items.</remarks>
        [TagNode(TagType = TagType.TAG_SHORT)]
        public int Damage { get; set; }

        /// <summary>
        /// Gets or sets the number of this item stacked together in an item slot.
        /// </summary>
        [TagNode(TagType = TagType.TAG_BYTE)]
        public int Count { get; set; }

        [TagNode(TagType = TagType.TAG_BYTE)]
        public int? Slot { get; set; }

        /// <summary>
        /// Gets or sets the number of this item stacked together in an item slot.
        /// </summary>
        [TagNode(Name = "tag", Optional = true)]
        public ItemTag Tag { get; set; }

        /// <summary>
        /// Gets the list of <see cref="Enchantment"/>s applied to this item.
        /// </summary>
        public List<Enchantment> Enchantments
        {
            get { return _enchantments; }
        }

        /// <summary>
        /// Gets the source <see cref="TagNodeCompound"/> used to create this <see cref="Item"/> if it exists.
        /// </summary>
        public TagNodeCompound Source
        {
            get { return _source; }
        }

        /// <summary>
        /// Gets a <see cref="SchemaNode"/> representing the schema of an item.
        /// </summary>
        public static SchemaNodeCompound Schema
        {
            get { return _schema; }
        }

        #endregion

        #region ICopyable<Item> Members

        /// <inheritdoc/>
        public virtual Item Copy()
        {
            Item item = new Item();
            item.ID = ID;
            item.Count = Count;
            item.Damage = Damage;

            foreach (Enchantment e in _enchantments)
            {
                item._enchantments.Add(e.Copy());
            }

            if (_source != null)
            {
                item._source = _source.Copy() as TagNodeCompound;
            }

            return item;
        }

        #endregion

        #region INBTObject<Item> Members

        /// <inheritdoc/>
        public Item LoadTree(TagNode tree)
        {
            TagNodeCompound ctree = tree as TagNodeCompound;
            if (ctree == null)
            {
                return null;
            }

            _enchantments.Clear();

            var id = ctree["id"];
            if (id.GetTagType() == TagType.TAG_SHORT)
            {
                ID = ItemInfo.ItemTable[id.ToTagShort()].NameID;
            }
            else
            {
                ID = id.ToTagString();
            }

            Count = ctree["Count"].ToTagByte();
            Damage = ctree["Damage"].ToTagShort();

            if (ctree.ContainsKey("tag"))
            {
                TagNodeCompound tagtree = ctree["tag"].ToTagCompound();
                if (tagtree.ContainsKey("ench"))
                {
                    TagNodeList enchList = tagtree["ench"].ToTagList();

                    foreach (TagNode tag in enchList)
                    {
                        _enchantments.Add(new Enchantment().LoadTree(tag));
                    }
                }
            }

            _source = ctree.Copy() as TagNodeCompound;

            return this;
        }

        /// <inheritdoc/>
        public Item LoadTreeSafe(TagNode tree)
        {
            if (!ValidateTree(tree))
            {
                return null;
            }

            return LoadTree(tree);
        }

        /// <inheritdoc/>
        public TagNode BuildTree()
        {
            TagNodeCompound tree = new TagNodeCompound();
            tree["id"] = new TagNodeString(ID);
            tree["Count"] = new TagNodeByte((byte)Count);
            tree["Damage"] = new TagNodeShort((short)Damage);

            if (_enchantments.Count > 0)
            {
                TagNodeList enchList = new TagNodeList(TagType.TAG_COMPOUND);
                foreach (Enchantment e in _enchantments)
                {
                    enchList.Add(e.BuildTree());
                }

                TagNodeCompound tagtree = new TagNodeCompound();
                tagtree["ench"] = enchList;

                if (_source != null && _source.ContainsKey("tag"))
                {
                    tagtree.MergeFrom(_source["tag"].ToTagCompound());
                }

                tree["tag"] = tagtree;
            }

            if (_source != null)
            {
                tree.MergeFrom(_source);
            }

            return tree;
        }

        /// <inheritdoc/>
        public bool ValidateTree(TagNode tree)
        {
            return new NbtVerifier(tree, _schema).Verify();
        }

        #endregion
    }
}
