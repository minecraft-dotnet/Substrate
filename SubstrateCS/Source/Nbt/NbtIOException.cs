﻿using System;

namespace Substrate.Nbt
{
    /// <summary>
    /// The exception that is thrown when errors occur during Nbt IO operations.
    /// </summary>
    /// <remarks>In most cases, the <see cref="Exception.InnerException"/> property will contain more detailed information on the
    /// error that occurred.</remarks>
    public class NbtIOException : SubstrateException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NbtIOException"/> class.
        /// </summary>
        public NbtIOException()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NbtIOException"/> class with a custom error message.
        /// </summary>
        /// <param name="message">A custom error message.</param>
        public NbtIOException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NbtIOException"/> class with a custom error message and a reference to
        /// an InnerException representing the original cause of the exception.
        /// </summary>
        /// <param name="message">A custom error message.</param>
        /// <param name="innerException">A reference to the original exception that caused the error.</param>
        public NbtIOException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
