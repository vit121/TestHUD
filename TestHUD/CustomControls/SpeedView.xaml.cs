﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using TestHUD.Helpers;
using TestHUD.Model;

namespace TestHUD.CustomControls
{
    /// <summary>
    /// Interaction logic for SpeedView.xaml
    /// </summary>
    public partial class SpeedView : UserControl
    {
        public SpeedModel Speed
        {
            get { return (SpeedModel)GetValue(SpeedProperty); }
            set { SetValue(SpeedProperty, value); }
        }

        public static readonly DependencyProperty SpeedProperty = DependencyProperty.Register("Speed", typeof(SpeedModel), typeof(SpeedView));

        DoubleAnimation animation = new DoubleAnimation();
        bool animationIsForward = true;

        public SpeedView()
        {
            InitializeComponent();

            createAnimation();
        }

        #region Animation
        void createAnimation()
        {
            animation = AnimationHelper.Instance.BuildDesiredSineEaseAnimation(speed_level,
                new PropertyPath(GroupBox.HeightProperty));
            animation.Completed += animationTower_Completed;
            animation.CurrentTimeInvalidated += Animation_CurrentTimeInvalidated;
            storyboardSpeed.Children.Add(animation);
            startAnimation();
        }

        void startAnimation()
        {
            animation.From = speed_level.Height;
            if (animationIsForward)
            {
                animation.To = 120;
                animation.Duration = new Duration(TimeSpan.FromSeconds(5));
            }
            else
            {
                animation.To = 0;
                animation.Duration = new Duration(TimeSpan.FromSeconds(10));
            }
            storyboardSpeed.Begin();
        }

        private void animationTower_Completed(object? sender, EventArgs e)
        {
            animationIsForward = !animationIsForward;
            startAnimation();
        }

        private void Animation_CurrentTimeInvalidated(object? sender, EventArgs e)
        {
            if (Speed != null)
            {
                Speed.Speed = speed_level.Height;
            }
        }
        #endregion

    }
}
