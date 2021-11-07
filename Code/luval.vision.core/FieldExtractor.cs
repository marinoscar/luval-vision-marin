using System;
using System.Collections.Generic;
using System.Text;
using luval.vision.core.extractors;

namespace luval.vision.core
{
    public class FieldExtractor
    {
        public FieldExtractor()
        {
            ExtractorOptions = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets the name for known extractors or the fully qualified name of the extractor class to use that implementes the <see cref="IFieldExtractor"/> interface
        /// </summary>
        public string ExtractorName { get; set; }

        /// <summary>
        /// Provides the options for the extractor
        /// </summary>
        public Dictionary<string, string> ExtractorOptions { get; set; }

        /// <summary>
        /// Direction where the value is expected to be found in relation to the anchor element
        /// </summary>
        public Direction Direction { get; set; }
        /// <summary>
        /// In case that more than one value is found, the last one available will be returned as value
        /// </summary>
        public bool UseLast { get; set; }
        /// <summary>
        /// Indicates if the value would be looked for line by line, or using the entire text available in the provided search relative area
        /// </summary>
        public bool UseAllArea { get; set; }

        /// <summary>
        /// Provides the a post processing custom code for the field
        /// </summary>
        public FieldExtractorPostProcessing PostProcessing { get; set; }

        public IFieldExtractor Create()
        {
            return FieldExtractorFactory.Create(ExtractorName);
        }
    }
}
