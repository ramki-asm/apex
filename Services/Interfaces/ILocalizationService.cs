using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ILocalizationService
    {
        string this[string key] { get; }
        CultureInfo CurrentCulture { get; set; }
        event EventHandler LanguageChanged;
        IEnumerable<CultureInfo> SupportedLanguages { get; }
        string GetLocalizedString(string key, CultureInfo culture = null);
    }
}
