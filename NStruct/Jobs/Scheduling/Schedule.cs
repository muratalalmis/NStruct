using System.Collections.Generic;

namespace NStruct.Jobs.Scheduling
{
    /// <summary>
    /// The schedule
    /// </summary>
    public class Schedule : List<SchedulableJob>
    {
        private Schedule()
        {
        }

        private Schedule(IEnumerable<SchedulableJob> list)
            : base(list)
        {
        }

        /// <summary>
        /// Creates the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public static Schedule Create(IEnumerable<SchedulableJob> list)
        {
            return new Schedule(list);
        }
    }
}
