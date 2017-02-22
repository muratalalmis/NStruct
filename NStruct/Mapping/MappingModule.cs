using NStruct.IoC;

namespace NStruct.Mapping
{
    /// <summary>
    /// The mapping module
    /// </summary>
    public class MappingModule : IocModule
    {
        /// <summary>
        /// Configures the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public override void Configure(ContainerBuilder builder)
        {
            builder.RegisterType<MappingManager, IMappingManager>();
        }
    }
}
