namespace Example.ApplicationCore.EventConfiguration
{
    public interface ICommandHandler<in T>
    {
        ValueTask Handle(T command, CancellationToken token);
    }
}