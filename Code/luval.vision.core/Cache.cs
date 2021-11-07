using System;
using System.Collections.Generic;
using System.Text;

namespace luval.vision.core
{
    public class Cache<TKey, TValue>
    {
        private IDictionary<TKey, TValue> _data = new Dictionary<TKey, TValue>();

        public TValue Get(TKey key, Func<TValue> getVal)
        {
            if (getVal == null) throw new ArgumentException("getVal");
            if (_data.ContainsKey(key)) return _data[key];
            _data.Add(key, getVal());
            return _data[key];
        }
    }
}
