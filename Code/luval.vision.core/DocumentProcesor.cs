using System;
using System.Collections.Generic;
using System.IO;
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


        public ProcessResult DoProcess(string fileName, IEnumerable<AttributeMapping> mappings)
        {
            return DoProcess(File.ReadAllBytes(fileName), fileName, mappings);
        }

        public ProcessResult DoProcess(byte[] data, string fileName, IEnumerable<AttributeMapping> mappings)
        {
            var ocr = OcrProvider.DoOcr(data, fileName);
            var nlp = NlpProvider.DoNlp(GetTextToAnalyze(ocr));
            var navigator = new Navigator(ocr.Info, ocr.Lines, mappings);
            var attributes = navigator.ExtractAttributes();
            return new ProcessResult()
            {
                NlpResult = nlp, OcrResult = ocr, TextResults = attributes
            };
        }

        private string GetTextToAnalyze(OcrResult ocr)
        {
            var sb = new StringBuilder();
            ocr.HorizontalLines.Where(i => i.Location.RelativeLocation.IsTopHalf)
                .Select(i => i.Text).ToList().ForEach(i => sb.AppendLine(i));
            return sb.ToString();
        }
    }
}
