using System;

namespace NStruct.NoSql.Redis
{
    /// <summary>
    /// The redis repository
    /// </summary>
    public interface IRedisRepository : IRedisWriter, IRedisReader, IRedisIncrementor, IRedisPublisher, IRedisSubscriber, IRedisListOperator, IRedisDeletor, IRedisManager, IRedisStorage, IDisposable
    {
        /// <summary>
        /// Gets the time to live.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        TimeSpan GetTimeToLive(string key);

        /// <summary>
        /// Expires the entry in.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="expireIn">The expire in.</param>
        /// <returns></returns>
        bool ExpireEntryIn(string key, TimeSpan expireIn);

        /// <summary>
        /// Expires the entry at.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="expireAt">The expire at.</param>
        /// <returns></returns>
        bool ExpireEntryAt(string key, DateTime expireAt);

        /// <summary>
        /// Determines whether the specified key contains key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        bool ContainsKey(string key);

        /// <summary>
        /// Expires the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="seconds">The seconds.</param>
        /// <returns></returns>
        bool Expire(string key, int seconds);
    }
}
