using Giftshop.Varna.Database.Models;
using Giftshop.Varna.Database.Repositories;

namespace Giftshop.Varna.Services
{
    public class ShoppingCartService : Service<IShoppingCartRepository, ShoppingCart>, IShoppingCartService
    {
        public ShoppingCartService(IShoppingCartRepository repository) 
            : base(repository)
        {
            
        }
    }
}
