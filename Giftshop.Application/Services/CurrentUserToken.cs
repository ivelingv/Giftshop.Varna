using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giftshop.Application.Services
{
    public class CurrentUserTokenService : ICurrentUserTokenService
    {
        private string _token;

        public string GetToken()
        {
            return _token;
        }

        public void SetToken(string token)
        {
            _token = token;
        }
    }
}
