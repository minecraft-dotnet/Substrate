using System;

namespace Substrate
{
    /// <summary>
    /// The exception that is thrown when IO errors occur during high-level player management operations.
    /// </summary>
    public class PlayerIOException : SubstrateException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerIOException"/> class.
        /// </summary>
        public PlayerIOException()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerIOException"/> class with a custom error message.
        /// </summary>
        /// <param name="message">A custom error message.</param>
        public PlayerIOException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerIOException"/> class with a custom error message and a reference to
        /// an InnerException representing the original cause of the exception.
        /// </summary>
        /// <param name="message">A custom error message.</param>
        /// <param name="innerException">A reference to the original exception that caused the error.</param>
        public PlayerIOException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
