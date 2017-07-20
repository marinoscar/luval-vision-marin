// Decompiled with JetBrains decompiler
// Type: Luval.Common.SqlFormatter
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Luval.Common
{
  public class SqlFormatter : IFormatProvider, ICustomFormatter
  {
    public static readonly SqlFormatter Instance = new SqlFormatter();
    public static readonly string[] StringComparisonOperators = new string[4]
    {
      "equals",
      "startsWith",
      "endsWith",
      "contains"
    };

    public object GetFormat(Type formatType)
    {
      return (object) this;
    }

    public string Format(string format, object arg, IFormatProvider formatProvider)
    {
      return SqlFormatter.Format(format, arg);
    }

    public static string Format(string format, object o)
    {
      string str1 = format == "equals" ? "= " : string.Empty;
      if (o.IsNullOrDbNull())
        return ((IEnumerable<string>) SqlFormatter.StringComparisonOperators).Contains<string>(format) ? "IS NULL" : "NULL";
      if (o is DateTime)
        return str1 + "'{0:yyyy-MM-dd HH:mm:ss.fff}'".Fi(o);
      if (o is string)
      {
        string str2 = (string) o;
        if (format == "verbatim")
          return str2;
        if (format == "name")
          return "[{0}]".Fi((object) str2.Replace("]", "]]"));
        string s = str2.Replace("'", "''");
        if (format == "startsWith")
          return "LIKE '{0}%'".Fi((object) s.EscapeMagicSqlLikeChars());
        if (format == "endsWith")
          return "LIKE '%{0}'".Fi((object) s.EscapeMagicSqlLikeChars());
        if (format == "contains")
          return "LIKE '%{0}%'".Fi((object) s.EscapeMagicSqlLikeChars());
        return str1 + "'{0}'".Fi((object) s);
      }
      if (o is bool)
        return str1 + ((bool) o ? "1" : "0");
      if (o is ICollection<byte>)
      {
        ICollection<byte> bytes = o as ICollection<byte>;
        StringBuilder stringBuilder = new StringBuilder(str1 + "0x", bytes.Count * 2 + 8);
        foreach (byte b in (IEnumerable<byte>) bytes)
          stringBuilder.Append(b.ToHex());
        return stringBuilder.ToString();
      }
      if (o is IEnumerable)
      {
        StringBuilder stringBuilder = new StringBuilder(str1, 32);
        stringBuilder.Append("(");
        foreach (object o1 in (IEnumerable) o)
          stringBuilder.AppendFormat("{0},", (object) SqlFormatter.Format((string) null, o1));
        if (1 == stringBuilder.Length)
          stringBuilder.Append("NULL");
        else
          --stringBuilder.Length;
        stringBuilder.Append(")");
        return stringBuilder.ToString();
      }
      if (o is int)
        return str1 + ((int) o).ToString((IFormatProvider) CultureInfo.InvariantCulture);
      if (o is double)
        return str1 + ((double) o).ToString((IFormatProvider) CultureInfo.InvariantCulture);
      return str1 + "{0}".Fi(o);
    }
  }
}
