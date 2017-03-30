using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.entity
{
    public class Extractor
    {
        public Extractor(Language lang)
        {
            Language = lang;
        }

        public Language Language { get; private set; }

        public void Process()
        {

        }
    }
}
