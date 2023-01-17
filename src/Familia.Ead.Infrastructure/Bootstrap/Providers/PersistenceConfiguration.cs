using Familia.Ead.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Familia.Ead.Infrastructure.Bootstrap.Providers
{
    public static class PersistenceConfiguration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("FamiliaEadDb")).EnableSensitiveDataLogging());

            services.AddDbContext<AuthenticationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("FamiliaEadDb")).EnableSensitiveDataLogging());

            return services;
        }

        
    }
}
