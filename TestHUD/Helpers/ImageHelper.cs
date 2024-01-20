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
