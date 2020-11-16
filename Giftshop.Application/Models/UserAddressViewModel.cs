using System.Collections.Generic;
using System.ComponentModel;

namespace Giftshop.Application.Models
{
    public class UserAddressViewModel : ViewModel
    {
        public long UserId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

        [DisplayName("Address Line 1")]
        public string AddressLine1 { get; set; }

        [DisplayName("Address Line 2")]
        public string AddressLine2 { get; set; }

        [DisplayName("Address Line 3")]
        public string AddressLine3 { get; set; }

        public bool IsActive { get; set; }
    }
}
