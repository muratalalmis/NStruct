using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace NStruct.Localization
{
    /// <summary>
    /// The xml localization provider
    /// </summary>
    public class XmlLocalizationProvider : ILocalizedTextProvider
    {
        /// <summary>
        /// Gets the dictionary.
        /// </summary>
        /// <value>
        /// The dictionary.
        /// </value>
        public Dictionary<string, string> Dictionary => _dictionary;

        // TODO : Configuration
        private static string fileName = AppDomain.CurrentDomain.BaseDirectory + "Language.xml";
        private static Dictionary<string, string> _dictionary = BindValues();
        private static Object _lock = new Object();
        private static Dictionary<string, string> BindValues()
        {
            var localizedDictionary = new Dictionary<string, string>();

            if (System.IO.File.Exists(fileName))
            {
                lock (_lock)
                {
                    if (localizedDictionary.Count < 1)
                    {
                        XmlDocument xml = new XmlDocument();
                        xml.Load(fileName);
                        var langNote = xml.SelectSingleNode("/TextItems");
                        var lang = langNote.Attributes["language"].Value;
                        XmlNodeList xnList = xml.SelectNodes("/TextItems/Text");

                        foreach (XmlNode xn in xnList)
                        {
                            string key = string.Format("{0}-{1}", lang, xn.Attributes["orginalText"].Value);
                            string value = xn.Attributes["localizedText"].Value;
                            if (!localizedDictionary.Keys.Contains(key))
                            {
                                localizedDictionary.Add(key, value);
                            }
                        }
                    }
                }
            }

            return localizedDictionary;
        }
    }
}
