using System.Windows.Media.Animation;
using System.Windows;

namespace TestHUD.Helpers
{
    public class AnimationHelper
    {
        public static AnimationHelper Instance = new AnimationHelper();

        public double CalculateAngle(double angle, bool initialReverse = false)
        {
            if (initialReverse)
            { 
                angle = -angle; // we need to reverse it for our compass
            }
            double realAngle = (angle % 360) + (angle < 0 ? 360 : 0);
            if (realAngle > 359.5)
            {
                return 0; 
            }
            return realAngle;
        }
    }
}
