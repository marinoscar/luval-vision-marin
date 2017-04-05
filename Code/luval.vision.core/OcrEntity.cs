using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace luval.vision.core
{
    public class OcrEntity
    {
        public string Text { get; set; }
        public DataType Type { get; set; }
        [JsonIgnore]
        public OcrElement Element { get; set; }

    }
}
