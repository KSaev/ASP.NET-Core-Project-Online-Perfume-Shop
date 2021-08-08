using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePerfumeShop.Services.Models
{
    public class ShoppingCartPerfumeServiceModel
    {
        public int Id { get; set; }
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public int Quantity { get; set; }
        public string ImageUrl { get; init; }
        public int CategoryId { get; init; }
        public IEnumerable<GetCategoriesServiceModel> Categories { get; set; }
        public int BrandId { get; set; }
        public IEnumerable<GetBrandsServiceModel> Brands { get; set; }
    }
}
