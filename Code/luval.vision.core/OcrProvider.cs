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


        public OcrProvider(IOcrEngine engine, IVisionResultParser loader)
        {
            Engine = engine;
            Loader = loader;
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
            imgInfo.WorkingHeight = result.Words.Max(i => i.Location.YBound) - result.Words.Min(i => i.Location.Y);
            imgInfo.WorkingHeight = result.Words.Max(i => i.Location.XBound) - result.Words.Min(i => i.Location.X);
            return result;
        }

        private byte[] GetImageBytes(string fileName)
        {
            return File.ReadAllBytes(fileName);
        }
    }
}
