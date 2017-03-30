using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.entity
{
    public class OcrWord : OcrElement
    {
        public OcrLine ParentLine { get; set; }
        public DataType DataType { get; set; }

        public T GetValue<T>()
        {
            if (string.IsNullOrWhiteSpace(Text)) return default(T);
            return default(T);
        }
    }
}
