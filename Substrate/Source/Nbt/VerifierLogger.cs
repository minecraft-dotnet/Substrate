using System;

namespace Substrate.Nbt
{
    /// <summary>
    /// A collection of static methods that can be hooked into <see cref="NbtVerifier"/> events for logging NBT errors to the console.
    /// </summary>
    public static class VerifierLogger
    {
        /// <summary>
        /// Logs an occurance of a missing tag error, and advances to the next event in the event chain.
        /// </summary>
        /// <param name="e">Data about the NBT node being verified.</param>
        /// <returns>A <see cref="TagEventCode"/> indicating whether event processing should pass, fail, or advance.</returns>
        public static TagEventCode MissingTagHandler(TagEventArgs e)
        {
            Console.WriteLine($"Missing Tag Error: '{e.TagName}'");

            return TagEventCode.NEXT;
        }

        /// <summary>
        /// Logs an occurance of an invalid tag type error, and advances to the next event in the event chain.
        /// </summary>
        /// <param name="e">Data about the NBT node being verified.</param>
        /// <returns>A <see cref="TagEventCode"/> indicating whether event processing should pass, fail, or advance.</returns>
        public static TagEventCode InvalidTagTypeHandler(TagEventArgs e)
        {
            Console.WriteLine($"Invalid Tag Type Error: '{e.TagName}' has type '{e.Tag.GetTagType()}', expected '{e.Schema.ToString()}'");

            return TagEventCode.NEXT;
        }

        /// <summary>
        /// Logs an occurance of an invalid tag value error, and advances to the next event in the event chain.
        /// </summary>
        /// <param name="e">Data about the NBT node being verified.</param>
        /// <returns>A <see cref="TagEventCode"/> indicating whether event processing should pass, fail, or advance.</returns>
        public static TagEventCode InvalidTagValueHandler(TagEventArgs e)
        {
            Console.WriteLine($"Invalid Tag Value Error: '{e.TagName}' of type '{e.Tag.GetTagType()}' is set to invalid value '{e.Tag.ToString()}'");

            return TagEventCode.NEXT;
        }
    }
}