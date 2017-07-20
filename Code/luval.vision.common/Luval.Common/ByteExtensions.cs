// Decompiled with JetBrains decompiler
// Type: Luval.Common.ByteExtensions
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Luval.Common
{
  public static class ByteExtensions
  {
    public static readonly ReadOnlyCollection<string> HexValues;

    static ByteExtensions()
    {
      string[] strArray = new string[256];
      for (int index = 0; index < strArray.Length; ++index)
        strArray[index] = "{0:x2}".Fi((object) index);
      ByteExtensions.HexValues = new ReadOnlyCollection<string>((IList<string>) strArray);
    }

    public static string ToHex(this byte b)
    {
      return ByteExtensions.HexValues[(int) b];
    }
  }
}
