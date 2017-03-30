using Ghostscript.NET.Rasterizer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.bll
{
    public class Pdf2Img
    {
        public static IEnumerable<Image> Convert(byte [] data)
        {
            var res = new List<Image>();
            using (var ras = new GhostscriptRasterizer())
            {
                using (var stream = new MemoryStream(data))
                {
                    ras.Open(stream);
                    for (int i = 0; i < ras.PageCount; i++)
                    {
                        var img = ras.GetPage(300, 300, i + 1);
                        res.Add(img);
                    }
                    stream.Close();
                }
                ras.Close();
            }
            return res;
        }

        public static IEnumerable<Image> Convert(string fileName)
        {
            return Convert(File.ReadAllBytes(fileName));
        }

        public static void ConvertToMultipleImages(string pdfFileName, string imageFileName)
        {
            var count = 1;
            var images = Convert(pdfFileName);
            foreach(var img in images)
            {
                var memStream = new MemoryStream();
                var fileInfo = new FileInfo(imageFileName);
                var fileName = string.Format(@"{0}\{1}-{2}.jpeg", fileInfo.Directory.FullName, fileInfo.Name.Replace(".jpeg", ""), count);
                img.Save(memStream, ImageFormat.Jpeg);
                File.WriteAllBytes(fileName, memStream.ToArray());
                count++;
            }
        }

        public static void ConverToSingleImage(string pdfFileName, string imageFileName)
        {
            var images = Convert(pdfFileName);
            var img = MergeImages(images);
            var memStream = new MemoryStream();
            img.Save(memStream, ImageFormat.Jpeg);
            File.WriteAllBytes(imageFileName, memStream.ToArray());
        }

        public static byte[] ConvertToImage(string pdfFileName)
        {
            var imgs = Convert(pdfFileName);
            var img = MergeImages(imgs);
            var stream = new MemoryStream();
            img.Save(stream, ImageFormat.Jpeg);
            return stream.ToArray();
        }

        private static Image MergeImages(IEnumerable<Image> images)
        {
            var width = images.Max(i => i.Width);
            var height = images.Sum(i => i.Height);
            var bitmap = new Bitmap(width, height);
            var y = 0;
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                foreach(var img in images)
                {
                    g.DrawImage(img, 0, y);
                    y += img.Height;
                }
            }
            return bitmap;
        }


    }
}
