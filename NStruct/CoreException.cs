using System;

namespace NStruct
{
    /// <summary>
    /// The nstruct core exception
    /// </summary>
    public class CoreException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CoreException"/> class.
        /// </summary>
        public CoreException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public CoreException(string message)
            :base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="parameters">The parameters.</param>
        public CoreException(string message, params object[] parameters)
            : base(string.Format(message, parameters))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public CoreException(string message, Exception exception)
            : base(message, exception)
        {
        }
    }
}
