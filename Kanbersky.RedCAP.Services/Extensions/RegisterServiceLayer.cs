using Kanbersky.RedCAP.Services.Consumers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Kanbersky.RedCAP.Services.Extensions
{
    public static class RegisterServiceLayer
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient<OrderCreatedSendEmailConsumer>();

            return services;
        }
    }
}
