public sealed class MemberCreatedAnalyticsHandler
    : IDomainEventHandler<MemberCreatedDomainEvent>
{
    private readonly ILogger<MemberCreatedAnalyticsHandler> _logger;

    public MemberCreatedAnalyticsHandler(
        ILogger<MemberCreatedAnalyticsHandler> logger)
    {
        _logger = logger;
    }

    public Task HandleAsync(
        MemberCreatedDomainEvent domainEvent,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Analytics projection for Member {MemberId}",
            domainEvent.MemberId);

        return Task.CompletedTask;
    }
}