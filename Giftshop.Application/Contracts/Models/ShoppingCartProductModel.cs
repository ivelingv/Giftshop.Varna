namespace Giftshop.Application.Contracts.Models
{
    public class ShoppingCartProductModel
    {
        public long Id { get; set; }

        public long ProductId { get; set; }

        public long ShoppingCartId { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public string Currency { get; set; }
    }
}
