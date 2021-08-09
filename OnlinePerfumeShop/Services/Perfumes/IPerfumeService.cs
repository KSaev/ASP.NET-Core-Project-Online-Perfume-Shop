using OnlinePerfumeShop.Data.Models;
using OnlinePerfumeShop.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePerfumeShop.Services.Perfumes
{
    public interface IPerfumeService
    {
        PerfumeDetailsServiceModel GetDetails(int id, string userId);             

        void Create(string name
            ,string desctription
            ,string imgUrl
            ,decimal price
            ,int categoryId
            ,int quantity
            ,int brandId);

        public IEnumerable<GetCategoriesServiceModel> GetCategories();

        public IEnumerable<GetBrandsServiceModel> GetBrands();        
    }
}
