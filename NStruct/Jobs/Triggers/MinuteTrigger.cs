namespace NStruct.Jobs.Triggers
{
    /// <summary>
    /// The minute trigger
    /// </summary>
    public class MinuteTrigger : TimeTrigger
    {
        private readonly int _minutesInterval;

        /// <summary>
        /// Initializes a new instance of the <see cref="MinuteTrigger"/> class.
        /// </summary>
        /// <param name="minutesInterval">The minutes interval.</param>
        public MinuteTrigger(int minutesInterval)
        {
            _minutesInterval = minutesInterval;
        }

        /// <summary>
        /// Gets the interval.
        /// </summary>
        /// <value>
        /// The interval.
        /// </value>
        public int Interval => _minutesInterval;
    }
}
