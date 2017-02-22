using System;

namespace NStruct.Events
{
    /// <summary>
    /// The event manager
    /// </summary>
    public interface IEventManager
    {
        /// <summary>
        /// Fors this instance.
        /// </summary>
        /// <typeparam name="TEvents">The type of the events.</typeparam>
        /// <returns></returns>
        IEventManager<TEvents> For<TEvents>() where TEvents : IEventHandler;
    }

    /// <summary>
    /// The generic event handler
    /// </summary>
    /// <typeparam name="TEvents">The type of the events.</typeparam>
    public interface IEventManager<TEvents> where TEvents : IEventHandler
    {
        /// <summary>
        /// Invokes the specified events.
        /// </summary>
        /// <typeparam name="TEvents">The type of the events.</typeparam>
        /// <param name="dispatch">The dispatch.</param>
        void Publish(Action<TEvents> dispatch);
    }
}
