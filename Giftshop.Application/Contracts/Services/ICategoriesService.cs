using Giftshop.Application.Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Giftshop.Application.Contracts
{
    public interface ICategoriesService
    {
        [Get("/api/Category/GetAll")]
        Task<IEnumerable<CategoryModel>> GetAllAsync();

        [Get("/api/Category/Get/{id}")]
        Task<CategoryModel> GetAsync([FromRoute] long id);

        [Post("/api/Category/Create")]
        Task<CategoryModel> CreateAsync([FromBody] CategoryModel model);

        [Patch("/api/Category/Update/{id}")]
        Task<CategoryModel> UpdateAsync([FromRoute] long id, [FromBody] CategoryModel model);

        [Delete("/api/Category/Delete/{id}")]
        Task<CategoryModel> DeleteAsync([FromRoute] long id);
    }
}
