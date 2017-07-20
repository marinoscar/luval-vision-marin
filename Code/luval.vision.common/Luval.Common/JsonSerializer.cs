// Decompiled with JetBrains decompiler
// Type: Luval.Common.JsonSerializer
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using Newtonsoft.Json;

namespace Luval.Common
{
  public class JsonSerializer
  {
    public static string ToJson(object data)
    {
      return JsonConvert.SerializeObject(data);
    }

    public static T FromJson<T>(string json)
    {
      return JsonConvert.DeserializeObject<T>(json);
    }
  }
}
