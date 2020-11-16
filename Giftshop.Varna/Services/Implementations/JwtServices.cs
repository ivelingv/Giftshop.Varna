using Giftshop.Varna.Configurations;
using Giftshop.Varna.Database.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Giftshop.Varna.Services
{
    public class JwtServices : IJwtServices
    {
        private readonly Security settings;

        public string Shema => JwtBearerDefaults.AuthenticationScheme;

        public JwtServices(IOptions<Security> settings)
        {
            this.settings = settings?.Value;
        }

        public string GenerateToken(string id, string email, string name, UserType userType)
        {
            var expires = DateTime.Now.AddHours(settings.ValidHours);
            var credentials = new SigningCredentials(
                settings.SecurityKey,
                SecurityAlgorithms.HmacSha256Signature);

            var handler = new JwtSecurityTokenHandler();
            var token = new JwtSecurityToken(
                issuer: settings.Iss,
                audience: settings.Aud,
                new[]
                {
                    new Claim(nameof(id), id),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Role, userType.ToString())
                },
                notBefore: DateTime.Now,
                expires: expires,
                signingCredentials: credentials);


            return handler.WriteToken(token);
        }

    }
}
