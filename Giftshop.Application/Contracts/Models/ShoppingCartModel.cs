using Giftshop.Application.Models.Enumerations;

namespace Giftshop.Application.Contracts.Models
{
    public class ShoppingCartModel
    {
        public long Id { get; set; }
        public double TotalPrice { get; set; }
        public string Currency { get; set; }
        public string Comment { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public ShoppingCartStatus Status { get; set; }
        public long UserId { get; set; }
        public long DeliveryAddressId { get; set; }
    }
}
