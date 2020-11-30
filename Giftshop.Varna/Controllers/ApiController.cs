using AutoMapper;
using Giftshop.Varna.Database.Models;
using Giftshop.Varna.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Giftshop.Varna.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController<TService, TEntity, TUxModel> : ControllerBase
        where TService : IService<TEntity>
        where TEntity : DatabaseModel
    {
        protected readonly IMapper Mapper;
        protected readonly TService Service;

        protected ApiController(TService service, IMapper mapper)
        {
            Service = service;
            Mapper = mapper;
        }

        [HttpGet]
        [Route(nameof(GetAll))]
        public IActionResult GetAll()
        {
            var result = Service.Get()
                .Select(e => Convert(e))
                .ToArray();

            return Ok(result);
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult Get([FromRoute][Required] long id)
        {
            var result = Service.Get(id);
            return Ok(Convert(result));
        }

        [HttpPatch]
        [Route("Update/{id}")]
        public virtual IActionResult Update([FromRoute][Required] long id, [Required] TUxModel model)
        {
            var entity = Convert(model);
            Service.Update(id, entity);
            return Ok(model);
        }

        [HttpPost]
        [Route(nameof(Create))]
        public virtual IActionResult Create([FromBody][Required] TUxModel model)
        {
            var entity = Convert(model);
            Service.Save(entity);

            return Created(HttpContext.Request.Path, Convert(entity));
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public virtual IActionResult Delete([FromRoute][Required] long id)
        {
            return Ok();
        }

        protected virtual TUxModel Convert(TEntity entity)
        {
            return Mapper.Map<TUxModel>(entity);
        }

        protected virtual TEntity Convert(TUxModel model)
        {
            return Mapper.Map<TEntity>(model);
        }

        protected virtual TEntity Convert(TUxModel model, TEntity entity)
        {
            Mapper.Map(model, entity);
            return entity;
        }
    }
}
