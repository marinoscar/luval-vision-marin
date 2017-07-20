// Decompiled with JetBrains decompiler
// Type: Luval.Common.ObjectContainer
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using System;

namespace Luval.Common
{
  public static class ObjectContainer
  {
    private const string CacheProviderKey = "ObjectContainerCacheKey";

    private static CacheItems<Type, ObjectContainer.ContainerItem> GetCache()
    {
      return ObjectCacheProvider.GetProvider<Type, ObjectContainer.ContainerItem>("ObjectContainerCacheKey");
    }

    public static void Register<T>(Func<object> instance)
    {
      ObjectContainer.GetCache().SetCacheItem(typeof (T), new ObjectContainer.ContainerItem()
      {
        Constructor = instance,
        Item = (object) null
      });
    }

    public static void Register<T>(object item)
    {
      ObjectContainer.GetCache().SetCacheItem(typeof (T), new ObjectContainer.ContainerItem()
      {
        Constructor = (Func<object>) null,
        Item = item
      });
    }

    public static bool IsRegistered<T>()
    {
      return ObjectContainer.GetCache().ContainsKey(typeof (T));
    }

    public static T Get<T>()
    {
      ObjectContainer.ContainerItem cacheItem = ObjectContainer.GetCache().GetCacheItem(typeof (T));
      return (T) (cacheItem.Constructor == null ? cacheItem.Item : cacheItem.Constructor());
    }

    private class ContainerItem
    {
      public object Item { get; set; }

      public Func<object> Constructor { get; set; }
    }
  }
}
