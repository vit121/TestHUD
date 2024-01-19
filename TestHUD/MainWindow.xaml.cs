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
using System.Xml.Linq;
using TestHUD.Helpers;
using TestHUD.ViewModel;

namespace TestHUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();
            ViewModel = (DataContext as MainWindowViewModel)!;

            //this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
            createAnimation_Compass();
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

        DoubleAnimation animation = new DoubleAnimation();

        void createAnimation_Compass()
        {
            //var animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = 180;
            animation.Duration = new Duration(TimeSpan.FromSeconds(2));
            animation.EasingFunction = new SineEase()
            {
                EasingMode = EasingMode.EaseInOut
            };
            Storyboard.SetTarget(animation, image_tankcompass_compass);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(Image.RenderTransform).(RotateTransform.Angle)"));
            animation.Changed += animationCompass_Changed;
            animation.Completed += animationCompass_Completed;
            //animation.CurrentTimeInvalidated += Animation_CurrentTimeInvalidated;
            storyboardCompass.Children.Add(animation);
            storyboardCompass.Begin();

            //var timeline = new StringAnimationUsingKeyFrames();
            //timeline.KeyFrames.Add(new DiscreteStringKeyFrame("Goodbye", KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1))));
            //text_speed.BeginAnimation(TextBox.TextProperty, timeline);
        }

        void calculateAnimation_Compass()
        {
            animation.From = rotateTransform_compass.Angle;
            animation.To = 0;
            storyboardCompass.Begin();
        }

        //private void Animation_CurrentTimeInvalidated(object? sender, EventArgs e)
        //{
        //    RotateTransform rotationTower = image_tankcompass_compass.RenderTransform as RotateTransform;
        //    ViewModel.Compass.CourseAngle = rotationTower.Angle;
        //    Debug.WriteLine("Animation_CurrentTimeInvalidated!");
        //}

        private void animationCompass_Changed(object? sender, EventArgs e)
        {
            Debug.WriteLine("animationCompass_Changed!");
        }

        private void animationCompass_Completed(object? sender, EventArgs e)
        {
            Debug.WriteLine("animationCompass_Completed!");
            calculateAnimation_Compass();
        }

    }
}