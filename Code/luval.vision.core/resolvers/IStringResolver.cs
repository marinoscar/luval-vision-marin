using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core.resolvers
{
    public interface IStringResolver
    {
        string Code { get; }
        bool IsMatch(string text);
        string GetValue(string text);
    }
}
