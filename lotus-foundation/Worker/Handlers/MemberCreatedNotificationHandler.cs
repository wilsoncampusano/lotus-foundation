public sealed class MemberCreatedNotificationHandler
    : IDomainEventHandler<MemberCreatedDomainEvent>
{
    private readonly ILogger<MemberCreatedNotificationHandler> _logger;

    public MemberCreatedNotificationHandler(
        ILogger<MemberCreatedNotificationHandler> logger)
    {
        _logger = logger;
    }

    public Task HandleAsync(
        MemberCreatedDomainEvent domainEvent,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Welcome notification for Member {MemberId}",
            domainEvent.MemberId);

        return Task.CompletedTask;
    }
}