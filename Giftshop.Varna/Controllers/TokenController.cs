using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Giftshop.Varna.Configurations;
using Giftshop.Varna.Model;
using Giftshop.Varna.Models;
using Giftshop.Varna.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Giftshop.Varna.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route(nameof(AdministartorLogin))]
        public IActionResult AdministartorLogin([FromBody] [Required] LoginRequest model)
        {
            return Ok(_tokenService.Login(model, Roles.Admin));
        }

        [HttpPost]
        [Route(nameof(CustomerLogin))]
        public IActionResult CustomerLogin([FromBody][Required] LoginRequest model)
        {
            return Ok(_tokenService.Login(model, Roles.Client));
        }


        [HttpPost]
        [Route(nameof(RegisterCustomer))]
        public IActionResult RegisterCustomer([FromBody][Required] RegisterRequest model)
        {
            return Ok(_tokenService.RegisterCustomer(model));
        }
    }
}
