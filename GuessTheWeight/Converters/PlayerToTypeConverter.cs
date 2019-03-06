using System;
using System.Globalization;
using System.Windows.Data;
using GameEngine.Players;

namespace GuessTheWeight.Converters
{
    public class PlayerToTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Binding.DoNothing;

            if (value is MemoryPlayer)
                return "Memory";
            if (value is CheaterPlayer)
                return "Cheater";
            if (value is RandomPlayer)
                return "Random";
            if (value is ThoroughPlayer)
                return "Thorough";
            if (value is ThoroughCheaterPlayer)
                return "Thorough cheater";

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
