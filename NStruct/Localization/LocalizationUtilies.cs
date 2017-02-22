using NStruct.IoC;

namespace NStruct.Localization
{
    /// <summary>
    /// The localization utilities
    /// </summary>
    public class LocalizationUtilies
    {
        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <returns></returns>
        public static Localizer Resolve()
        {
            var text = ContainerHolder.CurrentContainer.Resolve<IText>();
            return text.Get;
        }
    }
}
