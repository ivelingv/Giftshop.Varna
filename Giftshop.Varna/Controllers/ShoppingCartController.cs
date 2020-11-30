using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Giftshop.Varna.Database.Models;
using Giftshop.Varna.Models;
using Giftshop.Varna.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Giftshop.Varna.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ApiController<IShoppingCartService, ShoppingCart, ShoppingCartModel>
    {
        public ShoppingCartController(IShoppingCartService service, IMapper mapper) 
            : base(service, mapper)
        {
        }

        [HttpGet]
        [Authorize(Roles = "Client")]
        [Route(nameof(GetUserOrders))]
        public IActionResult GetUserOrders([FromQuery] long userId)
        {
            var orders = Service.GetCartsByUserId(userId);

            return Ok(orders);
        }

        [HttpPost]
        [Route(nameof(Create))]
        [Authorize(Roles = "Administrator, Client")]
        public override IActionResult Create([FromBody, Required] ShoppingCartModel model)
        {
            return base.Create(model);
        }
    }
}
