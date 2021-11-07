using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace luval.vision.core.extractors
{
    public class FieldExtractorFactory
    {

        private static Cache<string, IFieldExtractor> _cache = new Cache<string, IFieldExtractor>();

        private static Type[] _knownTypes = new[] {
            typeof(DateExtractor) , typeof(EmailExtractor), typeof(PercentageExtractor),
            typeof(NumberExtractor), typeof(RegexExtractor)
        };

        public static IFieldExtractor Create(string typeName)
        {
            return _cache.Get(typeName, () => {
                return ObjectFactory.Create<IFieldExtractor>(TryToGetFullName(typeName));
            });
        }

        private static string TryToGetFullName(string typeName)
        {
            var t = _knownTypes.FirstOrDefault(i => i.Name.ToLowerInvariant().Equals(typeName.ToLowerInvariant()));
            if (t != null) return t.AssemblyQualifiedName;
            return typeName;
        }

    }
}
