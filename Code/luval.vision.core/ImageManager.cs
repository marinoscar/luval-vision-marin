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
                foreach(var region in ocr.JsonResult)
                {
                    var regNum = region.Value<string>("boundingBox").Split(",".ToCharArray()).Select(i => Convert.ToInt32(i)).ToArray();
                    graphic.DrawRectangle(bluePen, regNum[0], regNum[1], regNum[2], regNum[3]);
                    foreach (var line in region.Value<JArray>("lines"))
                    {
                        var linNum = line.Value<string>("boundingBox").Split(",".ToCharArray()).Select(i => Convert.ToInt32(i)).ToArray();
                        graphic.DrawRectangle(redPen, linNum[0], linNum[1], linNum[2], linNum[3]);
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
