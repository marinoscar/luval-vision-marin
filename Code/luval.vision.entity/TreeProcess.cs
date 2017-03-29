using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using luval.vision.entity;
using System.Runtime.Serialization;

namespace luval.vision.entity
{
    [DataContract]
    public class TreeProcess
    {
        [DataMember]
        public string text { get; set; }
        [DataMember]
        public List<string[]> mappingResult { get; set; }
    }
}
