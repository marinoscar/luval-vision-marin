using System;
using System.Collections.Generic;
using System.Text;

namespace luval.vision.core
{
    public interface IFieldExtractorPostProcessing
    {
        string ProcessValue(string text, IDictionary<string, string> options);
    }
}
