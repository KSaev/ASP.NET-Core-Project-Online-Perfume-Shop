using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePerfumeShop.Services.Models
{
    public class ListPerfumesServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
        public int Quantity { get; set; }
      


    }
}
