// Decompiled with JetBrains decompiler
// Type: Luval.Common.NumericBaseConverter
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Luval.Common
{
  public class NumericBaseConverter
  {
    private readonly List<string> _baseValues = new List<string>()
    {
      "0",
      "1",
      "2",
      "3",
      "4",
      "5",
      "6",
      "7",
      "8",
      "9",
      "A",
      "B",
      "C",
      "D",
      "E",
      "F",
      "G",
      "H",
      "I",
      "J",
      "K",
      "L",
      "M",
      "N",
      "O",
      "P",
      "Q",
      "R",
      "S",
      "T",
      "U",
      "V",
      "W",
      "X",
      "Y",
      "Z"
    };

    public string ToBase(ulong value, int numericBase)
    {
      this.ValidateBase(numericBase);
      List<string> stringList = new List<string>();
      double num = (double) value;
      while (num > 0.0)
      {
        int index = (int) Math.Floor(num % (double) numericBase);
        num = Math.Floor(num / (double) numericBase);
        stringList.Add(this._baseValues[index]);
      }
      stringList.Reverse();
      return string.Join(string.Empty, (IEnumerable<string>) stringList).ToLowerInvariant();
    }

    public ulong FromBase(string value, int numericBase)
    {
      this.ValidateBase(numericBase);
      int[] array = ((IEnumerable<char>) value.ToUpperInvariant().ToCharArray()).Select<char, int>((Func<char, int>) (i => this._baseValues.IndexOf(i.ToString((IFormatProvider) CultureInfo.InvariantCulture)))).ToArray<int>();
      int num1 = ((IEnumerable<int>) array).Count<int>();
      double num2 = 0.0;
      for (int index = 0; index < num1; ++index)
      {
        double num3 = Math.Pow((double) numericBase, (double) (num1 - index - 1));
        num2 += num3 * (double) array[index];
      }
      return Convert.ToUInt64(num2);
    }

    private void ValidateBase(int numericBase)
    {
      if (numericBase < 2 || numericBase > this._baseValues.Count<string>())
        throw new ArgumentException("The numeric base needs to be between 2 and {0}".Fi((object) this._baseValues.Count<string>()));
    }

    public string ToBinary(ulong value)
    {
      return this.ToBase(value, 2);
    }

    public string ToHex(ulong value)
    {
      return this.ToBase(value, 16);
    }

    public string ToBase36(ulong value)
    {
      return this.ToBase(value, 36);
    }
  }
}
