using System.Threading;

namespace NStruct.Jobs
{
    /// <summary>
    /// The job processor
    /// </summary>
    public static class Processor
    {
        static Timer _timer = new Timer(TimerHandler, null, Interval, Interval);
        static JobQueue _queue;

        static void TimerHandler(object state)
        {
            _timer.Change(-1, -1);
            Process();
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

        /// <summary>
        /// Processes the job.
        /// </summary>
        /// <param name="job">The job.</param>
        public static void ProcessJob(Job job)
        {
            _queue.Enqueue(job);
        }

        static void Process()
        {
            var job = _queue.Dequeue();
            job.Run();
        }
    }
}
