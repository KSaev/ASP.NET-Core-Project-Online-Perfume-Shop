using OnlinePerfumeShop.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePerfumeShop.Services.Perfumes
{
    public interface IPerfumeService
    {
        IEnumerable<ListPerfumesServiceModel> All(int id,int itemsPerPage);

        void Create(string name
            ,string desctription
            ,string imgUrl
            ,decimal price
            ,int categoryId
            ,int quantity
            ,int brandId
            ,string userId);

        public IEnumerable<GetCategoriesServiceModel> GetCategories();

        public IEnumerable<GetBrandsServiceModel> GetBrands();

        public int GetCount();
    }
}
