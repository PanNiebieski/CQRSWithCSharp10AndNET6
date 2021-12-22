namespace Example.ApplicationCore.EventConfiguration
{
    public interface IEventHandler<in T>
    {
        ValueTask Handle(T command, CancellationToken token);
    }
}