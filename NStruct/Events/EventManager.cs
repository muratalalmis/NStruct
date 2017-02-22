using System;
using System.Collections.Generic;
using System.Linq;

namespace NStruct.Events
{
    /// <summary>
    /// The event manager implementation
    /// </summary>
    public class EventManager : IEventManager
    {
        private readonly IEnumerable<IEventHandler> _emosEventHandlers;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventManager"/> class.
        /// </summary>
        /// <param name="emosEventHandlers">The emos event handlers.</param>
        public EventManager(IEnumerable<IEventHandler> emosEventHandlers)
        {
            _emosEventHandlers = emosEventHandlers;
        }

        /// <summary>
        /// Fors this instance.
        /// </summary>
        /// <typeparam name="TEvents">The type of the events.</typeparam>
        /// <returns></returns>
        public IEventManager<TEvents> For<TEvents>() where TEvents : IEventHandler
        {
            var handlers = _emosEventHandlers.OfType<TEvents>();

            return new EventManager<TEvents>(handlers);
        }
    }

    /// <summary>
    /// the emos event manager
    /// </summary>
    /// <typeparam name="TEvents">The type of the events.</typeparam>
    public class EventManager<TEvents> : IEventManager<TEvents> where TEvents : IEventHandler
    {
        private readonly IEnumerable<TEvents> _emosEventHandlers;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventManager{TEvents}"/> class.
        /// </summary>
        /// <param name="emosEventHandlers">The emos event handlers.</param>
        public EventManager(IEnumerable<TEvents> emosEventHandlers)
        {
            _emosEventHandlers = emosEventHandlers;
        }

        /// <summary>
        /// Invokes the specified events.
        /// </summary>
        /// <param name="dispatch">The dispatch.</param>
        public void Publish(Action<TEvents> dispatch)
        {
            _emosEventHandlers.Invoke(dispatch);
        }
    }
}
