using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giftshop.Varna.Database.Models
{
    public class ShoppingCartProduct : DatabaseModel
    {
        public long ProductId { get; set; }

        public long ShoppingCartId { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public string Currency { get; set; }

        public virtual Product Product { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
