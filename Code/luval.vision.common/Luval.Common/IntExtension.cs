// Decompiled with JetBrains decompiler
// Type: Luval.Common.IntExtension
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using System;

namespace Luval.Common
{
  public static class IntExtension
  {
    public static void Times(this int i, Action<int> action)
    {
      for (int index = 0; index < i; ++index)
        action(index);
    }

    public static string ToBinary(this int i)
    {
      return new NumericBaseConverter().ToBinary(Convert.ToUInt64(i));
    }

    public static string ToHex(this int i)
    {
      return new NumericBaseConverter().ToHex(Convert.ToUInt64(i));
    }

    public static string ToBase36(this int i)
    {
      return new NumericBaseConverter().ToBase36(Convert.ToUInt64(i));
    }

    public static string ToBase(this int i, int numericBase)
    {
      return new NumericBaseConverter().ToBase(Convert.ToUInt64(i), numericBase);
    }
  }
}
