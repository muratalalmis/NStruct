namespace NStruct.IoC
{
    /// <summary>
    /// The module registrar
    /// </summary>
    public interface IModuleRegistrar
    {
        /// <summary>
        /// Registers the module.
        /// </summary>
        /// <param name="module">The module.</param>
        void RegisterModule(IocModule module);
    }
}
