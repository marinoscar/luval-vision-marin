using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class LuvalException : Exception
    {
        public LuvalException() { }
        public LuvalException(string message) : base(message) { }
        public LuvalException(string message, Exception innerException) : base(message, innerException) { }
    }
}
