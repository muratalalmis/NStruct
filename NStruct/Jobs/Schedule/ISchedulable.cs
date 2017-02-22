using System;

namespace NStruct.Jobs.Schedule
{
    /// <summary>
    /// The schedulable
    /// </summary>
    public interface ISchedulable
    {
        /// <summary>
        /// Forwards this instance.
        /// </summary>
        void Forward();

        /// <summary>
        /// Gets the next.
        /// </summary>
        /// <value>
        /// The next.
        /// </value>
        DateTime Next { get; }

        /// <summary>
        /// Gets the last.
        /// </summary>
        /// <value>
        /// The last.
        /// </value>
        DateTime Last { get; }
    }
}
