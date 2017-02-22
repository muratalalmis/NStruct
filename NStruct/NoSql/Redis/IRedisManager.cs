using System;
using System.Collections.Generic;

namespace NStruct.NoSql.Redis
{
    /// <summary>
    /// The redis manager
    /// </summary>
    public interface IRedisManager
    {
        /// <summary>
        /// Gets or sets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        long Db { get; set; }

        /// <summary>
        /// Gets the size of the database.
        /// </summary>
        /// <value>
        /// The size of the database.
        /// </value>
        long DbSize { get; }

        /// <summary>
        /// Gets the information.
        /// </summary>
        /// <value>
        /// The information.
        /// </value>
        Dictionary<string, string> Info { get; }

        /// <summary>
        /// Gets the last save.
        /// </summary>
        /// <value>
        /// The last save.
        /// </value>
        DateTime LastSave { get; }

        /// <summary>
        /// Gets the host.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        string Host { get; }

        /// <summary>
        /// Gets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        int Port { get; }

        /// <summary>
        /// Gets or sets the connect timeout.
        /// </summary>
        /// <value>
        /// The connect timeout.
        /// </value>
        int ConnectTimeout { get; set; }

        /// <summary>
        /// Gets or sets the retry timeout.
        /// </summary>
        /// <value>
        /// The retry timeout.
        /// </value>
        int RetryTimeout { get; set; }

        /// <summary>
        /// Gets or sets the retry count.
        /// </summary>
        /// <value>
        /// The retry count.
        /// </value>
        int RetryCount { get; set; }

        /// <summary>
        /// Gets or sets the send timeout.
        /// </summary>
        /// <value>
        /// The send timeout.
        /// </value>
        int SendTimeout { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        string Password { get; set; }

        /// <summary>
        /// Gets a value indicating whether [had exceptions].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [had exceptions]; otherwise, <c>false</c>.
        /// </value>
        bool HadExceptions { get; }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();

        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        void SaveAsync();

        /// <summary>
        /// Shutdowns this instance.
        /// </summary>
        void Shutdown();

        /// <summary>
        /// Rewrites the append only file asynchronous.
        /// </summary>
        void RewriteAppendOnlyFileAsync();

        /// <summary>
        /// Flushes the database.
        /// </summary>
        void FlushDb();

        /// <summary>
        /// Gets the server time.
        /// </summary>
        /// <returns></returns>
        DateTime GetServerTime();

        /// <summary>
        /// Flushes all.
        /// </summary>
        void FlushAll();
    }
}
