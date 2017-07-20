// Decompiled with JetBrains decompiler
// Type: Luval.Common.DateInYear
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using System;
using System.Globalization;

namespace Luval.Common
{
  public class DateInYear
  {
    private readonly System.DayOfWeek _firstDayOfWeek;
    private readonly double _productionDayOffSetInMinutes;

    public DateTime DateValue { get; set; }

    public string DateCode { get; set; }

    public ushort Year { get; set; }

    public ushort Semester { get; set; }

    public ushort Quater { get; set; }

    public ushort Month { get; set; }

    public string MonthName { get; set; }

    public ushort Week { get; set; }

    public ushort Day { get; set; }

    public ushort DayOfYear { get; set; }

    public ushort DayOfWeek { get; set; }

    public string DayOfWeekName { get; set; }

    public ushort Hour { get; set; }

    public uint HourOfYear { get; set; }

    public ushort Minute { get; set; }

    public uint MinuteOfYear { get; set; }

    public ushort Second { get; set; }

    public uint SecondOfYear { get; set; }

    public uint Chunk30MinOfYear { get; set; }

    public uint Chunk15MinOfYear { get; set; }

    public uint Chunk10MinOfYear { get; set; }

    public uint Chunk5MinOfYear { get; set; }

    public DateInYear()
      : this(DateTime.Now)
    {
    }

    public DateInYear(DateTime date)
      : this(date, 0.0)
    {
    }

    public DateInYear(DateTime date, double productionDayOffSetInMinutes)
      : this(date, productionDayOffSetInMinutes, DateInYear.GetDefaultCulture().DateTimeFormat.FirstDayOfWeek)
    {
    }

    public DateInYear(DateTime date, double productionDayOffSetInMinutes, System.DayOfWeek firstDayOfWeek)
    {
      this._productionDayOffSetInMinutes = productionDayOffSetInMinutes;
      this._firstDayOfWeek = firstDayOfWeek;
      this.Initialize(date);
    }

    private static CultureInfo GetDefaultCulture()
    {
      return new CultureInfo("es-ES");
    }

    public void Initialize(DateTime date)
    {
      this.Initialize(date, DateInYear.GetDefaultCulture());
    }

    public void Initialize(DateTime date, CultureInfo culture)
    {
      this.DateValue = date.AddMinutes(this._productionDayOffSetInMinutes);
      this.DateCode = date.ToString("yyyyMMddHHmmss");
      this.Year = (ushort) this.DateValue.Year;
      this.Semester = this.DateValue.Month > 6 ? (ushort) 2 : (ushort) 1;
      this.Quater = (ushort) ((this.DateValue.Month - 1) / 3 + 1);
      this.Month = (ushort) this.DateValue.Month;
      this.MonthName = this.DateValue.ToString("MMMM", (IFormatProvider) culture);
      this.Week = (ushort) culture.Calendar.GetWeekOfYear(this.DateValue, CalendarWeekRule.FirstDay, this._firstDayOfWeek);
      this.DayOfWeek = (ushort) this.DateValue.DayOfWeek;
      this.DayOfWeekName = this.DateValue.ToString("dddd", (IFormatProvider) culture);
      DateTime dateValue = this.DateValue;
      this.Day = (ushort) dateValue.Day;
      dateValue = this.DateValue;
      this.DayOfYear = (ushort) dateValue.DayOfYear;
      dateValue = this.DateValue;
      this.Hour = (ushort) dateValue.Hour;
      int num1 = ((int) this.DayOfYear - 1) * 24;
      dateValue = this.DateValue;
      int hour = dateValue.Hour;
      this.HourOfYear = (uint) (num1 + hour);
      dateValue = this.DateValue;
      this.Minute = (ushort) dateValue.Minute;
      long num2 = (long) (this.HourOfYear * 60U);
      dateValue = this.DateValue;
      long minute = (long) dateValue.Minute;
      this.MinuteOfYear = (uint) (num2 + minute);
      dateValue = this.DateValue;
      this.Second = (ushort) dateValue.Second;
      long num3 = (long) (this.MinuteOfYear * 60U);
      dateValue = this.DateValue;
      long second = (long) dateValue.Second;
      this.SecondOfYear = (uint) (num3 + second);
      long num4 = (long) (this.HourOfYear * 2U);
      dateValue = this.DateValue;
      long num5 = (long) (dateValue.Minute / 30);
      this.Chunk30MinOfYear = (uint) (num4 + num5);
      long num6 = (long) (this.HourOfYear * 4U);
      dateValue = this.DateValue;
      long num7 = (long) (dateValue.Minute / 15);
      this.Chunk15MinOfYear = (uint) (num6 + num7);
      long num8 = (long) (this.HourOfYear * 12U);
      dateValue = this.DateValue;
      long num9 = (long) (dateValue.Minute / 10);
      this.Chunk10MinOfYear = (uint) (num8 + num9);
      long num10 = (long) (this.HourOfYear * 12U);
      dateValue = this.DateValue;
      long num11 = (long) (dateValue.Minute / 5);
      this.Chunk5MinOfYear = (uint) (num10 + num11);
    }

    public static string ToSqlInsertHeader()
    {
      return "INSERT INTO Date ({0})".Fi((object) DateInYear.GetSqlColumnNames());
    }

    public string ToSqlInsertValues()
    {
      return "({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21})".FormatSql((object) this.DateValue, (object) this.DateCode, (object) this.Year, (object) this.Semester, (object) this.Quater, (object) this.Month, (object) this.MonthName, (object) this.Week, (object) this.DayOfWeek, (object) this.DayOfWeekName, (object) this.Day, (object) this.DayOfYear, (object) this.Hour, (object) this.HourOfYear, (object) this.Minute, (object) this.MinuteOfYear, (object) this.Second, (object) this.SecondOfYear, (object) this.Chunk30MinOfYear, (object) this.Chunk15MinOfYear, (object) this.Chunk10MinOfYear, (object) this.Chunk5MinOfYear);
    }

    public string ToSqlIsert()
    {
      return "{0} VALUES {1}".Fi((object) DateInYear.ToSqlInsertHeader(), (object) this.ToSqlInsertValues());
    }

    public string ToSqlSelect()
    {
      return "SELECT {0} FROM Date".Fi((object) DateInYear.GetSqlColumnNames());
    }

    private static string GetSqlColumnNames()
    {
      return "DateValue, DateCode, Year, Semester, Quater, Month, MonthName, Week, DayOfWeek, DayOfWeekName, Day, DayOfYear, Hour, HourOfYear, Minute, MinuteOfYear, Second, SecondOfYear, Chunk30MinOfYear, Chunk15MinOfYear, Chunk10MinOfYear, Chunk5MinOfYear";
    }

    public static DateInYear FromDateTime(DateTime dateTime)
    {
      return new DateInYear(dateTime);
    }
  }
}
