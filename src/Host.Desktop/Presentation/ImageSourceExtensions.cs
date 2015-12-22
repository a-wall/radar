using System;
using System.IO;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Host.Desktop.Presentation
{
    public static class ImageSourceExtensions
    {
        public static ImageSource ToImageSource(this string source)
        {
            var bytes = Convert.FromBase64String(source);
            using (var memoryStream = new MemoryStream(bytes))
            {
                var decoder = new PngBitmapDecoder(memoryStream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                return decoder.Frames.FirstOrDefault();
            }
        }

        public static string ToBase64String(this BitmapSource source)
        {
            using (var memoryStream = new MemoryStream())
            {
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(source));
                encoder.Save(memoryStream);
                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }
    }
}
