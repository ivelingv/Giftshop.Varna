using Giftshop.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giftshop.Application.Contracts
{
    public interface IUsersService
    {
        [Get("/api/User/GetAll")]
        Task<IEnumerable<UserModel>> GetAllAsync();

        [Get("/api/User/Get/{id}")]
        Task<UserModel> GetAsync([FromRoute] long id);

        [Post("/api/User/Create")]
        Task<UserModel> CreateAsync([FromBody] UserModel model);

        [Patch("/api/User/Update/{id}")]
        Task<UserModel> UpdateAsync([FromRoute] long id, [FromBody] UserModel model);

        [Delete("/api/User/Delete/{id}")]
        Task<UserModel> DeleteAsync([FromRoute] long id);
    }
}
