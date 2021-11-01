using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
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
                foreach(var region in ocr.Regions)
                {
                    var regNum = region.Location;
                    graphic.DrawRectangle(bluePen, regNum.X, regNum.Y, regNum.Width, regNum.Height);
                    foreach (var line in region.Lines)
                    {
                        foreach(var word in line.Words)
                        {
                            var wordLoc = word.Location;
                            graphic.DrawRectangle(redPen, wordLoc.X, wordLoc.Y, wordLoc.Width, wordLoc.Height);
                        }
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
                foreach(var map in results.Where(i => i.Location != null))
                {
                    graphic.DrawRectangle(bluePen, new Rectangle(map.Location.X, map.Location.Y, map.Location.Width, map.Location.Height));
                }
            }
            return bmp;
        }
    }
}
