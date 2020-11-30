using Giftshop.Application.Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Giftshop.Application.Contracts
{
    public interface IShoppingCartsService
    {
        [Get("/api/ShoppingCart/GetAll")]
        Task<IEnumerable<ShoppingCartModel>> GetAllAsync();

        [Get("/api/ShoppingCart/Get/{id}")]
        Task<ShoppingCartModel> GetAsync([FromRoute] long id);

        [Post("/api/ShoppingCart/Create")]
        Task<ShoppingCartModel> CreateAsync([FromBody] ShoppingCartModel model);

        [Patch("/api/ShoppingCart/Update/{id}")]
        Task<ShoppingCartModel> UpdateAsync([FromRoute] long id, [FromBody] ShoppingCartModel model);

        [Delete("/api/ShoppingCart/Delete/{id}")]
        Task<ShoppingCartModel> DeleteAsync([FromRoute] long id);

        [Get("/api/ShoppingCart/GetUserOrders")]
        Task<IEnumerable<ShoppingCartModel>> GetUserOrdersAsync([FromQuery] long userId);
    }
}
