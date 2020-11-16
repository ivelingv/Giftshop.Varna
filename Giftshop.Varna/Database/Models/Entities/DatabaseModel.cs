using System;

namespace Giftshop.Varna.Database.Models
{
    public abstract class DatabaseModel
    {
        public long Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
