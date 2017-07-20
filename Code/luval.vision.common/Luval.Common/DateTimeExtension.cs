// Decompiled with JetBrains decompiler
// Type: Luval.Common.DateTimeExtension
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using System;

namespace Luval.Common
{
  public static class DateTimeExtension
  {
    public static DateTime MinDate
    {
      get
      {
        return new DateTime(1970, 1, 1);
      }
    }

    public static DateTime MaxDate
    {
      get
      {
        return DateTime.MaxValue;
      }
    }

    public static uint ToEpoch(this DateTime d)
    {
      return (uint) d.Subtract(DateTimeExtension.MinDate).TotalMilliseconds;
    }

    public static uint ToInt(this DateTime d)
    {
      return d.ToEpoch();
    }

    public static DateTime TrimMilliseconds(this DateTime d)
    {
      return new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second, 0);
    }

    public static DateTime TrimSeconds(this DateTime d)
    {
      return new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, 0, 0);
    }

    public static DateTime TrimMinutes(this DateTime d)
    {
      return new DateTime(d.Year, d.Month, d.Day, d.Hour, 0, 0, 0);
    }

    public static DateTime TrimHours(this DateTime d)
    {
      return new DateTime(d.Year, d.Month, d.Day, 0, 0, 0, 0);
    }

    public static DateTime TrimDays(this DateTime d)
    {
      return new DateTime(d.Year, d.Month, 1, 0, 0, 0, 0);
    }

    public static DateTime TrimMonths(this DateTime d)
    {
      return new DateTime(d.Year, 1, 1, 0, 0, 0, 0);
    }

    public static string ToInternationalFormat(this DateTime d)
    {
      return d.ToString("yyyy-MM-dd hh:mm:ss");
    }

    public static string ToInternationalFormatShort(this DateTime d)
    {
      return d.ToString("yyyy-MM-dd");
    }
  }
}
