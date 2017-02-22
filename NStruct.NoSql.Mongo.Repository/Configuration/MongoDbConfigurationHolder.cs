namespace NStruct.NoSql.Mongo.Repository.Configuration
{
    /// <summary>
    /// The mongo dbo configuraiton holder
    /// </summary>
    public class MongoDbConfigurationHolder
    {
        /// <summary>
        /// Gets or sets the current configuration.
        /// </summary>
        /// <value>
        /// The current configuration.
        /// </value>
        internal static MongoDbConfiguration CurrentConfiguration { get; set; }
    }
}
