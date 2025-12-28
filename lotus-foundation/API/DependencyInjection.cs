using Application.Interfaces;
using Application.Members.CreateMember;
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
            services.Configure<MongoSettings>(
                configuration.GetSection("Mongo"));

            services.AddSingleton<MongoContext>();

            services.AddScoped<IMemberRepository, MongoMemberRepository>();
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
