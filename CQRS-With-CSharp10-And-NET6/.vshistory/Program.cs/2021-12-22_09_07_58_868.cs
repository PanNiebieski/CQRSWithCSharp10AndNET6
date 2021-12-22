using Example.ApplicationCore;
using Example.ApplicationCore.Configuration;
using Example.ApplicationCore.Functions.Posts.Queries;
using Example.Infrastructure.Dummy;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExampleInfrastructureDummy();
builder.Services.AddQueries();

var app = builder.Build();

app.MapGet("/post/getallposts", HandleGetProducts);



if (app.Environment.IsDevelopment())
{
    app.UseSwagger()
        .UseSwagger();
}

app.Run();


ValueTask<List<Post>> HandleGetProducts(
    [FromServices] QueryHandler<GetAllPostsQuery, List<Post>> getProducts,
    string? filter,
    int? page,
    int? pageSize,
    CancellationToken ct
) =>
    getProducts(GetAllPostsQuery.With(filter, page, pageSize), ct);
