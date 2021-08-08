using OnlinePerfumeShop.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePerfumeShop.Models.ShoppingCarts
{
    public class AllPerfumesInCartViewModel
    {
        public IEnumerable<ShoppingCartServiceModel> Perfumes { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
