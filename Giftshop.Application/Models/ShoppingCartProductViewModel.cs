using Giftshop.Varna.Models;

namespace Giftshop.Application.Models
{
    public class ShoppingCartProductViewModel : ViewModel
    {
        public long ProductId { get; set; }

        public long ShoppingCartId { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public string Currency { get; set; }

        public CommonViewModel Product { get; set; }
    }
}
