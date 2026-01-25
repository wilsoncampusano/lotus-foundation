using Application.Common;
using Domain.Common;
using MongoDB.Driver;
using System.Text.Json;

namespace Infraestructure.Outbox
{
    public sealed class MongoOutboxDispatcher : IDomainEventDispatcher
    {
        public readonly IMongoCollection<OutboxMesage> _collection;

        public MongoOutboxDispatcher(IMongoDatabase database)
        {
            _collection = database.GetCollection<OutboxMesage>("outbox");
        }
        public async Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken ct) 
        {
            var messages = domainEvents.Select(de => new OutboxMesage
            {
                Id = Guid.NewGuid(),
                Type = de.GetType().Name,
                Payload = JsonSerializer.Serialize(de), 
                OccuredOn = de.OccuredOn
            });

            await _collection.InsertManyAsync(messages, cancellationToken: ct);

        }
    }
}
