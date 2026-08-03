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
            new SchemaNodeScaler("Base", TagType.TAG_INT, SchemaOptions.OPTIONAL),
            new SchemaNodeList(
                "Patterns",
                TagType.TAG_COMPOUND,
                new SchemaNodeCompound() {
                    new SchemaNodeScaler("Color", TagType.TAG_INT),
                    new SchemaNodeScaler("Pattern", TagType.TAG_STRING)
                },
                SchemaOptions.OPTIONAL
            ),
            new SchemaNodeList(
                "patterns",
                TagType.TAG_COMPOUND,
                new SchemaNodeCompound() {
                    new SchemaNodeScaler("color", TagType.TAG_STRING),
                    new SchemaNodeScaler("pattern", TagType.TAG_STRING)
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
            if (ctree.TryGetValue("Base", out node)) {
                BaseColor = (BannerColor)(int)node.ToTagInt();
            }
            if (ctree.TryGetValue("patterns", out node)) {
                var items = node.ToTagList();
                List<BannerPattern> patterns = new List<BannerPattern>();
                foreach (var item in items) {
                    TagNodeCompound pattern = item.ToTagCompound();
                    patterns.Add(new BannerPattern(
                        ParseModernColor(pattern["color"].ToTagString()),
                        ParseModernPattern(pattern["pattern"].ToTagString())));
                }
                Patterns = patterns.ToArray();
            } else if (ctree.TryGetValue("Patterns", out node)) {
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
                tree["patterns"] = new TagNodeList(
                    TagType.TAG_COMPOUND,
                    Patterns.Select(x => new TagNodeCompound() {
                        {"color", new TagNodeString(GetModernColor(x.Color)) },
                        {"pattern", new TagNodeString(GetModernPattern(x.Pattern)) }
                    }).ToList<TagNode>()
                );
            }

            return tree;
        }

        private static string GetModernColor(BannerColor color) {
            switch (color) {
                case BannerColor.Black: return "black";
                case BannerColor.Red: return "red";
                case BannerColor.Green: return "green";
                case BannerColor.Brown: return "brown";
                case BannerColor.Blue: return "blue";
                case BannerColor.Purple: return "purple";
                case BannerColor.Cyan: return "cyan";
                case BannerColor.LightGray: return "light_gray";
                case BannerColor.DaryGray: return "gray";
                case BannerColor.Pink: return "pink";
                case BannerColor.LightGreen: return "lime";
                case BannerColor.Yellow: return "yellow";
                case BannerColor.LightBlue: return "light_blue";
                case BannerColor.LightPurple: return "magenta";
                case BannerColor.Orange: return "orange";
                case BannerColor.White: return "white";
                default: throw new ArgumentOutOfRangeException("color");
            }
        }

        private static BannerColor ParseModernColor(string color) {
            switch (color) {
                case "black": return BannerColor.Black;
                case "red": return BannerColor.Red;
                case "green": return BannerColor.Green;
                case "brown": return BannerColor.Brown;
                case "blue": return BannerColor.Blue;
                case "purple": return BannerColor.Purple;
                case "cyan": return BannerColor.Cyan;
                case "light_gray": return BannerColor.LightGray;
                case "gray": return BannerColor.DaryGray;
                case "pink": return BannerColor.Pink;
                case "lime": return BannerColor.LightGreen;
                case "yellow": return BannerColor.Yellow;
                case "light_blue": return BannerColor.LightBlue;
                case "magenta": return BannerColor.LightPurple;
                case "orange": return BannerColor.Orange;
                case "white": return BannerColor.White;
                default: throw new ArgumentException("Unknown banner color: " + color, "color");
            }
        }

        private static string GetModernPattern(string pattern) {
            switch (pattern) {
                case BannerStyles.TopTriangle: return "minecraft:triangle_top";
                case BannerStyles.BottomTriangle: return "minecraft:triangle_bottom";
                case BannerStyles.MiddleCircle: return "minecraft:circle";
                case BannerStyles.CurlyBorder: return "minecraft:curly_border";
                case BannerStyles.Border: return "minecraft:border";
                case BannerStyles.BottomStripe: return "minecraft:stripe_bottom";
                case BannerStyles.TopStripe: return "minecraft:stripe_top";
                case BannerStyles.MiddleRectangle: return "minecraft:rhombus";
                default: return pattern.IndexOf(':') >= 0 ? pattern : "minecraft:" + pattern;
            }
        }

        private static string ParseModernPattern(string pattern) {
            switch (pattern) {
                case "minecraft:triangle_top": return BannerStyles.TopTriangle;
                case "minecraft:triangle_bottom": return BannerStyles.BottomTriangle;
                case "minecraft:circle": return BannerStyles.MiddleCircle;
                case "minecraft:curly_border": return BannerStyles.CurlyBorder;
                case "minecraft:border": return BannerStyles.Border;
                case "minecraft:stripe_bottom": return BannerStyles.BottomStripe;
                case "minecraft:stripe_top": return BannerStyles.TopStripe;
                case "minecraft:rhombus": return BannerStyles.MiddleRectangle;
                default: return pattern;
            }
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
