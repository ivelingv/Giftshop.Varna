using Giftshop.Application.Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Giftshop.Application.Contracts
{
    public interface IShoppingCartProductsService
    {
        [Get("/api/ShoppingCartProduct/GetAll")]
        Task<IEnumerable<ShoppingCartProductModel>> GetAllAsync();

        [Get("/api/ShoppingCartProduct/Get/{id}")]
        Task<ShoppingCartProductModel> GetAsync([FromRoute] long id);

        [Get("/api/ShoppingCartProduct/GetByShoppingCart/{shoppingCartId}")]
        Task<IEnumerable<ShoppingCartProductModel>> GetByShoppingCart([FromRoute] long shoppingCartId);

        [Post("/api/ShoppingCartProduct/Create")]
        Task<ShoppingCartProductModel> CreateAsync([FromBody] ShoppingCartProductModel model);

        [Patch("/api/ShoppingCartProduct/Update/{id}")]
        Task<ShoppingCartProductModel> UpdateAsync([FromRoute] long id, [FromBody] ShoppingCartProductModel model);

        [Delete("/api/ShoppingCartProduct/Delete/{id}")]
        Task<ShoppingCartProductModel> DeleteAsync([FromRoute] long id);
    }
}
