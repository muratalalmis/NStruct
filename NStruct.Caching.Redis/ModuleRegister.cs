using NStruct.IoC;

namespace NStruct.Caching.Redis
{
    /// <summary>
    /// The redis registration
    /// </summary>
    public class ModuleRegister : IocModule
    {
        /// <summary>
        /// Configures the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public override void Configure(ContainerBuilder builder)
        {
            builder.RegisterType<RedisCacheManager, ICacheManager>();
        }
    }
}
