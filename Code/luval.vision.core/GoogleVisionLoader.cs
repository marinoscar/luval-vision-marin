using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class GoogleVisionLoader : IVisionResultParser
    {

        private const float HorizontalLineMargin = 0.025f;

        public OcrResult DoParse(string jsonResult, ImageInfo info)
        {
            var words = new List<OcrWord>();
            var json = JObject.Parse(jsonResult);
            var lang = default(string);
            var result = new OcrResult() { Info = info, TextAngle = 0 };
            var mainRegion = new OcrRegion()
            {
                Id = 1,
                Code = OcrLoaderHelper.GetRegionCode(1)
            };
            var responses = json["responses"].Value<JArray>();
            CheckForErrors(responses);
            var annotations = responses[0]["textAnnotations"].Value<JArray>();
            var wordId = 1;
            foreach (var ann in annotations)
            {
                if (string.IsNullOrWhiteSpace(lang)) lang = ann["locale"].Value<string>();
                if (wordId != 1)
                {
                    var word = new OcrWord()
                    {
                        Id = wordId,
                        Location = GetLocation(ann, info),
                        Text = ann["description"].Value<string>()
                    };
                    words.Add(word);
                }
                wordId++;
            }
            var lines = GetLines(words, mainRegion, info);
            mainRegion.Lines = lines;
            mainRegion.Location = new OcrLocation();
            mainRegion.Location.X = mainRegion.Lines.Min(i => i.Location.X);
            mainRegion.Location.Width = mainRegion.Lines.Max(i => i.Location.XBound) - mainRegion.Location.X;
            mainRegion.Location.Y = mainRegion.Lines.Min(i => i.Location.Y);
            mainRegion.Location.Height = mainRegion.Lines.Max(i => i.Location.YBound) - mainRegion.Location.Y;
            mainRegion.Location.RelativeLocation = OcrRelativeLocation.Load(mainRegion.Location, info);
            result.Regions.Add(mainRegion);
            result.Words = words;
            result.Lines = lines;
            return result;
        }

        private void CheckForErrors(JArray responses)
        {
            if(responses.Count > 0 && responses[0]["error"] != null)
            {
                var message = string.Format("Code: {0} - {1}", responses[0]["error"]["code"], responses[0]["error"]["message"]);
                throw new LuvalException(message);
            }
        }

        private List<OcrLine> GetLines(List<OcrWord> words, OcrRegion region, ImageInfo info)
        {
            var lineId = 1;
            var lines = new List<OcrLine>();
            var horLines = Navigator.GetWordsHorizontallyAligned(words, HorizontalLineMargin);
            foreach (var horLine in horLines)
            {
                horLine.ParentRegion = region;
                var newLines = ProcessLines(horLine, lineId);
                foreach (var line in newLines)
                {
                    line.ParentRegion = region;
                    line.Location.X = line.Words.Min(i => i.Location.X);
                    line.Location.Y = line.Words.Max(i => i.Location.Y);
                    line.Location.Height = line.Words.Max(i => i.Location.YBound) - line.Location.Y;
                    line.Location.Width = line.Words.Max(i => i.Location.XBound) - line.Location.X;
                    line.Location.RelativeLocation = OcrRelativeLocation.Load(line.Location, info);
                    line.Code = OcrLoaderHelper.GetLineCode(line.Id, region);
                    lines.Add(line);
                }
                lineId++;
            }
            return lines;
        }

        private List<OcrLine> ProcessLines(OcrLine line, int id)
        {
            var lineId = id;
            var lines = new List<OcrLine>();
            var words = new List<OcrWord>(line.Words.Where(i => !string.IsNullOrWhiteSpace(i.Text)));
            var currentLine = default(OcrLine);
            var currentWord = default(OcrWord);
            while (words.Count > 0)
            {
                if (currentLine == null)
                {
                    currentLine = GetNewLine(line.ParentRegion, lineId);
                    lines.Add(currentLine);
                }
                if(currentWord == null)
                {
                    currentWord = words[0];
                }
                words.Remove(currentWord);
                if(!currentLine.Words.Contains(currentWord)) currentLine.Words.Add(currentWord);
                if (words.Count <= 0)
                {
                    continue;
                }
                var nextWord = words[0];
                var spaceSize = (currentWord.Location.Width / currentWord.Text.Length) * 1.4;
                var distance = nextWord.Location.X - currentWord.Location.XBound;
                if (distance > spaceSize)
                {
                    lineId++;
                    currentLine = GetNewLine(line.ParentRegion, lineId);
                    currentLine.Words.Add(nextWord);
                    lines.Add(currentLine);
                }
                else
                {
                    currentLine.Words.Add(nextWord);
                }
                words.Remove(nextWord);
                currentWord = nextWord;
            }
            return lines;
        }

        private OcrLine GetNewLine(OcrRegion region, int id)
        {
            return new OcrLine()
            {
                ParentRegion = region,
                Id = id,
                Code = OcrLoaderHelper.GetLineCode(id, region)
            };
        }

        private OcrLocation GetLocation(JToken json, ImageInfo info)
        {
            var result = new OcrLocation();
            var boxVals = json["boundingPoly"]["vertices"].Value<JArray>();
            result.X = boxVals[0]["x"].Value<int>();
            result.Width = boxVals[1]["x"].Value<int>() - result.X;
            result.Y = boxVals[0]["y"].Value<int>();
            result.Height = boxVals[2]["y"].Value<int>() - result.Y;
            result.RelativeLocation = OcrRelativeLocation.Load(result, info);
            return result;
        }
    }
}
