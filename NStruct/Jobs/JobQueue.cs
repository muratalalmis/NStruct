using System.Collections.Generic;
using System.Linq;

namespace NStruct.Jobs
{
    /// <summary>
    /// The job queue
    /// </summary>
    internal class JobQueue
    {
        private readonly Queue<Job> _queue;
        private static object _lockObj;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobQueue"/> class.
        /// </summary>
        public JobQueue()
        {
            _queue = new Queue<Job>();
        }

        /// <summary>
        /// Enqueues the specified job.
        /// </summary>
        /// <param name="job">The job.</param>
        public void Enqueue(Job job)
        {
            lock (_lockObj)
            {
                _queue.Enqueue(job);
                var reOrdered = _queue.OrderByDescending(o => o.Priority).ToList();
                _queue.Clear();
                foreach (var orderedJob in reOrdered)
                {
                    _queue.Enqueue(orderedJob);
                }
            }
        }

        /// <summary>
        /// Dequeues this instance.
        /// </summary>
        /// <returns></returns>
        public Job Dequeue()
        {
            lock (_lockObj)
            {
                return _queue.Dequeue();
            }
        }
    }
}
