public delegate ValueTask<TResult>
    QueryHandler<in T, TResult>(T query, CancellationToken ct);


