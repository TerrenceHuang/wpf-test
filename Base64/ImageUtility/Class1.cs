using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ImageUtility {

    public class Class1 {

        public static string imageToBase64String(MemoryStream memoryStream) {

            byte[] byteImage = memoryStream.ToArray();

            return Convert.ToBase64String(byteImage);
        }

        public static string imageToBase64String(byte[] byteImage) {

            return Convert.ToBase64String(byteImage);
        }

        public static BitmapImage loadImage(string path) {

            byte[] buffer = File.ReadAllBytes(path);
            MemoryStream memoryStream = new MemoryStream(buffer);

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = memoryStream;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
            bitmapImage.Freeze();

            return bitmapImage;
        }
    }
}
