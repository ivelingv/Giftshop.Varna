using Giftshop.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giftshop.Application.Contracts
{
    public interface IAddressesService
    {
        [Get("/api/Address/GetAll")]
        Task<IEnumerable<AddressModel>> GetAllAsync();

        [Get("/api/Address/Get/{id}")]
        Task<AddressModel> GetAsync([FromRoute] long id);

        [Post("/api/Address/Create")]
        Task<AddressModel> CreateAsync([FromBody] AddressModel model);

        [Patch("/api/Address/Update/{id}")]
        Task<AddressModel> UpdateAsync([FromRoute] long id, [FromBody] AddressModel model);

        [Delete("/api/Address/Delete/{id}")]
        Task<AddressModel> DeleteAsync([FromRoute] long id);

        [Get("/api/Address/GetByUser/{userId}")]
        Task<IEnumerable<AddressModel>> GetByUserAsync([FromRoute] long userId);
    }
}
