using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class NlpResult
    {
        public string Language { get; set; }
        public List<NlpEntity> Entities { get; set; }
    }
}
