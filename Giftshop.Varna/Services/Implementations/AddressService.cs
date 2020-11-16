using Giftshop.Varna.Database.Models;
using Giftshop.Varna.Database.Repositories;
using System.Collections.Generic;

namespace Giftshop.Varna.Services
{
    public class AddressService : Service<IAddressRepository, UserAddress>, IAddressService
    {
        public AddressService(IAddressRepository repository) 
            : base(repository)
        {
            
        }

        public UserAddress Delete(long id)
        {
            var entity = Repository.Get(id);
            entity.IsActive = false;

            Repository.Update(entity);

            return entity;
        }

        public IEnumerable<UserAddress> GetByUser(long userId)
        {
            return Repository.GetByUser(userId);
        }
    }
}
