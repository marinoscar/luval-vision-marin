using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.ml
{
    public class ModelRequest
    {
        public string Name { get; set; }
        public Dictionary<string, object> Elements { get; set; }
    }
}
