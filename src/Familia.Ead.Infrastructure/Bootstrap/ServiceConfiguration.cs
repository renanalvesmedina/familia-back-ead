using Familia.Ead.Infrastructure.Bootstrap.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Familia.Ead.Infrastructure.Bootstrap
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigurePersistenceServices(configuration);
            services.ConfigureMediatrServices();
            services.ConfigureAuthenticationServices(configuration);

            return services;
        }
    }
}
