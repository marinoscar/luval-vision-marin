// Decompiled with JetBrains decompiler
// Type: Luval.Common.UIntExtension
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using System;

namespace Luval.Common
{
  public static class UIntExtension
  {
    public static void Times(this uint i, Action<int> action)
    {
      for (int index = 0; (long) index < (long) i; ++index)
        action(index);
    }

    public static string ToBinary(this uint i)
    {
      return new NumericBaseConverter().ToBinary((ulong) i);
    }

    public static string ToHex(this uint i)
    {
      return new NumericBaseConverter().ToHex((ulong) i);
    }

    public static string ToBase36(this uint i)
    {
      return new NumericBaseConverter().ToBase36((ulong) i);
    }

    public static string ToBase(this uint i, int numericBase)
    {
      return new NumericBaseConverter().ToBase((ulong) i, numericBase);
    }
  }
}
