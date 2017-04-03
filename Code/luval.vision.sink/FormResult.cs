using luval.vision.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.sink
{
    public class FormResult
    {
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public ProcessResult Result { get; set; }
    }
}
