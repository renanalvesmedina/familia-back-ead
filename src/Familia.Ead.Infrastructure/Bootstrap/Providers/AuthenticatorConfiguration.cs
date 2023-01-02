using Familia.Ead.Domain.Entities.Authentication;
using Familia.Ead.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Text;

namespace Familia.Ead.Infrastructure.Bootstrap.Providers
{
    public static class AuthenticatorConfiguration
    {
        public static IServiceCollection ConfigureAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var _jwtAppSettingsOptions = configuration.GetSection(nameof(JwtOptions));
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("JwtOptions:Secret").Value));


            services.AddAuthorization();

            services.AddIdentity<User, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<AuthenticationContext>()
                .AddDefaultTokenProviders();

            services.Configure<JwtOptions>(opt =>
            {
                opt.Issuer = _jwtAppSettingsOptions[nameof(JwtOptions.Issuer)];
                opt.Audience = _jwtAppSettingsOptions[nameof(JwtOptions.Audience)];
                opt.SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
                opt.Expiration = int.Parse(_jwtAppSettingsOptions[nameof(JwtOptions.Expiration)] ?? "0");
            });

            //services.Configure<IdentityOptions>(opt =>
            //{
            //    opt.Password.RequireDigit = true;
            //    opt.Password.RequireLowercase = true;
            //    opt.Password.RequireNonAlphanumeric = true;
            //    opt.Password.RequireUppercase = true;
            //    opt.Password.RequiredLength = 6;
            //});

            var _tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = configuration.GetSection("JwtOptions:Issuer").Value,

                ValidateAudience = false,
                ValidAudience = configuration.GetSection("JwtOptions:Audience").Value,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = _tokenValidationParameters;
            });

            return services;
        }
    }
}
