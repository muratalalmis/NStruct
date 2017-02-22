namespace NStruct.NoSql.Redis
{
    /// <summary>
    /// The redis list operator
    /// </summary>
    public interface IRedisListOperator
    {
        /// <summary>
        /// Gets the list count.
        /// </summary>
        /// <param name="listId">The list identifier.</param>
        /// <returns></returns>
        long GetListCount(string listId);
    }
}
