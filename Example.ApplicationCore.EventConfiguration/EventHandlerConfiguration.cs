using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.ApplicationCore.EventConfiguration
{
    public static class EventHandlerConfiguration
    {

        public static IServiceCollection AddEventHandler
            <T, TEventHandler>(
    this IServiceCollection services
            ) where TEventHandler : class, IEventHandler<T>
        {

            services.AddTransient<IEventHandler<T>, TEventHandler>()
                    .AddTransient<EventHandler<T>>(
                        sp => sp.GetRequiredService
                        <IEventHandler<T>>().Handle
                );

            return services;
        }

    }

    public delegate ValueTask
      EventHandler<in T>(T query, CancellationToken ct);
}
