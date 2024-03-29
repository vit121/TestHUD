﻿using System.Globalization;
using System.Windows.Data;
using TestHUD.Helpers;

namespace TestHUD.Converters
{
    public class AngleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool initialReverse = false;
            if (parameter is string && (string)parameter == "reverse")
            {
                initialReverse = true;
            }
            double angle = (double)value;
            return AnimationHelper.Instance.CalculateAngle(angle, initialReverse);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
}
