namespace NStruct.IoC
{
    /// <summary>
    /// The container registrar
    /// </summary>
    public interface IContainerRegistrar
    {
        /// <summary>
        /// Registers the type.
        /// </summary>
        /// <typeparam name="TImplementor">The type of the implementor.</typeparam>
        /// <typeparam name="TService">The type of the service.</typeparam>
        void RegisterType<TImplementor, TService>() where TImplementor : TService;
    }
}
