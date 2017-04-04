using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core.extractors
{
    public class ExtractResult<T>
    {
        public OcrElement Element { get; set; }
        public string Text { get; set; }
        public T Value { get; set; }
    }
}
