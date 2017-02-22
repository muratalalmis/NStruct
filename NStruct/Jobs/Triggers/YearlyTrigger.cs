namespace NStruct.Jobs.Triggers
{
    /// <summary>
    /// The yearly trigger
    /// </summary>
    public class YearlyTrigger : TimeTrigger
    {
        private readonly int _yearInterval;

        /// <summary>
        /// Initializes a new instance of the <see cref="YearlyTrigger"/> class.
        /// </summary>
        /// <param name="yearInterval">The year interval.</param>
        public YearlyTrigger(int yearInterval)
        {
            _yearInterval = yearInterval;
        }

        /// <summary>
        /// Gets the interval.
        /// </summary>
        /// <value>
        /// The interval.
        /// </value>
        public int Interval => _yearInterval;
    }
}
