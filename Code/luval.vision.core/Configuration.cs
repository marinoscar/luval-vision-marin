using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace luval.vision.core
{
    public class Configuration
    {
        public Configuration()
        {
            Mappings = new List<AttributeMapping>();
        }
        public List<AttributeMapping> Mappings { get; set; }
    }
}
