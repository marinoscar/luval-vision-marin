using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class ProcessResult
    {
        public OcrResult OcrResult { get; set; }
        public NlpResult NlpResult { get; set; }
        public List<MappingResult> TextResults { get; set; }

    }
}
