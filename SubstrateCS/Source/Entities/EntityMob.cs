using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.Entities
{
	using Substrate.Nbt;
	using Substrate.Core;

	/// <summary>
	/// Encompasses data in the "ActiveEffects" compound attribute of mob entity types, used to specify potion effects
	/// </summary>
	public class ActiveEffects : ICopyable<ActiveEffects>
	{
		private byte _id;
		private byte _amplifier;
		private int _duration;
		private byte _ambient;

		/// <summary>
		/// Gets or sets the ID of the potion effect type.
		/// </summary>
		public int Id
		{
			get { return _id; }
			set { _id = (byte)value; }
		}

		/// <summary>
		/// Gets or sets the amplification of the potion effect.
		/// </summary>
		public int Amplifier
		{
			get { return _amplifier; }
			set { _amplifier = (byte)value; }
		}

		/// <summary>
		/// Gets or sets the remaining duration of the potion effect.
		/// </summary>
		public int Duration
		{
			get { return _duration; }
			set { _duration = value; }
		}

		/// <summary>
		/// Gets or sets whether the potion effect should be less intrusive on the screen.
		/// </summary>
		public bool Ambient
		{
			get { return _ambient == 1; }
			set { _ambient = value ? (byte)1 : (byte)0; }
		}

		/// <summary>
		/// Determine if the combination of properties in this ActiveEffects is valid.
		/// </summary>
		public bool IsValid
		{
			get
			{
				return !(_id == 0 || _amplifier == 0 || _duration == 0);
			}
		}

		#region ICopyable<ActiveEffects> Members

		public ActiveEffects Copy ()
		{
			ActiveEffects ae = new ActiveEffects();
			ae._amplifier = _amplifier;
			ae._duration = _duration;
			ae._id = _id;
			ae._ambient = _ambient;

			return ae;
		}

		#endregion
	}

	public class EntityMob : TypedEntity
	{
		public static readonly SchemaNodeCompound MobSchema = TypedEntity.Schema.MergeInto(new SchemaNodeCompound("")
        {
            new SchemaNodeString("id", TypeId),
            new SchemaNodeScaler("AttackTime", TagType.TAG_SHORT),
            new SchemaNodeScaler("DeathTime", TagType.TAG_SHORT),
            new SchemaNodeScaler("Health", TagType.TAG_SHORT),
            new SchemaNodeScaler("HurtTime", TagType.TAG_SHORT),
            new SchemaNodeList("ActiveEffects", TagType.TAG_COMPOUND, new SchemaNodeCompound()
			{
                new SchemaNodeScaler("Id", TagType.TAG_BYTE),
                new SchemaNodeScaler("Amplifier", TagType.TAG_BYTE),
                new SchemaNodeScaler("Duration", TagType.TAG_INT),
				new SchemaNodeScaler("Ambient", TagType.TAG_BYTE)
			}, SchemaOptions.OPTIONAL),
			new SchemaNodeList("DropChances", TagType.TAG_FLOAT, SchemaOptions.OPTIONAL),
			new SchemaNodeList("Equipment", TagType.TAG_COMPOUND, Item.Schema, SchemaOptions.OPTIONAL),
			new SchemaNodeScaler("CanPickUpLoot", TagType.TAG_BYTE, SchemaOptions.OPTIONAL),
			new SchemaNodeScaler("PersistenceRequired", TagType.TAG_BYTE, SchemaOptions.OPTIONAL),
			new SchemaNodeString("CustomName", SchemaOptions.OPTIONAL),
			new SchemaNodeScaler("CustomNameVisible", TagType.TAG_BYTE, SchemaOptions.OPTIONAL),
        });

		public static string TypeId
		{
			get { return "Mob"; }
		}

		private short _attackTime;
		private short _deathTime;
		private short _health;
		private short _hurtTime;
		private Item[] _equipment;
		private float[] _dropChances;
		private byte _canPickUpLoot;
		private byte _persistenceRequired;
		private string _customName;
		private byte _customNameVisible;

		private List<ActiveEffects> _activeEffects;

		public int AttackTime
		{
			get { return _attackTime; }
			set { _attackTime = (short)value; }
		}

		public int DeathTime
		{
			get { return _deathTime; }
			set { _deathTime = (short)value; }
		}

		public int Health
		{
			get { return _health; }
			set { _health = (short)value; }
		}

		public int HurtTime
		{
			get { return _hurtTime; }
			set { _hurtTime = (short)value; }
		}

		public bool CanPickUpLoot
		{
			get { return _canPickUpLoot == 1; }
			set { _canPickUpLoot = value ? (byte)1 : (byte)0; }
		}

		/// <summary>
		/// True if the mob should be unable to despawn normally, false otherwise.
		/// </summary>
		public bool PersistenceRequired
		{
			get { return _persistenceRequired == 1; }
			set { _persistenceRequired = value ? (byte)1 : (byte)0; }
		}

		public string CustomName
		{
			get { return _customName; }
			set { _customName = value; }
		}

		public bool CustomNameVisible
		{
			get { return _customNameVisible == 1; }
			set { _customNameVisible = value ? (byte)1 : (byte)0; }
		}

		public List<ActiveEffects> ActiveEffects
		{
			get { return _activeEffects; }
			set { _activeEffects = value; }
		}

		public Item Weapon
		{
			get { return _equipment[0]; }
			set { _equipment[0] = value; }
		}

		public Item FeetArmor
		{
			get { return _equipment[1]; }
			set { _equipment[1] = value; }
		}

		public Item LegArmor
		{
			get { return _equipment[2]; }
			set { _equipment[2] = value; }
		}

		public Item ChestArmor
		{
			get { return _equipment[3]; }
			set { _equipment[3] = value; }
		}

		public Item HeadArmor
		{
			get { return _equipment[4]; }
			set { _equipment[4] = value; }
		}

		public Item[] Equipment
		{
			get { return _equipment; }
		}

		private float WeaponDropChance
		{
			get { return _dropChances[0]; }
			set { _dropChances[0] = value; }
		}

		private float FeetArmorDropChance
		{
			get { return _dropChances[1]; }
			set { _dropChances[1] = value; }
		}

		private float LegArmorDropChance
		{
			get { return _dropChances[2]; }
			set { _dropChances[2] = value; }
		}

		private float ChestArmorDropChance
		{
			get { return _dropChances[3]; }
			set { _dropChances[3] = value; }
		}

		private float HeadArmorDropChance
		{
			get { return _dropChances[4]; }
			set { _dropChances[4] = value; }
		}

		public float[] DropChances
		{
			get { return _dropChances; }
		}

		protected EntityMob (string id)
			: base(id)
		{
			_activeEffects = new List<ActiveEffects>();
			_equipment = new Item[5];
			_dropChances = new float[5];
		}

		public EntityMob ()
			: this(TypeId)
		{
		}

		public EntityMob (TypedEntity e)
			: base(e)
		{
			EntityMob e2 = e as EntityMob;
			if(e2 != null)
			{
				_attackTime = e2._attackTime;
				_deathTime = e2._deathTime;
				_health = e2._health;
				_hurtTime = e2._hurtTime;
				_canPickUpLoot = e2._canPickUpLoot;
				_persistenceRequired = e2._persistenceRequired;
				_customName = e2._customName;
				_customNameVisible = e2._customNameVisible;
				_activeEffects = new List<ActiveEffects>();
				foreach(ActiveEffects effect in e2._activeEffects)
				{
					_activeEffects.Add(effect.Copy());
				}
				_equipment = new Item[5];
				_dropChances = new float[5];
				for(int i = 0; i < 5; i++)
				{
					if(e2._equipment[i] != null)
					{
						_equipment[i] = e2._equipment[i].Copy();
						_dropChances[i] = e2._dropChances[i];
					}
				}
			}
			else
			{
				_activeEffects = new List<ActiveEffects>();
				_equipment = new Item[5];
				_dropChances = new float[5];
			}
		}


		#region INBTObject<Entity> Members

		public override TypedEntity LoadTree (TagNode tree)
		{
			TagNodeCompound ctree = tree as TagNodeCompound;
			if(ctree == null || base.LoadTree(tree) == null)
			{
				return null;
			}

			_attackTime = ctree["AttackTime"].ToTagShort();
			_deathTime = ctree["DeathTime"].ToTagShort();
			_health = ctree["Health"].ToTagShort();
			_hurtTime = ctree["HurtTime"].ToTagShort();
			if(ctree.ContainsKey("CanPickUpLoot")) _canPickUpLoot = ctree["CanPickUpLoot"].ToTagByte();
			if(ctree.ContainsKey("PersistenceRequired")) _persistenceRequired = ctree["PersistenceRequired"].ToTagByte();
			if(ctree.ContainsKey("CustomNameVisible")) _customNameVisible = ctree["CustomNameVisible"].ToTagByte();
			if(ctree.ContainsKey("CustomName")) _customName = ctree["CustomName"].ToTagString();


			if(ctree.ContainsKey("ActiveEffects"))
			{
				TagNodeList ae = ctree["ActiveEffects"].ToTagList();

				_activeEffects = new List<ActiveEffects>();
				foreach(TagNode tag in ae)
				{
					TagNodeCompound effectTag = tag.ToTagCompound();
					ActiveEffects effect = new ActiveEffects();
					effect.Id = effectTag["Id"].ToTagByte();
					effect.Amplifier = effectTag["Amplifier"].ToTagByte();
					effect.Duration = effectTag["Duration"].ToTagInt();
					effect.Ambient = effectTag["Ambient"].ToTagByte() == 1;
					_activeEffects.Add(effect);
				}
			}
			if(ctree.ContainsKey("Equipment"))
			{
				TagNodeList eq = ctree["Equipment"].ToTagList();

				for(int i = 0; i < 5 && i < eq.Count; i++)
				{
					_equipment[i] = new Item().LoadTree(eq[i]);
				}
			}
			if(ctree.ContainsKey("DropChances"))
			{
				TagNodeList dc = ctree["DropChances"].ToTagList();

				for(int i = 0; i < 5 && i < dc.Count; i++)
				{
					_dropChances[i] = dc[i].ToTagFloat();
				}
			}

			return this;
		}

		public override TagNode BuildTree ()
		{
			TagNodeCompound tree = base.BuildTree() as TagNodeCompound;
			tree["AttackTime"] = new TagNodeShort(_attackTime);
			tree["DeathTime"] = new TagNodeShort(_deathTime);
			tree["Health"] = new TagNodeShort(_health);
			tree["HurtTime"] = new TagNodeShort(_hurtTime);
			tree["CanPickUpLoot"] = new TagNodeByte(_canPickUpLoot);
			tree["PersistenceRequired"] = new TagNodeByte(_persistenceRequired);
			tree["CustomName"] = new TagNodeString(_customName);
			tree["CustomNameVisible"] = new TagNodeByte(_customNameVisible);

			if(_activeEffects != null)
			{
				TagNodeList effects = new TagNodeList(TagType.TAG_COMPOUND);
				foreach(ActiveEffects effect in _activeEffects)
				{
					if(!effect.IsValid) continue;
					TagNodeCompound ae = new TagNodeCompound();
					ae["Id"] = new TagNodeByte((byte)effect.Id);
					ae["Amplifier"] = new TagNodeByte((byte)effect.Amplifier);
					ae["Duration"] = new TagNodeInt(effect.Duration);
					ae["Ambient"] = new TagNodeByte(effect.Ambient ? (byte)1 : (byte)0);
					effects.Add(ae);
				}

				tree["ActiveEffects"] = effects;
			}
			if(_equipment != null)
			{
				TagNodeList equipment = new TagNodeList(TagType.TAG_COMPOUND);
				foreach(Item item in _equipment)
				{
					equipment.Add(item.BuildTree());
				}

				tree["Equipment"] = equipment;
			}
			if(_dropChances != null)
			{
				TagNodeList dropChances = new TagNodeList(TagType.TAG_FLOAT);

				foreach(float dc in _dropChances)
				{
					dropChances.Add(new TagNodeFloat(dc));
				}

				tree["DropChances"] = dropChances;
			}

			return tree;
		}

		public override bool ValidateTree (TagNode tree)
		{
			return new NbtVerifier(tree, MobSchema).Verify();
		}

		#endregion


		#region ICopyable<Entity> Members

		public override TypedEntity Copy ()
		{
			return new EntityMob(this);
		}

		#endregion
	}
}
