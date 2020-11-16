using Giftshop.Varna.Configurations;
using Giftshop.Varna.Database.Models;
using Giftshop.Varna.Database.Repositories;
using Giftshop.Varna.Model;
using Giftshop.Varna.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Giftshop.Varna.Services
{

    public class TokenService : ITokenService
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IUserRepository _userRepository;
        private readonly IJwtServices jwtServices;
        private readonly IHashService hashService;

        public TokenService(IHttpContextAccessor accessor,
            IUserRepository userRepository,
            IJwtServices jwtServices,
            IHashService hashService)
        {
            this._accessor = accessor;
            this._userRepository = userRepository;
            this.jwtServices = jwtServices;
            this.hashService = hashService;
        }

        public LoginResponse Login(LoginRequest model, Roles role)
        {
            var user = _userRepository.GetByEmail(model.Username);
            if (user is null)
            {
                return null;
            }

            if (role == Roles.None)
            {
                return null;
            }

            if (user.Type == UserType.Administrator
                && role != Roles.Admin)
            {
                return null;
            }

            if (user.Type == UserType.Client
                && role != Roles.Client)
            {
                return null;
            }

            if (!hashService.ComapareWithPlain(user.Password, model.Password))
            {
                return null;
            }

            return new LoginResponse
            {
                Shema = jwtServices.Shema,
                Token = jwtServices.GenerateToken(user.Id.ToString(), user.Username, user.Name, user.Type),
            };
        }

        public LoginResponse RegisterCustomer(RegisterRequest model)
        {
            var user = _userRepository.GetByEmail(model.Username);
            if (user != null)
            {
                return null;
            }

            user = new User
            {
                Username = model.Username,
                Password = hashService.ComputeHash(model.Password),
                Name = model.Name,
                Status = UserStatus.Active,
                Type = UserType.Client,
            };

            _userRepository.Save(user);
            return new LoginResponse
            {
                Shema = jwtServices.Shema,
                Token = jwtServices.GenerateToken(user.Id.ToString(), user.Username, user.Name, user.Type),
            };
        }
    }
}
