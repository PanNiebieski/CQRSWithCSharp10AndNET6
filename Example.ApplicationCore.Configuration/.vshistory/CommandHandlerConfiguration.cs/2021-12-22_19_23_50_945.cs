
using Microsoft.Extensions.DependencyInjection;

namespace Example.ApplicationCore.Configuration
{
    public static class CommandHandlerConfiguration
    {
        public static IServiceCollection AddCommandHandler
            <TCommand, TCommandHandler>(
            this IServiceCollection services
        ) where TCommandHandler : class, ICommandHandler<TCommand>
        {

            services.AddTransient<ICommandHandler<TCommand>, TCommandHandler>()
                    .AddTransient<CommandHandler<TCommand>>(
                        sp => sp.GetRequiredService
                        <ICommandHandler<TCommand>>().Handle
                );

            return services;
        }

        //public static IServiceCollection AddCommandHandler
        //    <AddPostCommand, AddPostCommandHandler>(
        //    this IServiceCollection services
        //    ) where AddPostCommandHandler : class, ICommandHandler<TCommand>
        //{

        //    services.AddTransient<ICommandHandler<AddPostCommand>, AddPostCommandHandler>();

        //    services.AddTransient<CommandHandler<AddPostCommand>>(
        //                sp => sp.GetRequiredService
        //                <ICommandHandler<AddPostCommand>>().Handle
        //        );

        //    return services;
        //}
    }

    public delegate ValueTask
        CommandHandler<in TCommand>(TCommand command, CancellationToken ct);
}
