using luval.vision.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.ml
{
    public interface IModelProvider
    {
        List<ModelResult> Execute(List<Dictionary<string, object>> elements);
    }
}
