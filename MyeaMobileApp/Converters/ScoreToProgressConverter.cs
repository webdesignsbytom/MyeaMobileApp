using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace MyeaMobileApp.Converters
{
    public class ScoreToProgressConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int score)
            {
                return (double)score / 100.0;
            }
            return 0.0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
