using Giftshop.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Giftshop.Application.Constants;

namespace Giftshop.Application.Infrastructure
{
    public class JwtCookieAuthenticationMiddleware : IMiddleware
    {
        private readonly ICurrentUserTokenService _currentUserToken;

        public JwtCookieAuthenticationMiddleware(ICurrentUserTokenService currentUserToken)
        {
            this._currentUserToken = currentUserToken;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Cookies.TryGetValue(AuthCookie, out var token))
            {
                context.Request.Headers.TryAdd(AuthorizationHeader, $"{JwtBearerDefaults.AuthenticationScheme} {token}");
                _currentUserToken.SetToken(token);
            }

            await next(context);
        }
    }
}
