namespace NStruct.NoSql.Redis
{
    /// <summary>
    /// The redis incrementor
    /// </summary>
    public interface IRedisIncrementor
    {
        /// <summary>
        /// Increments the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="amount">The amount.</param>
        /// <returns></returns>
        long Increment(string key, uint amount);

        /// <summary>
        /// Decrements the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="amount">The amount.</param>
        /// <returns></returns>
        long Decrement(string key, uint amount);

        /// <summary>
        /// Increments the value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        long IncrementValue(string key);

        /// <summary>
        /// Decrements the value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        long DecrementValue(string key);
    }
}
