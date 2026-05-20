public sealed class OutboxProcessor
{
    private readonly IMongoCollection<OutboxMessage> _collection;
    private readonly IEventDispatcher _dispatcher;

    public OutboxProcessor(
        MongoContext context,
        IEventDispatcher dispatcher)
    {
        _collection = context.Database
            .GetCollection<OutboxMessage>("outbox");

        _dispatcher = dispatcher;
    }

    public async Task ProcessAsync(CancellationToken ct)
    {
        var messages = await _collection
            .Find(x => x.ProcessedOn == null)
            .Limit(50)
            .ToListAsync(ct);

        foreach (var message in messages)
        {
            await _dispatcher.DispatchAsync(message, ct);

            message.ProcessedOn = DateTime.UtcNow;

            await _collection.ReplaceOneAsync(
                x => x.Id == message.Id,
                message,
                cancellationToken: ct);
        }
    }
}