
namespace NStruct.NoSql.Mongo
{
    /// <summary>
    /// The mongo configuration
    /// </summary>
    public interface IMongoConfiguration
    {
        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        string Host { get; set; }

        /// <summary>
        /// Gets or sets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        string Database { get; set; }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        int Port { get; set; }
    }
}