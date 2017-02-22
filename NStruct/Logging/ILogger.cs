namespace NStruct.Logging
{
    /// <summary>
    /// The logger
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="parameters">The parameters.</param>
        void Log(string message, params object[] parameters);

        /// <summary>
        /// Logs the specified exception.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exception">The exception.</param>
        void Log<T>(T exception) where T : CoreException;

        /// <summary>
        /// Warns the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="parameters">The parameters.</param>
        void Warn(string message, params object[] parameters);
    }
}
