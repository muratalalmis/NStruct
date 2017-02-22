using System;
using System.Collections.Generic;

namespace NStruct.NoSql.Redis
{
    /// <summary>
    /// The redis writer
    /// </summary>
    public interface IRedisWriter
    {
        /// <summary>
        /// Sets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        bool Set<T>(string key, T value);

        /// <summary>
        /// Replaces the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        bool Replace<T>(string key, T value);

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expiresAt">The expires at.</param>
        /// <returns></returns>
        bool Add<T>(string key, T value, DateTime expiresAt);

        /// <summary>
        /// Sets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expiresIn">The expires in.</param>
        /// <returns></returns>
        bool Set<T>(string key, T value, TimeSpan expiresIn);

        /// <summary>
        /// Sets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expiresAt">The expires at.</param>
        /// <returns></returns>
        bool Set<T>(string key, T value, DateTime expiresAt);

        /// <summary>
        /// Replaces the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expiresAt">The expires at.</param>
        /// <returns></returns>
        bool Replace<T>(string key, T value, DateTime expiresAt);

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expiresIn">The expires in.</param>
        /// <returns></returns>
        bool Add<T>(string key, T value, TimeSpan expiresIn);

        /// <summary>
        /// Replaces the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expiresIn">The expires in.</param>
        /// <returns></returns>
        bool Replace<T>(string key, T value, TimeSpan expiresIn);

        /// <summary>
        /// Sets all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">The values.</param>
        void SetAll<T>(IDictionary<string, T> values);

        /// <summary>
        /// Renames the key.
        /// </summary>
        /// <param name="fromName">From name.</param>
        /// <param name="toName">To name.</param>
        void RenameKey(string fromName, string toName);

        /// <summary>
        /// Sets all.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <param name="values">The values.</param>
        void SetAll(IEnumerable<string> keys, IEnumerable<string> values);

        /// <summary>
        /// Sets all.
        /// </summary>
        /// <param name="map">The map.</param>
        void SetAll(Dictionary<string, string> map);
    }
}
