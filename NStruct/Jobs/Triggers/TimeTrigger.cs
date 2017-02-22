namespace NStruct.Jobs.Triggers
{
    /// <summary>
    /// The time trigger
    /// </summary>
    public abstract class TimeTrigger : ITrigger
    {
        /// <summary>
        /// Gets or sets the interval.
        /// </summary>
        /// <value>
        /// The interval.
        /// </value>
        public int Interval { get; set; }
    }
}
