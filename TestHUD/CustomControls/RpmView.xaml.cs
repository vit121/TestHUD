using Microsoft.Expression.Shapes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
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

        private static void Rpm_PropertyChanged(DependencyObject dobj, DependencyPropertyChangedEventArgs e)
        {
            var userControl = (RpmView)dobj;
            userControl.createAnimation();
        }

        public static readonly DependencyProperty RpmProperty = DependencyProperty.Register("Rpm", typeof(RpmModel), typeof(RpmView),
             new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, new PropertyChangedCallback(Rpm_PropertyChanged)));

        DoubleAnimation animation = new DoubleAnimation();
        bool animationIsFirstType = true;

        public RpmView()
        {
            InitializeComponent();
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

        private void startAnimation()
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
