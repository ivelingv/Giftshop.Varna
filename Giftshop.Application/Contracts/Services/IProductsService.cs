using Giftshop.Application.Contracts.Models;
using Giftshop.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Giftshop.Application.Contracts
{
    public interface IProductsService
    {
        [Get("/api/Products/GetAll")]
        Task<IEnumerable<ProductModel>> GetAllAsync();

        [Get("/api/Products/GetProducts")]
        Task<IEnumerable<ProductModel>> GetProducts();

        [Get("/api/Products/Get/{id}")]
        Task<ProductModel> GetAsync([FromRoute] long id);

        [Post("/api/Products/Create")]
        Task<ProductModel> CreateAsync([FromBody] ProductModel model);

        [Patch("/api/Products/Update/{id}")]
        Task<ProductModel> UpdateAsync([FromRoute] long id, [FromBody] ProductModel model);

        [Delete("/api/Products/Delete/{id}")]
        Task<ProductModel> DeleteAsync([FromRoute] long id);

        [Get("/api/Products/GetByCategory/{categoryId}")]
        public Task<IEnumerable<ProductModel>> GetByCategoryAsync([FromRoute] long categoryId);
    }
}
