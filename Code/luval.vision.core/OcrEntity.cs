using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class OcrEntity
    {
        public string Text { get; set; }
        public DataType Type { get; set; }
        public OcrElement Element { get; set; }

    }
}
