using Giftshop.Application.Contracts.Models;
using Giftshop.Varna.Models;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Threading.Tasks;

namespace Giftshop.Application.Contracts
{
    public interface ITokenService
    {
        [Post("/api/token/AdministartorLogin")]
        Task<LoginResponse> AdministartorLogin([FromBody] LoginRequest model);

        [Post("/api/token/CustomerLogin")]
        Task<LoginResponse> CustomerLogin([FromBody] LoginRequest model);

        [Post("/api/token/RegisterCustomer")]
        Task<LoginResponse> RegisterCustomer([FromBody] RegisterRequest model);
    }
}
