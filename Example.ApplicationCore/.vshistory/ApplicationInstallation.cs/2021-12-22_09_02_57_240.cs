using Example.ApplicationCore.Configuration;
using Example.ApplicationCore.Functions.Posts.Queries;
using Microsoft.Extensions.DependencyInjection;


namespace Example.ApplicationCore
{
    public static class ApplicationInstallation
    {
        public static IServiceCollection AddQueries
            (this IServiceCollection services)
        {

            services.AddQueryHandler
                <GetAllPostsQuery, List<Post>, GetAllPostsQueryHandler>();
                

            return services;
        }


    }
}
