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
                {typeof(DateResolver), new DateResolver()},
                {typeof(AmountResolver), new AmountResolver()},
                {typeof(NumberResolver), new NumberResolver()},
                {typeof(CodeResolver), new CodeResolver()},
                {typeof(WordResolver), new WordResolver()}

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

        public DataType Classify(string text)
        {
            if (Get<DateResolver>().IsMatch(text)) return DataType.Date;
            if (Get<AmountResolver>().IsMatch(text)) return DataType.Amount;
            if (Get<NumberResolver>().IsMatch(text)) return DataType.Number;
            if (Get<CodeResolver>().IsMatch(text)) return DataType.Code;
            if (Get<WordResolver>().IsMatch(text)) return DataType.Word;
            return DataType.None;
        }

    }
}
