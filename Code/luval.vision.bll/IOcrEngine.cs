using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace luval.vision.bll
{
    public interface IOcrEngine
    {
        IRestResponse Execute(string name, byte[] image);
    }
}
