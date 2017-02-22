using System.Linq;

namespace NStruct.Localization
{
    /// <summary>
    /// The localizer extensions
    /// </summary>
    public static class LocalizerExtensions
    {
        /// <summary>
        /// Plurals the specified t.
        /// </summary>
        /// <param name="T">The t.</param>
        /// <param name="textSingular">The text singular.</param>
        /// <param name="textPlural">The text plural.</param>
        /// <param name="count">The count.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>LocalizedString.</returns>
        public static LocalizedString Plural(this Localizer T, string textSingular, string textPlural, int count, params object[] args)
        {
            return T(count == 1 ? textSingular : textPlural, new object[] { count }.Concat(args).ToArray());
        }

        /// <summary>
        /// Plurals the specified t.
        /// </summary>
        /// <param name="T">The t.</param>
        /// <param name="textNone">The text none.</param>
        /// <param name="textSingular">The text singular.</param>
        /// <param name="textPlural">The text plural.</param>
        /// <param name="count">The count.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>LocalizedString.</returns>
        public static LocalizedString Plural(this Localizer T, string textNone, string textSingular, string textPlural, int count, params object[] args)
        {
            switch (count)
            {
                case 0:
                    return T(textNone, new object[] { count }.Concat(args).ToArray());
                case 1:
                    return T(textSingular, new object[] { count }.Concat(args).ToArray());
                default:
                    return T(textPlural, new object[] { count }.Concat(args).ToArray());
            }
        }
    }
}
