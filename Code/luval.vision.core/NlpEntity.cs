using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class NlpEntity
    {
        public NlpEntity()
        {
            Metadata = new Dictionary<string, string>();
        }
        public string Name { get; set; }
        public EntityType Type { get; set; }
        public IDictionary<string, string> Metadata { get; set; }
        public float Score { get; set; }
    }
}
