namespace NStruct.NoSql.Redis.Repository.Configuration
{
    /// <summary>
    /// The redis configuration holder
    /// </summary>
    static class RedisConfigurationHolder
    {
        /// <summary>
        /// Gets or sets the current configuration.
        /// </summary>
        /// <value>
        /// The current configuration.
        /// </value>
        internal static RedisConfiguration CurrentConfiguration { get; set; }
    }
}