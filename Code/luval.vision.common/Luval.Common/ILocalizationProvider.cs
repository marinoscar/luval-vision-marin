// Decompiled with JetBrains decompiler
// Type: Luval.Common.ILocalizationProvider
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using System;
using System.Collections.Generic;

namespace Luval.Common
{
  public interface ILocalizationProvider : IDisposable
  {
    string CultureCode { get; }

    string GetResource(string resourceName);

    IEnumerable<KeyValuePair<string, string>> GetAll();
  }
}
