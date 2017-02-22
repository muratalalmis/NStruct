namespace NStruct.Localization
{
    /// <summary>
    /// The get text
    /// </summary>
    public interface IText : IDependency
    {
        /// <summary>
        /// Gets the specified text hint.
        /// </summary>
        /// <param name="textHint">The text hint.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>LocalizedString.</returns>
        LocalizedString Get(string textHint, params object[] args);
    }
}
