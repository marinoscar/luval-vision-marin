// Decompiled with JetBrains decompiler
// Type: Luval.Common.CacheItems`2
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using System;

namespace Luval.Common
{
  public class CacheItems<TKey, TValue> : IClearableCacheItems
  {
    public ICacheStorageProvider<TKey, CacheItemContainer<TValue>> Internal { get; private set; }

    public string BucketName { get; private set; }

    public CacheItems(string bucketName)
    {
      this.Internal = (ICacheStorageProvider<TKey, CacheItemContainer<TValue>>) new DictionaryCacheStorage<TKey, CacheItemContainer<TValue>>(bucketName);
      this.BucketName = bucketName;
    }

    public void Clear()
    {
      this.Internal.Clear();
    }

    public TValue GetCacheItem(TKey key)
    {
      return this.GetCacheItem(key, (Func<TKey, TValue>) null);
    }

    public TValue GetCacheItem(TKey key, Func<TKey, TValue> functionToGetValue)
    {
      return this.GetCacheItem(key, functionToGetValue, DateTime.MaxValue);
    }

    public TValue GetCacheItem(TKey key, Func<TKey, TValue> functionToGetValue, TimeSpan expiration)
    {
      DateTime utcExpiredBy = DateTime.MaxValue;
      if (expiration.TotalMilliseconds > 0.0)
        utcExpiredBy = DateTime.UtcNow.Add(expiration);
      return this.GetCacheItem(key, functionToGetValue, utcExpiredBy);
    }

    public TValue GetCacheItem(TKey key, Func<TKey, TValue> functionToGetValue, DateTime utcExpiredBy)
    {
      if (!this.Internal.ContainsKey(key))
        return this.GetValueFromFunction(key, functionToGetValue, utcExpiredBy);
      CacheItemContainer<TValue> cacheItemContainer = this.Internal[key];
      ++cacheItemContainer.LookedUpCount;
      cacheItemContainer.UtcLastAccesedOn = DateTime.UtcNow;
      if (cacheItemContainer.UtcLastAccesedOn > cacheItemContainer.UtcExpireOn)
        return this.GetValueFromFunction(key, functionToGetValue, utcExpiredBy);
      return cacheItemContainer.Item;
    }

    private TValue GetValueFromFunction(TKey key, Func<TKey, TValue> func, DateTime utcExpiredBy)
    {
      if (func == null)
        throw new ArgumentNullException("The key {0} is not cached and no function was provided to properly store the value in cache".Fi((object) key));
      TValue obj = func(key);
      this.SetCacheItem(key, obj, utcExpiredBy);
      return obj;
    }

    public void RemoveFromCache(TKey key)
    {
      this.Internal.Remove(key);
    }

    public void SetCacheItem(TKey key, TValue value)
    {
      this.SetCacheItem(key, value, DateTime.MaxValue);
    }

    public void SetCacheItem(TKey key, TValue value, TimeSpan expiration)
    {
      DateTime utcExpiredBy = DateTime.MaxValue;
      if (expiration.TotalMilliseconds > 0.0)
        utcExpiredBy = DateTime.UtcNow.Add(expiration);
      this.SetCacheItem(key, value, utcExpiredBy);
    }

    public void SetCacheItem(TKey key, TValue value, DateTime utcExpiredBy)
    {
      this.Internal[key] = new CacheItemContainer<TValue>(value)
      {
        UtcExpireOn = utcExpiredBy
      };
    }

    public bool ContainsKey(TKey key)
    {
      return this.Internal.ContainsKey(key);
    }
  }
}
