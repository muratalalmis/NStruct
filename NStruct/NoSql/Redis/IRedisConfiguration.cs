namespace NStruct.NoSql.Redis
{
    /// <summary>
    /// The redis configuration
    /// </summary>
    public interface IRedisConfiguration
    {
        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        string Host { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        string Password { get; set; }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        int Port { get; set; }

        /// <summary>
        /// Gets or sets the connection time out.
        /// </summary>
        /// <value>
        /// The connection time out.
        /// </value>
        int ConnectionTimeOut { get; set; }
    }
}
