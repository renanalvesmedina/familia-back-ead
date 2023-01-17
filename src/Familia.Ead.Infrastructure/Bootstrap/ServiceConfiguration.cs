using Familia.Ead.Infrastructure.Bootstrap.Providers;
using Familia.Ead.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
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

        public static IApplicationBuilder Configure(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope();

            using var appDbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
            using var authenticationContext = serviceScope.ServiceProvider.GetService<AuthenticationContext>();

            appDbContext?.Database.Migrate();
            authenticationContext?.Database.Migrate();

            return app;
        }
    }
}
