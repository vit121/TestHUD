using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(ImageSource), typeof(DamageItemView));

        public static readonly DependencyProperty IsDamagedProperty = DependencyProperty.Register("IsDamaged", typeof(bool), typeof(DamageItemView));
        public static readonly DependencyProperty ItemDamageColorProperty = DependencyProperty.Register("ItemDamageColor", typeof(Color), typeof(DamageItemView));

        public DamageItemView()
        {
            InitializeComponent();
        }
    }
}
