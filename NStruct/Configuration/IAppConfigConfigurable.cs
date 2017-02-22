using System.Configuration;

namespace NStruct.Configuration
{
    /// <summary>
    /// The app config configurable
    /// </summary>
    public interface IAppConfigConfigurable
    {
        /// <summary>
        /// Connections the strings.
        /// </summary>
        /// <returns></returns>
        ConnectionStringSettingsCollection ConnectionStrings { get; }

        /// <summary>
        /// Applications the setting.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        string AppSetting(string key);

        /// <summary>
        /// Gets the section.
        /// </summary>
        /// <typeparam name="TSection">The type of the section.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        TSection GetSection<TSection>(string key) where TSection : class;
    }
}
