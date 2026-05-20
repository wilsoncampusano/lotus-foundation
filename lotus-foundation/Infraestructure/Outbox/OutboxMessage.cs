namespace Infraestructure.Outbox
{
    public sealed class OutboxMessage
    {
        public Guid Id { get; set; }

        public string Type { get; set; } = default!;
        public string Payload { get; set; } = default!;
        public DateTime OccuredOn { get; set; }
        public DateTime? ProcessedOn { get; set; }
    }
}
