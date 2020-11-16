using Giftshop.Varna.Database.Models;
using System.Collections.Generic;

namespace Giftshop.Varna.Services
{
    public interface IAddressService : IService<UserAddress>
    {
        UserAddress Delete(long id);

        IEnumerable<UserAddress> GetByUser(long userId);
    }
}
