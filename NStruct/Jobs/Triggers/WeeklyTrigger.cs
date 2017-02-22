namespace NStruct.Jobs.Triggers
{
    /// <summary>
    /// The weekly trigger
    /// </summary>
    public class WeeklyTrigger : TimeTrigger
    {
        private readonly int _weeksInterval;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeeklyTrigger"/> class.
        /// </summary>
        /// <param name="weeksInterval">The weeks interval.</param>
        public WeeklyTrigger(int weeksInterval)
        {
            _weeksInterval = weeksInterval;
        }

        /// <summary>
        /// Gets the interval.
        /// </summary>
        /// <value>
        /// The interval.
        /// </value>
        public int Interval => _weeksInterval;
    }
}
