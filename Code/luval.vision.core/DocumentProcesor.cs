using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class DocumentProcesor
    {

        public DocumentProcesor(OcrProvider ocr)
        {
            OcrProvider = ocr;
        }

        public OcrProvider OcrProvider { get; private set; }


        public ProcessResult DoProcess(string fileName, IEnumerable<AttributeMapping> mappings)
        {
            return DoProcess(File.ReadAllBytes(fileName), fileName, mappings);
        }

        public ProcessResult DoProcess(byte[] data, string fileName, IEnumerable<AttributeMapping> mappings)
        {
            var startedOn = DateTime.UtcNow;
            var ocr = OcrProvider.DoOcr(data, fileName);
            return DoProcess(data, fileName, mappings, ocr, startedOn);
        }

        public ProcessResult DoProcess(byte[] data, string fileName, IEnumerable<AttributeMapping> mappings, OcrResult ocr)
        {
            var startedOn = DateTime.UtcNow;
            return DoProcess(data, fileName, mappings, ocr, startedOn);
        }

        private ProcessResult DoProcess(byte[] data, string fileName, IEnumerable<AttributeMapping> mappings, OcrResult ocr, DateTime startedOn)
        {
            var navigator = new Navigator(ocr.Info, ocr, mappings);
            var attributes = navigator.ExtractAttributes();
            return new ProcessResult()
            {
                OcrResult = ocr,
                TextResults = attributes,
                DurationInMs = DateTime.UtcNow.Subtract(startedOn).TotalMilliseconds
            };
        }
    }
}
