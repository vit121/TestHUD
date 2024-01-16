﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestHUD.Helpers;

namespace TestHUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            setupImages();
        }

        void setupImages()
        {
            image_tankcompass_compass.Source = ImageHelper.Instance.GetImage("tankcompass_compass");

            image_isAccumLowPower.Source = ImageHelper.Instance.GetImage("isAccumLowPower");
            image_isEngineDamaged.Source = ImageHelper.Instance.GetImage("isEngineDamaged");
            image_isEngineOverheat.Source = ImageHelper.Instance.GetImage("isEngineOverheat");
            image_isHeadLightsOn.Source = ImageHelper.Instance.GetImage("isHeadLightsOn");
            image_isOilLowPressure.Source = ImageHelper.Instance.GetImage("isOilLowPressure");
            image_sucompass_compass.Source = ImageHelper.Instance.GetImage("sucompass_compass");
            image_sucompass_pad.Source = ImageHelper.Instance.GetImage("sucompass_pad");
            image_sucompass_pad_left.Source = ImageHelper.Instance.GetImage("sucompass_pad_left");
            image_sucompass_pad_right.Source = ImageHelper.Instance.GetImage("sucompass_pad_right");
            image_tankcompass_pad.Source = ImageHelper.Instance.GetImage("tankcompass_pad");
            image_tankcompass_tower.Source = ImageHelper.Instance.GetImage("tankcompass_tower");
        }
    }
}