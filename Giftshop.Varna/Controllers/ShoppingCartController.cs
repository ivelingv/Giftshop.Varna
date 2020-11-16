using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Giftshop.Varna.Database.Models;
using Giftshop.Varna.Models;
using Giftshop.Varna.Services;
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
    }
}
