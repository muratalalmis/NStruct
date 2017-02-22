using System.Collections.Generic;
using NStruct.NoSql.Redis;
using NStruct.NoSql.Redis.Repository;

namespace NStruct.Caching.Redis
{
    /// <summary>
    /// The redis cache manager
    /// </summary>
    public class RedisCacheManager : CacheManagerBase
    {
        /// <summary>
        /// Gets the cache.
        /// </summary>
        /// <value>
        /// The cache.
        /// </value>
        /// <exception cref="System.ArgumentNullException">The redis client was not configured!</exception>
        private IRedisRepository Cache => RedisRepository.New();

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public override T Get<T>(string key)
        {
            using (Cache)
            {
                return Cache.Get<T>(PrepareCacheKey(key));
            }
        }

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        /// System.Object.
        /// </returns>
        public override object Get(string key)
        {
            return Get<object>(PrepareCacheKey(key));
        }

        /// <summary>
        /// Adds the specified key and object to the cache.
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">Data</param>
        /// <param name="cacheTime">Cache time</param>
        public override void Set(string key, object data, int cacheTime)
        {
            Set<object>(PrepareCacheKey(key), data, cacheTime);
        }

        /// <summary>
        /// Sets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="data">The data.</param>
        /// <param name="cacheTime">The cache time.</param>
        public override void Set<T>(string key, T data, int cacheTime)
        {
            using (Cache)
            {
                Cache.Set(PrepareCacheKey(key), data);
                Cache.Expire(PrepareCacheKey(key), cacheTime);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the value associated with the specified key is cached
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>
        /// Result
        /// </returns>
        public override bool IsSet(string key)
        {
            using (Cache)
            {
                return Cache.ContainsKey(PrepareCacheKey(key));
            }
        }

        /// <summary>
        /// Removes the value with the specified key from the cache
        /// </summary>
        /// <param name="key">/key</param>
        public override void Remove(string key)
        {
            Cache.GetAllKeys().Remove(PrepareCacheKey(key));
        }

        /// <summary>
        /// Removes items by pattern
        /// </summary>
        /// <param name="pattern">pattern</param>
        public override void RemoveByPattern(string pattern)
        {
            using (Cache)
            {
                Cache.RemoveByPattern(PrepareCacheKey(pattern));
            }
        }

        /// <summary>
        /// Clear all cache data
        /// </summary>
        public override void Clear()
        {
            using (Cache)
            {
                Cache.FlushAll();
            }
        }

        /// <summary>
        /// Gets all key.
        /// </summary>
        /// <returns>
        /// List&lt;System.String&gt;.
        /// </returns>
        public override List<string> GetAllKey()
        {
            using (Cache)
            {
                return Cache.GetAllKeys();
            }
        }
    }
}
