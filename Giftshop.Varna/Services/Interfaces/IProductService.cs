using Giftshop.Varna.Database.Models;
using System.Collections.Generic;

namespace Giftshop.Varna.Services
{
    public interface IProductService : IService<Product>
    {
        IEnumerable<Product> GetProductsByCategoryId(long categoryId);

        Product Delete(long id);
    }
}
