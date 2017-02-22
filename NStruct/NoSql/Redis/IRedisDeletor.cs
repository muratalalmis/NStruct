using System.Collections;
using System.Collections.Generic;

namespace NStruct.NoSql.Redis
{
    /// <summary>
    /// The redis deletor
    /// </summary>
    public interface IRedisDeletor
    {
        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        bool Remove(string key);

        /// <summary>
        /// Removes all.
        /// </summary>
        /// <param name="keys">The keys.</param>
        void RemoveAll(IEnumerable<string> keys);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        void Delete<T>(T entity);

        /// <summary>
        /// Deletes the by identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        void DeleteById<T>(object id);

        /// <summary>
        /// Deletes the by ids.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ids">The ids.</param>
        void DeleteByIds<T>(ICollection ids);

        /// <summary>
        /// Deletes all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void DeleteAll<T>();

        /// <summary>
        /// Removes the by pattern.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        void RemoveByPattern(string pattern);

        /// <summary>
        /// Removes the by regex.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        void RemoveByRegex(string pattern);

        /// <summary>
        /// Removes the entry.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        bool RemoveEntry(params string[] args);
    }
}
