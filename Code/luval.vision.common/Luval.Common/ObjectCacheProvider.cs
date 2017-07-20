// Decompiled with JetBrains decompiler
// Type: Luval.Common.ObjectCacheProvider
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using System.Collections.Generic;

namespace Luval.Common
{
  public static class ObjectCacheProvider
  {
    private static Dictionary<string, IClearableCacheItems> _cacheCollection;

    public static CacheItems<TKey, TValue> GetProvider<TKey, TValue>(string bucketName)
    {
      ObjectCacheProvider.CreateIfRequired();
      if (ObjectCacheProvider._cacheCollection.ContainsKey(bucketName))
        return (CacheItems<TKey, TValue>) ObjectCacheProvider._cacheCollection[bucketName];
      CacheItems<TKey, TValue> cacheItems = new CacheItems<TKey, TValue>(bucketName);
      ObjectCacheProvider._cacheCollection.Add(bucketName, (IClearableCacheItems) cacheItems);
      return cacheItems;
    }

    public static void ClearProvider(string name)
    {
      ObjectCacheProvider.CreateIfRequired();
      if (!ObjectCacheProvider._cacheCollection.ContainsKey(name))
        return;
      ObjectCacheProvider._cacheCollection[name].Clear();
    }

    public static void ClearAll()
    {
      ObjectCacheProvider._cacheCollection = (Dictionary<string, IClearableCacheItems>) null;
    }

    private static void CreateIfRequired()
    {
      if (ObjectCacheProvider._cacheCollection != null)
        return;
      ObjectCacheProvider._cacheCollection = new Dictionary<string, IClearableCacheItems>();
    }
  }
}
