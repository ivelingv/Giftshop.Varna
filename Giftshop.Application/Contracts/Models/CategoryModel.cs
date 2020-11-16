namespace Giftshop.Application.Contracts.Models
{
    public class CategoryModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public long UserId { get; set; }
    }
}
