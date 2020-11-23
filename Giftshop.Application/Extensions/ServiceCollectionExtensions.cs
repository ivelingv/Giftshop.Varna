using Giftshop.Application.Configurations;
using Giftshop.Application.Contracts;
using Giftshop.Application.Infrastructure;
using Giftshop.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Refit;

namespace Giftshop.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddStandardServices(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddControllersWithViews();

            return services.AddSecurity(configuration)
                .AddConnections(configuration);
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddScoped<JwtCookieAuthenticationMiddleware>()
                .AddScoped<ICurrentUserTokenService, CurrentUserTokenService>()
                .AddScoped<ICurrentUserService, CurrentUserService>();
        }

        private static IServiceCollection AddSecurity(this IServiceCollection services,
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

        private static IServiceCollection AddConnections(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.Configure<HttpSettings>(configuration.GetSection(nameof(HttpSettings)));
            services.AddHttpContextAccessor();

            services.AddRefitClient<ITokenService>()
                .WithConfiguration();

            services.AddRefitClient<IUsersService>()
                .WithConfiguration();

            services.AddRefitClient<IAddressesService>()
                .WithConfiguration();

            services.AddRefitClient<ICategoriesService>()
                .WithConfiguration();

            services.AddRefitClient<IProductsService>()
                .WithConfiguration();

            services.AddRefitClient<IShoppingCartProductsService>()
                .WithConfiguration();

            services.AddRefitClient<IShoppingCartsService>()
                .WithConfiguration();

            return services;
        }

    }
}
