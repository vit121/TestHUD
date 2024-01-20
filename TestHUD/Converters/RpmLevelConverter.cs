using System.Globalization;
using System.Windows.Data;
using TestHUD.Helpers;

namespace TestHUD.Converters
{
    public class RpmLevelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double)
            {
                return (double)value * Constants.RpmLevelCircleMultiplier;
            }
            throw new NotSupportedException();
        }
            

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
}
