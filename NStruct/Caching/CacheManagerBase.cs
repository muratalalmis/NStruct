using System;
using System.Collections.Generic;

namespace NStruct.Caching
{
    /// <summary>
    /// The cache manager base
    /// </summary>
    public abstract class CacheManagerBase : ICacheManager
    {
        /// <summary>
        /// The prepare cache key 
        /// Works with default value (Enter whatever it off)
        /// </summary>
        public static Func<string, string> PrepareCacheKey = s => s;

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public abstract T Get<T>(string key);

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        /// System.Object.
        /// </returns>
        public abstract object Get(string key);

        /// <summary>
        /// Adds the specified key and object to the cache.
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">Data</param>
        /// <param name="cacheTime">Cache time</param>
        public abstract void Set(string key, object data, int cacheTime);

        /// <summary>
        /// Sets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="data">The data.</param>
        /// <param name="cacheTime">The cache time.</param>
        public abstract void Set<T>(string key, T data, int cacheTime);

        /// <summary>
        /// Gets a value indicating whether the value associated with the specified key is cached
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>
        /// Result
        /// </returns>
        public abstract bool IsSet(string key);

        /// <summary>
        /// Removes the value with the specified key from the cache
        /// </summary>
        /// <param name="key">/key</param>
        public abstract void Remove(string key);

        /// <summary>
        /// Removes items by pattern
        /// </summary>
        /// <param name="pattern">pattern</param>
        public abstract void RemoveByPattern(string pattern);

        /// <summary>
        /// Clear all cache data
        /// </summary>
        public abstract void Clear();

        /// <summary>
        /// Gets all key.
        /// </summary>
        /// <returns>
        /// List&lt;System.String&gt;.
        /// </returns>
        public abstract List<string> GetAllKey();
    }
}
