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

    public interface IQueryHandler<in T, TResult>
    {
        ValueTask<TResult> Handle(T query, CancellationToken ct);
    }
}