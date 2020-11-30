using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Giftshop.Application.Contracts;
using Giftshop.Application.Models;
using Giftshop.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Giftshop.Application.Controllers
{
    [Authorize(Roles = "Client")]
    public class CatalogueController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly IShoppingCartProductsService _shoppingCartProductsService;
        private readonly IShoppingCartsService _shoppingCartsService;
        private readonly ICurrentUserService _userService;
        private readonly IAddressesService _addressesService;

        public CatalogueController(IProductsService productsService, 
            IShoppingCartProductsService shoppingCartProductsService, 
            IShoppingCartsService shoppingCartsService, 
            ICurrentUserService userService,
            IAddressesService addressesService)
        {
            _productsService = productsService;
            _shoppingCartProductsService = shoppingCartProductsService;
            _shoppingCartsService = shoppingCartsService;
            _userService = userService;
            _addressesService = addressesService;
        }

        [HttpGet]
        public async Task<IActionResult> Orders()
        {
            var results = new List<OrderHistoryViewModel>();
            var orders = await _shoppingCartsService.GetUserOrdersAsync(_userService.UserId);

            foreach (var order in orders)
            {
                var address = await _addressesService.GetAsync(order.DeliveryAddressId);
                var orderItems = await _shoppingCartProductsService.GetByShoppingCart(order.Id);
                var produtViewModels = new List<ShoppingCartProductViewModel>();

                foreach (var item in orderItems)
                {
                    var product = await _productsService.GetAsync(item.ProductId);
                    produtViewModels.Add(new ShoppingCartProductViewModel
                    {
                        ProductId = item.ProductId,
                        Currency = item.Currency,
                        Product = new CommonViewModel { Id = item.ProductId, Description = product.Title },
                        Price = item.Price,
                        Quantity = item.Quantity,
                        ShoppingCartId = item.ShoppingCartId,
                        Id = item.Id,
                    });
                }

                results.Add(new OrderHistoryViewModel
                {
                    Id = order.Id,
                    Status = order.Status,
                    CreateDate = order.CreateDate,
                    PaymentMethod = order.PaymentMethod,
                    DeliveryAddressId = order.DeliveryAddressId,
                    Comment = order.Comment,
                    Currency = order.Currency,
                    TotalPrice = order.TotalPrice,
                    UserId = _userService.UserId,
                    Products = produtViewModels,
                    DeliveryAddress = new CommonViewModel { Id = address.Id, Description = address.ToString() }
                });
            }

            return View(results);
        }

        [HttpGet]
        public async Task<IActionResult> Checkout(long[] products)
        {
            var order = (await _shoppingCartsService.GetUserOrdersAsync(_userService.UserId))
                .Where(e => e.Status == Models.Enumerations.ShoppingCartStatus.None)
                .OrderByDescending(e => e.Id)
                .FirstOrDefault();


            if (order is null)
            {
                var defaultAddress = (await _addressesService.GetByUserAsync(_userService.UserId))
                    .Where(e => e.IsActive)
                    .FirstOrDefault();

                order = await _shoppingCartsService.CreateAsync(new Contracts.Models.ShoppingCartModel
                {
                    Currency = "EUR",
                    PaymentMethod = Models.Enumerations.PaymentMethod.Cash,
                    Status = Models.Enumerations.ShoppingCartStatus.None,
                    UserId = _userService.UserId,
                    DeliveryAddressId = defaultAddress.Id,
                });
            }

            var orders = await _shoppingCartsService.GetUserOrdersAsync(_userService.UserId);
            var address = await _addressesService.GetAsync(order.DeliveryAddressId);
            var cardProducts = new List<ShoppingCartProductViewModel>();

            foreach (var item in products.Distinct())
            {
                var product = await _productsService.GetAsync(item);
                cardProducts.Add(new ShoppingCartProductViewModel
                {
                    ProductId = product.Id,
                    Currency = product.Currency,
                    Product = new CommonViewModel { Id = product.Id, Description = product.Title },
                    Price = product.Price,
                    Quantity = products.Count(e => e == product.Id),
                    ShoppingCartId = order.Id,
                });
            }

            return View(new OrderHistoryViewModel
            {
                Id = order.Id,
                Status = order.Status,
                CreateDate = order.CreateDate,
                PaymentMethod = order.PaymentMethod,
                DeliveryAddressId = order.DeliveryAddressId,
                Comment = order.Comment,
                Currency = order.Currency,
                TotalPrice = cardProducts.Sum(e => e.Price * e.Quantity),
                UserId = _userService.UserId,
                Products = cardProducts,
                DeliveryAddress = new CommonViewModel { Id = address.Id, Description = address.ToString() }
            });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var products = await _productsService.GetProducts();
            return View(products.Select(e => new ProductViewModel
            {
                Id = e.Id,
                IsActive = e.IsActive,
                Description = e.Description,
                Title = e.Title,
                Currency = e.Currency,
                CategoryId = e.CategoryId,
                Price = e.Price,
                Image = "https://cdn.shopify.com/s/files/1/2112/9639/products/11_dedb91d9-77ab-4f8e-9ca9-3919eea9456d_grande.jpg?v=1499581461",
                Rating = e.Rating,
                ViewCount = e.ViewCount,
                UserId = e.UserId,
            }));
        }
    }
}
