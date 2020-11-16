using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Giftshop.Application.Models;
using Giftshop.Application.Contracts;
using Giftshop.Application.Services;
using Giftshop.Application.Contracts.Models;
using Microsoft.AspNetCore.Authorization;

namespace Giftshop.Application.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ProductsController : Controller
    {
        private readonly IProductsService _service;
        private readonly ICurrentUserService _currentUser;

        public ProductsController(IProductsService service, ICurrentUserService currentUser)
        {
            _service = service;
            _currentUser = currentUser;
        }

        [HttpGet]
        public async Task<IActionResult> Index(long id)
        {
            var records = await _service.GetByCategoryAsync(id);
            ViewBag.CategoryId = id;

            return View(records.Where(e => e.IsActive)
                .Select(e => new ProductViewModel
                {
                    Id = e.Id,
                    IsActive = e.IsActive,
                    Description = e.Description,
                    Title = e.Title,
                    Currency = e.Currency,
                    CategoryId = e.CategoryId,
                    Price = e.Price,
                    Image = e.Image,
                    Rating = e.Rating,
                    ViewCount = e.ViewCount,
                    UserId = e.UserId,
                })
                .ToArray());
        }

        [HttpGet]
        public async Task<IActionResult> Details(long id)
        {
            var record = await _service.GetAsync(id);

            return View(new ProductViewModel
            {
                Id = record.Id,
                IsActive = record.IsActive,
                Description = record.Description,
                Title = record.Title,
                Currency = record.Currency,
                CategoryId = record.CategoryId,
                Price = record.Price,
                Image = record.Image,
                Rating = record.Rating,
                ViewCount = record.ViewCount,
                UserId = record.UserId,
            });
        }

        [HttpGet]
        public IActionResult Create([FromRoute] long id)
        {
            return View(new ProductViewModel
            {
                IsActive = true,
                CategoryId = id,
                UserId = _currentUser.UserId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {

            var record = await _service.CreateAsync(new ProductModel
            {
                IsActive = productViewModel.IsActive,
                Description = productViewModel.Description,
                Title = productViewModel.Title,
                Currency = productViewModel.Currency,
                CategoryId = productViewModel.CategoryId,
                Price = productViewModel.Price,
                Image = productViewModel.Image,
                Rating = productViewModel.Rating,
                ViewCount = productViewModel.ViewCount,
                UserId = _currentUser.UserId,
            });

            return RedirectToAction(nameof(Details), new { id = record.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var record = await _service.GetAsync(id);

            return View(new ProductViewModel
            {
                Id = record.Id,
                IsActive = record.IsActive,
                Description = record.Description,
                Title = record.Title,
                Currency = record.Currency,
                CategoryId = record.CategoryId,
                Price = record.Price,
                Image = record.Image,
                Rating = record.Rating,
                ViewCount = record.ViewCount,
                UserId = record.UserId,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, ProductViewModel productViewModel)
        {
            var category = await _service.UpdateAsync(productViewModel.Id, new ProductModel
            {
                Id = productViewModel.Id,
                IsActive = productViewModel.IsActive,
                Description = productViewModel.Description,
                Title = productViewModel.Title,
                Currency = productViewModel.Currency,
                CategoryId = productViewModel.CategoryId,
                Price = productViewModel.Price,
                Image = productViewModel.Image,
                Rating = productViewModel.Rating,
                ViewCount = productViewModel.ViewCount,
                UserId = _currentUser.UserId,
            });

            return RedirectToAction(nameof(Details), new { id = category.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var record = await _service.GetAsync(id);

            return View(new ProductViewModel
            {
                Id = record.Id,
                IsActive = record.IsActive,
                Description = record.Description,
                Title = record.Title,
                Currency = record.Currency,
                CategoryId = record.CategoryId,
                Price = record.Price,
                Image = record.Image,
                Rating = record.Rating,
                ViewCount = record.ViewCount,
                UserId = record.UserId,
            });
        }

        [HttpPost, ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var category = await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
