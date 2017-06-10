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
            if (ContainsDate(text)) return DataType.Date;
            if (ContainsAmount(text)) return DataType.Amount;
            if (ContainsNumber(text)) return DataType.Number;
            if (ContainsCode(text)) return DataType.Code;
            if (Get<WordResolver>().IsMatch(text)) return DataType.Word;
            return DataType.None;
        }

        public bool ContainsDate(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return false;
            return Get<DateResolver>().IsMatch(text);
        } 

        public bool ContainsAmount(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return false;
            return Get<AmountResolver>().IsMatch(text);
        }

        public bool ContainsNumber(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return false;
            return Get<NumberResolver>().IsMatch(text);
        }

        public bool ContainsCode(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return false;
            return Get<CodeResolver>().IsMatch(text);
        }
    }
}
