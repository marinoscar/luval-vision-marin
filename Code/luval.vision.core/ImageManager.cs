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
                    foreach (var line in region.Words)
                    {
                        var wordLoc = line.Location;
                        graphic.DrawRectangle(redPen, wordLoc.X, wordLoc.Y, wordLoc.Width, wordLoc.Height);

                        //foreach (var word in line.Words)
                        //{
                        //    var wordLoc = word.Location;
                        //    graphic.DrawRectangle(redPen, wordLoc.X, wordLoc.Y, wordLoc.Width, wordLoc.Height);
                        //}
                    }
                }
            }
            return bmp;
        }

        public Image DrawRegion(OcrRegion region, OcrLocation ocrLocation)
        {
            var bmp = new Bitmap(Source);
            var bluePen = new Pen(Color.Blue, 3);
            var greenPen = new Pen(Color.Green, 4);
            using (var graphic = Graphics.FromImage(bmp))
            {
                graphic.DrawRectangle(bluePen, region.Location.X, region.Location.Y, region.Location.Width, region.Location.Height);
                graphic.DrawRectangle(greenPen, ocrLocation.X, ocrLocation.Y, ocrLocation.Width, ocrLocation.Height);
            }
            return bmp;
        }
    }
}
