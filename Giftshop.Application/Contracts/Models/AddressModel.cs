namespace Giftshop.Application.Models
{
    public class AddressModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return string.Join(", ", Country, PostalCode, City, AddressLine1, AddressLine2, AddressLine3);
        }
    }
}
