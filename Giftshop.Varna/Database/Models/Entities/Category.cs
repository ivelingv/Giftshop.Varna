using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giftshop.Varna.Database.Models
{

    public class Category : DatabaseModel
    {
        public long UserId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public virtual User User { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}
