using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Familia.Ead.Infrastructure.Bootstrap.Providers
{
    public static class MediatorConfiguration
    {

        public static void ConfigureMediatrServices(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.Load("Familia.Ead.Application");

            services.AddMediatR(assemblies);

            services.AddAutoMapper(assemblies);
        }
    }
}
