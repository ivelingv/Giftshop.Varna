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
    public class ShoppingCartProductController : ApiController<IShoppingCartProductService,
        ShoppingCartProduct,
        ShoppingCartProductModel>
    {
        public ShoppingCartProductController(IShoppingCartProductService service, IMapper mapper) 
            : base(service, mapper)
        {
        }

        [HttpPost]
        [Route(nameof(Create))]
        [Authorize(Roles ="Administrator, Client")]
        public override IActionResult Create([FromBody, Required] ShoppingCartProductModel model)
        {
            return base.Create(model);
        }

        [HttpGet]
        [Route("GetByShoppingCart/{shoppingCartId}")]
        [Authorize(Roles = "Administrator, Client")]
        public IActionResult GetByShoppingCart(long shoppingCartId)
        {
            var products = Service.GetByShoppingCart(shoppingCartId);
            return Ok(products);
        }

        [HttpPatch]
        [Route("Update/{id}")]
        [Authorize(Roles = "Administrator, Client")]
        public override IActionResult Update([FromRoute, Required] long id, [Required] ShoppingCartProductModel model)
        {
            return base.Update(id, model);
        }

    }
}
