using System.Collections.Generic;

namespace NStruct.NoSql.Redis
{
    /// <summary>
    /// The redis storage
    /// </summary>
    public interface IRedisStorage
    {
        /// <summary>
        /// Stores the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        T Store<T>(T entity);

        /// <summary>
        /// Stores all.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entities">The entities.</param>
        void StoreAll<TEntity>(IEnumerable<TEntity> entities);

        /// <summary>
        /// Stores the object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        object StoreObject(object entity);
    }
}
