using Giftshop.Varna.Database.Models;
using System.Collections.Generic;

namespace Giftshop.Varna.Services
{
    public interface IShoppingCartService : IService<ShoppingCart>
    {
        IEnumerable<ShoppingCart> GetCartsByUserId(long userId);
    }
}
