using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giftshop.Varna.Database.Models
{
    public class UserAddress : DatabaseModel
    {
        public long UserId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public virtual User User { get; set; }
        public bool IsActive { get; set; }
    }
}
