using Giftshop.Application.Configurations;
using Giftshop.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Giftshop.Application.Extensions
{
    public static class HttpClientBuilderExtensions
    {
        public static void WithConfiguration(this IHttpClientBuilder builder)
        {
            builder.ConfigureHttpClient((provider, client) =>
            {
                var address = provider.GetRequiredService<IOptions<HttpSettings>>()
                    .Value
                    .ApiAddress;

                client.BaseAddress = new Uri(address);

                var token = provider
                    .GetService<IHttpContextAccessor>()
                    .HttpContext
                    .RequestServices
                    .GetRequiredService<ICurrentUserTokenService>()
                    .GetToken();

                if (token is null)
                {
                    return;
                }
                
                client.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, token);
            });
        }
    }
}
