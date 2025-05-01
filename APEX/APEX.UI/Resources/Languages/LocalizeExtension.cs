using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows;
using Microsoft.Web.XmlTransform;

namespace APEX.UI.Resources.Languages
{
    public class LocalizeExtension : MarkupExtension
    {
        private readonly string _key;

        public LocalizeExtension(string key)
        {
            _key = key;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var binding = new Binding
            {
                Mode = BindingMode.OneWay,
                Path = new PropertyPath($"[{_key}]"),
                Source = Locator.Instance.LocalizationService
            };

            return binding.ProvideValue(serviceProvider);
        }
    }
}
