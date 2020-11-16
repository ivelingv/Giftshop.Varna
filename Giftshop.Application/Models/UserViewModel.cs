using Giftshop.Application.Models.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace Giftshop.Application.Models
{
    public class UserViewModel : ViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public UserStatus Status { get; set; }
        [Required]
        public UserType Type { get; set; }
    }
}
