using Giftshop.Varna.Models;

namespace Giftshop.Varna.Models
{
    public class ShoppingCartProductModel : UxModel
    {
        public long ProductId { get; set; }

        public long ShoppingCartId { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public string Currency { get; set; }
    }
}
