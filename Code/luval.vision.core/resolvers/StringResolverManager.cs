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
                {typeof(AmountResolver), new AmountResolver()},
                {typeof(DateResolver), new DateResolver()},
                {typeof(WordResolver), new WordResolver()},
                {typeof(CodeResolver), new CodeResolver()},
                {typeof(NumberResolver), new NumberResolver()},
                {typeof(EmailResolver), new EmailResolver()},
                {typeof(RepNameResover), new RepNameResover()}

            };
        }

        public T Get<T>() where T : IStringResolver
        {
            return (T)_resolvers[typeof(T)];
        }

        public IStringResolver GetByCode(string code)
        {
            return _resolvers.Values.Where(i => i.Code == code).FirstOrDefault();
        }

    }
}
