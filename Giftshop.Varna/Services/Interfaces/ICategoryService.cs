using Giftshop.Varna.Database.Models;

namespace Giftshop.Varna.Services
{
    public interface ICategoryService : IService<Category>
    {
        Category Delete(long id);
    }
}
