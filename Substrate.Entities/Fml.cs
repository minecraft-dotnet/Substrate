using Substrate.Core;
using Substrate.Nbt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate
{
    public class Fml : ICopyable<Fml>
    {
        private static readonly SchemaNodeCompound _schema = new SchemaNodeCompound("")
        {
            new SchemaNodeList("ModeItemData", TagType.TAG_COMPOUND, new SchemaNodeCompound("") {
                new SchemaNodeScalar("ItemId", TagType.TAG_INT),
                new SchemaNodeScalar("ordinal", TagType.TAG_INT),
                new SchemaNodeScalar("ItemType", TagType.TAG_STRING),
                new SchemaNodeScalar("ModeId", TagType.TAG_STRING),
                new SchemaNodeScalar("ForcedModId", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
                new SchemaNodeScalar("ForcedName", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
                }),
            new SchemaNodeList("ModList", TagType.TAG_COMPOUND, new SchemaNodeCompound("") {
                new SchemaNodeScalar("ModId", TagType.TAG_STRING),
                new SchemaNodeScalar("ModVersion", TagType.TAG_STRING),
                }),
        };

        public class ModeItemDataItem
        {
            private int _itemId;
            private int _ordinal;
            private string _itemType;
            private string _modId;

            public int ItemId
            {
                get { return _itemId; }
                set { _itemId = value; }
            }

            public int Ordinal
            {
                get { return _ordinal; }
                set { _ordinal = value; }
            }

            public string ItemType
            {
                get { return _itemType; }
                set { _itemType = value; }
            }

            public string ModId
            {
                get { return _modId; }
                set { _modId = value; }
            }
        }

        public class ModListItem
        {
            private string _modId;
            private string _modVersion;

            public string ModId
            {
                get { return _modId; }
                set { _modId = value; }
            }

            public string ModVersion
            {
                get { return _modVersion; }
                set { _modVersion = value; }
            }
        }

        private bool _commandBlockOutput = true;

        public bool CommandBlockOutput
        {
            get { return _commandBlockOutput; }
            set { _commandBlockOutput = value; }
        }

        #region ICopyable<GameRules> Members

        /// <inheritdoc />
        public Fml Copy()
        {
            Fml gr = new Fml();
            gr._commandBlockOutput = _commandBlockOutput;

            return gr;
        }

        #endregion
    }
}
