using Domain.Common;

namespace Application.Common
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken ct);
    }
}
