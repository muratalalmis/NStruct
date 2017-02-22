using System.Collections;
using System.Collections.Generic;

namespace NStruct.NoSql.Redis
{
    /// <summary>
    /// The redis reader
    /// </summary>
    public interface IRedisReader
    {
        /// <summary>
        /// Gets or sets the <see cref="System.String"/> with the specified key.
        /// </summary>
        /// <value>
        /// The <see cref="System.String"/>.
        /// </value>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        string this[string key] { get; set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        string GetValue(string key);

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        T GetById<T>(object id);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys">The keys.</param>
        /// <returns></returns>
        IDictionary<string, T> GetAll<T>(IEnumerable<string> keys);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IList<T> GetAll<T>();

        /// <summary>
        /// Gets the by ids.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        IList<T> GetByIds<T>(ICollection ids);

        /// <summary>
        /// Gets all keys.
        /// </summary>
        /// <returns></returns>
        List<string> GetAllKeys();

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <returns></returns>
        List<string> GetValues(List<string> keys);

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys">The keys.</param>
        /// <returns></returns>
        List<T> GetValues<T>(List<string> keys);

        /// <summary>
        /// Searches the keys.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        List<string> SearchKeys(string pattern);
    }
}
