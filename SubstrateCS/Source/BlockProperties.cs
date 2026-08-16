namespace Substrate
{
    public enum BlockFacing { Down, Up, North, South, West, East }
    public enum BlockAxis { X, Y, Z }
    public enum BlockHalf { Top, Bottom, Upper, Lower }
    public enum BlockHinge { Left, Right }
    public enum BlockFace { Floor, Wall, Ceiling }
    public enum BlockSlabType { Top, Bottom, Double }
    public enum BlockStairShape
    {
        Straight, InnerLeft, InnerRight, OuterLeft, OuterRight
    }
    public enum BlockAttachment
    {
        Floor, Ceiling, SingleWall, DoubleWall
    }
    public enum BlockChestType { Single, Left, Right }
    public enum BlockBedPart { Head, Foot }
    public enum BlockComparatorMode { Compare, Subtract }
    public enum BlockBambooLeaves { None, Small, Large }
    public enum BlockSculkSensorPhase { Inactive, Active, Cooldown }
    public enum BlockVerticalDirection { Up, Down }
    public enum BlockThickness
    {
        Tip, TipMerge, Frustum, Middle, Base
    }
    public enum BlockTilt { None, Unstable, Partial, Full }

    /// <summary>Block-state property keys available in Minecraft Java Edition 26.2.</summary>
    public static class BlockProperties
    {
        public const string Age = "age";
        public const string Attached = "attached";
        public const string Attachment = "attachment";
        public const string Axis = "axis";
        public const string Berries = "berries";
        public const string Bites = "bites";
        public const string Bloom = "bloom";
        public const string Bottom = "bottom";
        public const string CanSummon = "can_summon";
        public const string Candles = "candles";
        public const string Charges = "charges";
        public const string Conditional = "conditional";
        public const string CopperGolemPose = "copper_golem_pose";
        public const string Cracked = "cracked";
        public const string Crafting = "crafting";
        public const string CreakingHeartState = "creaking_heart_state";
        public const string Delay = "delay";
        public const string Disarmed = "disarmed";
        public const string Distance = "distance";
        public const string Down = "down";
        public const string Drag = "drag";
        public const string Dusted = "dusted";
        public const string East = "east";
        public const string Eggs = "eggs";
        public const string Enabled = "enabled";
        public const string Extended = "extended";
        public const string Eye = "eye";
        public const string Face = "face";
        public const string Facing = "facing";
        public const string FlowerAmount = "flower_amount";
        public const string Half = "half";
        public const string Hanging = "hanging";
        public const string HasBook = "has_book";
        public const string HasBottle0 = "has_bottle_0";
        public const string HasBottle1 = "has_bottle_1";
        public const string HasBottle2 = "has_bottle_2";
        public const string HasRecord = "has_record";
        public const string Hatch = "hatch";
        public const string Hinge = "hinge";
        public const string HoneyLevel = "honey_level";
        public const string Hydration = "hydration";
        public const string InWall = "in_wall";
        public const string Instrument = "instrument";
        public const string Inverted = "inverted";
        public const string Layers = "layers";
        public const string Leaves = "leaves";
        public const string Level = "level";
        public const string Lit = "lit";
        public const string Locked = "locked";
        public const string Mode = "mode";
        public const string Moisture = "moisture";
        public const string Natural = "natural";
        public const string North = "north";
        public const string Note = "note";
        public const string Occupied = "occupied";
        public const string Ominous = "ominous";
        public const string Open = "open";
        public const string Orientation = "orientation";
        public const string Part = "part";
        public const string Persistent = "persistent";
        public const string Pickles = "pickles";
        public const string PotentSulfurState = "potent_sulfur_state";
        public const string Power = "power";
        public const string Powered = "powered";
        public const string Rotation = "rotation";
        public const string SculkSensorPhase = "sculk_sensor_phase";
        public const string SegmentAmount = "segment_amount";
        public const string Shape = "shape";
        public const string Short = "short";
        public const string Shrieking = "shrieking";
        public const string SideChain = "side_chain";
        public const string SignalFire = "signal_fire";
        public const string Slot0Occupied = "slot_0_occupied";
        public const string Slot1Occupied = "slot_1_occupied";
        public const string Slot2Occupied = "slot_2_occupied";
        public const string Slot3Occupied = "slot_3_occupied";
        public const string Slot4Occupied = "slot_4_occupied";
        public const string Slot5Occupied = "slot_5_occupied";
        public const string Snowy = "snowy";
        public const string South = "south";
        public const string Stage = "stage";
        public const string Thickness = "thickness";
        public const string Tilt = "tilt";
        public const string Tip = "tip";
        public const string TrialSpawnerState = "trial_spawner_state";
        public const string Triggered = "triggered";
        public const string Type = "type";
        public const string Unstable = "unstable";
        public const string Up = "up";
        public const string VaultState = "vault_state";
        public const string VerticalDirection = "vertical_direction";
        public const string Waterlogged = "waterlogged";
        public const string West = "west";
    }
}
