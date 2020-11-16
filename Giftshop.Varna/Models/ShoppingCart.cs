namespace Giftshop.Varna.Models
{
    public class ShoppingCartModel : UxModel
    {
        public double TotalPrice { get; set; }
        public string Currency { get; set; }
        public string Comment { get; set; }
        public int PaymentMethod { get; set; }
        public int Status { get; set; }
        public long UserId { get; set; }
        public long DeliveryAddressId { get; set; }
    }
}
