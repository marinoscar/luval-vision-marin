using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
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

        public OcrProvider(IOcrEngine engine, IVisionResultParser loader)
        {
            Engine = engine;
            Loader = loader;
        }

        public IOcrEngine Engine { get; private set; }
        public IVisionResultParser Loader { get; private set; }

        public OcrResult DoOcr(string fileName)
        {
            var response = Engine.Execute(fileName, null);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new InvalidOperationException("Unable to process request");
            var result = Loader.DoParse(response.Content);
            result.HorizontalLines.AddRange(GetLines(result));
            return result;
        }

        public IEnumerable<LineItem> GetLines(OcrResult item)
        {
            var result = new List<OcrArea>();
            var id = 1;
            var regionId = 1;
            foreach (var region in item.Regions)
            {
                foreach (var line in region.Lines)
                {
                    var box = line.Location;
                    var words = line.Words;
                    result.Add(new OcrArea()
                    {
                        Id = id,
                        RegionId = regionId,
                        X = box.X,
                        Y = box.Y,
                        Height = box.Height,
                        Width = box.Width,
                        Words = words.Select(i => i.Text).ToArray() 
                    });
                    id++;
                }
                regionId++;
            }
            return AlignLines(result);
        }

        private IEnumerable<LineItem> AlignLines(IEnumerable<OcrArea> items)
        {
            var resultLineItems = new List<LineItem>();
            var offset = (int)(items.Max(i => i.Height) * 0.05); //Lines within 5% of the selected Y axis
            var lineNo = 1;
            var iterator = items.OrderBy(i => i.Y).ToList();
            while (iterator.Count > 0)
            {
                var item = iterator.First();
                var min = item.Y - offset;
                var max = item.Y + offset;
                var similar = iterator.Where(i => i.Id != item.Id && (i.Y >= min && i.Y < max)).ToList();
                if (similar.Count > 0)
                {
                    var tmp = new List<OcrArea>(similar) { item };
                    tmp.ForEach(i => iterator.Remove(i));
                    resultLineItems.Add(new LineItem()
                    {
                        LineNumber = lineNo,
                        Areas = tmp.OrderBy(i => i.X).ToList() //order from left to right
                    });
                }
                else
                {
                    iterator.Remove(item);
                    resultLineItems.Add(new LineItem()
                    {
                        LineNumber = lineNo,
                        Areas = new[] { item } //order from left to right
                    });
                }
                lineNo++;
            }
            return resultLineItems;
        }
    }
}
