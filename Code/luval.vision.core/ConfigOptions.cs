using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace luval.vision.core
{
    public class ConfigOptions
    {
        public ConfigOptions()
        {
            Fields = new List<FieldOption>();
        }
        public List<FieldOption> Fields { get; set; }
    }
}
