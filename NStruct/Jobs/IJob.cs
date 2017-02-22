namespace NStruct.Jobs
{
    /// <summary>
    /// The job
    /// </summary>
    public interface IJob : IDependency
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        TaskStatus Status { get; set; }

        /// <summary>
        /// Gets the priority.
        /// </summary>
        /// <value>
        /// The priority.
        /// </value>
        Priority Priority { get; }

        /// <summary>
        /// Runs this instance.
        /// </summary>
        void Run();
    }
}
