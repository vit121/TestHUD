using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;

namespace TestHUD.Helpers
{
    public class CustomTestFunction : EasingFunctionBase
    {
        public double NormalizedStep { get; set; }

        public CustomTestFunction()
            : base()
        {
        }

        // Specify your own logic for the easing function by overriding
        // the EaseInCore method. Note that this logic applies to the "EaseIn"
        // mode of interpolation.
        protected override double EaseInCore(double normalizedTime)
        {

            Debug.WriteLine("normalizedTime: " + normalizedTime);
            return normalizedTime;

            // applies the formula of time to the seventh power.
            //return Math.Pow(normalizedTime, 7);
        }

        // Typical implementation of CreateInstanceCore
        protected override Freezable CreateInstanceCore()
        {
            //return new CustomTestFunction();
            return new CustomTestFunction { NormalizedStep = NormalizedStep };
        }
    }
}
