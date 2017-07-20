// Decompiled with JetBrains decompiler
// Type: Luval.Common.PathHelper
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using System;
using System.Web.Hosting;

namespace Luval.Common
{
  public static class PathHelper
  {
    public static string GetPath()
    {
      if (!HostingEnvironment.IsHosted)
        return Environment.CurrentDirectory;
      return HostingEnvironment.ApplicationPhysicalPath;
    }

    public static string GetPathForFile(string fileName)
    {
      string path = PathHelper.GetPath();
      if (!path.EndsWith("\\"))
        path += "\\";
      if (fileName.StartsWith("\\"))
        fileName = fileName.Remove(0, 1);
      return "{0}{1}".Fi((object) path, (object) fileName);
    }
  }
}
