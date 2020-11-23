using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Giftshop.Application.Models;
using Giftshop.Application.Services;
using Giftshop.Application.Contracts;
using Giftshop.Application.Models.Enumerations;
using Giftshop.Application.Contracts.Models;
using Microsoft.AspNetCore.Authorization;
using static Giftshop.Application.Constants;

namespace Giftshop.Application.Controllers
{
    [Authorize(Roles = AdministratorRole)]
    public class ShoppingCartsController : Controller
    {
        private readonly IShoppingCartsService _service;
        private readonly IAddressesService _addressesService;
        private readonly IUsersService _usersService;
        private readonly ICurrentUserService _currentUser;

        public ShoppingCartsController(IShoppingCartsService service, IAddressesService addressesService, IUsersService usersService, ICurrentUserService currentUser)
        {
            _service = service;
            _addressesService = addressesService;
            _usersService = usersService;
            _currentUser = currentUser;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var records = await _service.GetAllAsync();

            return View(records.Where(e => e.Status != (int)ShoppingCartStatus.None)
                .Select(record => new ShoppingCartViewModel
                {
                    Id = record.Id,
                    Status = record.Status,
                    PaymentMethod = record.PaymentMethod,
                    DeliveryAddressId = record.DeliveryAddressId,
                    Comment = record.Comment,
                    Currency = record.Currency,
                    TotalPrice = record.TotalPrice,
                    UserId = record.UserId,
                })
                .ToArray());
        }

        [HttpGet]
        public async Task<IActionResult> Details(long id)
        {
            var record = await _service.GetAsync(id);
            var addresses = await _addressesService.GetAsync(record.DeliveryAddressId);
            var user = await _usersService.GetAsync(record.UserId);

            return View(new ShoppingCartViewModel
            {
                Id = record.Id,
                Status = record.Status,
                PaymentMethod = record.PaymentMethod,
                DeliveryAddress = new CommonViewModel { Id = addresses.Id, Description = addresses.ToString() },
                User = new CommonViewModel { Id = user.Id, Description = user.Name },
                Comment = record.Comment,
                Currency = record.Currency,
                TotalPrice = record.TotalPrice,
            });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var record = await _service.GetAsync(id);
            var addresses = await _addressesService.GetByUserAsync(record.UserId);
            var user = await _usersService.GetAsync(record.UserId);

            return View(new ShoppingCartViewModel
            {
                Id = record.Id,
                Status = record.Status,
                PaymentMethod = record.PaymentMethod,
                DeliveryAddressId = record.DeliveryAddressId,
                Comment = record.Comment,
                Currency = record.Currency,
                TotalPrice = record.TotalPrice,
                UserAddresses = addresses.Where(e => e.IsActive).Select(e => new CommonViewModel
                {
                    Id = e.Id,
                    Description = e.ToString()
                }),
                User = new CommonViewModel
                {
                    Id = user.Id,
                    Description = user.Name,
                },
                UserId = record.UserId,
            }); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, ShoppingCartViewModel shoppingCartViewModel)
        {
            var category = await _service.UpdateAsync(shoppingCartViewModel.Id, new ShoppingCartModel
            {
                Id = shoppingCartViewModel.Id,
                Status = shoppingCartViewModel.Status,
                PaymentMethod = shoppingCartViewModel.PaymentMethod,
                DeliveryAddressId = shoppingCartViewModel.DeliveryAddressId,
                Comment = shoppingCartViewModel.Comment,
                Currency = shoppingCartViewModel.Currency,
                TotalPrice = shoppingCartViewModel.TotalPrice,
                UserId = shoppingCartViewModel.UserId,
            });

            return RedirectToAction(nameof(Details), new { id = category.Id });
        }
    }
}
