using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.ml
{
    public class ModelResult
    {
        public Dictionary<string, double> AttributeScore { get; set; }
        public string ScoredAttribute { get; set; }
    }
}
