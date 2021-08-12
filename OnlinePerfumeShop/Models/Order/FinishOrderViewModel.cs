using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePerfumeShop.Models.Order
{
    public class FinishOrderViewModel
    {
        public string UserName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public ICollection<PefumesOrderList> Perfumes { get; set; }
        public decimal Total => Perfumes.Sum(x => x.Total);
    }
}
