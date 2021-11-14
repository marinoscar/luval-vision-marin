using luval.vision.core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.app
{
    [Serializable]
    public class ExternalCallAndOptions : ISerializable
    {

        public ExternalCallAndOptions()
        {
            Options = new List<ExternalDataOptions>();
        }

        public string Name { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<ExternalDataOptions> Options { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        public FieldExtractorPostProcessing ToPostProcessing()
        {
            return new FieldExtractorPostProcessing()
            {
                PostProcessingName = Name,
                Options = OptionsToDic()
            };
        }

        public IDictionary<string, string> OptionsToIDic()
        {
            return OptionsToIDic();
        }

        public Dictionary<string, string> OptionsToDic()
        {
            var res = new Dictionary<string, string>();
            foreach (var item in Options)
            {
                if (item == null || string.IsNullOrWhiteSpace(item.Name)) continue;
                res[item.Name] = item.Value;
            }
            return res;
        }
    }
}
