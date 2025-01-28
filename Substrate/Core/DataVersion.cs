using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.Core
{
    public enum DataVersion
    {
        Unknown = 0,
        Java_v1_9 = 169,
        Java_v1_10 = 510,
        Java_v1_11 = 819,
        Java_v1_12 = 1139,
        Java_v1_13 = 1519,
        Java_v1_14 = 1952,
        Java_v1_15 = 2225,
        Java_v1_16 = 2566,
        Java_v1_17 = 2724,
        Java_v1_18 = 2860,
        Java_v1_19 = 3105,
        Java_v1_20 = 3463,
        Java_v1_21 = 3953,
    }

    public static class VersionExtentions
    {
    }

    public static class VersionUtils
    {
        /// <summary>
        /// Checks for the version where packed indexes stopped being packed bitwise across long boundaries (1.16).
        /// From 1.16 onwards, packed indexes are whole within a single long value.
        /// </summary>
        public static bool UsesWholeIndexes(int dataVersion)
        {
            return dataVersion >= (int)DataVersion.Java_v1_16;
        }
    }
}
