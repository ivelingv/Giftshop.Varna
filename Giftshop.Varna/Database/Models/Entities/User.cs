using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giftshop.Varna.Database.Models
{
    public class User : DatabaseModel
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public UserStatus Status { get; set; }
        public UserType Type { get; set; }
        public virtual IEnumerable<UserAddress> Addresses { get; set; }
        public virtual IEnumerable<ShoppingCart> Carts { get; set; }
    }
}
