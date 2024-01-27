using System.Diagnostics;
using System.Windows;
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

        private static void Speed_PropertyChanged(DependencyObject dobj, DependencyPropertyChangedEventArgs e)
        {
            var userControl = (SpeedView)dobj;
        }

        public static readonly DependencyProperty SpeedProperty = DependencyProperty.Register("Speed", typeof(SpeedModel), typeof(SpeedView),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, new PropertyChangedCallback(Speed_PropertyChanged)));

        DoubleAnimation animation = new DoubleAnimation();
        bool animationIsForward = true;

        public SpeedView()
        {
            InitializeComponent();
        }
    }
}
