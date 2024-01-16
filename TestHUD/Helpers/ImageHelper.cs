using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TestHUD.Helpers
{
    public class ImageHelper
    {
        public static ImageHelper Instance = new ImageHelper();

        public BitmapImage GetImage(string imageName)
        {
            return new BitmapImage(new Uri("../Images/" + imageName + ".png", UriKind.Relative));
        }
    }
}
