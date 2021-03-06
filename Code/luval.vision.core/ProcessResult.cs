﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class ProcessResult
    {
        public ProcessResult()
        {
            Id = Guid.NewGuid().ToString().Replace("-", "").ToLowerInvariant();
            UtcTimestamp = DateTime.UtcNow;
        }
        public string Id { get; set; }
        public string UserId { get; set; }
        public OcrResult OcrResult { get; set; }
        public NlpResult NlpResult { get; set; }
        public List<MappingResult> TextResults { get; set; }
        public DateTime UtcTimestamp { get; set; }
        public double DurationInMs { get; set; }

    }
}
