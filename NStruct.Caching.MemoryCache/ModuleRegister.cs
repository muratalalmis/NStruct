using NStruct.IoC;

namespace NStruct.Caching.MemoryCache
{
    /// <summary>
    /// The memory cache register
    /// </summary>
    public class ModuleRegister : IocModule
    {
        /// <summary>
        /// Configures the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public override void Configure(ContainerBuilder builder)
        {
            builder.RegisterType<MemoryCacheManager, ICacheManager>();
        }
    }
}
