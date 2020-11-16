using Giftshop.Varna.Database.Context;
using Giftshop.Varna.Database.Models;
using System.Collections.Generic;
using System.Linq;

namespace Giftshop.Varna.Database.Repositories
{
    public class AddressRepository : Repository<UserAddress>, IAddressRepository
    {
        public AddressRepository(DatabaseContext context) 
            : base(context)
        {
        }

        public IEnumerable<UserAddress> GetByUser(long userId)
        {
            return Context.Set<UserAddress>()
                .Where(e => e.UserId == userId)
                .ToList();
        }
    }
}
