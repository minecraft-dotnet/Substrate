using System;

namespace Substrate
{
    /// <summary>
    /// The exception that is thrown when IO errors occur during level management operations.
    /// </summary>
    public class LevelIOException : SubstrateException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LevelIOException"/> class.
        /// </summary>
        public LevelIOException()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="LevelIOException"/> class with a custom error message.
        /// </summary>
        /// <param name="message">A custom error message.</param>
        public LevelIOException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="LevelIOException"/> class with a custom error message and a reference to
        /// an InnerException representing the original cause of the exception.
        /// </summary>
        /// <param name="message">A custom error message.</param>
        /// <param name="innerException">A reference to the original exception that caused the error.</param>
        public LevelIOException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
