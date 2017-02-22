namespace NStruct.Jobs.Triggers
{
    /// <summary>
    /// The hourly trigger
    /// </summary>
    public class HourlyTrigger : TimeTrigger
    {
        private readonly int _hoursInterval;

        /// <summary>
        /// Initializes a new instance of the <see cref="HourlyTrigger"/> class.
        /// </summary>
        /// <param name="hoursInterval">The hours interval.</param>
        public HourlyTrigger(int hoursInterval)
        {
            _hoursInterval = hoursInterval;
        }

        /// <summary>
        /// Gets the interval.
        /// </summary>
        /// <value>
        /// The interval.
        /// </value>
        public int Interval => _hoursInterval;
    }
}
