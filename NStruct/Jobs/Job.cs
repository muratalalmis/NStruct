namespace NStruct.Jobs
{
    /// <summary>
    /// The job base
    /// </summary>
    public abstract class Job : IJob
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public TaskStatus Status { get; set; }

        /// <summary>
        /// Gets the priority.
        /// </summary>
        /// <value>
        /// The priority.
        /// </value>
        public abstract Priority Priority { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Job"/> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        public bool Enabled { get; set; }

        /// <summary>
        /// Runs this instance.
        /// </summary>
        public virtual void Run()
        {
            
        }
    }
}
