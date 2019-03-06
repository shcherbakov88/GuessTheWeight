using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace GuessTheWeight.Converters
{
    public class EnumValueToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumSource = value as Enum;
            var enumValue = parameter as Enum;
            if (enumSource == null || enumValue == null)
                return Visibility.Collapsed;

            return enumSource.Equals(enumValue) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}