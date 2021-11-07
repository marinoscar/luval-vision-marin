using System;
using System.Collections.Generic;
using System.Text;

namespace luval.vision.core
{
    public class  FieldExtractorPostProcessing
    {
        private static Cache<string, IFieldExtractorPostProcessing> _cache = new Cache<string, IFieldExtractorPostProcessing>();

        public FieldExtractorPostProcessing()
        {
            Options = new Dictionary<string, string>();
        }
        /// <summary>
        /// Indicates the name of a custom post processing code that will recieve the extraction results and will post process them
        /// </summary>
        public string PostProcessingName { get; set; }
        /// <summary>
        /// Provides options for the post processing code to succesfully change the values
        /// </summary>
        public Dictionary<string, string> Options { get; set; }

        public IFieldExtractorPostProcessing Create()
        {
            return _cache.Get(PostProcessingName, () => {
                return ObjectFactory.Create<IFieldExtractorPostProcessing>(PostProcessingName);
            });
        }
    }
}
