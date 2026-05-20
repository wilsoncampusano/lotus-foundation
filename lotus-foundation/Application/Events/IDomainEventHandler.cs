using Domain.Common;

namespace Application.Events;

public interface IDomainEventHandler<TEvent>
    where TEvent : IDomainEvent
{
    Task HandleAsync(
        TEvent domainEvent,
        CancellationToken cancellationToken);
}