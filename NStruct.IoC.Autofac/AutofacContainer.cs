using Autofac;

namespace NStruct.IoC.Autofac
{
    /// <summary>
    /// The autofac IoC Container
    /// </summary>
    public class AutofacContainer : Container
    {
        private IContainer _container;
        private global::Autofac.ContainerBuilder _containerBuilder;

        /// <summary>
        /// Creates the builder.
        /// </summary>
        /// <returns></returns>
        public override ContainerBuilder CreateBuilder()
        {
            _containerBuilder = new global::Autofac.ContainerBuilder();
            var containerBuilder = new AutofacContainerBuilder(_containerBuilder);

            return containerBuilder;
        }

        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns></returns>
        public override TService Resolve<TService>()
        {
            return this._container.Resolve<TService>();
        }

        /// <summary>
        /// Builds the container.
        /// </summary>
        /// <returns></returns>
        protected override Container BuildContainer()
        {
            _container = _containerBuilder.Build();

            return this;
        }
    }
}
