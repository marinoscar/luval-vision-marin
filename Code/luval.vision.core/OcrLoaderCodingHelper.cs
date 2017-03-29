using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class OcrLoaderHelper
    {
        public static string GetRegionCode(int id)
        {
            return id.ToString().PadLeft(3, '0');
        }

        public static string GetLineCode(int id, OcrElement region)
        {
            return string.Format("{0}.{1}", region.Code, id.ToString().PadLeft(4, '0'));
        }

        public static string GetWordCode(int id, OcrElement line)
        {
            return string.Format("{0}.{1}", line.Code, id.ToString().PadLeft(5, '0'));
        }
    }
}
