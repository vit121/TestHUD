using System.Windows;
using System.Windows.Controls;
using TestHUD.Model;

namespace TestHUD.CustomControls
{
    /// <summary>
    /// Interaction logic for DamagesView.xaml
    /// </summary>
    public partial class DamagesView : UserControl
    {
        public DamagesModel Damages
        {
            get { return (DamagesModel)GetValue(DamagesProperty); }
            set { SetValue(DamagesProperty, value); }
        }

        public static readonly DependencyProperty DamagesProperty = DependencyProperty.Register("Damages", typeof(DamagesModel), typeof(DamagesView));

        public DamagesView()
        {
            InitializeComponent();
        }
    }
}
