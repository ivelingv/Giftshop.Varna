﻿namespace Giftshop.Varna.Models
{
    public class UserAddressModel : UxModel
    {
        public long UserId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public bool IsActive { get; set; }
    }
}
