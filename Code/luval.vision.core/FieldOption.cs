using luval.vision.core.extractors;
using System;
using System.Collections.Generic;
using System.Text;

namespace luval.vision.core
{
    public class FieldOption
    {
        private static Cache<string, IOcrLineResolver> _cache = new Cache<string, IOcrLineResolver>();

        /// <summary>
        /// Indentify the name of the filed
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// Field anchor options
        /// </summary>
        public FieldAnchor FieldAnchor { get; set; }

        /// <summary>
        /// Extractor to get the value from the text
        /// </summary>
        public FieldExtractor FieldExtractor { get; set; }

        /// <summary>
        /// Provides a location relative to the document size
        /// </summary>
        public OcrRelativeSearchLocation SearchArea { get; set; }

        /// <summary>
        /// The full qualified name of a class that implements the <see cref="IOcrLineResolver"/> interface
        /// </summary>
        [Obsolete]
        public string LineResolverQualifiedName { get; set; }

        /// <summary>
        /// Provides information to create a line resolver for the extraction or the default resolver will be used
        /// </summary>
        public FieldLineResolver LineResolver { get; set; }

        public IOcrLineResolver GetLineResolver()
        {
            if(LineResolver != null && !string.IsNullOrWhiteSpace(LineResolver.LineResolverQualifiedName))
            {
                return _cache.Get(LineResolver.LineResolverQualifiedName, () =>
                {
                    return ObjectFactory.Create<IOcrLineResolver>(LineResolver.LineResolverQualifiedName);
                });
            }

            if (string.IsNullOrWhiteSpace(LineResolverQualifiedName)) return new TraditionalOcrLineResolver();
            return _cache.Get(LineResolverQualifiedName, () =>
            {
                return ObjectFactory.Create<IOcrLineResolver>(LineResolverQualifiedName);
            });
        }

        public IDictionary<string, string> GetLinerResolverOptions()
        {
            if (LineResolver == null) return null;
            return LineResolver.Options;
        }

        public OcrLocation GetAreaSearch(OcrLocation workingArea)
        {
            if (SearchArea == null) return workingArea;
            return FromRelative(workingArea, SearchArea.X, SearchArea.XBound, SearchArea.Y, SearchArea.YBound);
        }

        private static OcrLocation FromRelative(OcrLocation workingArea, double x, double xbound, double y, double ybound)
        {
            if (x >= xbound) throw new ArgumentOutOfRangeException("X cannot be greater or equal than XBound");
            if (y >= ybound) throw new ArgumentOutOfRangeException("Y cannot be greater or equal than YBound");
            return new OcrLocation()
            {
                X = (int)(workingArea.Width * x),
                Width = (int)((workingArea.Width * xbound) - (workingArea.Width * x)),
                Y = (int)(workingArea.Height * y),
                Height = (int)((workingArea.Height * ybound) - (workingArea.Height * y)),
            };
        }
    }
}
