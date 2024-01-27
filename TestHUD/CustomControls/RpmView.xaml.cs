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
        public int RpmViewSize { get { return 120; } }
        public double RpmTargetAngle { get { return 300; } }

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
