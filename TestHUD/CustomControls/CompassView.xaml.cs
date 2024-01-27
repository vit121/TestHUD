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

        private static void Compass_PropertyChanged(DependencyObject dobj, DependencyPropertyChangedEventArgs e)
        {
            var userControl = (CompassView)dobj;
        }

        public static readonly DependencyProperty CompassProperty = DependencyProperty.Register("Compass", typeof(CompassModel), typeof(CompassView),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, new PropertyChangedCallback(Compass_PropertyChanged)));

        public CompassView()
        {
            InitializeComponent();
        }
    }
}
