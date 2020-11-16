using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Giftshop.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Giftshop.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Giftshop.Application.Contracts.Models;

namespace Giftshop.Application.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITokenService _tokenService;

        public HomeController(ILogger<HomeController> logger, ITokenService tokenService)
        {
            _logger = logger;
            _tokenService = tokenService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult LoginAdministrator()
        {
            if (HttpContext.User.Identity.IsAuthenticated 
                && HttpContext.User.IsInRole("Administrator"))
            {
                return RedirectToAction(nameof(Index), "ShoppingCarts");
            }

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult LoginCustomer()
        {
            if (HttpContext.User.Identity.IsAuthenticated 
                && HttpContext.User.IsInRole("Client"))
            {
                return RedirectToAction(nameof(Index), "ShoppingCarts");
            }

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _tokenService.RegisterCustomer(new RegisterRequest
            {
                Name = registerViewModel.Name,
                Password = registerViewModel.Password,
                Username = registerViewModel.Username,
            });

            if (result.Token != null)
            {
                Response.Cookies.Append("AuthCookie", result.Token, new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Lax,
                    Domain = Request.PathBase,
                    Expires = DateTime.Now.AddHours(1),
                });

                return RedirectToAction(nameof(Index), "ShoppingCarts");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("AuthCookie");
            if (!User.IsInRole("Client"))
            {
                return RedirectToAction(nameof(LoginAdministrator));
            }
            else
            {
                return RedirectToAction(nameof(LoginCustomer));
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginCustomer(LoginViewModel model)
        {
            var result = await _tokenService.CustomerLogin(new Varna.Models.LoginRequest
            {
                Password = model.Password,
                Username = model.Username,
            });

            if (result.Token != null)
            {
                Response.Cookies.Append("AuthCookie", result.Token, new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Lax,
                    Domain = Request.PathBase,
                    Expires = DateTime.Now.AddHours(1),
                });

                return RedirectToAction(nameof(Index), "ShoppingCarts");
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAdministrator(LoginViewModel model)
        {
            var result = await _tokenService.AdministartorLogin(new Varna.Models.LoginRequest
            {
                Password = model.Password,
                Username = model.Username,
            });

            if (result.Token != null)
            {
                Response.Cookies.Append("AuthCookie", result.Token, new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Lax,
                    Domain = Request.PathBase,
                    Expires = DateTime.Now.AddHours(1),
                });

                return RedirectToAction(nameof(Index), "ShoppingCarts");
            }

            return View();
        }
    }
}
