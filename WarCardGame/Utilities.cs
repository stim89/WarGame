using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
//this is how to get your card images
namespace WarCardGame
{
    static class Utilities
    {
        public static BitmapImage GetImage(string path)
        {
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);
            img.EndInit();
            return img;
        }
    }
}
