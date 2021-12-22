using Example.ApplicationCore.Configuration;
using Example.ApplicationCore.Functions.Posts.Command;
using Example.ApplicationCore.Functions.Posts.Events;
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

        public static IServiceCollection AddCommands
            (this IServiceCollection services)
        {

            services.AddCommandHandler
                <AddPostCommand, AddPostCommandHandler>();

            services.AddCommandHandler
                <SendSEOCheckCommand, 
                SendSEOCheckCommandHandler>();


            services.AddCommandHandler
                <SendToGrammarCheckerCommand, 
                SendToGrammarCheckerCommandHandler>();

            return services;
        }

        public static IServiceCollection AddEvents
    (this IServiceCollection services)
        {

            services.AddCommandHandler
                <PostCreatedEvent, PostCreatedEventHandler>();


            return services;
        }
    }
}
