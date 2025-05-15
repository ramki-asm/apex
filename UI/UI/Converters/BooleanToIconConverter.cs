using System;
using System.Globalization;
using System.Windows.Data;

namespace UI.Converters
{
    public class BooleanToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isOpen = (bool)value;
            string[] icons = parameter.ToString().Split('|');
            return isOpen ? icons[0] : icons[1];
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}