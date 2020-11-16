using Giftshop.Varna.Database.Context;
using Giftshop.Varna.Database.Models;
using System.Collections.Generic;
using System.Linq;

namespace Giftshop.Varna.Database.Repositories
{
    public class ShoppingCartProductRepository : Repository<ShoppingCartProduct>, IShoppingCartProductRepository
    {
        public ShoppingCartProductRepository(DatabaseContext context) 
            : base(context)
        {
        }

        public IEnumerable<ShoppingCartProduct> GetByShoppingCart(long shoppingCartId)
        {
            return Context.Set<ShoppingCartProduct>()
                .Where(e => e.ShoppingCartId == shoppingCartId)
                .ToList();
        }
    }
}
