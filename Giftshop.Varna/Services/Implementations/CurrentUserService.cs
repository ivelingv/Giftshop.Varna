using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Giftshop.Varna.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public long GetCurrentUserId()
        {
            if (!httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return default;
            }

            var userId = httpContextAccessor.HttpContext.User
                ?.Claims
                ?.FirstOrDefault(e => e.Type == "id")
                ?.Value;

            return long.Parse(userId);
        }

        public bool IsAdministrator()
        {
            return httpContextAccessor.HttpContext.User?
                .IsInRole("Administrator") ?? false;
        }
    }
}
