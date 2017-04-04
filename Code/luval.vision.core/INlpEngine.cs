using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public interface INlpEngine
    {
        IRestResponse ProcessText(string text);
    }
}
