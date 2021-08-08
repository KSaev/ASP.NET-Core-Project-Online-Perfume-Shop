using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePerfumeShop.Services.Models
{
    public class ShoppingCartServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public int Count { get; set; }
    }
}
