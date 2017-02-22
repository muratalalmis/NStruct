using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NStruct.Logging
{
    /// <summary>
    /// The logging invoker extensions
    /// </summary>
    public static class LoggingInvokerExtensions
    {
        /// <summary>
        /// Safely invoke methods by catching non fatal exceptions and logging them
        /// </summary>
        public static void Invoke<TEvents>(this IEnumerable<TEvents> events, Action<TEvents> dispatch) where TEvents : ILogger
        {
            Parallel.ForEach(events, dispatch);
        }
    }
}
