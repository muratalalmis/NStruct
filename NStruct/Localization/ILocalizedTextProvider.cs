using System.Collections.Generic;

namespace NStruct.Localization
{
    /// <summary>
    /// The localized text provider
    /// </summary>
    public interface ILocalizedTextProvider : IDependency
    {
        /// <summary>
        /// Gets the dictionary.
        /// </summary>
        /// <value>
        /// The dictionary.
        /// </value>
        Dictionary<string, string> Dictionary { get; }
    }
}
