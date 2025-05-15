using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Reflection;
using APEX.Services.Interfaces;
using Services.Interfaces;

namespace Services.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly ResourceManager _resourceManager;
        private CultureInfo _currentCulture;

        public LocalizationService()
        {
            // This assumes your resources are in the same assembly as this service
            // If they're in a different assembly, use:
            // var assembly = Assembly.Load("APEX.UI");
            var assembly = Assembly.GetExecutingAssembly();
            _resourceManager = new ResourceManager("APEX.UI.Resources.Languages.Resources", assembly);
            _currentCulture = CultureInfo.CurrentCulture;
        }

        public string this[string key]
        {
            get { return _resourceManager.GetString(key, _currentCulture) ?? key; }
        }

        public CultureInfo CurrentCulture
        {
            get { return _currentCulture; }
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

        public IEnumerable<CultureInfo> SupportedLanguages
        {
            get
            {
                return new[]
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("zh-CN")
                };
            }
        }

        public string GetLocalizedString(string key, CultureInfo culture = null)
        {
            return _resourceManager.GetString(key, culture ?? _currentCulture) ?? key;
        }
    }
}