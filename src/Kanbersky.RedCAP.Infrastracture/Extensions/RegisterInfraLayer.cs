using Kanbersky.RedCAP.Infrastracture.Outbox.EntityFramework.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Kanbersky.RedCAP.Infrastracture.Extensions
{
    public static class RegisterInfraLayer
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            services.AddCap(c=> 
            {
                c.UseEntityFramework<OutboxDbContext>();
                c.UseSqlServer("");
                c.UseRabbitMQ("");
            });
            return services;
        }
    }
}
