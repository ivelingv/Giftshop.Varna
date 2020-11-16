using Giftshop.Varna.Database.Models;
using Giftshop.Varna.Database.Repositories;

namespace Giftshop.Varna.Services
{
    public class CategoryService : Service<ICategoryRepository, Category>, ICategoryService
    {
        private readonly ICurrentUserService currentUserService;

        public CategoryService(ICategoryRepository repository, ICurrentUserService currentUserService) 
            : base(repository)
        {
            this.currentUserService = currentUserService;
        }

        public Category Delete(long id)
        {
            var entity = Repository.Get(id);
            entity.IsActive = false;
            entity.UserId = currentUserService.GetCurrentUserId();

            Repository.Update(entity);

            return entity;
        }

        public override void Save(Category entity)
        {
            entity.UserId = currentUserService.GetCurrentUserId();
            base.Save(entity);
        }
    }
}
