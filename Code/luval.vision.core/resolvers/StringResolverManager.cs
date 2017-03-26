using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core.resolvers
{
    public class StringResolverManager
    {
        private Dictionary<Type, IStringResolver> _resolvers;

        public StringResolverManager()
        {
            _resolvers = new Dictionary<Type, IStringResolver>()
            {
                {typeof(NumberResolver), new NumberResolver()},
                {typeof(DateResolver), new DateResolver() }
            };
        }

        public T Get<T>() where T : IStringResolver
        {
            return (T)_resolvers[typeof(T)];
        }

    }
}
