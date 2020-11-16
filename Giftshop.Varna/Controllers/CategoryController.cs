using AutoMapper;
using Giftshop.Varna.Database.Models;
using Giftshop.Varna.Models;
using Giftshop.Varna.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Giftshop.Varna.Controllers
{
    public class CategoryController : ApiController<ICategoryService, Category, CategoryModel>
    {
        public CategoryController(ICategoryService service, IMapper mapper) 
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
