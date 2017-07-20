// Decompiled with JetBrains decompiler
// Type: Luval.Common.CacheItemContainer`1
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using System;

namespace Luval.Common
{
  public class CacheItemContainer<TValue>
  {
    public TValue Item { get; set; }

    public uint LookedUpCount { get; set; }

    public ulong Size { get; set; }

    public DateTime UtcCreatedOn { get; set; }

    public DateTime UtcLastAccesedOn { get; set; }

    public DateTime UtcExpireOn { get; set; }

    public CacheItemContainer(TValue item)
    {
      this.Item = item;
      this.LookedUpCount = 0U;
      this.Size = 0UL;
      this.UtcCreatedOn = DateTime.UtcNow;
      this.UtcLastAccesedOn = this.UtcCreatedOn;
      this.UtcExpireOn = DateTime.MaxValue;
    }
  }
}
