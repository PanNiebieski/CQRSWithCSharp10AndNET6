﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.ApplicationCore.Configuration
{
    public static class CommandHandlerConfiguration
    {
        public static IServiceCollection AddCommandHandler<T, TCommandHandler>(
            this IServiceCollection services
        ) where TCommandHandler : class, ICommandHandler<T>
        {

            services.AddTransient<ICommandHandler<T>, TCommandHandler>()
                    .AddTransient<CommandHandler<T>>(
                        sp => sp.GetRequiredService<ICommandHandler<T>>().Handle
                );

            return services;
        }
    }

    public delegate ValueTask
        CommandHandler<in T>(T query, CancellationToken ct);
}