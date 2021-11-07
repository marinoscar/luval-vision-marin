using System;
using System.Collections.Generic;
using System.Text;

namespace luval.vision.core
{
    public class FieldAnchor
    {
        public FieldAnchor()
        {
            Patterns = new List<string>();
        }

        /// <summary>
        /// List of regular expressions used to identify the anchot element 
        /// </summary>
        public List<string> Patterns { get; set; }

        /// <summary>
        /// If multiple elements are found, which element to use on a 0 based index
        /// </summary>
        public int ExpectedIndex { get; set; }

        /// <summary>
        /// If multiple elements are found, it would use the last one
        /// </summary>
        public bool UseLast { get; set; }
    }
}
