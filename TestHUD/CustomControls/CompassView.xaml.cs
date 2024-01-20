using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using TestHUD.Helpers;
using TestHUD.Model;

namespace TestHUD.CustomControls
{
    /// <summary>
    /// Interaction logic for CompassView.xaml
    /// </summary>
    public partial class CompassView : UserControl
    {
        public CompassModel Compass
        {
            get { return (CompassModel)GetValue(CompassProperty); }
            set { SetValue(CompassProperty, value); }
        }

        public static readonly DependencyProperty CompassProperty = DependencyProperty.Register("Compass", typeof(CompassModel), typeof(CompassView));

        DoubleAnimation animationCompass = new DoubleAnimation();
        bool animationCompassIsForward = true;

        DoubleAnimation animationTower = new DoubleAnimation();
        bool animationTowerIsForward = true;

        public CompassView()
        {
            InitializeComponent();

            createAnimation_Compass();
            createAnimation_Tower();
        }

        #region Animation Compass
        void createAnimation_Compass()
        {
            animationCompass = AnimationHelper.Instance.BuildDesiredSineEaseAnimation(image_tankcompass_compass, 
                new PropertyPath("(Image.RenderTransform).(RotateTransform.Angle)"));
            animationCompass.Completed += animationCompass_Completed;
            //animationCompass.CurrentTimeInvalidated += Animation_CurrentTimeInvalidated;
            storyboardCompass.Children.Add(animationCompass);
            startAnimation_Compass();
        }

        void startAnimation_Compass()
        {
            animationCompass.From = rotateTransform_compass.Angle;
            if (animationCompassIsForward)
            {
                animationCompass.To = rotateTransform_compass.Angle - 180; // 0.5 turn forward
                animationCompass.Duration = new Duration(TimeSpan.FromSeconds(10)); // 10 seconds
            }
            else
            {
                animationCompass.To = rotateTransform_compass.Angle + 720; // 2 turn back
                animationCompass.Duration = new Duration(TimeSpan.FromSeconds(15)); // 15 seconds
            }
            storyboardCompass.Begin();
        }

        private void animationCompass_Completed(object? sender, EventArgs e)
        {
            animationCompassIsForward = !animationCompassIsForward;
            startAnimation_Compass();
        }

        //private void Animation_CurrentTimeInvalidated(object? sender, EventArgs e)
        //{
        //    RotateTransform rotationTower = image_tankcompass_compass.RenderTransform as RotateTransform;
        //    Compass.CourseAngle = rotationTower.Angle;
        //}
        #endregion

        #region Animation Tower
        void createAnimation_Tower()
        {
            animationTower = AnimationHelper.Instance.BuildDesiredSineEaseAnimation(image_tankcompass_tower,
                new PropertyPath("(Image.RenderTransform).(RotateTransform.Angle)"));
            animationTower.Completed += animationTower_Completed;
            storyboardTower.Children.Add(animationTower);
            startAnimation_Tower();
        }

        void startAnimation_Tower()
        {
            animationTower.From = rotateTransform_tower.Angle;
            if (animationTowerIsForward)
            {
                animationTower.To = rotateTransform_tower.Angle + 45; // 45 forward
                animationTower.Duration = new Duration(TimeSpan.FromSeconds(12)); // 12
            }
            else
            {
                animationTower.To = rotateTransform_tower.Angle - 65; // 65 back
                animationTower.Duration = new Duration(TimeSpan.FromSeconds(14)); // 14
            }
            storyboardTower.Begin();
        }

        private void animationTower_Completed(object? sender, EventArgs e)
        {
            animationTowerIsForward = !animationTowerIsForward;
            startAnimation_Tower();
        }
        #endregion

    }
}
