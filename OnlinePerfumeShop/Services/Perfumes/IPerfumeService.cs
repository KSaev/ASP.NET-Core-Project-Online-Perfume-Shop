using OnlinePerfumeShop.Areas.Admin.Models.Perfumes;
using OnlinePerfumeShop.Data.Models;
using OnlinePerfumeShop.Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePerfumeShop.Services.Perfumes
{
    public interface IPerfumeService
    {
        PerfumeDetailsServiceModel GetDetails(int id);             

        void Create(string name
            ,string desctription
            ,string imgUrl
            ,decimal price
            ,int categoryId
            ,int quantity
            ,int brandId);

        public IQueryable<Perfume> GetById(int id);
        public IEnumerable<GetCategoriesServiceModel> GetCategories();

        public IEnumerable<GetBrandsServiceModel> GetBrands();

        void Update(int id,EditPerfumeInputModel model);
        public void Delete(int id);
    }
}
