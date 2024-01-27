using System.Globalization;
using System.Windows.Data;

namespace TestHUD.Converters
{
    public class RpmAngleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is double)
            {
                double angle = (double)values[0];
                if (values[1] is double)
                {
                    return ((double)values[1] * angle) / 100;
                }
            }
            return 10;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
           => throw new NotSupportedException();
    }
}
