using Substrate.Core;
using Substrate.Nbt;
using Substrate.Source.Nbt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate
{
    public class Villages
    {
        public static SchemaNodeCompound Schema { get; } = SchemaBuilder.FromClass(typeof(Villages));

        [TagNode("data")]
        public VillageCompound Data { get; set; }

        public class VillageCompound
        {
            /// <summary>
            ///  Internal clock.
            /// </summary>
            [TagNode]
            public int Tick { get; set; }

            /// <summary>
            /// List of Byte tags when empty, list of Compound tags otherwise.
            /// </summary>
            [TagNode]
            public List<VillagesCompound> Villages { get; set; }
        }

        /// <summary>
        /// A village
        /// </summary>
        public class VillagesCompound
        {
            /// <summary>
            /// Aggregate of the x-coordinates of all houses.
            /// </summary>
            [TagNode]
            public int ACX { get; set; }

            /// <summary>
            /// Aggregate of the y-coordinates of all houses.
            /// </summary>
            [TagNode]
            public int ACY { get; set; }

            /// <summary>
            ///  Aggregate of the z-coordinates of all houses.
            /// </summary>
            [TagNode]
            public int ACZ { get; set; }

            /// <summary>
            ///  X coordinate of the village center.
            /// </summary>
            [TagNode]
            public int CX { get; set; }

            /// <summary>
            /// Y coordinate of the village center.
            /// </summary>
            [TagNode]
            public int CY { get; set; }

            /// <summary>
            /// Z coordinate of the village center.
            /// </summary>
            [TagNode]
            public int CZ { get; set; }

            /// <summary>
            /// The number of Iron Golems.
            /// </summary>
            [TagNode]
            public int Golems { get; set; }

            /// <summary>
            /// Last time a villager was killed by a mob, or by a damage source that's not related to an entity while a player was nearby.
            /// </summary>
            [TagNode]
            public int MTick { get; set; }

            /// <summary>
            /// The number of Villagers.
            /// </summary>
            [TagNode]
            public int PopSize { get; set; }

            /// <summary>
            /// Radius of the village.
            /// </summary>
            [TagNode]
            public int Radius { get; set; }

            /// <summary>
            /// Last time a house was added to the village.
            /// </summary>
            [TagNode]
            public int Stable { get; set; }

            /// <summary>
            /// Internal clock.
            /// </summary>
            [TagNode]
            public int Tick { get; set; }

            /// <summary>
            /// The doors in the village.
            /// </summary>
            [TagNode]
            public List<DoorsCompound> Doors { get; set; }

            /// <summary>
            /// List of Byte tags when empty, list of Compound tags otherwise.
            /// </summary>
            [TagNode]
            public List<PlayersCompound> Players { get; set; }
        }

        /// <summary>
        /// A door.
        /// </summary>
        public class DoorsCompound
        {
            /// <summary>
            /// Specifies the inside direction along x.
            /// </summary>
            [TagNode]
            public int IDX { get; set; }

            /// <summary>
            /// Specifies the inside direction along z.
            /// </summary>
            [TagNode]
            public int IDZ { get; set; }

            /// <summary>
            /// Last time a villager was nearby.
            /// </summary>
            [TagNode]
            public int TS { get; set; }

            /// <summary>
            /// X coordinate.
            /// </summary>
            [TagNode]
            public int X { get; set; }

            /// <summary>
            /// Y coordinate.
            /// </summary>
            [TagNode]
            public int Y { get; set; }

            /// <summary>
            /// Z coordinate.
            /// </summary>
            [TagNode]
            public int Z { get; set; }
        }
        
        /// <summary>
        /// A player who has traded or harmed villagers.
        /// </summary>
        public class PlayersCompound
        {
            /// <summary>
            /// The name of the player.
            /// </summary>
            [TagNode]
            public int Name { get; set; }

            /// <summary>
            /// The social rank of the player. Can be negative. Goes up with trading and down with harming villagers
            /// </summary>
            [TagNode]
            public int S { get; set; }
        }
    }
}
