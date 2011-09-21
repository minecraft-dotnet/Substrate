﻿using System;
using System.Runtime.Serialization;

namespace Substrate
{
    /// <summary>
    /// The exception that is thrown when IO errors occur during high-level player management operations.
    /// </summary>
    [Serializable]
    public class PlayerIOException : SubstrateException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerIOException"/> class.
        /// </summary>
        public PlayerIOException ()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerIOException"/> class with a custom error message.
        /// </summary>
        /// <param name="message">A custom error message.</param>
        public PlayerIOException (string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerIOException"/> class with a custom error message and a reference to
        /// an InnerException representing the original cause of the exception.
        /// </summary>
        /// <param name="message">A custom error message.</param>
        /// <param name="innerException">A reference to the original exception that caused the error.</param>
        public PlayerIOException (string message, Exception innerException)
            : base(message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerIOException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected PlayerIOException (SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
