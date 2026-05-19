using Application.Common;
using Application.Interfaces;
using Application.Members.CreateMember;
using Infraestructure.Outbox;
using Infraestructure.Persistence.Mongo;
using Infraestructure.Persistence.Repositories;

namespace API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            MongoConfiguration.Configure();
            MongoMappings.Register();
            services.Configure<MongoSettings>(
                configuration.GetSection("Mongo"));

            services.AddSingleton<MongoContext>();

            services.AddScoped<IMemberRepository, MongoMemberRepository>();
            services.AddScoped<IDomainEventDispatcher>(sp =>
                new MongoOutboxDispatcher(sp.GetRequiredService<MongoContext>().Database));
            services.AddScoped<MongoHealthCheck>();

            return services;
        }

        public static IServiceCollection AddApplication(
       this IServiceCollection services)
        {
            services.AddScoped<CreateMemberHandler>();

            return services;
        }
    }
}
