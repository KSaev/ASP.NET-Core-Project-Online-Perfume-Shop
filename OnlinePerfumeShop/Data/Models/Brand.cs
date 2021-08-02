using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OnlinePerfumeShop.Data.DataConstants;

namespace OnlinePerfumeShop.Data.Models
{
    public class Brand
    {
        public Brand()
        {
            this.Perfumes = new HashSet<Perfume>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Perfume> Perfumes { get; set; }
    }
}
