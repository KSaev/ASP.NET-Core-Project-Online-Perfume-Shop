using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePerfumeShop.Services.Models
{
    public class PerfumeDetailsServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string Desctripion { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice => Price + this.Price * 0.20m;
        public int Quantity { get; set; }

        public string UserId { get; set; }
    }
}
