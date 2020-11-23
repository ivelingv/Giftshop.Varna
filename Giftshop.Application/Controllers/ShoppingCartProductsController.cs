using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Giftshop.Application.Models;
using Giftshop.Application.Contracts;
using Microsoft.AspNetCore.Authorization;
using static Giftshop.Application.Constants;

namespace Giftshop.Application.Controllers
{
    [Authorize(Roles = AdministratorRole)]
    public class ShoppingCartProductsController : Controller
    {
        private readonly IShoppingCartProductsService _service;
        private readonly IProductsService _productsService;

        public ShoppingCartProductsController(IShoppingCartProductsService service, IProductsService productsService)
        {
            _service = service;
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(long id)
        {
            var records = await _service.GetByShoppingCart(id);
           
            return View(records.Select(record =>
            {
                var product = _productsService.GetAsync(record.ProductId)
                    .GetAwaiter()
                    .GetResult();

                return new ShoppingCartProductViewModel
                {
                    Id = record.Id,
                    Currency = record.Currency,
                    Price = record.Price,
                    ProductId = record.ProductId,
                    Product = new CommonViewModel { Id = product.Id, Description = product.Title},
                    Quantity = record.Quantity,
                    ShoppingCartId = record.ShoppingCartId,
                };
            })
            .ToArray());
        }
    }
}
