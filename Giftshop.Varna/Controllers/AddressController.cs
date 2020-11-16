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
    public class AddressController : ApiController<IAddressService, UserAddress, UserAddressModel>
    {
        public AddressController(IAddressService service, IMapper mapper)
            : base(service, mapper)
        {
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [Authorize(Roles = "Administrator")]
        public override IActionResult Delete([FromRoute, Required] long id)
        {
            var deletedEntry = Service.Delete(id);
            return Ok(deletedEntry);
        }

        [HttpGet]
        [Route("GetByUser/{userId}")]
        public IActionResult GetByUser([FromRoute, Required] long userId)
        {
            var addresses = Service.GetByUser(userId);
            return Ok(addresses);
        }
    }
}
