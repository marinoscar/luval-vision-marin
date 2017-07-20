// Decompiled with JetBrains decompiler
// Type: Luval.Common.StreamExtension
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using System.IO;

namespace Luval.Common
{
  public static class StreamExtension
  {
    public static byte[] ReadToEnd(this Stream s)
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        s.CopyTo((Stream) memoryStream);
        return memoryStream.ToArray();
      }
    }
  }
}
