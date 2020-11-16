using Giftshop.Varna.Database.Models;
using System.Collections.Generic;

namespace Giftshop.Varna.Services
{
    public interface IShoppingCartProductService : IService<ShoppingCartProduct>
    {
        IEnumerable<ShoppingCartProduct> GetByShoppingCart(long shoppingCartId);
    }
}
