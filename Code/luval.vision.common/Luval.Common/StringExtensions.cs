// Decompiled with JetBrains decompiler
// Type: Luval.Common.StringExtensions
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Luval.Common
{
  public static class StringExtensions
  {
    public static readonly char[] MagicRegexChars = new char[12]
    {
      '^',
      '$',
      '.',
      '(',
      ')',
      '{',
      '\\',
      '[',
      '?',
      '+',
      '*',
      '|'
    };
    public static readonly char[] MagicSqlLikeChars = new char[4]
    {
      '%',
      '_',
      '[',
      ']'
    };
    public static readonly char[] AngleBrackets = new char[2]
    {
      '<',
      '>'
    };
    public static readonly Regex EmailPattern = new Regex("^[\\w._%+-]+@[\\w.-]+\\.[A-Za-z]{2,4}$", RegexOptions.IgnoreCase | RegexOptions.Multiline);

    public static string FormatInvariant(this string format, params object[] args)
    {
      if (args.Length != 0)
        return string.Format((IFormatProvider) CultureInfo.InvariantCulture, format, args);
      return format;
    }

    public static string FormatSql(this string format, params object[] args)
    {
      return string.Format((IFormatProvider) SqlFormatter.Instance, format, args);
    }

    public static string Fi(this string format, params object[] args)
    {
      return format.FormatInvariant(args);
    }

    public static string EscapeMagicSqlLikeChars(this string s)
    {
      if (-1 == s.LastIndexOfAny(StringExtensions.MagicSqlLikeChars))
        return s;
      for (int index = 0; index < StringExtensions.MagicSqlLikeChars.Length; ++index)
      {
        char magicSqlLikeChar = StringExtensions.MagicSqlLikeChars[index];
        if (s.LastIndexOf(magicSqlLikeChar) != -1)
          s = s.Replace(magicSqlLikeChar.ToString(), "[" + magicSqlLikeChar.ToString() + "]");
      }
      return s;
    }

    public static IEnumerable<string> Split(this string s, int itemSize)
    {
      if (s.Length > itemSize)
        return Enumerable.Range(0, s.Length / itemSize).Select<int, string>((Func<int, string>) (i => s.Substring(i * itemSize, itemSize)));
      return (IEnumerable<string>) new string[1]
      {
        s
      };
    }
  }
}
