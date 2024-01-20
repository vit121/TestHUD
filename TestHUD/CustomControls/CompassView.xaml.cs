using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        bool animationCompassIsFirstType = true;

        DoubleAnimation animationTower = new DoubleAnimation();
        bool animationTowerIsFirstType = true;

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
            if (animationCompassIsFirstType)
            {
                animationCompass.To = -180; // 180
                animationCompass.Duration = new Duration(TimeSpan.FromSeconds(10)); // 10
            }
            else
            {
                animationCompass.To = 720; // 720
                animationCompass.Duration = new Duration(TimeSpan.FromSeconds(15)); // 15
            }
            storyboardCompass.Begin();
        }

        //private void Animation_CurrentTimeInvalidated(object? sender, EventArgs e)
        //{
        //    RotateTransform rotationTower = image_tankcompass_compass.RenderTransform as RotateTransform;
        //    Compass.CourseAngle = rotationTower.Angle;
        //    Debug.WriteLine("Animation_CurrentTimeInvalidated!");
        //}

        private void animationCompass_Completed(object? sender, EventArgs e)
        {
            RotateTransform rotationTower = image_tankcompass_compass.RenderTransform as RotateTransform;
            animationCompassIsFirstType = !animationCompassIsFirstType;
            startAnimation_Compass();
        }
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
            if (animationTowerIsFirstType)
            {
                animationTower.To = 45;
                animationTower.Duration = new Duration(TimeSpan.FromSeconds(12)); // 10
            }
            else
            {
                animationTower.To = -65;
                animationTower.Duration = new Duration(TimeSpan.FromSeconds(14)); // 15
            }
            storyboardTower.Begin();
        }

        private void animationTower_Completed(object? sender, EventArgs e)
        {
            RotateTransform rotationTower = image_tankcompass_tower.RenderTransform as RotateTransform;
            animationTowerIsFirstType = !animationTowerIsFirstType;
            startAnimation_Tower();
        }
        #endregion

    }
}
