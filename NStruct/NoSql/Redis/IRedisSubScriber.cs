namespace NStruct.NoSql.Redis
{
    /// <summary>
    /// The redis subscriber
    /// </summary>
    public interface IRedisSubscriber
    {
        /// <summary>
        /// Watches the specified keys.
        /// </summary>
        /// <param name="keys">The keys.</param>
        void Watch(params string[] keys);

        /// <summary>
        /// Uns the watch.
        /// </summary>
        void UnWatch();
    }
}
