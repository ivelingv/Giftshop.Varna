using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Giftshop.Application.Models;
using Giftshop.Application.Contracts;
using Giftshop.Application.Services;
using Giftshop.Application.Contracts.Models;
using Microsoft.AspNetCore.Authorization;
using static Giftshop.Application.Constants;

namespace Giftshop.Application.Controllers
{
    [Authorize(Roles = AdministratorRole)]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _service;
        private readonly ICurrentUserService _currentUser;

        public CategoriesController(ICategoriesService service, ICurrentUserService currentUser)
        {
            _service = service;
            _currentUser = currentUser;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var records = await _service.GetAllAsync();
                
            return View(records.Where(e => e.IsActive)
                .Select(e => new CategoryViewModel
                {
                    Id = e.Id,
                    IsActive = e.IsActive,
                    Description = e.Description,
                    Title = e.Title,
                    UserId = e.UserId,
                })
                .ToArray());
        }

        [HttpGet]
        public async Task<IActionResult> Details(long id)
        {
            var record = await _service.GetAsync(id);

            return View(new CategoryViewModel
            {
                Id = record.Id,
                IsActive = record.IsActive,
                Description = record.Description,
                Title = record.Title,
                UserId = record.UserId,
            });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CategoryViewModel
            {
                IsActive = true,
                UserId = _currentUser.UserId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel categoryViewModel)
        {

            var record = await _service.CreateAsync(new CategoryModel
            {
                IsActive = categoryViewModel.IsActive,
                Description = categoryViewModel.Description,
                Title = categoryViewModel.Title,
                UserId = _currentUser.UserId,
            });

            return RedirectToAction(nameof(Details), new { id = record.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var record = await _service.GetAsync(id);

            return View(new CategoryViewModel
            {
                Id = record.Id,
                IsActive = record.IsActive,
                Description = record.Description,
                Title = record.Title,
                UserId = record.UserId,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, CategoryViewModel categoryViewModel)
        {
            var category = await _service.UpdateAsync(categoryViewModel.Id, new CategoryModel
            {
                Id = categoryViewModel.Id,
                IsActive = categoryViewModel.IsActive,
                Description = categoryViewModel.Description,
                Title = categoryViewModel.Title,
                UserId = _currentUser.UserId,
            });

            return RedirectToAction(nameof(Details), new { id = category.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var record = await _service.GetAsync(id);

            return View(new CategoryViewModel
            {
                Id = record.Id,
                IsActive = record.IsActive,
                Description = record.Description,
                Title = record.Title,
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
