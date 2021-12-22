using Microsoft.Extensions.DependencyInjection;

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
        QueryHandler<in TQuery, TResult>(TQuery query, CancellationToken ct);
}
