using Giftshop.Application.Models.Enumerations;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Giftshop.Application.Models
{
    public class ShoppingCartViewModel : ViewModel
    {
        [DisplayName("Total Amount")]
        [Required]
        [Range(0.01, double.PositiveInfinity)]
        public double TotalPrice { get; set; }

        [DisplayName("Currency")]
        [Required]
        [MaxLength(3)]
        public string Currency { get; set; }

        [DisplayName("Comment")]
        [MaxLength(2048)]
        public string Comment { get; set; }

        [DisplayName("Payment")]
        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        [DisplayName("Status")]
        [Required]
        public ShoppingCartStatus Status { get; set; }

        [DisplayName("Customer")]
        [Required]
        public long UserId { get; set; }

        [DisplayName("Delivery Address")]
        [Required]
        public long DeliveryAddressId { get; set; }

        public CommonViewModel User { get; set; }

        public CommonViewModel DeliveryAddress { get; set; }

        public IEnumerable<CommonViewModel> UserAddresses { get; set; }
    }
}
