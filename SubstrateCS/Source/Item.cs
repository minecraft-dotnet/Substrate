using System;
using System.Collections.Generic;
using Substrate.Core;
using Substrate.Nbt;

namespace Substrate
{
    /// <summary>
    /// Represents an item (or item stack) within an item slot.
    /// </summary>
    public class Item : INbtObject<Item>, ICopyable<Item>
    {
        private static readonly SchemaNodeCompound _schema = new SchemaNodeCompound("")
        {
            new SchemaNodeScaler("id", TagType.TAG_SHORT),
            new SchemaNodeScaler("Damage", TagType.TAG_SHORT),
            new SchemaNodeScaler("Count", TagType.TAG_BYTE),
            new SchemaNodeCompound("tag", new SchemaNodeCompound("") {
                new SchemaNodeList("ench", TagType.TAG_COMPOUND, Enchantment.Schema, SchemaOptions.OPTIONAL),
                new SchemaNodeScaler("title", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
                new SchemaNodeScaler("author", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
                new SchemaNodeList("pages", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
				new SchemaNodeList("StoredEnchantments", TagType.TAG_COMPOUND, Enchantment.Schema, SchemaOptions.OPTIONAL),
				new SchemaNodeCompound("display", new SchemaNodeCompound("") {
					new SchemaNodeScaler("color", TagType.TAG_INT, SchemaOptions.OPTIONAL),
					new SchemaNodeScaler("Name", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
					new SchemaNodeList("Lore", TagType.TAG_STRING, SchemaOptions.OPTIONAL)
				}, SchemaOptions.OPTIONAL)
            }, SchemaOptions.OPTIONAL),
        };

        private TagNodeCompound _source;

        private short _id;
        private byte _count;
		private short _damage;
		private int _color;
		private string _name;
		private string _lore;

		private List<Enchantment> _enchantments;
		private List<Enchantment> _storedEnchantments;

        /// <summary>
        /// Constructs an empty <see cref="Item"/> instance.
        /// </summary>
        public Item ()
        {
			_enchantments = new List<Enchantment>();
			_storedEnchantments = new List<Enchantment>();
            _source = new TagNodeCompound();
        }

        /// <summary>
        /// Constructs an <see cref="Item"/> instance representing the given item id.
        /// </summary>
        /// <param name="id">An item id.</param>
        public Item (int id)
            : this()
        {
            _id = (short)id;
        }

        #region Properties

        /// <summary>
        /// Gets an <see cref="ItemInfo"/> entry for this item's type.
        /// </summary>
        public ItemInfo Info
        {
            get { return ItemInfo.ItemTable[_id]; }
        }

        /// <summary>
        /// Gets or sets the current type (id) of the item.
        /// </summary>
        public int ID
        {
            get { return _id; }
            set { _id = (short)value; }
        }

        /// <summary>
        /// Gets or sets the damage value of the item.
        /// </summary>
        /// <remarks>The damage value may represent a generic data value for some items.</remarks>
        public int Damage
        {
            get { return _damage; }
            set { _damage = (short)value; }
        }

        /// <summary>
        /// Gets or sets the number of this item stacked together in an item slot.
        /// </summary>
        public int Count
        {
            get { return _count; }
            set { _count = (byte)value; }
        }

        /// <summary>
        /// Gets the list of <see cref="Enchantment"/>s applied to this item.
        /// </summary>
        public IList<Enchantment> Enchantments
        {
            get { return _enchantments; }
		}

		/// <summary>
		/// Gets the list of <see cref="Enchantment"/>s stored in this Enchanted Book (does not work with other items).
		/// </summary>
		public IList<Enchantment> StoredEnchantments
		{
			get { return _storedEnchantments; }
		}

		/// <summary>
		/// Gets or sets the custom name of this item.
		/// </summary>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		/// <summary>
		/// Gets or sets the lore text of this item.
		/// </summary>
		public string Lore
		{
			get { return _lore; }
			set { _lore = value; }
		}

		/// <summary>
		/// Gets or sets the display color value of this item (BGR).
		/// </summary>
		public int Color
		{
			get { return _color; }
			set { _color = (int)value; }
		}

		/// <summary>
		/// Gets or sets the red component of the display color value of this item.
		/// </summary>
		public byte Red
		{
			get { return (byte)(_color >> 16); }
			set { _color = (value << 16) | (_color & 0x00FF00) | (_color & 0x0000FF); }
		}

		/// <summary>
		/// Gets or sets the green component of the display color value of this item.
		/// </summary>
		public byte Green
		{
			get { return (byte)((_color & 0x00FF00) >> 8); }
			set { _color = (_color & 0xFF0000) | (value << 8) | (_color & 0x0000FF); }
		}

		/// <summary>
		/// Gets or sets the blue component of the display color value of this item.
		/// </summary>
		public byte Blue
		{
			get { return (byte)(_color & 0x0000FF); }
			set { _color = (_color & 0xFF0000) | (_color & 0x00FF00) | value; }
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
        public Item Copy ()
        {
            Item item = new Item();
            item._id = _id;
            item._count = _count;
			item._damage = _damage;
			item._color = _color;
			item._lore = _lore;
			item._name = _name;

            foreach (Enchantment e in _enchantments) {
                item._enchantments.Add(e.Copy());
			}
			foreach(Enchantment e in _storedEnchantments)
			{
				item._storedEnchantments.Add(e.Copy());
			}

            if (_source != null) {
                item._source = _source.Copy() as TagNodeCompound;
            }

            return item;
        }

        #endregion

        #region INBTObject<Item> Members

        /// <inheritdoc/>
        public Item LoadTree (TagNode tree)
        {
            TagNodeCompound ctree = tree as TagNodeCompound;
            if (ctree == null) {
                return null;
            }

            _enchantments.Clear();

            _id = ctree["id"].ToTagShort();
            _count = ctree["Count"].ToTagByte();
            _damage = ctree["Damage"].ToTagShort();

            if (ctree.ContainsKey("tag")) {
                TagNodeCompound tagtree = ctree["tag"].ToTagCompound();
                if (tagtree.ContainsKey("ench")) {
                    TagNodeList enchList = tagtree["ench"].ToTagList();

                    foreach (TagNode tag in enchList) {
                        _enchantments.Add(new Enchantment().LoadTree(tag));
                    }
				}
				if(tagtree.ContainsKey("StoredEnchantments"))
				{
					TagNodeList storedEnchList = tagtree["StoredEnchantments"].ToTagList();

					foreach(TagNode tag in storedEnchList)
					{
						_storedEnchantments.Add(new Enchantment().LoadTree(tag));
					}
				}
				if(tagtree.ContainsKey("display"))
				{
					TagNodeCompound displaytree = tagtree["display"].ToTagCompound();

					_color = displaytree["color"].ToTagInt();
					_name = displaytree["Name"].ToTagString();
					TagNodeList loreList = displaytree["Lore"].ToTagList();
					string str = "";
					foreach(TagNode tag in loreList)
					{
						str += tag.ToTagString() + "\n";
					}
					str = str.Substring(0, str.Length - 1); // get rid of last \n
					_lore = str;
				}
            }

            _source = ctree.Copy() as TagNodeCompound;

            return this;
        }

        /// <inheritdoc/>
        public Item LoadTreeSafe (TagNode tree)
        {
            if (!ValidateTree(tree)) {
                return null;
            }

            return LoadTree(tree);
        }

        /// <inheritdoc/>
        public TagNode BuildTree ()
        {
            TagNodeCompound tree = new TagNodeCompound();
            tree["id"] = new TagNodeShort(_id);
            tree["Count"] = new TagNodeByte(_count);
            tree["Damage"] = new TagNodeShort(_damage);

			TagNodeCompound tagtree = new TagNodeCompound();
            if (_enchantments.Count > 0) {
                TagNodeList enchList = new TagNodeList(TagType.TAG_COMPOUND);
                foreach (Enchantment e in _enchantments) {
                    enchList.Add(e.BuildTree());
                }

                tagtree["ench"] = enchList;

                if (_source != null && _source.ContainsKey("tag")) {
                    tagtree.MergeFrom(_source["tag"].ToTagCompound());
                }
            }
			if(_storedEnchantments.Count > 0)
			{
				TagNodeList storedEnchList = new TagNodeList(TagType.TAG_COMPOUND);
				foreach(Enchantment e in _storedEnchantments)
				{
					storedEnchList.Add(e.BuildTree());
				}

				tagtree["StoredEnchantments"] = storedEnchList;

				if(_source != null && _source.ContainsKey("tag"))
				{
					tagtree.MergeFrom(_source["tag"].ToTagCompound());
				}
			}

			if(_name != null || _lore != null || _color != 0)
			{
				TagNodeCompound displayTag = new TagNodeCompound();
				if(_color != 0)
				{
					displayTag.Add("color", new TagNodeInt(_color));
				}
				if(_name != null)
				{
					displayTag.Add("Name", new TagNodeString(_name));
				}
				if(_lore != null)
				{
					List<TagNode> LoreList = new List<TagNode>();
					string[] lores = _lore.Split('\n');
					foreach(string lore in lores)
					{
						LoreList.Add(new TagNodeString(lore));
					}
					displayTag.Add("Lore", new TagNodeList(TagType.TAG_STRING, LoreList));
				}
				tagtree["display"] = displayTag;
			}

			if(tagtree.Count > 0)
			{
				tree["tag"] = tagtree;
			}

            if (_source != null) {
                tree.MergeFrom(_source);
            }

            return tree;
        }

        /// <inheritdoc/>
        public bool ValidateTree (TagNode tree)
        {
            return new NbtVerifier(tree, _schema).Verify();
        }

        #endregion
    }
}
