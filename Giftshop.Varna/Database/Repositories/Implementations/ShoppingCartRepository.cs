using Giftshop.Varna.Database.Context;
using Giftshop.Varna.Database.Models;

namespace Giftshop.Varna.Database.Repositories
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(DatabaseContext context) 
            : base(context)
        {
        }
    }
}
