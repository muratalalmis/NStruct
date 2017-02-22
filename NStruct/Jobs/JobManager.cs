using System;
using NStruct.Jobs.Schedule;

namespace NStruct.Jobs
{
    /// <summary>
    /// The job manager
    /// </summary>
    public static class JobManager
    {
        /// <summary>
        /// Starts this instance.
        /// </summary>
        public static void Start()
        {
            TimedJobScheduler.Start();
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public static void Stop()
        {
            TimedJobScheduler.Start();
        }

        /// <summary>
        /// Gets the schedule.
        /// </summary>
        /// <value>
        /// The schedule.
        /// </value>
        public static Scheduling.Schedule Schedule => TimedJobScheduler.Schedule;

        /// <summary>
        /// Enqueues the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="priority">The priority.</param>
        public static void Enqueue(Action action, Priority priority = Priority.Normal)
        {
            Validation.Validator.AgainstNullArgument(nameof(action), action);

            Processor.Enqueue(new ActionJob(action, priority));
        }
    }
}
