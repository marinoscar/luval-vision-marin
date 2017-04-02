using luval.vision.core.extractors;
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
            var imgBytes = Pdf2Img.CheckForPdfAndConvert(data, fileName);
            var ocr = OcrProvider.DoOcr(imgBytes, fileName);
            var nlp = NlpProvider.DoNlp(GetTextToAnalyze(ocr, mappings));
            var navigator = new Navigator(ocr.Info, ocr.Lines, mappings);
            var attributes = navigator.ExtractAttributes();
            ValidateTotal(attributes, ocr);
            return new ProcessResult()
            {
                NlpResult = nlp,
                OcrResult = ocr,
                TextResults = attributes
            };
        }

        private void ValidateTotal(List<MappingResult> mappingResult, OcrResult ocrResult)
        {
            if (mappingResult.Any(i => i.Map.AttributeName == "Total")) return;
            var totalExtractor = new TotalExtractor(ocrResult.Lines);
            var val = totalExtractor.Extract();
            if (val == null) return;
            mappingResult.Add(new MappingResult()
            {
                AnchorElement = null,
                Location = val.Element.Location,
                ResultElement = val.Element,
                RelativeLocation = val.Element.Location.RelativeLocation,
                Map = new AttributeMapping() { AttributeName = "Total" }
            });
        }

        private string GetTextToAnalyze(OcrResult ocr, IEnumerable<AttributeMapping> mappings)
        {
            var lines = ocr.Lines.Where(i => i.Location.RelativeLocation.HorizontalQuadrant == 1).ToList();
            foreach (var line in lines)
            {
                var wordsToRemove = line.Words.Where(i => i.DataType != DataType.Word && i.DataType != DataType.None).ToList();
                foreach (var map in mappings)
                {
                    foreach (var reg in map.AnchorPatterns)
                    {
                        wordsToRemove.AddRange(line.Words.Where(i => Regex.IsMatch(i.Text, reg)).ToList());
                    }
                }
                foreach (var word in wordsToRemove.Distinct())
                {
                    line.Words.Remove(word);
                }
            }
            var sb = new StringBuilder();
            lines.ForEach(i => sb.AppendLine(i.Text));
            return sb.ToString();
        }
    }
}
