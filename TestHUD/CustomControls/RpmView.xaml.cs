using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using TestHUD.Helpers;
using TestHUD.Model;

namespace TestHUD.CustomControls
{
    /// <summary>
    /// Interaction logic for RpmView.xaml
    /// </summary>
    public partial class RpmView : UserControl
    {
        public double RpmViewSize { get { return 120; } }

        public double ArcAngleStart { get { return 90; } }
        public double ArcAngleEnd { get { return 300; } }

        public double ArcAnglePercentTest { get; set; } = 10;

        public RpmModel Rpm
        {
            get { return (RpmModel)GetValue(RpmProperty); }
            set { SetValue(RpmProperty, value); }
        }

        private static void Rpm_PropertyChanged(DependencyObject dobj, DependencyPropertyChangedEventArgs e)
        {
            var userControl = (RpmView)dobj;
        }

        public static readonly DependencyProperty RpmProperty = DependencyProperty.Register("Rpm", typeof(RpmModel), typeof(RpmView),
             new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, new PropertyChangedCallback(Rpm_PropertyChanged)));

        public RpmView()
        {
            InitializeComponent();
        }
    }
}
