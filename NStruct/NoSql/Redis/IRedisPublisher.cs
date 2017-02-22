namespace NStruct.NoSql.Redis
{
    /// <summary>
    /// The redis publish
    /// </summary>
    public interface IRedisPublisher
    {
        /// <summary>
        /// Publishes the message.
        /// </summary>
        /// <param name="toChannel">To channel.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        long PublishMessage(string toChannel, string message);
    }
}
