// Decompiled with JetBrains decompiler
// Type: Luval.Common.FileLocalization
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Luval.Common
{
  public class FileLocalization : ILocalizationProvider, IDisposable
  {
    private readonly string _fileLocation;
    private IDictionary<string, string> _data;

    public string CultureCode { get; private set; }

    public FileLocalization(string cultureCode, string resourceFolderLocation)
    {
      this.CultureCode = cultureCode;
      this._fileLocation = resourceFolderLocation;
      if (!Directory.Exists(resourceFolderLocation))
        throw new ArgumentException("{0} is not a valid folder location".Fi((object) resourceFolderLocation));
      this._data = (IDictionary<string, string>) new ConcurrentDictionary<string, string>();
      this.LoadFile();
    }

    public static ILocalizationProvider GetLocalizationProvider()
    {
      return FileLocalization.GetLocalizationProvider("es");
    }

    public static ILocalizationProvider GetLocalizationProvider(string cultureCode)
    {
      return FileLocalization.GetLocalizationProvider(cultureCode, "\\Localization");
    }

    public static ILocalizationProvider GetLocalizationProvider(string cultureCode, string relativeFileName)
    {
      return (ILocalizationProvider) new FileLocalization(cultureCode, PathHelper.GetPathForFile(relativeFileName));
    }

    public void LoadFile()
    {
      this._data = (IDictionary<string, string>) new ConcurrentDictionary<string, string>();
      using (StreamReader streamReader = new StreamReader(Path.Combine(this._fileLocation, "localization.{0}.txt".Fi((object) this.CultureCode.ToLowerInvariant()))))
      {
        while (!streamReader.EndOfStream)
        {
          string str = streamReader.ReadLine();
          if (!string.IsNullOrWhiteSpace(str) && !str.Trim().Equals(string.Empty) && !str.Trim().StartsWith("#"))
          {
            string[] strArray = str.Split(";".ToCharArray());
            if (((IEnumerable<string>) strArray).Any<string>() && ((IEnumerable<string>) strArray).Count<string>() == 2)
              this._data.Add(strArray[0].Trim(), strArray[1].Trim());
          }
        }
      }
    }

    public string GetResource(string resourceName)
    {
      if (this._data.ContainsKey(resourceName))
        return this._data[resourceName];
      return "!WRONG!";
    }

    public IEnumerable<KeyValuePair<string, string>> GetAll()
    {
      return (IEnumerable<KeyValuePair<string, string>>) this._data;
    }

    public void Dispose()
    {
      this._data.Clear();
      this._data = (IDictionary<string, string>) null;
    }
  }
}
