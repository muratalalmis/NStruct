using System;
using System.Configuration;

namespace NStruct.NoSql.Redis.Repository.Configuration
{
    /// <summary>
    /// The redis configuraiton
    /// </summary>
    public class RedisConfiguration : ConfigurationSection, IRedisConfiguration
    {
        private const string HOST = "Host";
        private const string PASSWORD = "Password";
        private const string PORT = "Port";
        private const string CONNECTION_TIMEOUT = "ConnectionTimeOut";

        /// <summary>
        /// Initializes a new instance of the <see cref="RedisConfiguration"/> class.
        /// </summary>
        public RedisConfiguration()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RedisConfiguration"/> class.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="password">The password.</param>
        /// <param name="port">The port.</param>
        /// <param name="connectionTimeOut"></param>
        public RedisConfiguration(string host, string password, int port, int connectionTimeOut)
        {
            Host = host;
            Password = password;
            Port = port;
            ConnectionTimeOut = connectionTimeOut;
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
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [ConfigurationProperty(PASSWORD, IsRequired = true)]
        public string Password
        {
            get
            {
                return (string)this[PASSWORD];
            }
            set
            {
                this[PASSWORD] = value;
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

        /// <summary>
        /// Gets or sets the connection time out.
        /// </summary>
        /// <value>
        /// The connection time out.
        /// </value>
        [ConfigurationProperty(CONNECTION_TIMEOUT, IsRequired = true)]
        public int ConnectionTimeOut
        {
            get
            {
                return Int32.Parse(this[CONNECTION_TIMEOUT].ToString());
            }
            set
            {
                this[CONNECTION_TIMEOUT] = value.ToString();
            }
        }
    }
}