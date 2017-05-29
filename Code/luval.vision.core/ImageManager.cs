using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class ImageManager
    {
        public ImageManager(Image source)
        {
            Source = source;
        }

        public Image Source { get; private set; }

        public Image ProcessOcrResult(OcrResult ocr)
        {
            var bmp = new Bitmap(Source);
            var redPen = new Pen(Color.Red, 2);
            var bluePen = new Pen(Color.Blue, 3);
            var greenPen = new Pen(Color.Green, 1);
            using (var graphic = Graphics.FromImage(bmp))
            {
                foreach (var region in ocr.Regions)
                {
                    var regNum = region.Location;
                    graphic.DrawRectangle(bluePen, regNum.X, regNum.Y, regNum.Width, regNum.Height);
                    foreach (var line in region.Lines)
                    {
                        var linNum = line.Location;
                        graphic.DrawRectangle(redPen, linNum.X, linNum.Y, linNum.Width, linNum.Height);
                    }
                }
            }
            return bmp;
        }

        public Image ProcessParseResult(List<MappingResult> results)
        {
            var bmp = new Bitmap(Source);
            var bluePen = new Pen(Color.Blue, 3);
            using (var graphic = Graphics.FromImage(bmp))
            {
                foreach (var map in results)
                {
                    graphic.DrawRectangle(bluePen, new Rectangle(map.Location.X, map.Location.Y, map.Location.Width, map.Location.Height));
                }
            }
            return bmp;
        }

        public static Image ProcessElements(Image source, IEnumerable<OcrElement> elements, Pen pen)
        {
            return ProcessElements(source, elements.Select(i => i.Location), pen);
        }

        public static Image ProcessElements(Image source, IEnumerable<OcrLocation> locations, Pen pen)
        {
            var bmp = new Bitmap(source);
            using (var graphic = Graphics.FromImage(bmp))
            {
                foreach (var loc in locations)
                {
                    graphic.DrawRectangle(pen, new Rectangle(loc.X, loc.Y, loc.Width, loc.Height));
                }
            }
            return bmp;
        }

        public static Image ProcessElements(Image source, IEnumerable<OcrElement> elements, Color color)
        {
            return ProcessElements(source, elements, new Pen(color, 3));
        }

        public static Image ProcessElements(Image source, IEnumerable<OcrElement> elements)
        {
            return ProcessElements(source, elements, Color.Blue);
        }

        public static void ChangeFormat(string imageFile, string destinationDir, ImageFormat format)
        {
            ChangeFormat(imageFile, destinationDir, format, 0);

        }

        public static void ChangeFormat(string imageFile, string destinationDir, ImageFormat format, int maxWidth)
        {
            var desDir = new DirectoryInfo(destinationDir);
            var fileName = new FileInfo(imageFile);
            if (!fileName.Exists) return;
            try
            {
                var img = Image.FromFile(imageFile);
                if (maxWidth > 0) img = ScaleImage(img, maxWidth);
                img.Save(GetNewFileNameAfterConversion(fileName, desDir, format), format);
            }
            catch (Exception ex)
            {
                throw new LuvalException(string.Format("Unable to convert file {0}", fileName.FullName), ex);
            }

        }

        private static string GetNewFileNameAfterConversion(FileInfo file, DirectoryInfo desDir, ImageFormat format)
        {
            var ex = ".jpg";
            var fileName = file.Name.Replace(file.Extension, "");
            if (format == ImageFormat.Gif) ex = ".gif";
            if (format == ImageFormat.Png) ex = ".png";
            return string.Format(@"{0}\{1}", desDir.FullName, fileName + ex);
        }

        public static Image ScaleImage(Image image, int maxWidth)
        {
            var adjustedHeight = (double)maxWidth * (double)image.Height / (double)image.Width;
            return ScaleImage(image, maxWidth, (int)adjustedHeight);
        }

        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }
    }
}
