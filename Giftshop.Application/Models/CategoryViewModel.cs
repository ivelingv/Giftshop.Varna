namespace Giftshop.Application.Models
{
    public class CategoryViewModel : ViewModel
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public long UserId { get; set; }
    }
}
