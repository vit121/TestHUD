using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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

        public static readonly DependencyProperty SpeedProperty = DependencyProperty.Register("Speed", typeof(SpeedModel), typeof(SpeedView));

        public SpeedView()
        {
            InitializeComponent();

            //CompositionTarget.Rendering += UpdateData;
        }


        private async void UpdateData(object? sender, EventArgs e)
        {
            Thread.Sleep(2000);
            double sample_rate = 4;
            double sineFrequensy = 10;
            int index = 0;
            var val = Math.Sin(2 * Math.PI * sineFrequensy * index / sample_rate);
            if (Speed.Speed > 120)
            {
                Speed.Speed = 0;
            }
            Speed.Speed = val;
        }

    }
}
