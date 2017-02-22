using System;

namespace NStruct.Localization
{
    /// <summary>
    /// The localized string
    /// </summary>
    public class LocalizedString : MarshalByRefObject
    {
        private readonly string _localized;
        private readonly string _scope;
        private readonly string _textHint;
        private readonly object[] _args;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizedString"/> class.
        /// </summary>
        /// <param name="languageNeutral">The language neutral.</param>
        public LocalizedString(string languageNeutral)
        {
            _localized = languageNeutral;
            _textHint = languageNeutral;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizedString"/> class.
        /// </summary>
        /// <param name="localized">The localized.</param>
        /// <param name="scope">The scope.</param>
        /// <param name="textHint">The text hint.</param>
        /// <param name="args">The arguments.</param>
        public LocalizedString(string localized, string scope, string textHint, object[] args)
        {
            _localized = localized;
            _scope = scope;
            _textHint = textHint;
            _args = args;
        }

        /// <summary>
        /// Texts the or default.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>LocalizedString.</returns>
        public static LocalizedString TextOrDefault(string text, LocalizedString defaultValue)
        {
            if (string.IsNullOrEmpty(text))
                return defaultValue;
            return new LocalizedString(text);
        }

        /// <summary>
        /// Gets the scope.
        /// </summary>
        /// <value>The scope.</value>
        public string Scope => _scope;

        /// <summary>
        /// Gets the text hint.
        /// </summary>
        /// <value>The text hint.</value>
        public string TextHint => _textHint;

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>The arguments.</value>
        public object[] Args => _args;

        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text => _localized;

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return _localized;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            var hashCode = 0;
            if (_localized != null)
                hashCode ^= _localized.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var that = (LocalizedString)obj;
            return string.Equals(_localized, that._localized);
        }

    }
}
