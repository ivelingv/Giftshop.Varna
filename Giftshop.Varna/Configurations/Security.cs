using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Giftshop.Varna.Configurations
{
    public class Security
    {
        public string Key { get; set; }
        public string Aud { get; set; }
        public string Iss { get; set; }
        public int ValidHours { get; set; }
        public SymmetricSecurityKey SecurityKey 
            => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
    }
}
