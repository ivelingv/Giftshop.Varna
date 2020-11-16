using Giftshop.Varna.Database.Context;
using Giftshop.Varna.Database.Models;

namespace Giftshop.Varna.Database.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DatabaseContext context) 
            : base(context)
        {
        }
    }
}
