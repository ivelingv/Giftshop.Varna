using Giftshop.Varna.Model;
using Giftshop.Varna.Models;

namespace Giftshop.Varna.Services
{
    public interface ITokenService
    {
        LoginResponse Login(LoginRequest model, Roles role);

        LoginResponse RegisterCustomer(RegisterRequest model);
    }
}