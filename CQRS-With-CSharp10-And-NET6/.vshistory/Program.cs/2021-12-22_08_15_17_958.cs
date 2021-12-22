
using CQRS_With_CSharp10_And_NET6;
using Microsoft.AspNetCore.Mvc;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/api/products", HandleGetProducts)
    .Produces((int)HttpStatusCode.BadRequest);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger()
        .UseSwagger();
}

app.Run();


ValueTask<IReadOnlyList<ProductListItem>> HandleGetProducts(
    [FromServices] QueryHandler<GetProducts, IReadOnlyList<ProductListItem>> getProducts,
    string? filter,
    int? page,
    int? pageSize,
    CancellationToken ct
) =>
    getProducts(GetProducts.With(filter, page, pageSize), ct);




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
