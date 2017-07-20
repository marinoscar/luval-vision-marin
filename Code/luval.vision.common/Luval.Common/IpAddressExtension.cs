// Decompiled with JetBrains decompiler
// Type: Luval.Common.IpAddressExtension
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using System;
using System.Net;

namespace Luval.Common
{
  public static class IpAddressExtension
  {
    public static uint ToInt(this IPAddress ip)
    {
      uint result = 0;
      byte[] array = ip.GetAddressBytes();
      3.Times((Action<int>) (i => result += (uint) ((double) array[i] * Math.Pow(256.0, Convert.ToDouble(3 - i)))));
      result += (uint) array[3];
      return result;
    }

    public static IPAddress FromInt(this IPAddress ip, uint ipAddress)
    {
      return new IPAddress(BitConverter.GetBytes(ipAddress));
    }
  }
}
