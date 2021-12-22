namespace CQRS_With_CSharp10_And_NET6
{
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



    public interface ICommandHandler<in T>
    {
        ValueTask Handle(T command, CancellationToken token);
    }
}
