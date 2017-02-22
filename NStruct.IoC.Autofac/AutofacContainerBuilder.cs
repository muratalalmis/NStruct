using Autofac;

namespace NStruct.IoC.Autofac
{
    /// <summary>
    /// The autofac container builder
    /// </summary>
    public class AutofacContainerBuilder : ContainerBuilder
    {
        private readonly global::Autofac.ContainerBuilder _containerBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutofacContainerBuilder"/> class.
        /// </summary>
        /// <param name="containerBuilder">The container builder.</param>
        internal AutofacContainerBuilder(global::Autofac.ContainerBuilder containerBuilder)
        {
            _containerBuilder = containerBuilder;
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="TImplementor"></typeparam>
        /// <typeparam name="TService"></typeparam>
        /// void Registerementor, TService&gt;() whmentor : TServ
        public override void RegisterType<TImplementor, TService>()
        {
            _containerBuilder.RegisterType<TImplementor>().As<TService>();
        }
    }
}
