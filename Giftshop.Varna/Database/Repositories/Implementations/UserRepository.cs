using Giftshop.Varna.Database.Context;
using Giftshop.Varna.Database.Models;
using System.Linq;

namespace Giftshop.Varna.Database.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) 
            : base(context)
        {
        }

        public User GetByEmail(string username)
        {
            return Context.Set<User>()
                 .SingleOrDefault(e => e.Username == username);
        }
    }
}
