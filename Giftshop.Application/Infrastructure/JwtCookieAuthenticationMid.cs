using Giftshop.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giftshop.Application.Infrastructure
{
    public class JwtCookieAuthenticationMiddleware : IMiddleware
    {
        private const string CookieName = "AuthCookie";
        private readonly ICurrentUserTokenService _currentUserToken;

        public JwtCookieAuthenticationMiddleware(ICurrentUserTokenService currentUserToken)
        {
            this._currentUserToken = currentUserToken;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Cookies.TryGetValue(CookieName, out var token))
            {
                context.Request.Headers.TryAdd("Authorization", $"{JwtBearerDefaults.AuthenticationScheme} {token}");
                _currentUserToken.SetToken(token);
            }

            await next(context);
        }
    }
}
