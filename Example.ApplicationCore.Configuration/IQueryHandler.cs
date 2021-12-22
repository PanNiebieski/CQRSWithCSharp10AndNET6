namespace Example.ApplicationCore.Configuration
{
    //public interface IQueryHandler<in T, TResult>
    //{
    //    TResult Handle(T query, CancellationToken ct);
    //}

    //public interface IQueryHandler<in T, TResult>
    //{
    //    Task<TResult> Handle(T query, CancellationToken ct);
    //}

    public interface IQueryHandler<in TQuery, TResult>
    {
        ValueTask<TResult> Handle(TQuery query, CancellationToken ct);
    }
}