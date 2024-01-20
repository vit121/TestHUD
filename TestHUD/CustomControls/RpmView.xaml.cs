using Microsoft.Expression.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestHUD.Helpers;
using TestHUD.Model;

namespace TestHUD.CustomControls
{
    /// <summary>
    /// Interaction logic for RpmView.xaml
    /// </summary>
    public partial class RpmView : UserControl
    {
        public RpmModel Rpm
        {
            get { return (RpmModel)GetValue(RpmProperty); }
            set { SetValue(RpmProperty, value); }
        }

        public static readonly DependencyProperty RpmProperty = DependencyProperty.Register("Rpm", typeof(RpmModel), typeof(RpmView));

        DoubleAnimation animation = new DoubleAnimation();
        bool animationIsFirstType = true;

        public RpmView()
        {
            InitializeComponent();

            createAnimation();
        }

        #region Animation
        void createAnimation()
        {
            animation = AnimationHelper.Instance.BuildDesiredSineEaseAnimation(rpm_level,
                new PropertyPath(Arc.EndAngleProperty));
            animation.Completed += animationTower_Completed;
            storyboardRpm.Children.Add(animation);
            startAnimation();
        }

        void startAnimation()
        {
            animation.From = rpm_level.EndAngle;
            if (animationIsFirstType)
            {
                animation.To = 100 * Constants.RpmLevelCircleMultiplier;
                animation.Duration = new Duration(TimeSpan.FromSeconds(5));
            }
            else
            {
                animation.To = 25 * Constants.RpmLevelCircleMultiplier;
                animation.Duration = new Duration(TimeSpan.FromSeconds(10));
            }
            storyboardRpm.Begin();
        }

        private void animationTower_Completed(object? sender, EventArgs e)
        {
            animationIsFirstType = !animationIsFirstType;
            startAnimation();
        }
        #endregion
    }
}
