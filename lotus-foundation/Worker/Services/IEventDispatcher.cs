public interface IEventDispatcher
{
    Task DispatchAsync(
        OutboxMessage message,
        CancellationToken cancellationToken);
}
