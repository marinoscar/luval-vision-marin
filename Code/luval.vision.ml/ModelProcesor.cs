using luval.vision.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.ml
{
    public class ModelProcesor
    {
        public ModelProcesor(IModelProvider provider)
        {
            Provider = provider;
        }

        public IModelProvider Provider { get; private set; }

        public IEnumerable<MappingResult> GetScoredResults(IEnumerable<MappingResult> toScore)
        {

            return null;
        }
    }
}
