namespace NStruct.IoC
{
    /// <summary>
    /// The container resolver
    /// </summary>
    public interface IContainerResolver
    {
        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns></returns>
        TService Resolve<TService>();
    }
}
