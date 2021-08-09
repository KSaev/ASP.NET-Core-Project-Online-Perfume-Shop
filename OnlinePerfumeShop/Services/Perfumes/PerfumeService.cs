using OnlinePerfumeShop.Data;
using OnlinePerfumeShop.Data.Models;
using OnlinePerfumeShop.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePerfumeShop.Services.Perfumes
{
    public class PerfumeService : IPerfumeService
    {
        private readonly OnlinePerfumeShopDbContext dbContext;

        public PerfumeService(OnlinePerfumeShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(string name
            , string desctription
            , string imgUrl
            , decimal price
            , int categoryId
            , int quantity
            , int brandId)
        {
            var perfume = new Perfume
            {
                Name = name,
                Desctription = desctription,
                ImageUrl = imgUrl,
                Price = price,
                CategoryId = categoryId,
                Qunatity = quantity,
                BrandId = brandId,
            };

            dbContext.Perfumes.Add(perfume);
            dbContext.SaveChanges();
        }

        public PerfumeDetailsServiceModel GetDetails(int id, string userId) 
        {
            return dbContext.Perfumes
               .Where(x => x.Id == id)
               .Select(x => new PerfumeDetailsServiceModel
               {
                   Brand = x.Brand.Name,
                   Desctripion = x.Desctription,
                   Id = id,
                   Name = x.Name,
                   Price = x.Price,
                   Quantity = x.Qunatity,
                   ImgUrl = x.ImageUrl,
                   Category = x.Category.Name,
                   UserId = userId,
               })
               .FirstOrDefault();
        }   
        public IEnumerable<GetCategoriesServiceModel> GetCategories()
        {
            return this.dbContext
           .Categories
           .Select(x => new GetCategoriesServiceModel
           {
               Id = x.Id,
               Name = x.Name,
           })
           .OrderBy(x => x.Name)
           .ToList();
        }
        public IEnumerable<GetBrandsServiceModel> GetBrands()
        {
            return this.dbContext
               .Brands
               .Select(x => new GetBrandsServiceModel
               {
                   Id = x.Id,
                   Name = x.Name,
               })
               .OrderBy(x => x.Name)
               .ToList();
        }      
    }
}
