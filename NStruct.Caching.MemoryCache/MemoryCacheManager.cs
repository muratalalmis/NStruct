using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text.RegularExpressions;

namespace NStruct.Caching.MemoryCache
{
    /// <summary>
    /// The memory cache manager
    /// </summary>
    public sealed class MemoryCacheManager : CacheManagerBase
    {
        /// <summary>
        /// Gets the cache.
        /// </summary>
        /// <value>The cache.</value>
        private ObjectCache Cache
        {
            get
            {
                return System.Runtime.Caching.MemoryCache.Default;
            }
        }

        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value associated with the specified key.</returns>
        public override T Get<T>(string key)
        {
            return (T)Cache[PrepareCacheKey(key)];
        }

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.Object.</returns>
        public override object Get(string key)
        {
            return Cache[PrepareCacheKey(key)];
        }

        /// <summary>
        /// Adds the specified key and object to the cache.
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">Data</param>
        /// <param name="cacheTime">Cache time</param>
        public override void Set(string key, object data, int cacheTime)
        {
            Set<object>(key, data, cacheTime);
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
            if (data == null)
                return;

            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromSeconds(cacheTime);

            Cache.Add(new CacheItem(PrepareCacheKey(key), data), policy);
        }

        /// <summary>
        /// Gets a value indicating whether the value associated with the specified key is cached
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>Result</returns>
        public override bool IsSet(string key)
        {
            return (Cache.Contains(PrepareCacheKey(key)));
        }

        /// <summary>
        /// Removes the value with the specified key from the cache
        /// </summary>
        /// <param name="key">/key</param>
        public override void Remove(string key)
        {
            Cache.Remove(PrepareCacheKey(key));
        }

        /// <summary>
        /// Removes items by pattern
        /// </summary>
        /// <param name="pattern">pattern</param>
        public override void RemoveByPattern(string pattern)
        {
            var regex = new Regex(PrepareCacheKey(pattern), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = new List<String>();

            foreach (var item in Cache)
                if (regex.IsMatch(item.Key))
                    keysToRemove.Add(item.Key);

            foreach (string key in keysToRemove)
            {
                Remove(key);
            }
        }

        /// <summary>
        /// Clear all cache data
        /// </summary>
        public override void Clear()
        {
            foreach (var item in Cache)
                Remove(item.Key);
        }

        /// <summary>
        /// Gets all key.
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        public override List<string> GetAllKey()
        {
            return Cache.Select(o => o.Key.ToString()).ToList();
        }
    }
}
