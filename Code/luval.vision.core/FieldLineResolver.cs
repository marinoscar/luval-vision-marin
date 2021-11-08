using System;
using System.Collections.Generic;
using System.Text;

namespace luval.vision.core
{
    public class FieldLineResolver
    {
        /// <summary>
        /// The full qualified name of a class that implements the <see cref="IOcrLineResolver"/> interface
        /// </summary>
        public string LineResolverQualifiedName { get; set; }
        public Dictionary<string, string> Options { get; set; }
    }
}
