namespace NStruct.IoC
{
    /// <summary>
    /// The IoC container
    /// </summary>
    public abstract class Container : IContainerResolver
    {
        protected ContainerBuilder Builder;
        protected Container CurrentInstance;

        /// <summary>
        /// Gets the current.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        public Container Current => CurrentInstance;

        /// <summary>
        /// Creates the builder.
        /// </summary>
        /// <returns></returns>
        public abstract ContainerBuilder CreateBuilder();

        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns></returns>
        public abstract TService Resolve<TService>();

        /// <summary>
        /// Builds the container.
        /// </summary>
        /// <returns></returns>
        protected abstract Container BuildContainer();

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        public Container Build()
        {
            this.CurrentInstance = BuildContainer();
            ContainerHolder.CurrentContainer = CurrentInstance;

            return Current;
        }
    }
}
