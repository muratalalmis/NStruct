using System;
using System.Configuration;
using NStruct.Configuration;

namespace NStruct.NoSql.Mongo.Repository.Configuration
{
    /// <summary>
    /// The mongo db configuration builder
    /// </summary>
    public class MongoDbConfigurationBuilder
    {
        internal MongoDbConfiguration Configuration;

        /// <summary>
        /// Prevents a default instance of the <see cref="MongoDbConfigurationBuilder"/> class from being created.
        /// </summary>
        private MongoDbConfigurationBuilder()
        {
            Configuration = new MongoDbConfiguration();
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public static MongoDbConfigurationBuilder Create()
        {
            return new MongoDbConfigurationBuilder();
        }

        /// <summary>
        /// Configures mongo client from application configuration file.
        /// When using this method, go web config and implement config section.
        /// For an example : https://msdn.microsoft.com/en-us/library/2tw134k3.aspx
        /// </summary>
        /// <param name="section">The section.</param>
        /// <returns></returns>
        public static MongoDbConfigurationBuilder Create(string section)
        {
            MongoDbConfigurationHolder.CurrentConfiguration =
                (MongoDbConfiguration)ConfigurationManager.GetSection(section);

            return new MongoDbConfigurationBuilder();
        }

        /// <summary>
        /// Creates the specified function.
        /// </summary>
        /// <param name="func">The function.</param>
        /// <returns></returns>
        public static MongoDbConfigurationBuilder Create(Func<AppConfigConfigurable, MongoDbConfiguration> func)
        {
            MongoDbConfigurationHolder.CurrentConfiguration = func(new AppConfigConfigurable());

            return new MongoDbConfigurationBuilder();
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        public void Build()
        {
            if (MongoDbConfigurationHolder.CurrentConfiguration == null)
            {
                MongoDbConfigurationHolder.CurrentConfiguration = Configuration;
            }
        }
    }
}
