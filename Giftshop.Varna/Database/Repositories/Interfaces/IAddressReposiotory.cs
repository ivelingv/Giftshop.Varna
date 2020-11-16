using Giftshop.Varna.Database.Models;
using System.Collections.Generic;

namespace Giftshop.Varna.Database.Repositories
{
    public interface IAddressRepository : IRepository<UserAddress>
    {
        IEnumerable<UserAddress> GetByUser(long userId);
    }
}
