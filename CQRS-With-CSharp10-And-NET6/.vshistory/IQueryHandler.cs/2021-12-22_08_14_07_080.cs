namespace CQRS_With_CSharp10_And_NET6
{

    public interface IQueryHandler<in T, TResult>
    {
        ValueTask<TResult> Handle(T query, CancellationToken ct);
    }
}
