namespace NStruct.IoC
{
    /// <summary>
    /// The ioc module
    /// </summary>
    public abstract class IocModule
    {
        /// <summary>
        /// Configures the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public abstract void Configure(ContainerBuilder builder);
    }
}
