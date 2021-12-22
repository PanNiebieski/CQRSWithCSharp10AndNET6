using Microsoft.AspNetCore.Mvc;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddQueries();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");



if (app.Environment.IsDevelopment())
{
    app.UseSwagger()
        .UseSwagger();
}

app.Run();



