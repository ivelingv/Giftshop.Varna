using Giftshop.Varna.Database.Models;
using Giftshop.Varna.Database.Repositories;
using System.Collections.Generic;

namespace Giftshop.Varna.Services
{
    public class ShoppingCartService : Service<IShoppingCartRepository, ShoppingCart>, IShoppingCartService
    {
        public ShoppingCartService(IShoppingCartRepository repository) 
            : base(repository)
        {
            
        }

        public IEnumerable<ShoppingCart> GetCartsByUserId(long userId)
        {
            return Repository.GetCartsByUserId(userId);
        }
    }
}
