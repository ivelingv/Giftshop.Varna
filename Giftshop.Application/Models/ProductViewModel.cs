namespace Giftshop.Application.Models
{
    public class ProductViewModel : ViewModel
    {
        public long CategoryId { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int ViewCount { get; set; }
        public int Rating { get; set; }
        public bool IsActive { get; set; }
        public long UserId { get; set; }
    }
}
