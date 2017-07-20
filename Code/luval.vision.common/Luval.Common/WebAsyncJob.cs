// Decompiled with JetBrains decompiler
// Type: Luval.Common.WebAsyncJob
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using System.Threading.Tasks;
using System.Web.Hosting;

namespace Luval.Common
{
  public class WebAsyncJob : IRegisteredObject
  {
    private readonly object _lock = new object();
    private bool _shuttingDown;

    public WebAsyncJob()
    {
      HostingEnvironment.RegisterObject((IRegisteredObject) this);
    }

    public void Stop(bool immediate)
    {
      lock (this._lock)
        this._shuttingDown = true;
      HostingEnvironment.UnregisterObject((IRegisteredObject) this);
    }

    public void Execute(Task task)
    {
      if (task == null)
        return;
      lock (this._lock)
      {
        if (this._shuttingDown || task.Status != TaskStatus.Created)
          return;
        task.Start();
      }
    }
  }
}
