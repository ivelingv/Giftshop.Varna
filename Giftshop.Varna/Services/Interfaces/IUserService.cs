using Giftshop.Varna.Database.Models;

namespace Giftshop.Varna.Services
{
    public interface IUserService : IService<User>
    {
        User Delete(long id);
    }
}
