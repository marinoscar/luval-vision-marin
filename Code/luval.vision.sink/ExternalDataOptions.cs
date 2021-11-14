using System;
using System.Runtime.Serialization;

namespace luval.vision.app
{
    [Serializable]
    public class ExternalDataOptions : ISerializable
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
