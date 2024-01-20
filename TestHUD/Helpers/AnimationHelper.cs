﻿using System;
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

        public double CalculateAngle(double angle, bool initialReverse = false)
        {
            if (initialReverse)
            { 
                angle = -angle; // we need to reverse it for our compass
            }
            return (angle % 360) + (angle < 0 ? 360 : 0);
        }

        public DoubleAnimation BuildDesiredSineEaseAnimation(DependencyObject dependencyObject, PropertyPath propertyPath)
        {
            DoubleAnimation animation = new DoubleAnimation()
            {
                EasingFunction = new SineEase()
                {
                    EasingMode = EasingMode.EaseInOut
                }
            };
            Storyboard.SetTarget(animation, dependencyObject);
            Storyboard.SetTargetProperty(animation, propertyPath);
            return animation;
        }
    }
}
