using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core.extractors
{
    public interface IExtractor<T>
    {
        ExtractResult<T> Extract();
    }
}
