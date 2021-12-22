var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExampleInfrastructureDummy();
builder.Services.AddQueries();
builder.Services.AddCommands();
builder.Services.AddEvents();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

app.MapGet("/post/getallposts", HandleGetAllPost)
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status400BadRequest)
    .Produces(StatusCodes.Status404NotFound);

app.MapPost("/post/addpost", HandleAddPost)
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status400BadRequest);


if (app.Environment.IsDevelopment())
{
    app.UseSwagger()
        .UseSwaggerUI();
}

app.Run();


async ValueTask<IResult> HandleGetAllPost(
    [FromServices] QueryHandler<GetAllPostsQuery, List<Post>> query,
    OrderByPostOptions filter,
    int? page,
    int? pageSize,
    CancellationToken ct
)
{
    Console.WriteLine("================");
    var result = await query(GetAllPostsQuery.With(filter, page, pageSize), ct);

    if (result == null || result.Count == 0)
        return Results.BadRequest();

    return Results.Ok(result);
}
  


async Task<IResult> HandleAddPost(
    [FromServices] CommandHandler<AddPostCommand> handler,
    AddPostCommand request,
    CancellationToken ct
)
{
    Console.WriteLine("================");
    await handler(request,ct);

    return Results.Ok();

    //return Results.Created($"/post/{postId}", Id);
}