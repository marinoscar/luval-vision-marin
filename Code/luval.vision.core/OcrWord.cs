using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class OcrWord
    {
        public OcrLine ParentLine { get; set; }
        public OcrLocation Location { get; set; }
        public string Text { get; set; }
        public DataType DataType { get; set; }

        public T GetValue<T>()
        {
            if (string.IsNullOrWhiteSpace(Text)) return default(T);
            return default(T);
        }
    }
}
