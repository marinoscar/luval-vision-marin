using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class ImageInfo
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Format { get; set; }
        public string Name { get; set; }
        public double HorizontalResolution { get; set; }
        public double VerticalResolution { get; set; }
        public int WorkingHeight { get; set; }
        public int WorkingWidth { get; set; }

        public static ImageInfo Load(Image img, string fileName)
        {
            var fileInfo = new FileInfo(fileName);
            return new ImageInfo()
            {
                Height = img.Height,
                Width = img.Width,
                HorizontalResolution = img.HorizontalResolution,
                VerticalResolution = img.VerticalResolution,
                Format = fileInfo.Extension.Replace(".", ""),
                Name = fileInfo.Name
            };
        }
    }
}
