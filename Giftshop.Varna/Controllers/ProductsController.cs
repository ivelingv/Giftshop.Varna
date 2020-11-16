using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Giftshop.Varna.Database.Models;
using Giftshop.Varna.Models;
using Giftshop.Varna.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Giftshop.Varna.Controllers
{
    public class ProductsController : ApiController<IProductService, Product, ProductModel>
    {
        public ProductsController(IProductService service, IMapper mapper) 
            : base(service, mapper)
        {

        }

        [HttpGet]
        [Route("GetByCategory/{categoryId}")]
        public IActionResult GetByCategory([FromRoute] [Required] long categoryId)
        {
            var products = Service.GetProductsByCategoryId(categoryId);
            return Ok(products);
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
