﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.entity
{
    public class BlobDownloadModel
    {
        public MemoryStream BlobStream { get; set; }
        public string BlobFileName { get; set; }
        public string BlobContentType { get; set; }
        public long BlobLength { get; set; }
    }
}
