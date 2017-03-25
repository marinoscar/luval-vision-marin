using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public interface IOcrEngine
    {
        IRestResponse Execute(string name, byte[] image);
    }
}
