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
        public Image Process(OcrResult ocr, Image img)
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
                        //foreach(var word in line.Value<JArray>("words"))
                        //{
                        //    var wordNum = word.Value<string>("boundingBox").Split(",".ToCharArray()).Select(i => Convert.ToInt32(i)).ToArray();
                        //    graphic.DrawRectangle(greenPen, wordNum[0], wordNum[1], wordNum[2], wordNum[3]);
                        //}
                    }
                }
            }
            return bmp;
        }

        public Image ProcessLines(IEnumerable<LineItem> lines, Image img)
        {
            var bmp = new Bitmap(img);
            var grayPen = new Pen(Color.DarkGreen, 1);
            using (var graphic = Graphics.FromImage(bmp))
            {
                foreach(var line in lines)
                {
                    var y = line.GetY();
                    graphic.DrawLine(grayPen, new Point(0, y), new Point(img.Width, y));
                }
            }
            return bmp;
        }
    }
}
