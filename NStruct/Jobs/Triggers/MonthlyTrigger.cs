namespace NStruct.Jobs.Triggers
{
    /// <summary>
    /// The monthly trigger
    /// </summary>
    public class MonthlyTrigger : TimeTrigger
    {
        private readonly int _monthInterval;

        /// <summary>
        /// Initializes a new instance of the <see cref="MonthlyTrigger"/> class.
        /// </summary>
        /// <param name="monthInterval">The month interval.</param>
        public MonthlyTrigger(int monthInterval)
        {
            _monthInterval = monthInterval;
        }

        /// <summary>
        /// Gets the interval.
        /// </summary>
        /// <value>
        /// The interval.
        /// </value>
        public int Interval => _monthInterval;
    }
}
