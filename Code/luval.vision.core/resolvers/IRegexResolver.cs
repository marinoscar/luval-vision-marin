using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core.resolvers
{
    public interface IRegexResolver : IStringResolver
    {
        string Pattern { get; set; }
    }
}
