// Decompiled with JetBrains decompiler
// Type: Luval.Common.DictionaryCacheStorage`2
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using System.Collections.Generic;

namespace Luval.Common
{
  public class DictionaryCacheStorage<TKey, TValue> : ICacheStorageProvider<TKey, TValue>
  {
    protected IDictionary<TKey, TValue> Internal { get; private set; }

    public string BucketName { get; private set; }

    public TValue this[TKey key]
    {
      get
      {
        return this.Internal[key];
      }
      set
      {
        this.Internal[key] = value;
      }
    }

    public DictionaryCacheStorage(string bucketName)
    {
      this.Internal = (IDictionary<TKey, TValue>) new Dictionary<TKey, TValue>();
      this.BucketName = bucketName;
    }

    public bool ContainsKey(TKey key)
    {
      return this.Internal.ContainsKey(key);
    }

    public void Add(TKey key, TValue value)
    {
      this.Internal.Add(key, value);
    }

    public void Remove(TKey key)
    {
      this.Internal.Remove(key);
    }

    public void Clear()
    {
      this.Internal.Clear();
    }
  }
}
