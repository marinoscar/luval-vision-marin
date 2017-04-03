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
            var startedOn = DateTime.UtcNow;
            var imgBytes = Pdf2Img.CheckForPdfAndConvert(data, fileName);
            var ocr = OcrProvider.DoOcr(imgBytes, fileName);
            var nlp = NlpProvider.DoNlp(GetTextToAnalyze(ocr, mappings));
            return DoProcess(data, fileName, mappings, ocr, nlp, startedOn);
        }

        public ProcessResult DoProcess(byte[] data, string fileName, IEnumerable<AttributeMapping> mappings, OcrResult ocr, NlpResult nlp)
        {
            var startedOn = DateTime.UtcNow;
            return DoProcess(data, fileName, mappings, ocr, nlp, startedOn);
        }

        private ProcessResult DoProcess(byte[] data, string fileName, IEnumerable<AttributeMapping> mappings, OcrResult ocr, NlpResult nlp, DateTime startedOn)
        {
            var navigator = new Navigator(ocr.Info, ocr.Lines, mappings);
            var attributes = navigator.ExtractAttributes();
            DoExtraValidations(attributes, ocr);
            return new ProcessResult()
            {
                NlpResult = nlp,
                OcrResult = ocr,
                TextResults = attributes,
                DurationInMs = DateTime.UtcNow.Subtract(startedOn).TotalMilliseconds
            };
        }

        private void DoExtraValidations(List<MappingResult> mappingResult, OcrResult ocrResult)
        {
            DoExtractions<double?>(mappingResult, ocrResult, "Total", new TotalExtractor(ocrResult.Lines));
            DoExtractions<DateTime?>(mappingResult, ocrResult, "Date", new DateExtractor(ocrResult.Lines));
        }

        private void DoExtractions<T>(List<MappingResult> mappingResult, OcrResult ocrResult, string attName, IExtractor<T> extractor)
        {
            if (mappingResult.Any(i => i.Map.AttributeName == attName)) return;
            var val = extractor.Extract();
            if (val == null) return;
            mappingResult.Add(new MappingResult()
            {
                AnchorElement = null,
                Location = val.Element.Location,
                ResultElement = val.Element,
                RelativeLocation = val.Element.Location.RelativeLocation,
                Value = Convert.ToString(val.Value),
                Map = new AttributeMapping() { AttributeName = attName }
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
