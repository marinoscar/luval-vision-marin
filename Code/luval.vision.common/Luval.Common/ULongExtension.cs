// Decompiled with JetBrains decompiler
// Type: Luval.Common.ULongExtension
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using System;

namespace Luval.Common
{
  public static class ULongExtension
  {
    public static void Times(this ulong i, Action<ulong> action)
    {
      for (ulong index = 0; index < i; ++index)
        action(index);
    }

    public static string ToBinary(this ulong i)
    {
      return new NumericBaseConverter().ToBinary(i);
    }

    public static string ToHex(this ulong i)
    {
      return new NumericBaseConverter().ToHex(i);
    }

    public static string ToBase36(this ulong i)
    {
      return new NumericBaseConverter().ToBase36(i);
    }

    public static string ToBase(this ulong i, int numericBase)
    {
      return new NumericBaseConverter().ToBase(i, numericBase);
    }
  }
}
