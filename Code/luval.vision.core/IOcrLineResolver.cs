using System;
using System.Collections.Generic;
using System.Text;

namespace luval.vision.core
{
    public interface IOcrLineResolver
    {
        IEnumerable<OcrLine> GetLines(IEnumerable<OcrWord> words);
    }
}
