using Colossal;
using System.Collections.Generic;

namespace MertsIntersectionFix.Settings
{
    public class LocaleEN : IDictionarySource
    {
        private readonly IntersectionFixSettings m_Settings;

        public LocaleEN(IntersectionFixSettings settings)
        {
            m_Settings = settings;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Settings.GetSettingsLocaleID(), "Mert's Intersection Fix" },
            };
        }

        public void Unload()
        {
        }
    }
}