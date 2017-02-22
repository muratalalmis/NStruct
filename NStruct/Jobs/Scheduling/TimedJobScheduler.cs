using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NStruct.IoC;

namespace NStruct.Jobs.Schedule
{
    /// <summary>
    /// The timed job scheduler
    /// </summary>
    internal static class TimedJobScheduler
    {
        static IEnumerable<SchedulableJob> _jobs;
        static Timer _timer;

        /// <summary>
        /// Starts job scheduler.
        /// </summary>
        public static void Start()
        {
            _timer = new Timer(TimerHandler, null, Interval, Interval);
            if (_jobs == null)
            {
                var type = typeof(SchedulableJob);
                var jobs = ContainerHolder.CurrentContainer.Resolve<IEnumerable<IJob>>();
                var schedulableJobs = jobs.Where(o => type.IsInstanceOfType(o)).Select(o => (SchedulableJob)o);

                _jobs = schedulableJobs;
            }
        }

        /// <summary>
        /// Stops job scheduler.
        /// </summary>
        public static void Stop()
        {
            _timer.Dispose();
            _timer = null;
        }

        /// <summary>
        /// Gets the schedule.
        /// </summary>
        /// <value>
        /// The schedule.
        /// </value>
        public static Scheduling.Schedule Schedule => Scheduling.Schedule.Create(_jobs);

        static void TimerHandler(object state)
        {
            _timer.Change(-1, -1);
            Run();
            _timer.Change(Interval, Interval);
        }

        /// <summary>
        /// Gets the interval.
        /// </summary>
        /// <value>
        /// The interval.
        /// </value>
        public static int Interval => Seconds * 1000;

        /// <summary>
        /// Gets or sets the seconds.
        /// </summary>
        /// <value>
        /// The seconds.
        /// </value>
        public static int Seconds { get; set; } = 5;

        static void Run()
        {
            var date = DateTime.Now;
            var query = _jobs.Where(o => o.Next <= date).OrderBy(o => o.Priority).ToList();
            foreach (var job in query)
            {
                job.Forward();
            }
        }
    }
}
