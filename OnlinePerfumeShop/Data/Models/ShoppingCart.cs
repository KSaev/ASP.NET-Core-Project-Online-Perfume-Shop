using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePerfumeShop.Data.Models
{
    public class ShoppingCart
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public int PerfumeId { get; set; }

        public Perfume Perfume { get; set; }

        public int Quantity { get; set; }
    }
}
