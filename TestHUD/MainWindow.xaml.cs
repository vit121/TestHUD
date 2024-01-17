using System.Text;
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
using TestHUD.ViewModel;

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
            DataContext = new MainWindowViewModel();
        }

        void setupImages()
        {
            image_tankcompass_compass.Source = ImageHelper.Instance.GetImage("tankcompass_compass");
            image_tankcompass_pad.Source = ImageHelper.Instance.GetImage("tankcompass_pad");
            image_tankcompass_tower.Source = ImageHelper.Instance.GetImage("tankcompass_tower");

            //image_isEngineOverheat.Source = ImageHelper.Instance.GetImage("isEngineOverheat");
            //image_isOilLowPressure.Source = ImageHelper.Instance.GetImage("isOilLowPressure");
            //image_isEngineDamaged.Source = ImageHelper.Instance.GetImage("isEngineDamaged");
            //image_isHeadLightsOn.Source = ImageHelper.Instance.GetImage("isHeadLightsOn");
            //image_isAccumLowPower.Source = ImageHelper.Instance.GetImage("isAccumLowPower");

            //image_sucompass_compass.Source = ImageHelper.Instance.GetImage("sucompass_compass");
            //image_sucompass_pad_left.Source = ImageHelper.Instance.GetImage("sucompass_pad_left");
            //image_sucompass_pad_right.Source = ImageHelper.Instance.GetImage("sucompass_pad_right");
            //image_tankcompass_pad.Source = ImageHelper.Instance.GetImage("tankcompass_pad");
            //image_sucompass_pad.Source = ImageHelper.Instance.GetImage("sucompass_pad");
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //var def = ARC2.EndAngle;
            //var sldr = (Slider)sender;
            //ARC1.EndAngle = sldr.Value * 3.6;
            //ARC2.EndAngle = sldr.Value * 3.6;
        }


    }
}