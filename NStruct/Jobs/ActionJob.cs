using System;

namespace NStruct.Jobs
{
    /// <summary>
    /// The action job
    /// </summary>
    public class ActionJob : Job
    {
        private readonly Action _process;
        private readonly Priority _priority;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionJob"/> class.
        /// </summary>
        /// <param name="process">The process.</param>
        /// <param name="priority"></param>
        public ActionJob(Action process, Priority priority = Priority.Normal)
        {
            _process = process;
            _priority = priority;
        }

        // ReSharper disable once ConvertToAutoProperty
        /// <summary>
        /// Gets the priority.
        /// </summary>
        /// <value>
        /// The priority.
        /// </value>
        public override Priority Priority => _priority;

        /// <summary>
        /// Runs this instance.
        /// </summary>
        public override void Run()
        {
            _process();
        }
    }
}
