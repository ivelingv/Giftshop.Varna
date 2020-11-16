using System;

namespace Giftshop.Application.Contracts.Models
{
    public class LoginResponse
    {
        public string Token { get; set; }

        public string Shema { get; set; }

        public DateTime ValidTo { get; set; }
    }
}
