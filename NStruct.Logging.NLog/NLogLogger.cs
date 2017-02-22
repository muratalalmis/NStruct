using NLog;

namespace NStruct.Logging.NLog
{
    /// <summary>
    /// Nlog implementation
    /// </summary>
    public class NLogLogger : ILogger
    {
        const string FATAL = "FatalLogger";

        /// <summary>
        /// Initializes a new instance of the <see cref="NLogLogger"/> class.
        /// </summary>
        public NLogLogger()
        {
        }

        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="parameters">The parameters.</param>
        public void Log(string message, params object[] parameters)
        {
            LogManager.GetCurrentClassLogger().Info(message, parameters);
        }

        /// <summary>
        /// Logs the specified exception.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exception">The exception.</param>
        public void Log<T>(T exception) where T : CoreException
        {
            if (exception is FatalException)
            {
                LogManager.GetLogger(FATAL).Fatal(exception); 
            }
            else
            {
                LogManager.GetCurrentClassLogger().Error(exception);
            }
        }

        /// <summary>
        /// Warns the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="parameters">The parameters.</param>
        public void Warn(string message, params object[] parameters)
        {
            LogManager.GetCurrentClassLogger().Warn(message, parameters);
        }
    }
}
