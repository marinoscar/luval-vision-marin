using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using luval.vision.entity;

namespace luval.vision.bll
{
    public interface IVisionResultParser
    {
        OcrResult DoParse(string jsonResult, ImageInfo info);
    }
}
