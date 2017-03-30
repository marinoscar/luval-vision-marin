using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.bll
{
    public class Constants
    {
        public static readonly HashSet<string> validExtensions = new HashSet<string>()
        {
            "png",
            "jpg",
            "bmp"
        };

        public static bool IsImageExtension(string ext)
        {
            return validExtensions.Contains(ext);
        }
    }
}
