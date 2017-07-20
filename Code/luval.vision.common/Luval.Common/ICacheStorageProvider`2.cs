// Decompiled with JetBrains decompiler
// Type: Luval.Common.ICacheStorageProvider`2
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

namespace Luval.Common
{
  public interface ICacheStorageProvider<TKey, TValue>
  {
    string BucketName { get; }

    TValue this[TKey key] { get; set; }

    bool ContainsKey(TKey key);

    void Add(TKey key, TValue value);

    void Remove(TKey key);

    void Clear();
  }
}
