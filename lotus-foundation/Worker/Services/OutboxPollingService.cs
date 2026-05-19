public sealed class OutboxPollingService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<OutboxPollingService> _logger;

    public OutboxPollingService(
        IServiceScopeFactory scopeFactory,
        ILogger<OutboxPollingService> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();

                var processor =
                    scope.ServiceProvider
                        .GetRequiredService<OutboxProcessor>();

                await processor.ProcessAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while processing outbox");
            }

            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        }
    }
}