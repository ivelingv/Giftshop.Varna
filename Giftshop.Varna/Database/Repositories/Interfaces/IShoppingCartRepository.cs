using Giftshop.Varna.Database.Models;
using System.Collections.Generic;

namespace Giftshop.Varna.Database.Repositories
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        IEnumerable<ShoppingCart> GetCartsByUserId(long userId);
    }
}
