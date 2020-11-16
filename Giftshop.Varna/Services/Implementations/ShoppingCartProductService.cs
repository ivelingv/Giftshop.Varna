using Giftshop.Varna.Database.Models;
using Giftshop.Varna.Database.Repositories;
using System.Collections.Generic;

namespace Giftshop.Varna.Services
{
    public class ShoppingCartProductService : Service<IShoppingCartProductRepository, ShoppingCartProduct>,
        IShoppingCartProductService
    {
        public ShoppingCartProductService(IShoppingCartProductRepository repository) 
            : base(repository)
        {
            
        }

        public IEnumerable<ShoppingCartProduct> GetByShoppingCart(long shoppingCartId)
        {
            return Repository.GetByShoppingCart(shoppingCartId);
        }
    }
}
