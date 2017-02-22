using System;
using System.Configuration;
using NStruct.Configuration;

namespace NStruct.NoSql.Redis.Repository.Configuration
{
    /// <summary>
    /// The redis configuration builder
    /// </summary>
    public class RedisConfigurationBuilder
    {
        internal RedisConfiguration Configuration;

        /// <summary>
        /// Prevents a default instance of the <see cref="RedisConfigurationBuilder"/> class from being created.
        /// </summary>
        private RedisConfigurationBuilder()
        {
            Configuration = new RedisConfiguration();
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public static RedisConfigurationBuilder Create()
        {
            return new RedisConfigurationBuilder();
        }

        /// <summary>
        /// Configures redis client from application configuration file.
        /// When using this method, go web config and implement config section.
        /// For an example : https://msdn.microsoft.com/en-us/library/2tw134k3.aspx
        /// </summary>
        /// <param name="section">The section.</param>
        /// <returns></returns>
        public static RedisConfigurationBuilder Create(string section)
        {
            RedisConfigurationHolder.CurrentConfiguration =
                (RedisConfiguration)ConfigurationManager.GetSection(section);

            return new RedisConfigurationBuilder();
        }

        /// <summary>
        /// Creates the specified function.
        /// </summary>
        /// <param name="func">The function.</param>
        /// <returns></returns>
        public static RedisConfigurationBuilder Create(Func<AppConfigConfigurable, RedisConfiguration> func)
        {
            RedisConfigurationHolder.CurrentConfiguration = func(new AppConfigConfigurable());

            return new RedisConfigurationBuilder();
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        public void Build()
        {
            if (RedisConfigurationHolder.CurrentConfiguration == null)
            {
                RedisConfigurationHolder.CurrentConfiguration = Configuration;
            }
        }
    }
}