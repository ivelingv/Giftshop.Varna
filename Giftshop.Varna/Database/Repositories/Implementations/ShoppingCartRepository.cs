using Giftshop.Varna.Database.Context;
using Giftshop.Varna.Database.Models;
using System.Collections.Generic;
using System.Linq;

namespace Giftshop.Varna.Database.Repositories
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(DatabaseContext context) 
            : base(context)
        {
        }

        public IEnumerable<ShoppingCart> GetCartsByUserId(long userId)
        {
            return Context.Set<ShoppingCart>()
                .Where(e => e.UserId == userId)
                .ToList();
        }
    }
}
