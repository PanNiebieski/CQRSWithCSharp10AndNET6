



// Command

// Query
public interface IEventHubHandler<in TEvent>
{
    ValueTask Handle(TEvent @event,
    CancellationToken ct);
}