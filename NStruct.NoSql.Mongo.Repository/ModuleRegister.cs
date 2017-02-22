using NStruct.IoC;

namespace NStruct.NoSql.Mongo.Repository
{
    /// <summary>
    /// The module registrar
    /// </summary>
    public class ModuleRegister : IocModule
    {
        /// <summary>
        /// Configures the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        public override void Configure(ContainerBuilder container)
        {
            container.RegisterType<MongoRepositoryV240, IMongoRepository>();
        }
    }
}
