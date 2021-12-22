using Example.ApplicationCore;
using Example.ApplicationCore.Configuration;
using Example.ApplicationCore.Functions.Posts;
using Example.ApplicationCore.Functions.Posts.Queries;
using Example.Infrastructure.Dummy;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExampleInfrastructureDummy();
builder.Services.AddQueries();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

app.MapGet("/post/getallposts", HandleGetProducts)
    ;
app.MapPost("/post/addpost", HandleGetProducts);

//app.MapGet("/post/getallposts", 
//    (QueryHandler<GetAllPostsQuery, List<Post>> getProducts) => "Hello World!");


if (app.Environment.IsDevelopment())
{
    app.UseSwagger()
        .UseSwaggerUI();
}

app.Run();


ValueTask<List<Post>> HandleGetProducts(
    [FromServices] QueryHandler<GetAllPostsQuery, List<Post>> getProducts,
    OrderByPostOptions filter,
    int? page,
    int? pageSize,
    CancellationToken ct
) =>
    getProducts(GetAllPostsQuery.With(filter, page, pageSize), ct);
