using DotNetCore.CAP;
using Kanbersky.RedCAP.Core.Infrastructure.Abstract.EntityFramework;
using Kanbersky.RedCAP.Core.Settings.Concrete.AllCSSettings;
using Kanbersky.RedCAP.Core.Settings.Concrete.Outbox;
using Kanbersky.RedCAP.Infrastracture.DataAccess.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kanbersky.RedCAP.Infrastracture.Extensions
{
    public static class RegisterInfraLayer
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            OrderDbSettings orderDbSettings = new OrderDbSettings();
            configuration.GetSection(nameof(OrderDbSettings)).Bind(orderDbSettings);
            services.AddSingleton(orderDbSettings);

            OutboxDbSettings outboxDbSettings = new OutboxDbSettings();
            configuration.GetSection(nameof(OutboxDbSettings)).Bind(outboxDbSettings);
            services.AddSingleton(outboxDbSettings);

            OutboxRabbitMQSettings outboxRabbitMQSettings = new OutboxRabbitMQSettings();
            configuration.GetSection(nameof(OutboxRabbitMQSettings)).Bind(outboxRabbitMQSettings);
            services.AddSingleton(outboxRabbitMQSettings);

            services.AddCap(c =>
            {
                c.UseEntityFramework<OrderDbContext>();

                c.UseRabbitMQ(outboxRabbitMQSettings.Uri);
                c.UseDashboard();
            });

            services.AddDbContext<OrderDbContext>(c =>
                c.UseSqlServer(orderDbSettings.ConnectionStrings), ServiceLifetime.Transient);

            //services.AddScoped(typeof(IEfGenericRepository<>), typeof(EfGenericRepository<>));

            return services;
        }

        public static IApplicationBuilder UseInfra(this IApplicationBuilder app)
        {
            app.UseCapDashboard();

            return app;
        }
    }
}
