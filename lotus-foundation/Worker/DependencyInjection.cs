public static class DependencyInjection
{
    public static IServiceCollection AddWorker(
        this IServiceCollection services)
    {
        services.AddHostedService<OutboxPollingService>();

        services.AddScoped<IEventDispatcher, EventDispatcher>();
        services.AddScoped<OutboxProcessor>();

        services.AddScoped<
            IDomainEventHandler<MemberCreatedDomainEvent>,
            MemberCreatedAnalyticsHandler>();

        services.AddScoped<
            IDomainEventHandler<MemberCreatedDomainEvent>,
            MemberCreatedNotificationHandler>();

        return services;
    }
}