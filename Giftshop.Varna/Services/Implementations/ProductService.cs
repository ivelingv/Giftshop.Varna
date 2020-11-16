using Giftshop.Varna.Database.Models;
using Giftshop.Varna.Database.Repositories;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;

namespace Giftshop.Varna.Services
{
    public class ProductService : Service<IProductRepository, Product>, IProductService
    {
        private readonly ICurrentUserService currentUserService;

        public ProductService(IProductRepository repository, ICurrentUserService currentUserService) 
            : base(repository)
        {
            this.currentUserService = currentUserService;
        }

        public IEnumerable<Product> GetProductsByCategoryId(long categoryId)
        {
            return Repository.GetProductsByCategoryId(categoryId);
        }

        public Product Delete(long id)
        {
            var entity = Repository.Get(id);
            entity.IsActive = false;
            entity.UserId = currentUserService.GetCurrentUserId();

            Repository.Update(entity);

            return entity;
        }

        public override void Save(Product entity)
        {
            entity.UserId = currentUserService.GetCurrentUserId();
            base.Save(entity);
        }
    }
}
