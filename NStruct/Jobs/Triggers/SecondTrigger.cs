namespace NStruct.Jobs.Triggers
{
    /// <summary>
    /// The second trigger
    /// </summary>
    public class SecondTrigger : TimeTrigger
    {
        private readonly int _secondsInterval;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecondTrigger"/> class.
        /// </summary>
        /// <param name="secondsInterval">The seconds interval.</param>
        public SecondTrigger(int secondsInterval)
        {
            _secondsInterval = secondsInterval;
        }

        /// <summary>
        /// Gets the interval.
        /// </summary>
        /// <value>
        /// The interval.
        /// </value>
        public int Interval => _secondsInterval;
    }
}
