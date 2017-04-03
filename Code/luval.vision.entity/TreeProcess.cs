using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using luval.vision.entity;
using System.Runtime.Serialization;
using luval.vision.core;

namespace luval.vision.entity
{
    [DataContract]
    public class TreeProcess
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public OcrResult OcrResult { get; set; }
        [DataMember]
        public NlpResult NlpResult { get; set; }
        [DataMember]
        public List<MappingResult> TextResults { get; set; }
        [DataMember]
        public DateTime UtcTimestamp { get; set; }
        [DataMember]
        public double DurationInMs { get; set; }
    }
}
