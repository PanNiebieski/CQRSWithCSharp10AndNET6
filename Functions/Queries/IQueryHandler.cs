



// Command

// Query
public interface IQueryHandler<in TQuery,TResult>
{
    ValueTask<TResult> Handle(TQuery query, CancellationToken ct);
}
