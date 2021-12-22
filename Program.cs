var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointDefinitions(typeof(EndpointDefinition));
var app = builder.Build();

app.UseEndpointDefinitions();
app.Run();



// Command
record RegisterProduct;

// Query
record GetProductDetails;


public static class EndPointDefinitionExtension
{
    public static void AddEndpointDefinitions(
        this IServiceCollection services,params Type[] scanMarkers)
    {
        var endpoints = new List<IEndpointDefinition>();

        foreach (var scanMarker in scanMarkers)
        {
            endpoints.AddRange(
                scanMarker.Assembly.ExportedTypes
                .Where(x => typeof(IEndpointDefinition)
                .IsAssignableFrom(x) && (!x.IsInterface && !x.IsAbstract))
                .Select(Activator.CreateInstance)
                .Cast<IEndpointDefinition>()
            );
        }

        foreach (var endpoint in endpoints)
        {
            endpoint.DefineServices(services);
        }

        services.AddSingleton
            (endpoints as IReadOnlyCollection<IEndpointDefinition>);
    }

    public static void UseEndpointDefinitions(this WebApplication app)
    {
        var defs = app.Services.GetRequiredService<IReadOnlyCollection<IEndpointDefinition>>();

        foreach (var def in defs)
        {
            def.DefineEndpoints(app);
        }
    }
}

public interface IEndpointDefinition
{
    void DefineServices(IServiceCollection services);

    void DefineEndpoints(WebApplication app);
}


public class EndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapPost("api/hello", async context =>
        {

        });
    }

    public void DefineServices(IServiceCollection services)
    {
        
    }
}