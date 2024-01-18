using System.Diagnostics;
using System.Text;
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

            DataContext = new MainWindowViewModel();

            //this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var def = ARC2.EndAngle;
            var sldr = (Slider)sender;
            ARC2.EndAngle = sldr.Value * 2.8; //3.6 For the full circle
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //Storyboard sb = this.FindResource("storyboardCompass") as Storyboard;
            //Storyboard.SetTarget(sb, (DataContext as MainWindowViewModel));
            //sb.Begin();
        }

        void StartAnimation()
        {
            Storyboard rotateTo90 = new Storyboard();
            // Add rotate animation
            rotateTo90.Completed += (s, e) =>
            {
                Storyboard rotateTo180 = new Storyboard();
                // Add rotate animation
                rotateTo180.Begin();
            };
            rotateTo90.Begin();
        }

        private void DoubleAnimation_Completed(object sender, EventArgs e)
        {
            Debug.WriteLine("DoubleAnimation_Completed!");
        }

        private void testDoubleAnimation_Changed(object sender, EventArgs e)
        {
            Debug.WriteLine("testDoubleAnimation_Changed!");
        }
    }
}