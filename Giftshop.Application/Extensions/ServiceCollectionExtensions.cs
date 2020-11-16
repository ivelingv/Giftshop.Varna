using Giftshop.Application.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Giftshop.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSecurityServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<Security>(
                configuration.GetSection(nameof(Security)));

            var securitySettings = services.BuildServiceProvider()
              .GetRequiredService<IOptions<Security>>()
              .Value;

            services.AddAuthentication(conf =>
            {
                conf.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                conf.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opts =>
            {
                opts.ClaimsIssuer = securitySettings.Iss;
                opts.Audience = securitySettings.Aud;
                opts.SaveToken = true;
                opts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = securitySettings.Iss,
                    ValidAudience = securitySettings.Aud,
                    IssuerSigningKey = securitySettings.SecurityKey,
                };
            });

            services.AddAuthorization(conf =>
            {
                var defaultPolicy = new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();

                conf.DefaultPolicy = defaultPolicy;
            });

            return services;
        }

    }
}
