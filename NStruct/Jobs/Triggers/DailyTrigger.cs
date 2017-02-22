namespace NStruct.Jobs.Triggers
{
    /// <summary>
    /// The daily trigger
    /// </summary>
    public class DailyTrigger : TimeTrigger
    {
        private readonly int _daysInterval;

        /// <summary>
        /// Initializes a new instance of the <see cref="DailyTrigger"/> class.
        /// </summary>
        /// <param name="daysInterval">The days interval.</param>
        public DailyTrigger(int daysInterval)
        {
            _daysInterval = daysInterval;
        }

        /// <summary>
        /// Gets the interval.
        /// </summary>
        /// <value>
        /// The interval.
        /// </value>
        public int Interval => _daysInterval;
    }
}
