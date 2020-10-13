using Substrate.Nbt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Substrate.TileEntities {
    public class TileEntityBanner : TileEntity {
        public static readonly SchemaNodeCompound BannerSchema = TileEntity.Schema.MergeInto(new SchemaNodeCompound("") {
            new SchemaNodeString("id", TypeId),
            new SchemaNodeScaler("CustomName", TagType.TAG_STRING, SchemaOptions.OPTIONAL),
            new SchemaNodeScaler("Base", TagType.TAG_INT),
            new SchemaNodeList(
                "Patterns",
                TagType.TAG_LIST,
                new SchemaNodeCompound() {
                    new SchemaNodeScaler("Color", TagType.TAG_INT),
                    new SchemaNodeScaler("Pattern", TagType.TAG_STRING)
                },
                SchemaOptions.OPTIONAL
            )
        });

        public BannerColor BaseColor {
            get;
            set;
        }

        public TileEntityBanner() : base(TypeId) {
            Patterns = new BannerPattern[0];
        }

        public TileEntityBanner(TileEntity te) : base(te) {
            var teb = te as TileEntityBanner;
            if (teb != null) {
                CustomName = teb.CustomName;
                Patterns = (BannerPattern[])teb.Patterns.Clone();
                BaseColor = teb.BaseColor;
            } else {
                Patterns = new BannerPattern[0];
            }
        }

        public static string TypeId {
            get { return "minecraft:banner"; }
        }

        public string CustomName {
            get;
            set;
        }

        public BannerPattern[] Patterns {
            get;
            set;
        }

        public override TileEntity Copy() {
            return new TileEntityBanner(this);
        }

        #region INBTObject<TileEntity> Members

        public override TileEntity LoadTree(TagNode tree) {
            TagNodeCompound ctree = tree as TagNodeCompound;
            if (ctree == null || base.LoadTree(tree) == null) {
                return null;
            }

            TagNode node;
            if (ctree.TryGetValue("CustomName", out node)) {
                CustomName = node.ToTagString();
            }
            BaseColor = (BannerColor)(int)ctree["Base"].ToTagInt();
            if (ctree.TryGetValue("Patterns", out node)) {
                var items = node.ToTagList();
                List<BannerPattern> patterns = new List<BannerPattern>();
                foreach (var item in items) {
                    patterns.Add(
                        new BannerPattern(
                            (BannerColor)(int)(item.ToTagCompound()["Color"].ToTagInt()),
                            item.ToTagCompound()["Pattern"].ToTagString()
                        )
                    );
                }
                Patterns = patterns.ToArray();
            } else {
                Patterns = new BannerPattern[0];
            }

            return this;
        }

        public override TagNode BuildTree() {
            TagNodeCompound tree = base.BuildTree() as TagNodeCompound;
            if (CustomName != null) {
                tree["CustomName"] = new TagNodeString(CustomName);
            }
            tree["Base"] = new TagNodeInt((int)BaseColor);
            if (Patterns.Length != 0) {
                tree["Patterns"] = new TagNodeList(
                    TagType.TAG_COMPOUND,
                    Patterns.Select(x => new TagNodeCompound() {    
                        {"Color", new TagNodeInt((int)x.Color) },
                        {"Pattern", new TagNodeString(x.Pattern) }
                    }).ToList<TagNode>()
                );
            }

            return tree;
        }

        public override bool ValidateTree(TagNode tree) {
            return new NbtVerifier(tree, BannerSchema).Verify();
        }

        #endregion
    }

    // TODO: https://minecraft.gamepedia.com/Banner/Patterns
    public class BannerStyles {
        public const string TopTriangle = "tt";
        public const string BottomTriangle = "bt";
        public const string MiddleCircle = "mc";
        public const string CurlyBorder = "cbo";
        public const string Border = "bo";
        public const string BottomStripe = "bs";
        public const string TopStripe = "ts";
        public const string tr = "tr";
        public const string MiddleRectangle = "mr";
    }
 

    public struct BannerPattern {
        public readonly BannerColor Color;
        public readonly string Pattern;

        public BannerPattern(BannerColor color, string pattern) {
            Color = color;
            Pattern = pattern;
        }
    }

    public enum BannerColor {
        Black,
        Red,
        Green,
        Brown,
        Blue,
        Purple,
        Cyan,
        LightGray,
        DaryGray,
        Pink,
        LightGreen,
        Yellow,
        LightBlue,
        LightPurple,
        Orange,
        White
    }
}
