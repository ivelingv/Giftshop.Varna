using System.ComponentModel.DataAnnotations;

namespace Giftshop.Varna.Models
{
    public class RegisterRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }
    }

}
