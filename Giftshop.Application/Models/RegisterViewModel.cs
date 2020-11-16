using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Giftshop.Application.Models
{
    public class RegisterViewModel : ViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Name { get; set; }
    }

}
