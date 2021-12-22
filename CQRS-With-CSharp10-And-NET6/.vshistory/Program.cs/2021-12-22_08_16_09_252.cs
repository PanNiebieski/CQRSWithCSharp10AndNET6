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
