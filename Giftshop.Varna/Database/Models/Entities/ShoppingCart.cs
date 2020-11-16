using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giftshop.Varna.Database.Models
{
    public class ShoppingCart : DatabaseModel
    {
        public double TotalPrice { get; set; }
        public string Currency { get; set; }
        public string Comment { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public ShoppingCartStatus Status { get; set; }
        public long UserId { get; set; }
        public long DeliveryAddressId { get; set; }
        public virtual User User { get; set; }
        public virtual IEnumerable<ShoppingCartProduct> Products { get; set; }
        public virtual UserAddress DeliveryAddress { get; set; }
    }
}
