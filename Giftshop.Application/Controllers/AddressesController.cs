using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Giftshop.Application.Models;
using System.ComponentModel.DataAnnotations;
using Giftshop.Application.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace Giftshop.Application.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AddressesController : Controller
    {
        private readonly IAddressesService service;

        public AddressesController(IAddressesService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index(long id)
        {
            var records = await service.GetAllAsync();
            ViewBag.UserId = id;

            return View(records.Where(e => e.IsActive && e.UserId == id)
                .Select(record => new UserAddressViewModel
                {
                    Id = record.Id,
                    UserId = record.UserId,
                    City = record.City,
                    Country = record.Country,
                    PostalCode = record.PostalCode,
                    IsActive = record.IsActive,
                    AddressLine1 = record.AddressLine1,
                    AddressLine2 = record.AddressLine2,
                    AddressLine3 = record.AddressLine3,
                }));
        }

        [HttpGet]
        public async Task<IActionResult> Details([Required] long id)
        {
            var record = await service.GetAsync(id);

            return View(new UserAddressViewModel
            {
                Id = record.Id,
                UserId = record.UserId,
                City = record.City,
                Country = record.Country,
                PostalCode = record.PostalCode,
                IsActive = record.IsActive,
                AddressLine1 = record.AddressLine1,
                AddressLine2 = record.AddressLine2,
                AddressLine3 = record.AddressLine3,
            });
        }

        [HttpGet]
        public IActionResult Create([Required] long id)
        {
            return View(new UserAddressViewModel
            {
                UserId = id
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserAddressViewModel model)
        {
            var record = await service.CreateAsync(new AddressModel
            {
                UserId = model.UserId,
                City = model.City,
                Country = model.Country,
                PostalCode = model.PostalCode,
                IsActive = model.IsActive,
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                AddressLine3 = model.AddressLine3,
            });

            return RedirectToAction(nameof(Details), new { id = record.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit([Required] long id)
        {
            var record = await service.GetAsync(id);

            return View(new UserAddressViewModel
            {
                Id = record.Id,
                UserId = record.UserId,
                City = record.City,
                Country = record.Country,
                PostalCode = record.PostalCode,
                IsActive = record.IsActive,
                AddressLine1 = record.AddressLine1,
                AddressLine2 = record.AddressLine2,
                AddressLine3 = record.AddressLine3,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Required] long id, [Required] UserAddressViewModel model)
        {
            var record = await service.UpdateAsync(id, new AddressModel
            {
                Id = model.Id,
                UserId = model.UserId,
                City = model.City,
                Country = model.Country,
                PostalCode = model.PostalCode,
                IsActive = model.IsActive,
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                AddressLine3 = model.AddressLine3,
            });

            return RedirectToAction(nameof(Details), new { id = record.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete([Required] long id)
        {
            var record = await service.GetAsync(id);

            return View(new UserAddressViewModel
            {
                Id = record.Id,
                UserId = record.UserId,
                City = record.City,
                Country = record.Country,
                PostalCode = record.PostalCode,
                IsActive = record.IsActive,
                AddressLine1 = record.AddressLine1,
                AddressLine2 = record.AddressLine2,
                AddressLine3 = record.AddressLine3,
            });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var record = await service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
