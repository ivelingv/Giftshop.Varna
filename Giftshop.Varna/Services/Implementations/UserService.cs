using Giftshop.Varna.Database.Models;
using Giftshop.Varna.Database.Repositories;

namespace Giftshop.Varna.Services
{
    public class UserService : Service<IUserRepository, User>, IUserService
    {
        public UserService(IUserRepository repository) 
            : base(repository)
        {
            
        }

        public User Delete(long id)
        {
            var user = Repository.Get(id);
            user.Status = UserStatus.Inactive;
            Update(id, user);

            return user;
        }
    }
}
