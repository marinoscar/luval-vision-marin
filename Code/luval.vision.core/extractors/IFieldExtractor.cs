using System;
using System.Collections.Generic;
using System.Text;

namespace luval.vision.core.extractors
{
    public interface IFieldExtractor
    {
        IEnumerable<string> GetValue(string text, IDictionary<string, string> options);
    }
}
