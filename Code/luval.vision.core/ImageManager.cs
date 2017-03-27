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
        public Image ProcessOcrResult(OcrResult ocr, Image img)
        {
            var bmp = new Bitmap(img);
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
                        var linNum = line.Location;
                        graphic.DrawRectangle(redPen, linNum.X, linNum.Y, linNum.Width, linNum.Height);
                    }
                }
            }
            return bmp;
        }
    }
}
