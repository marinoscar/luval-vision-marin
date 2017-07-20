// Decompiled with JetBrains decompiler
// Type: Luval.Common.TypeExtensions
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using System;

namespace Luval.Common
{
  public static class TypeExtensions
  {
    public static object GetDefaultValue(this Type type)
    {
      switch (Type.GetTypeCode(type))
      {
        case TypeCode.DBNull:
          return (object) null;
        case TypeCode.Boolean:
          return (object) false;
        case TypeCode.Char:
          return (object) char.MinValue;
        case TypeCode.Byte:
          return (object) (byte) 0;
        case TypeCode.Int16:
          return (object) (short) 0;
        case TypeCode.UInt16:
          return (object) (ushort) 0;
        case TypeCode.Int32:
          return (object) 0;
        case TypeCode.UInt32:
          return (object) 0U;
        case TypeCode.Int64:
          return (object) 0L;
        case TypeCode.UInt64:
          return (object) 0UL;
        case TypeCode.Single:
          return (object) 0.0f;
        case TypeCode.Double:
          return (object) 0.0;
        case TypeCode.Decimal:
          return (object) Decimal.Zero;
        case TypeCode.DateTime:
          return (object) new DateTime();
        case TypeCode.String:
          return (object) null;
        default:
          return Activator.CreateInstance(type);
      }
    }
  }
}
