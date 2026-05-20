using System.Text.Json;

public sealed class EventDispatcher : IEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<EventDispatcher> _logger;

    public EventDispatcher(
        IServiceProvider serviceProvider,
        ILogger<EventDispatcher> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public async Task DispatchAsync(
        OutboxMessage message,
        CancellationToken cancellationToken)
    {
        switch (message.Type)
        {
            case nameof(MemberCreatedDomainEvent):
                var domainEvent = JsonSerializer.Deserialize<MemberCreatedDomainEvent>(message.Payload);
                if (domainEvent is null)
                {
                    _logger.LogWarning(
                        "Could not deserialize {Type} from outbox message {Id}",
                        message.Type,
                        message.Id);
                    return;
                }

                var handlers = _serviceProvider
                    .GetServices<IDomainEventHandler<MemberCreatedDomainEvent>>();

                foreach (var handler in handlers)
                {
                    await handler.HandleAsync(domainEvent, cancellationToken);
                }

                break;

            default:
                _logger.LogWarning(
                    "No handler registered for outbox event type {Type}",
                    message.Type);
                break;
        }
    }
}
