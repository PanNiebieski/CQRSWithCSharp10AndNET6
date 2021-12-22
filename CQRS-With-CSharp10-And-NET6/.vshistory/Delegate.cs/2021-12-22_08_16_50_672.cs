


public delegate ValueTask 
    CommandHandler<in T>(T query, CancellationToken ct);