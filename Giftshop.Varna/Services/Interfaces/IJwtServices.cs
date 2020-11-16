using Giftshop.Varna.Database.Models;

namespace Giftshop.Varna.Services
{
    public interface IJwtServices
    {
        string Shema { get; }

        string GenerateToken(string id, string email, string name, UserType userType);
    }
}