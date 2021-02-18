using Kanbersky.RedCAP.Core.Mappings.Abstract;
using Kanbersky.RedCAP.Core.Mappings.Concrete.Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Kanbersky.RedCAP.Core.Extensions
{
    public static class RegisterCoreExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddSingleton<IMapping, MapsterMapping>();

            return services;
        }
    }
}
