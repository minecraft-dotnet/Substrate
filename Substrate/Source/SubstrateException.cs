using System;

namespace Substrate
{
    /// <summary>
    /// A base class for all Substrate-related exception classes.
    /// </summary>
    public class SubstrateException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubstrateException"/> class.
        /// </summary>
        public SubstrateException()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubstrateException"/> class with a custom error message.
        /// </summary>
        /// <param name="message">A custom error message.</param>
        public SubstrateException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubstrateException"/> class with a custom error message and a reference to
        /// an InnerException representing the original cause of the exception.
        /// </summary>
        /// <param name="message">A custom error message.</param>
        /// <param name="innerException">A reference to the original exception that caused the error.</param>
        public SubstrateException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
