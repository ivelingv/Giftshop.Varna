using Giftshop.Application.Models.Enumerations;

namespace Giftshop.Application.Models
{
    public class UserModel
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public UserStatus Status { get; set; }
        public UserType Type { get; set; }
    }
}
