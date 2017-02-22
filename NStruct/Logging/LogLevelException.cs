using System;
using System.Text;

namespace NStruct.Logging
{
    /// <summary>
    /// The nstruct log level exception
    /// This exception throwns when you did not handle exception.
    /// </summary>
    public class LogLevelException : FatalException
    {
        private readonly Exception _inner;
        const string MESSAGE = "An unhandled nstruct exception level thrown.";

        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        public override string Message
        {
            get
            {
                var builder = new StringBuilder();
                builder.AppendLine();

                // Add Message
                builder.AppendLine(MESSAGE);

                return builder.ToString();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogLevelException"/> class.
        /// </summary>
        /// <param name="inner">The inner.</param>
        public LogLevelException(Exception inner)
            : base(string.Empty, inner)
        {
            _inner = inner;
        }
    }
}
