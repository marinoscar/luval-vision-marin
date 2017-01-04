﻿using Newtonsoft.Json.Linq;
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
            var redPen = new Pen(Color.Red, 1);
            var bluePen = new Pen(Color.Blue, 3);
            using (var graphic = Graphics.FromImage(bmp))
            {
                foreach(var region in ocr.Regions)
                {
                    var regNum = region.Value<string>("boundingBox").Split(",".ToCharArray()).Select(i => Convert.ToInt32(i)).ToArray();
                    graphic.DrawRectangle(bluePen, regNum[0], regNum[1], regNum[2], regNum[3]);
                    foreach (var line in region.Value<JArray>("lines"))
                    {
                        var linNum = line.Value<string>("boundingBox").Split(",".ToCharArray()).Select(i => Convert.ToInt32(i)).ToArray();
                        graphic.DrawRectangle(redPen, linNum[0], linNum[1], linNum[2], linNum[3]);
                    }
                }
            }
            return bmp;
        }
    }
}