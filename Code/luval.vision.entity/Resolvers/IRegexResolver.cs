using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.entity.Resolvers
{
    public interface IRegexResolver : IStringResolver
    {
        string Pattern { get; set; }
    }
}
