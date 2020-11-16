namespace Giftshop.Varna.Models
{
    public class CategoryModel : UxModel
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public long UserId { get; set; }
    }
}
