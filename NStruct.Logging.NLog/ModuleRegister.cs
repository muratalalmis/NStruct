using NStruct.IoC;

namespace NStruct.Logging.NLog
{
    /// <summary>
    /// The nlog module register
    /// </summary>
    public class ModuleRegister : IocModule
    {
        /// <summary>
        /// Configures the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public override void Configure(ContainerBuilder builder)
        {
            builder.RegisterType<NLogLogger, ILogger>();
        }
    }
}
