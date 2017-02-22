namespace NStruct.IoC
{
    /// <summary>
    /// The container builder
    /// </summary>
    public abstract class ContainerBuilder : IContainerRegistrar, IModuleRegistrar
    {
        /// <summary>
        /// </summary>
        /// <typeparam name="TImplementor"></typeparam>
        /// <typeparam name="TService"></typeparam>
        /// void Registerementor, TService&gt;() whmentor : TServ
        public abstract void RegisterType<TImplementor, TService>() where TImplementor : TService;

        /// <summary>
        /// Registers the module.
        /// </summary>
        /// <param name="module">The module.</param>
        public void RegisterModule(IocModule module)
        {
            module.Configure(this);
        }
    }
}
