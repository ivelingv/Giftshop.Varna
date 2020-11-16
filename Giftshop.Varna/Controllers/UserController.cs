using AutoMapper;
using Giftshop.Varna.Database.Models;
using Giftshop.Varna.Models;
using Giftshop.Varna.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Giftshop.Varna.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UserController : ApiController<IUserService, User, UserModel>
    {
        public UserController(IUserService service, IMapper mapper) 
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
    }
}
