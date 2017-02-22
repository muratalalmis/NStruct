using System.Configuration;

namespace NStruct.Configuration
{
    /// <summary>
    /// The app config configuration
    /// </summary>
    public class AppConfigConfigurable : IAppConfigConfigurable
    {
        private static IAppConfigConfigurable Instance { get; set; }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public static IAppConfigConfigurable Create()
        {
            return Instance ?? (Instance = new AppConfigConfigurable());
        }

        /// <summary>
        /// Connections the strings.
        /// </summary>
        public ConnectionStringSettingsCollection ConnectionStrings => ConfigurationManager.ConnectionStrings;

        /// <summary>
        /// Applications the setting.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public string AppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// Gets the section.
        /// </summary>
        /// <typeparam name="TSection">The type of the section.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public TSection GetSection<TSection>(string key) where TSection : class
        {
            return (TSection)ConfigurationManager.GetSection(key);
        }
    }
}
