using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.entity
{
    public class BlobUploadModel
    {
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public long FileSizeInBytes { get; set; }
        public long FileSizeInKb { get { return (long)Math.Ceiling((double)FileSizeInBytes / 1024); } }
    }
}
