using System;

namespace Giftshop.Varna.Models
{
    public class LoginResponse
    {
        public string Token { get; set; }

        public string Shema { get; set; }

        public DateTime ValidTo { get; set; }
    }
}
