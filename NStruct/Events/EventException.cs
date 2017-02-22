namespace NStruct.Events
{
    /// <summary>
    /// The event exception
    /// </summary>
    public class EventException : FatalException
    {
        private readonly IEventHandler _eventHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventException"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public EventException(IEventHandler handler)
        {
            _eventHandler = handler;

            // TODO : handle this
        }
    }
}
