using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giftshop.Application.Models
{
    public class OrderHistoryViewModel : ShoppingCartViewModel
    {
        public IEnumerable<ShoppingCartProductViewModel> Products { get; set; }
    }
}
