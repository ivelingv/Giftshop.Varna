using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Giftshop.Application.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public long UserId => GetUserIdentifier();

        private long GetUserIdentifier()
        {
            if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var id = _contextAccessor.HttpContext.User.Claims
                    .First(e => e.Type == "id")
                    .Value;

                return long.Parse(id);
            }

            return 0;
        }
    }
}