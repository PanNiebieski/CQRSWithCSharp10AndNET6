public delegate ValueTask<TResult>
    QueryHandler<in T, TResult>(T query, CancellationToken ct);


public delegate ValueTask CommandHandler<in T>(T query, CancellationToken ct);