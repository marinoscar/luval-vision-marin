using luval.vision.core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luval.FormExtractor
{
    public class ExtractionPackage
    {

        public DataTable Table { get; set; }
        public OcrResult OcrResult { get; set; }
    }
}
