using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.ApplicationCore.EventConfiguration
{
    public static class EventHandlerConfiguration
    {


  
    }

    public delegate ValueTask
      EventHandler<in T>(T query, CancellationToken ct);
}
