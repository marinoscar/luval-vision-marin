using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class NlpProvider
    {
        public NlpProvider(INlpEngine engine, INlpLoader loader)
        {
            Engine = engine;
            Loader = loader;
        }

        public INlpEngine Engine { get; private set; }
        public INlpLoader Loader { get; private set; }

        public NlpResult DoNlp(string text)
        {
            var request = Engine.ProcessText(text);
            if (request.StatusCode != HttpStatusCode.OK) throw new InvalidOperationException("Unable to process request");
            var result = Loader.Load(request.Content);
            return result;
        }
    }
}
