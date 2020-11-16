using Giftshop.Varna.Database.Models;
using System.Collections.Generic;

namespace Giftshop.Varna.Database.Repositories
{
    public interface IShoppingCartProductRepository : IRepository<ShoppingCartProduct>
    {
        IEnumerable<ShoppingCartProduct> GetByShoppingCart(long shoppingCartId);
    }
}
