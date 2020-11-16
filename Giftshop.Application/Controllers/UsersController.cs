using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Giftshop.Application.Models;
using System.Linq;
using Giftshop.Application.Contracts;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Giftshop.Application.Models.Enumerations;
using Microsoft.AspNetCore.Authorization;

namespace Giftshop.Application.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UsersController : Controller
    {
        private readonly IUsersService service;

        public UsersController(IUsersService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var records = await service.GetAllAsync();

            return View(records.Where(e => e.Status == UserStatus.Active || e.Status == UserStatus.Blocked)
                .Select(record => new UserViewModel
            {
                Id = record.Id,
                Name = record.Name,
                Username = record.Username,
                Password = record.Password,
                Status = record.Status,
                Type = record.Type,
            }));
        }

        [HttpGet]
        public async Task<IActionResult> Details([Required] long id)
        {
            var record = await service.GetAsync(id);

            return View(new UserViewModel
            {
                Id = record.Id,
                Name = record.Name,
                Username = record.Username,
                Password = record.Password,
                Status = record.Status,
                Type = record.Type,
            });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel userViewModel)
        {
            var record = await service.CreateAsync(new UserModel
            {
                Name = userViewModel.Name,
                Username = userViewModel.Username,
                Password = userViewModel.Password,
                Status  = userViewModel.Status,
                Type = userViewModel.Type,
            });

            return RedirectToAction(nameof(Details), new { id = record.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit([Required] long id)
        {
            var record = await service.GetAsync(id);

            return View(new UserViewModel
            {
                Id = record.Id,
                Name = record.Name,
                Username = record.Username,
                Password = record.Password,
                Status = record.Status,
                Type = record.Type,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Required] long id, [Required] UserViewModel userViewModel)
        {
            var record = await service.UpdateAsync(id, new UserModel
            {
                Id = userViewModel.Id,
                Name = userViewModel.Name,
                Username = userViewModel.Username,
                Password = userViewModel.Password,
                Status = userViewModel.Status,
                Type = userViewModel.Type,
            });

            return RedirectToAction(nameof(Details), new { id = record.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete([Required] long id)
        {
            var record = await service.GetAsync(id);

            return View(new UserViewModel
            {
                Id = record.Id,
                Name = record.Name,
                Username = record.Username,
                Password = record.Password,
                Status = record.Status,
                Type = record.Type,
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
