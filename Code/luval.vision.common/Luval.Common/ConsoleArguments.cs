// Decompiled with JetBrains decompiler
// Type: Luval.Common.ConsoleArguments
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using System.Collections.Generic;

namespace Luval.Common
{
  public class ConsoleArguments
  {
    private List<string> _args;

    public ConsoleArguments(IEnumerable<string> args)
    {
      this._args = new List<string>(args);
    }

    public bool ContainsSwitch(string name)
    {
      return this._args.Contains(name);
    }

    public string GetSwitchValue(string name)
    {
      if (!this.ContainsSwitch(name))
        return (string) null;
      int num = this._args.IndexOf(name);
      if (this._args.Count - 1 < num + 1)
        return (string) null;
      return this._args[num + 1];
    }
  }
}
