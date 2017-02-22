using System;

namespace NStruct.Mapping
{
    /// <summary>
    /// The mapping exception
    /// </summary>
    public class MappingException : CoreException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingException"/> class.
        /// </summary>
        public MappingException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MappingException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public MappingException(string message)
            :base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MappingException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public MappingException(string message, Exception innerException)
            :base(message, innerException)
        {
        }
    }
}
