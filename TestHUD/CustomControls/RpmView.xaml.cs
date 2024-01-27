using System.Windows;
using System.Windows.Controls;
using TestHUD.Model;

namespace TestHUD.CustomControls
{
    /// <summary>
    /// Interaction logic for RpmView.xaml
    /// </summary>
    public partial class RpmView : UserControl
    {
        public int RpmViewSize
        {
            get { return (int)GetValue(RpmViewSizeProperty); }
            set { SetValue(RpmViewSizeProperty, value); }
        }

        public static readonly DependencyProperty RpmViewSizeProperty =
            DependencyProperty.Register("RpmViewSize", typeof(int), typeof(RpmView), new FrameworkPropertyMetadata(120));

        public double RpmTargetAngle
        {
            get { return (double)GetValue(RpmTargetAngleProperty); }
            set { SetValue(RpmTargetAngleProperty, value); }
        }

        public static readonly DependencyProperty RpmTargetAngleProperty =
            DependencyProperty.Register("RpmTargetAngle", typeof(double), typeof(RpmView), new FrameworkPropertyMetadata(300.0));

        public double RpmRadius
        {
            get { return (double)GetValue(RpmRadiusProperty); }
            set { SetValue(RpmRadiusProperty, value); }
        }

        public static readonly DependencyProperty RpmRadiusProperty =
            DependencyProperty.Register("RpmRadius", typeof(double), typeof(RpmView), new FrameworkPropertyMetadata(40.0));

        public Point RpmArcCenter
        {
            get
            {
                int size = RpmViewSize / 2;
                return new Point(size, size);
            }
        }

        public double RpmAngle
        {
            get
            {
                double angle = (360 - RpmTargetAngle) / 2;
                return angle;
            }
        }

        public RpmModel Rpm
        {
            get { return (RpmModel)GetValue(RpmProperty); }
            set { SetValue(RpmProperty, value); }
        }

        public static readonly DependencyProperty RpmProperty = DependencyProperty.Register("Rpm", typeof(RpmModel), typeof(RpmView));

        public RpmView()
        {
            InitializeComponent();
        }
    }
}
