// Decompiled with JetBrains decompiler
// Type: Luval.Common.GuidExtension
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using System;

namespace Luval.Common
{
  public static class GuidExtension
  {
    public static string ToPrettyString(this Guid g)
    {
      return g.ToString().Replace("-", "").ToUpperInvariant();
    }
  }
}
