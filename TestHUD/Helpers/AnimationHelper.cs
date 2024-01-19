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
using System.Windows.Media.Imaging;
using System.Reflection.Metadata;

namespace TestHUD.Helpers
{
    public class AnimationHelper
    {
        public static AnimationHelper Instance = new AnimationHelper();

        public double CalculateAngle(double angle)
        {
            angle = -angle; // we need to reverse it for our compass
            if (IsZero(angle))
            {
                return 0;
            }
            if (angle < 0)
            {
                angle = -angle;
                angle = 360 - angle;
            }
            while (angle >= 359.5)
            {
                angle = 360 - angle;
            }
            if (angle < 0)
            {
                angle = -angle;
            }
            return angle;
        }

        private bool IsZero(double currentValue)
        {
            if (Math.Abs(currentValue) < 0.1)
            {
                return true;
            }
            return false;
        }
    }



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
