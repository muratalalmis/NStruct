using System;

namespace NStruct.Caching
{
    /// <summary>
    /// The cache manager extensions
    /// </summary>
    public static class CacheManagerExtensions
    {
        /// <summary>
        /// Gets the or add.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="cacheManager">The cache manager.</param>
        /// <param name="key">The key.</param>
        /// <param name="func">The function.</param>
        /// <returns></returns>
        public static TValue GetOrAdd<TValue>(this ICacheManager cacheManager, string key, Func<TValue> func)
        {
            return cacheManager.GetOrAdd(key, func, 3600);
        }

        /// <summary>
        /// Gets the or add.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="cacheManager">The cache manager.</param>
        /// <param name="key">The key.</param>
        /// <param name="func">The function.</param>
        /// <param name="expireSeconds">The expire seconds.</param>
        /// <returns></returns>
        public static TValue GetOrAdd<TValue>(this ICacheManager cacheManager, string key, Func<TValue> func, int expireSeconds)
        {
            if (!cacheManager.IsSet(key))
            {
                cacheManager.Set(key, func(), expireSeconds);
            }

            return cacheManager.Get<TValue>(key);
        }
    }
}
