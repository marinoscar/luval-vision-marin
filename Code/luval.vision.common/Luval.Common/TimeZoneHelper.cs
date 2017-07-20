// Decompiled with JetBrains decompiler
// Type: Luval.Common.TimeZoneHelper
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using System;

namespace Luval.Common
{
  public static class TimeZoneHelper
  {
    private static TimeZoneInfo _computerTz;
    private static TimeZoneInfo _costaRicaTz;

    public static TimeZoneInfo TimeZone
    {
      get
      {
        return TimeZoneHelper._computerTz ?? (TimeZoneHelper._computerTz = TimeZoneInfo.Local);
      }
    }

    public static TimeZoneInfo CostaRicaTimeZone
    {
      get
      {
        return TimeZoneHelper._costaRicaTz ?? (TimeZoneHelper._costaRicaTz = TimeZoneInfo.FindSystemTimeZoneById("Central America Standard Time"));
      }
    }

    public static DateTime CostaRicaTime
    {
      get
      {
        return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneHelper.CostaRicaTimeZone);
      }
    }

    public static DateTime FromUtc(TimeZoneInfo tz, DateTime utcTime)
    {
      return TimeZoneInfo.ConvertTimeFromUtc(utcTime, tz);
    }

    public static DateTime FromUtcToCostaRicaTime(DateTime utcTime)
    {
      return TimeZoneHelper.FromUtc(TimeZoneHelper.CostaRicaTimeZone, utcTime);
    }
  }
}
