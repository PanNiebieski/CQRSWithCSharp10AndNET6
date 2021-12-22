



// Command

// Query
public interface ICommandHandler<in TCommand, TStatus>
{
    ValueTask<TStatus> Handle(TCommand command,
        CancellationToken ct);
}
