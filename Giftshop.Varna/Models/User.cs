namespace Giftshop.Varna.Models
{
    public class UserModel : UxModel
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
    }
}
