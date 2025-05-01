using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using APEX.Services.Interfaces;

namespace APEX.Services.Services
{
   
    public class LocalizationService : ILocalizationService
    {
        private readonly ResourceManager _resourceManager;
        private CultureInfo _currentCulture;

        public LocalizationService()
        {
            _resourceManager = new ResourceManager("APEX.UI.Resources.Languages.Resources", typeof(App).Assembly);
            _currentCulture = CultureInfo.CurrentCulture;
        }

        public string this[string key] => _resourceManager.GetString(key, _currentCulture) ?? key;

        public CultureInfo CurrentCulture
        {
            get => _currentCulture;
            set
            {
                if (_currentCulture != value)
                {
                    _currentCulture = value;
                    LanguageChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public event EventHandler LanguageChanged;

        public IEnumerable<CultureInfo> SupportedLanguages => new[]
        {
        new CultureInfo("en-US"),
        new CultureInfo("zh-CN")
    };

        public string GetLocalizedString(string key, CultureInfo culture = null)
        {
            throw new NotImplementedException();
        }
    }
}
