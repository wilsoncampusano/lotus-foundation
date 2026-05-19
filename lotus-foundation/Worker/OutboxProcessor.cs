using Microsoft.Extensions.Hosting;

namespace Worker
{
    public sealed class OutboxProcessor : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken) =>
            Task.CompletedTask;
    }
}
