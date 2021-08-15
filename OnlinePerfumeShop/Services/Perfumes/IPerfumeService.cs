namespace OnlinePerfumeShop.Services.Perfumes
{
    using OnlinePerfumeShop.Areas.Admin.Models.Perfumes;
    using OnlinePerfumeShop.Data.Models;
    using OnlinePerfumeShop.Services.Models;
    using System.Collections.Generic;
    using System.Linq;

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
        public int GetCount();
        public int GetWomenCount();
        public int GetMenCount();
        public IEnumerable<ListPerfumesServiceModel> Men(int page, int itemsPerPage);
        public IEnumerable<ListPerfumesServiceModel> Women(int page, int itemsPerPage);
        public IQueryable<Perfume> GetById(int id);
        public IEnumerable<GetCategoriesServiceModel> GetCategories();

        public IEnumerable<GetBrandsServiceModel> GetBrands();

        void Update(int id,EditPerfumeInputModel model);
        public void Delete(int id);
    }
}
