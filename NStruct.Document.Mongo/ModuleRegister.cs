using NStruct.IoC;
using NStruct.NoSql.Document;

namespace NStruct.Document.Mongo
{
    /// <summary>
    /// The registration of mongo storage
    /// </summary>
    public class ModuleRegister : IocModule
    {
        /// <summary>
        /// Configures the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public override void Configure(ContainerBuilder builder)
        {
            builder.RegisterType<DefaultMongoStorage, IDocumentStorage>();
        }
    }
}
