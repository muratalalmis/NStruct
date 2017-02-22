using System;

namespace NStruct
{
    /// <summary>
    /// The nstruct fatal exception
    /// </summary>
    public class FatalException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CoreException"/> class.
        /// </summary>
        public FatalException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public FatalException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="parameters">The parameters.</param>
        public FatalException(string message, params object[] parameters)
            : base(string.Format(message, parameters))
        {

        }
    }
}