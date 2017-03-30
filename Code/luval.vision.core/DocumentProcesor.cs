using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class DocumentProcesor
    {

        public DocumentProcesor(OcrProvider ocr, NlpProvider nlp)
        {
            OcrProvider = ocr;
            NlpProvider = nlp;
        }

        public OcrProvider OcrProvider { get; private set; }
        public NlpProvider NlpProvider { get; private set; }

        public ProcessResult DoProcess(byte[] data, string fileName)
        {
        }
    }
}
