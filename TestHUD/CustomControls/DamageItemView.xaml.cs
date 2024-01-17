using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestHUD.Helpers;
using static System.Net.Mime.MediaTypeNames;

namespace TestHUD.CustomControls
{
    /// <summary>
    /// Interaction logic for DamageItemView.xaml
    /// </summary>
    public partial class DamageItemView : UserControl
    {
        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        private static void SourceProperty_PropertyChanged(DependencyObject dobj, DependencyPropertyChangedEventArgs e)
        {       
            Debug.WriteLine("Image SourceProperty changed is fired");
        }

        public bool IsDamaged
        {
            get { return (bool)GetValue(IsDamagedProperty); }
            set { SetValue(IsDamagedProperty, value); }
        }

        public Color ItemDamageColor
        {
            get { return (Color)GetValue(ItemDamageColorProperty); }
            set { SetValue(ItemDamageColorProperty, value); }
        }

        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(ImageSource), typeof(DamageItemView),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, new PropertyChangedCallback(SourceProperty_PropertyChanged)));

        public static readonly DependencyProperty IsDamagedProperty = DependencyProperty.Register("IsDamaged", typeof(bool), typeof(DamageItemView));
        public static readonly DependencyProperty ItemDamageColorProperty = DependencyProperty.Register("ItemDamageColor", typeof(Color), typeof(DamageItemView));

        public DamageItemView()
        {
            InitializeComponent();
        }
    }
}
