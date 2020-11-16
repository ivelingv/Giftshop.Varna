using AutoMapper;
using Giftshop.Varna.Configurations;
using Giftshop.Varna.Database.Context;
using Giftshop.Varna.Filters;
using Giftshop.Varna.Models.Profiles;
using Giftshop.Varna.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Giftshop.Varna.Database.Repositories
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddScoped<IShoppingCartProductRepository, ShoppingCartProductRepository>();
            
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddSingleton<IJwtServices, JwtServices>();
            services.AddSingleton<IHashService, HashService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IProductService , ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IShoppingCartProductService, ShoppingCartProductService>();


            services.AddSingleton<HashAlgorithm>(MD5.Create());

            return services;
        }

        public static IServiceCollection AddStandardServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(conf =>
            {
                conf.AddProfile<GiftshopProfiles>();
            });

            services.AddMvcCore(conf =>
            {
                conf.Filters.Add(typeof(GlobalExceptionFilter));
                conf.Filters.Add(typeof(ModelStateFilter));
            })
            .AddNewtonsoftJson(options =>
            {
                // Use the default property (Pascal) casing
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver
                { 
                    NamingStrategy = new CamelCaseNamingStrategy()
                };
            });            
            return services;
        }

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

        public static IServiceCollection AddDatabaseContext<TDbContext>(this IServiceCollection services, 
            IConfiguration configuration)
            where TDbContext : DbContext
        {
            services.Configure<DatabaseSettings>(
                configuration.GetSection(nameof(DatabaseSettings)));

            var databaseSettings = services.BuildServiceProvider()
               .GetRequiredService<IOptions<DatabaseSettings>>()
               .Value;

            services.AddDbContext<TDbContext>(conf =>
            {
                conf.UseSqlite(databaseSettings.ConnectionString);
            })
            .AddScoped<DbContext, DatabaseContext>();

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });
            return services;
        }
    }
}
