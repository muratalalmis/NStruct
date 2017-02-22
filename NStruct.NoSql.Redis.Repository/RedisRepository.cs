using System;
using System.Collections;
using System.Collections.Generic;
using NStruct.NoSql.Redis.Repository.Configuration;
using ServiceStack.Redis;

namespace NStruct.NoSql.Redis.Repository
{
    /// <summary>
    /// The redis repository
    /// </summary>
    /// <seealso cref="IRedisRepository" />
    public class RedisRepository : IRedisRepository
    {
        /// <summary>
        /// News the specified configuration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static IRedisRepository New(IRedisConfiguration configuration)
        {
            return new RedisRepository(configuration);
        }

        /// <summary>
        /// News this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NStruct.FatalException">The redis client was not configured!</exception>
        public static IRedisRepository New()
        {

            if (RedisConfigurationHolder.CurrentConfiguration == null)
            {
                throw new FatalException("The redis client was not configured!");
            }

            var config = RedisConfigurationHolder.CurrentConfiguration;

            return new RedisRepository(config);
        }

        private readonly RedisClient _client;

        /// <summary>
        /// Creates the client.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        /// <exception cref="NStruct.FatalException">
        /// Redis host was not configured!
        /// or
        /// Redis password was not configured!
        /// or
        /// Redis port was not configured!
        /// </exception>
        private RedisClient CreateClient(IRedisConfiguration configuration)
        {
            if (string.IsNullOrEmpty(configuration.Host)) throw new FatalException("Redis host was not configured!");
            if (string.IsNullOrEmpty(configuration.Password)) throw new FatalException("Redis password was not configured!");
            if (configuration.Port == 0) throw new FatalException("Redis port was not configured!");

            var client = new RedisClient(configuration.Host, configuration.Port, configuration.Password);
            client.ConnectTimeout = configuration.ConnectionTimeOut;

            return client;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RedisRepository"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        private RedisRepository(IRedisConfiguration configuration)
        {
            _client = CreateClient(configuration);
        }

        /// <summary>
        /// Sets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public bool Set<T>(string key, T value)
        {
            return _client.Set(key, value);
        }

        /// <summary>
        /// Replaces the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public bool Replace<T>(string key, T value)
        {
            return _client.Replace(key, value);
        }

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expiresAt">The expires at.</param>
        /// <returns></returns>
        public bool Add<T>(string key, T value, DateTime expiresAt)
        {
            return _client.Add(key, value, expiresAt);
        }

        /// <summary>
        /// Sets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expiresIn">The expires in.</param>
        /// <returns></returns>
        public bool Set<T>(string key, T value, TimeSpan expiresIn)
        {
            return _client.Set(key, value, expiresIn);
        }

        /// <summary>
        /// Sets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expiresAt">The expires at.</param>
        /// <returns></returns>
        public bool Set<T>(string key, T value, DateTime expiresAt)
        {
            return _client.Set(key, value, expiresAt);
        }

        /// <summary>
        /// Replaces the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expiresAt">The expires at.</param>
        /// <returns></returns>
        public bool Replace<T>(string key, T value, DateTime expiresAt)
        {
            return _client.Replace(key, value, expiresAt);
        }

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expiresIn">The expires in.</param>
        /// <returns></returns>
        public bool Add<T>(string key, T value, TimeSpan expiresIn)
        {
            return _client.Add(key, value, expiresIn);
        }

        /// <summary>
        /// Replaces the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expiresIn">The expires in.</param>
        /// <returns></returns>
        public bool Replace<T>(string key, T value, TimeSpan expiresIn)
        {
            return _client.Replace(key, value, expiresIn);
        }

        /// <summary>
        /// Sets all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">The values.</param>
        public void SetAll<T>(IDictionary<string, T> values)
        {
            _client.SetAll(values);
        }

        /// <summary>
        /// Writes all.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entities">The entities.</param>
        public void WriteAll<TEntity>(IEnumerable<TEntity> entities)
        {
            _client.WriteAll(entities);
        }

        /// <summary>
        /// Renames the key.
        /// </summary>
        /// <param name="fromName">From name.</param>
        /// <param name="toName">To name.</param>
        public void RenameKey(string fromName, string toName)
        {
            _client.RenameKey(fromName, toName);
        }

        /// <summary>
        /// Sets the entry.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void SetEntry(string key, string value)
        {
            _client.SetEntry(key, value);
        }

        /// <summary>
        /// Sets the entry.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expireIn">The expire in.</param>
        public void SetEntry(string key, string value, TimeSpan expireIn)
        {
            _client.SetEntry(key, value, expireIn);
        }

        /// <summary>
        /// Sets the entry if not exists.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public bool SetEntryIfNotExists(string key, string value)
        {
            return _client.SetEntryIfNotExists(key, value);
        }

        /// <summary>
        /// Sets all.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <param name="values">The values.</param>
        public void SetAll(IEnumerable<string> keys, IEnumerable<string> values)
        {
            _client.SetAll(keys, values);
        }

        /// <summary>
        /// Sets all.
        /// </summary>
        /// <param name="map">The map.</param>
        public void SetAll(Dictionary<string, string> map)
        {
            _client.SetAll(map);
        }

        /// <summary>
        /// Appends to value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public long AppendToValue(string key, string value)
        {
            return _client.AppendToValue(key, value);
        }

        /// <summary>
        /// Sets the configuration.
        /// </summary>
        /// <param name="configItem">The configuration item.</param>
        /// <param name="value">The value.</param>
        public void SetConfig(string configItem, string value)
        {
            _client.SetConfig(configItem, value);
        }

        /// <summary>
        /// Gets or sets the <see cref="System.String" /> with the specified key.
        /// </summary>
        /// <value>
        /// The <see cref="System.String" />.
        /// </value>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public string this[string key]
        {
            get { return _client[key]; }
            set { _client[key] = value; }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            return _client.GetValue(key);
        }

        /// <summary>
        /// Gets the and set entry.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public string GetAndSetEntry(string key, string value)
        {
            return _client.GetAndSetEntry(key, value);
        }

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            return _client.Get<T>(key);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public T GetById<T>(object id)
        {
            return _client.GetById<T>(id);
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <param name="configItem">The configuration item.</param>
        /// <returns></returns>
        public string GetConfig(string configItem)
        {
            return _client.GetConfig(configItem);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys">The keys.</param>
        /// <returns></returns>
        public IDictionary<string, T> GetAll<T>(IEnumerable<string> keys)
        {
            return _client.GetAll<T>(keys);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IList<T> GetAll<T>()
        {
            return _client.GetAll<T>();
        }

        /// <summary>
        /// Gets the by ids.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        public IList<T> GetByIds<T>(ICollection ids)
        {
            return _client.GetByIds<T>(ids);
        }

        /// <summary>
        /// Gets all keys.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllKeys()
        {
            return _client.GetAllKeys();
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <returns></returns>
        public List<string> GetValues(List<string> keys)
        {
            return _client.GetValues(keys);
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys">The keys.</param>
        /// <returns></returns>
        public List<T> GetValues<T>(List<string> keys)
        {
            return _client.GetValues<T>(keys);
        }

        /// <summary>
        /// Gets the values map.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <returns></returns>
        public Dictionary<string, string> GetValuesMap(List<string> keys)
        {
            return _client.GetValuesMap(keys);
        }

        /// <summary>
        /// Gets the values map.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys">The keys.</param>
        /// <returns></returns>
        public Dictionary<string, T> GetValuesMap<T>(List<string> keys)
        {
            return _client.GetValuesMap<T>(keys);
        }

        /// <summary>
        /// Searches the keys.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        public List<string> SearchKeys(string pattern)
        {
            return _client.SearchKeys(pattern);
        }

        /// <summary>
        /// Gets the sorted entry values.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="startingFrom">The starting from.</param>
        /// <param name="endingAt">The ending at.</param>
        /// <returns></returns>
        public List<string> GetSortedEntryValues(string key, int startingFrom, int endingAt)
        {
            return _client.GetSortedEntryValues(key, startingFrom, endingAt);
        }

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            return _client.Remove(key);
        }

        /// <summary>
        /// Removes all.
        /// </summary>
        /// <param name="keys">The keys.</param>
        public void RemoveAll(IEnumerable<string> keys)
        {
            _client.RemoveAll(keys);
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        public void Delete<T>(T entity)
        {
            _client.Delete(entity);
        }

        /// <summary>
        /// Deletes the by identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        public void DeleteById<T>(object id)
        {
            _client.DeleteById<T>(id);
        }

        /// <summary>
        /// Deletes the by ids.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ids">The ids.</param>
        public void DeleteByIds<T>(ICollection ids)
        {
            _client.DeleteByIds<T>(ids);
        }

        /// <summary>
        /// Deletes all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void DeleteAll<T>()
        {
            _client.DeleteAll<T>();
        }

        /// <summary>
        /// Removes the by pattern.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        public void RemoveByPattern(string pattern)
        {
            _client.RemoveByPattern(pattern);
        }

        /// <summary>
        /// Removes the by regex.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        public void RemoveByRegex(string pattern)
        {
            _client.RemoveByRegex(pattern);
        }

        /// <summary>
        /// Removes the entry.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public bool RemoveEntry(params string[] args)
        {
            return _client.RemoveEntry(args);
        }

        /// <summary>
        /// Gets or sets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        public long Db
        {
            get { return _client.Db; }
            set { _client.Db = value; }
        }

        /// <summary>
        /// Gets the size of the database.
        /// </summary>
        /// <value>
        /// The size of the database.
        /// </value>
        public long DbSize
        {
            get { return _client.DbSize; }
        }

        /// <summary>
        /// Gets the information.
        /// </summary>
        /// <value>
        /// The information.
        /// </value>
        public Dictionary<string, string> Info
        {
            get { return _client.Info; }
        }

        /// <summary>
        /// Gets the last save.
        /// </summary>
        /// <value>
        /// The last save.
        /// </value>
        public DateTime LastSave
        {
            get { return _client.LastSave; }
        }

        /// <summary>
        /// Gets the host.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        public string Host
        {
            get { return _client.Host; }
        }

        /// <summary>
        /// Gets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        public int Port
        {
            get { return _client.Port; }
        }

        /// <summary>
        /// Gets or sets the connect timeout.
        /// </summary>
        /// <value>
        /// The connect timeout.
        /// </value>
        public int ConnectTimeout
        {
            get { return _client.ConnectTimeout; }
            set { _client.ConnectTimeout = value; }
        }

        /// <summary>
        /// Gets or sets the retry timeout.
        /// </summary>
        /// <value>
        /// The retry timeout.
        /// </value>
        public int RetryTimeout
        {
            get { return _client.RetryTimeout; }
            set { _client.RetryTimeout = value; }
        }

        /// <summary>
        /// Gets or sets the retry count.
        /// </summary>
        /// <value>
        /// The retry count.
        /// </value>
        public int RetryCount
        {
            get { return _client.RetryCount; }
            set { _client.RetryCount = value; }
        }

        /// <summary>
        /// Gets or sets the send timeout.
        /// </summary>
        /// <value>
        /// The send timeout.
        /// </value>
        public int SendTimeout
        {
            get { return _client.SendTimeout; }
            set { _client.SendTimeout = value; }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password
        {
            get { return _client.Password; }
            set { _client.Password = value; }
        }

        /// <summary>
        /// Gets a value indicating whether [had exceptions].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [had exceptions]; otherwise, <c>false</c>.
        /// </value>
        public bool HadExceptions
        {
            get { return _client.HadExceptions; }
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            _client.Save();
        }

        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        public void SaveAsync()
        {
            _client.SaveAsync();
        }

        /// <summary>
        /// Shutdowns this instance.
        /// </summary>
        public void Shutdown()
        {
            _client.Shutdown();
        }

        /// <summary>
        /// Rewrites the append only file asynchronous.
        /// </summary>
        public void RewriteAppendOnlyFileAsync()
        {
            _client.RewriteAppendOnlyFileAsync();
        }

        /// <summary>
        /// Flushes the database.
        /// </summary>
        public void FlushDb()
        {
            _client.FlushDb();
        }

        /// <summary>
        /// Gets the server time.
        /// </summary>
        /// <returns></returns>
        public DateTime GetServerTime()
        {
            return _client.GetServerTime();
        }

        /// <summary>
        /// Flushes all.
        /// </summary>
        public void FlushAll()
        {
            _client.FlushAll();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _client.Dispose();
        }

        /// <summary>
        /// Gets the time to live.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public TimeSpan GetTimeToLive(string key)
        {
            return _client.GetTimeToLive(key);
        }

        /// <summary>
        /// Expires the entry in.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="expireIn">The expire in.</param>
        /// <returns></returns>
        public bool ExpireEntryIn(string key, TimeSpan expireIn)
        {
            return _client.ExpireEntryIn(key, expireIn);
        }

        /// <summary>
        /// Expires the entry at.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="expireAt">The expire at.</param>
        /// <returns></returns>
        public bool ExpireEntryAt(string key, DateTime expireAt)
        {
            return _client.ExpireEntryAt(key, expireAt);
        }

        /// <summary>
        /// Determines whether the specified key contains key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public bool ContainsKey(string key)
        {
            return _client.ContainsKey(key);
        }

        /// <summary>
        /// Expires the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="seconds">The seconds.</param>
        /// <returns></returns>
        public bool Expire(string key, int seconds)
        {
            return _client.Expire(key, seconds);
        }

        /// <summary>
        /// Increments the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="amount">The amount.</param>
        /// <returns></returns>
        public long Increment(string key, uint amount)
        {
            return _client.Increment(key, amount);
        }

        /// <summary>
        /// Decrements the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="amount">The amount.</param>
        /// <returns></returns>
        public long Decrement(string key, uint amount)
        {
            return _client.Decrement(key, amount);
        }

        /// <summary>
        /// Increments the value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public long IncrementValue(string key)
        {
            return _client.IncrementValue(key);
        }

        /// <summary>
        /// Decrements the value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public long DecrementValue(string key)
        {
            return _client.DecrementValue(key);
        }

        public long PublishMessage(string toChannel, string message)
        {
            return _client.PublishMessage(toChannel, message);
        }

        /// <summary>
        /// Watches the specified keys.
        /// </summary>
        /// <param name="keys">The keys.</param>
        public void Watch(params string[] keys)
        {
            _client.Watch(keys);
        }

        /// <summary>
        /// Uns the watch.
        /// </summary>
        public void UnWatch()
        {
            _client.UnWatch();
        }

        public long GetListCount(string listId)
        {
            return _client.GetListCount(listId);
        }

        /// <summary>
        /// Stores the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public T Store<T>(T entity)
        {
            return _client.Store(entity);
        }

        /// <summary>
        /// Stores all.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entities">The entities.</param>
        public void StoreAll<TEntity>(IEnumerable<TEntity> entities)
        {
            _client.StoreAll(entities);
        }

        /// <summary>
        /// Stores the object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public object StoreObject(object entity)
        {
            return _client.StoreObject(entity);
        }
    }
}
