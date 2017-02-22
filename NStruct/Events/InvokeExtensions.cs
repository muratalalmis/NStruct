using System;
using System.Collections.Generic;

namespace NStruct.Events
{
    /// <summary>
    /// The invoke extensions
    /// </summary>
    public static class InvokeExtensions
    {
        /// <summary>
        /// Safely invoke methods by catching non fatal exceptions and logging them
        /// </summary>
        public static void Invoke<TEvents>(this IEnumerable<TEvents> events, Action<TEvents> dispatch) where TEvents : IEventHandler
        {
            foreach (var sink in events)
            {
                dispatch(sink);
            }
        }
    }
}
