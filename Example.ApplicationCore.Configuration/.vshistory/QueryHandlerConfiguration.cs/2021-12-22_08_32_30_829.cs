using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.ApplicationCore.Configuration
{
    public static class QueryHandlerConfiguration
    {
        public static IServiceCollection AddQueryHandler<T, TResult, TQueryHandler>(
            this IServiceCollection services
        ) where TQueryHandler : class, IQueryHandler<T, TResult>
        {
            services
                .AddTransient<IQueryHandler<T, TResult>, TQueryHandler>()
                .AddTransient<QueryHandler<T, TResult>>(
                    sp => sp.GetRequiredService<IQueryHandler<T, TResult>>().Handle
            );

            return services;
        }
    }

    public delegate ValueTask<TResult>
        QueryHandler<in T, TResult>(T query, CancellationToken ct);
}
