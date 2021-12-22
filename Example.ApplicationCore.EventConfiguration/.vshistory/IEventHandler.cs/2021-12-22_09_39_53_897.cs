namespace Example.ApplicationCore.EventConfiguration
{
    public interface <in T>
    {
        ValueTask Handle(T command, CancellationToken token);
    }
}