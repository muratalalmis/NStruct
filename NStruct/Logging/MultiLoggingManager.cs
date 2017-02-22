using System.Collections.Generic;

namespace NStruct.Logging
{
    /// <summary>
    /// The nstruct multi logging exception
    /// </summary>
    public class MultiLoggingManager : ILoggingManager
    {
        private readonly IEnumerable<ILogger> _loggers;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiLoggingManager"/> class.
        /// </summary>
        /// <param name="loggers">The loggers.</param>
        public MultiLoggingManager(IEnumerable<ILogger> loggers)
        {
            _loggers = loggers;
        }

        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="parameters">The parameters.</param>
        public void Log(string message, params object[] parameters)
        {
            _loggers.Invoke(invoker => invoker.Log(message, parameters));
        }

        /// <summary>
        /// Logs the specified exception.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exception">The exception.</param>
        public void Log<T>(T exception) where T : CoreException
        {
            _loggers.Invoke(invoker => invoker.Log(exception));
        }

        /// <summary>
        /// Warns the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="parameters">The parameters.</param>
        public void Warn(string message, params object[] parameters)
        {
            _loggers.Invoke(invoker => invoker.Log(message, parameters));
        }
    }
}
