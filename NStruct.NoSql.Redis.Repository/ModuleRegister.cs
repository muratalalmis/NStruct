using NStruct.IoC;

namespace NStruct.NoSql.Redis.Repository
{
    /// <summary>
    /// The redis module registration
    /// </summary>
    public class ModuleRegister : IocModule
    {
        public override void Configure(ContainerBuilder container)
        {
            container.RegisterType<RedisRepository, IRedisRepository>();
        }
    }
}
