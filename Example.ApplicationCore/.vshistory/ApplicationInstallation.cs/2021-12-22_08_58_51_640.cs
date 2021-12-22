using Example.ApplicationCore.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Example.ApplicationCore
{
    public static class ApplicationInstallation
    {
        public static IServiceCollection AddAllPostQuery
            (this IServiceCollection services)
        {

            services.AddQueryHandler<GetAllPostsQuery,

            return services;
        }


    }
}
