using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Substrate.Core;
using Substrate.Nbt;

#nullable enable

namespace Substrate.World
{
    public class Properties : INbtObject<Properties>, ICopyable<Properties>
    {
        public static SchemaNodeCompound Schema = new SchemaNodeCompound()
        {
            new SchemaNodeString("thickness", SchemaOptions.OPTIONAL),
            new SchemaNodeString("vertical_direction", SchemaOptions.OPTIONAL),
            new SchemaNodeString("waterlogged", SchemaOptions.OPTIONAL),
            new SchemaNodeString("up", SchemaOptions.OPTIONAL),
            new SchemaNodeString("down", SchemaOptions.OPTIONAL),
            new SchemaNodeString("north", SchemaOptions.OPTIONAL),
            new SchemaNodeString("east", SchemaOptions.OPTIONAL),
            new SchemaNodeString("south", SchemaOptions.OPTIONAL),
            new SchemaNodeString("west", SchemaOptions.OPTIONAL),
            new SchemaNodeString("axis", SchemaOptions.OPTIONAL),
            new SchemaNodeString("distance", SchemaOptions.OPTIONAL),
            new SchemaNodeString("persistent", SchemaOptions.OPTIONAL),
            new SchemaNodeString("note", SchemaOptions.OPTIONAL),
            new SchemaNodeString("powered", SchemaOptions.OPTIONAL),
            new SchemaNodeString("instrument", SchemaOptions.OPTIONAL),
            new SchemaNodeString("snowy", SchemaOptions.OPTIONAL),
            new SchemaNodeString("stage", SchemaOptions.OPTIONAL),
            new SchemaNodeString("hanging", SchemaOptions.OPTIONAL),
            new SchemaNodeString("age", SchemaOptions.OPTIONAL),
            new SchemaNodeString("triggered", SchemaOptions.OPTIONAL),
            new SchemaNodeString("facing", SchemaOptions.OPTIONAL),
            new SchemaNodeString("level", SchemaOptions.OPTIONAL),
            new SchemaNodeString("dusted", SchemaOptions.OPTIONAL),
            new SchemaNodeString("part", SchemaOptions.OPTIONAL),
            new SchemaNodeString("occupied", SchemaOptions.OPTIONAL),
            new SchemaNodeString("shape", SchemaOptions.OPTIONAL),
            new SchemaNodeString("extended", SchemaOptions.OPTIONAL),
            new SchemaNodeString("half", SchemaOptions.OPTIONAL),
            new SchemaNodeString("short", SchemaOptions.OPTIONAL),
            new SchemaNodeString("type", SchemaOptions.OPTIONAL),
            new SchemaNodeString("power", SchemaOptions.OPTIONAL),
            new SchemaNodeString("natural", SchemaOptions.OPTIONAL),
            new SchemaNodeString("active", SchemaOptions.OPTIONAL),
            new SchemaNodeString("lit", SchemaOptions.OPTIONAL),
            new SchemaNodeString("layers", SchemaOptions.OPTIONAL),
            new SchemaNodeString("slot_0_occupied", SchemaOptions.OPTIONAL),
            new SchemaNodeString("slot_1_occupied", SchemaOptions.OPTIONAL),
            new SchemaNodeString("slot_2_occupied", SchemaOptions.OPTIONAL),
            new SchemaNodeString("slot_3_occupied", SchemaOptions.OPTIONAL),
            new SchemaNodeString("slot_4_occupied", SchemaOptions.OPTIONAL),
            new SchemaNodeString("slot_5_occupied", SchemaOptions.OPTIONAL),
        };


        public string? Thickness => GetProperty("thickness");
        public string? VerticalDirection => GetProperty("vertical_direction");
        public string? Waterlogged => GetProperty("waterlogged");
        public string? Up => GetProperty("up");
        public string? Down => GetProperty("down");
        public string? North => GetProperty("north");
        public string? East => GetProperty("east");
        public string? South => GetProperty("south");
        public string? West => GetProperty("west");
        public string? Axis => GetProperty("axis");
        public string? Distance => GetProperty("distance");
        public string? Persistent => GetProperty("persistent");
        public string? Note => GetProperty("note");
        public string? Powered => GetProperty("powered");
        public string? Instrument => GetProperty("instrument");
        public string? Snowy => GetProperty("snowy");
        public string? Stage => GetProperty("stage");
        public string? Hanging => GetProperty("hanging");
        public string? Age => GetProperty("age");
        public string? Triggered => GetProperty("triggered");
        public string? Facing => GetProperty("facing");
        public string? Level => GetProperty("level");
        public string? Dusted => GetProperty("dusted");
        public string? Part => GetProperty("part");
        public string? Occupied => GetProperty("occupied");
        public string? Shape => GetProperty("shape");
        public string? Extended => GetProperty("extended");
        public string? Half => GetProperty("half");
        public string? Short => GetProperty("short");
        public string? Type => GetProperty("type");
        public string? Power => GetProperty("power");
        public string? Natural => GetProperty("natural");
        public string? Active => GetProperty("active");
        public string? Slot0Occupied => GetProperty("slot_0_occupied");
        public string? Slot1Occupied => GetProperty("slot_1_occupied");
        public string? Slot2Occupied => GetProperty("slot_2_occupied");
        public string? Slot3Occupied => GetProperty("slot_3_occupied");
        public string? Slot4Occupied => GetProperty("slot_4_occupied");
        public string? Slot5Occupied => GetProperty("slot_5_occupied");


        private TagNodeCompound? _tree;

        public Properties()
        {
        }

        public Properties(TagNodeCompound tree)
        {
            LoadTree(tree);
        }

        public string? GetProperty(string property)
        {
            Debug.Assert(_tree != null);
            if (_tree.TryGetValue(property, out var node))
            {
                return node.ToTagString().Data;
            }
            return null;
        }

        public TagNode BuildTree()
        {
            Debug.Assert(_tree != null);
            TagNodeCompound copy = new TagNodeCompound();
            foreach (KeyValuePair<string, TagNode> node in _tree)
            {
                copy.Add(node.Key, node.Value);
            }

            return copy;
        }

        public Properties? Copy()
        {
            Debug.Assert(_tree != null);
            return new Properties().LoadTree(_tree.Copy());
        }

        public Properties? LoadTree(TagNode tree)
        {
            var properties = tree as TagNodeCompound;
            if (properties == null)
            {
                return null;
            }

            _tree = properties;
            return this;
        }

        public Properties? LoadTreeSafe(TagNode tree)
        {
            if (!ValidateTree(tree))
            {
                return null;
            }

            return LoadTree(tree);
        }

        public bool ValidateTree(TagNode tree)
        {
            NbtVerifier v = new NbtVerifier(tree, Schema);
            return v.Verify();
        }
    }
}
