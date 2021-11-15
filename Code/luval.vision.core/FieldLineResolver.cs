using System;
using System.Collections.Generic;
using System.Text;

namespace luval.vision.core
{
    public class FieldLineResolver
    {
        public FieldLineResolver()
        {
            Options = new Dictionary<string, string>();
        }

        /// <summary>
        /// The full qualified name of a class that implements the <see cref="IOcrLineResolver"/> interface
        /// </summary>
        public string LineResolverQualifiedName { get; set; }
        public Dictionary<string, string> Options { get; set; }
    }
}
