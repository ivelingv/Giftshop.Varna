using Giftshop.Varna.Database.Models;
using System.Collections.Generic;

namespace Giftshop.Varna.Database.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string username);
    }
}
