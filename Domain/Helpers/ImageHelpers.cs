using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Controls;

namespace ADO.NET_Task9.Domain.Helpers
{
    public class ImageHelpers
    {
        public static ImageSource StringToImageSource(string source)
        {
            var fullFilePath = source;

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.RelativeOrAbsolute);
            bitmap.EndInit();

            return bitmap;
            try
            {
                if (!source.Contains("https://"))
                    source = "https://" + source;

                var imgUrl = new Uri(source);
                var imageData = new WebClient().DownloadData(imgUrl);
                return ByteImageConverter.ByteToImage(imageData);
            }
            catch (Exception)
            {
                return null;
            }

        }
    }

    public class ByteImageConverter
    {
        public static ImageSource ByteToImage(byte[] imageData)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }
    }
}
