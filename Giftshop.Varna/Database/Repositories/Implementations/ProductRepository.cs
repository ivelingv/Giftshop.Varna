using Giftshop.Varna.Database.Context;
using Giftshop.Varna.Database.Models;
using System.Collections.Generic;
using System.Linq;

namespace Giftshop.Varna.Database.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext context) 
            : base(context)
        {
        }

        public IEnumerable<Product> GetProductsByCategoryId(long categoryId)
        {
            return Context.Products.Where(e => e.CategoryId == categoryId)
                .ToArray();
        }
    }
}
