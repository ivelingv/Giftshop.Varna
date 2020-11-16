using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

namespace Giftshop.Varna.Database.Models
{
    public class Product : DatabaseModel
    {
        public long CategoryId { get; set; }
        public long UserId { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int ViewCount { get; set; }
        public int Rating { get; set; }
        public bool IsActive { get; set; }
        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
    }
}
