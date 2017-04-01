using luval.vision.core.resolvers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace luval.vision.core
{
    public class OcrProvider
    {

        private IStringResolver _dateResolver;
        private IStringResolver _codeResolver;
        private IStringResolver _numberResolver;
        private IStringResolver _amountResolver;


        public OcrProvider(IOcrEngine engine, IVisionResultParser loader)
        {
            Engine = engine;
            Loader = loader;
            var res = new StringResolverManager();
            _dateResolver = res.Get<DateResolver>();
            _codeResolver = res.Get<CodeResolver>();
            _numberResolver = res.Get<NumberResolver>();
            _amountResolver = res.Get<AmountResolver>();
        }

        public IOcrEngine Engine { get; private set; }
        public IVisionResultParser Loader { get; private set; }

        public OcrResult DoOcr(string fileName)
        {
            var bytes = GetImageBytes(fileName);
            return DoOcr(bytes, fileName);
        }

        public OcrResult DoOcr(byte[] bytes, string fileName)
        {
            var stream = new MemoryStream(bytes);
            var img = Image.FromStream(stream);
            var imgInfo = ImageInfo.Load(img, fileName);
            var response = Engine.Execute(fileName, bytes);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new InvalidOperationException("Unable to process request");
            var result = Loader.DoParse(response.Content, imgInfo);
            result.HorizontalLines = Navigator.GetWordsHorizontallyAligned(result.Words, 0.025f).ToList();
            result.HorizontalLines.ForEach(i => i.Location.RelativeLocation = OcrRelativeLocation.Load(i.Location, result.Info));
            result.Lines.ForEach(ExtractEntitiesFromLine);
            result.Entities = result.Lines.SelectMany(i => i.Entities).ToList();
            return result;
        }

        private byte[] GetImageBytes(string fileName)
        {
            return File.ReadAllBytes(fileName);
        }

        private void ExtractEntitiesFromLine(OcrLine line)
        {
            var codes = _codeResolver.GetValues(line.Text).Select(i => new OcrEntity() { Type = DataType.Code, Text = i.Text, Element = line }).ToList();
            var dates = _dateResolver.GetValues(line.Text).Select(i => new OcrEntity() { Type = DataType.Date, Text = i.Text, Element = line }).ToList();
            var nums= _numberResolver.GetValues(line.Text).Select(i => new OcrEntity() { Type = DataType.Number, Text = i.Text, Element = line }).ToList();
            var amounts = _amountResolver.GetValues(line.Text).Select(i => new OcrEntity() { Type = DataType.Amount, Text = i.Text, Element = line }).ToList();
            line.Entities.AddRange(codes);
            line.Entities.AddRange(dates);
            line.Entities.AddRange(nums);
            line.Entities.AddRange(amounts);
        }
    }
}
