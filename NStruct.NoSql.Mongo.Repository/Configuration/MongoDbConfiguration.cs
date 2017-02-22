using System;
using System.Configuration;

namespace NStruct.NoSql.Mongo.Repository.Configuration
{
    /// <summary>
    /// The mongo db configuration
    /// </summary>
    /// <seealso cref="IMongoConfiguration" />
    public class MongoDbConfiguration : ConfigurationSection, IMongoConfiguration
    {
        private const string HOST = "Host";
        private const string DATABASE = "Database";
        private const string PORT = "Port";

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbConfiguration"/> class.
        /// </summary>
        public MongoDbConfiguration()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbConfiguration"/> class.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="database">The database.</param>
        /// <param name="port">The port.</param>
        public MongoDbConfiguration(string host, string database, int port)
        {
            Host = host;
            Database = database;
            Port = port;
        }

        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        [ConfigurationProperty(HOST, IsRequired = true)]
        public string Host
        {
            get
            {
                return (string)this[HOST];
            }
            set
            {
                this[HOST] = value;
            }
        }

        /// <summary>
        /// Gets or sets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        [ConfigurationProperty(DATABASE, IsRequired = true)]
        public string Database
        {
            get
            {
                return (string)this[DATABASE];
            }
            set
            {
                this[DATABASE] = value;
            }
        }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        [ConfigurationProperty(PORT, IsRequired = true)]
        public int Port
        {
            get
            {
                return Int32.Parse(this[PORT].ToString());
            }
            set
            {
                this[PORT] = value.ToString();
            }
        }
    }
}
