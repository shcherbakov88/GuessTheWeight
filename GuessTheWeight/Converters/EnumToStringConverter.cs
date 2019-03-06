using System;
using System.Globalization;
using System.Windows.Data;

namespace GuessTheWeight.Converters
{
    public class EnumToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumValue = value as Enum;
            if (enumValue == null)
                return Binding.DoNothing;

            return enumValue.Description();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}