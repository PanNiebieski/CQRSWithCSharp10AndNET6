var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();


//public interface ICommandHandler<in T>
//{
//    void Handle(T command, CancellationToken token);
//}

//public interface IQueryHandler<in T, TResult>
//{
//    TResult Handle(T query, CancellationToken ct);
//}


//public interface ICommandHandler<in T>
//{
//    Task Handle(T command, CancellationToken token);
//}

//public interface IQueryHandler<in T, TResult>
//{
//    Task<TResult> Handle(T query, CancellationToken ct);
//}

public interface ICommandHandler<in T>
{
    ValueTask Handle(T command, CancellationToken token);
}

public interface IQueryHandler<in T, TResult>
{
    ValueTask<TResult> Handle(T query, CancellationToken ct);
}