namespace OnlinePerfumeShop.Services.Perfumes
{
    using System.Linq;
    using OnlinePerfumeShop.Areas.Admin.Models.Perfumes;
    using OnlinePerfumeShop.Data;
    using OnlinePerfumeShop.Data.Models;
    using OnlinePerfumeShop.Services.Models;
    using System.Collections.Generic;

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
        public IEnumerable<ListPerfumesServiceModel> Men(int page, int itemsPerPage)
        {
            return dbContext.Perfumes
                 .Where(x => x.CategoryId == 1)
                .OrderBy(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .Select(x => new ListPerfumesServiceModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    ImgUrl = x.ImageUrl,
                    Quantity = x.Qunatity,
                }).ToList();
        }
        public int GetCount()
        {
            return dbContext.Perfumes.Count();
        }
        public int GetWomenCount()
        {
            return dbContext.Perfumes.Where(x => x.CategoryId == 2).Count();
        }
        public int GetMenCount()
        {
            return dbContext.Perfumes.Where(x => x.CategoryId == 1).Count();
        }
        public IEnumerable<ListPerfumesServiceModel> Women(int page, int itemsPerPage)
        {
            return dbContext.Perfumes
                .Where(x => x.CategoryId == 2)
                .OrderBy(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .Select(x => new ListPerfumesServiceModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    ImgUrl = x.ImageUrl,
                    Quantity = x.Qunatity,
                }).ToList();
        }

        public PerfumeDetailsServiceModel GetDetails(int id) 
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

        public void Delete(int id)
        {
            var perfume = this.dbContext.Perfumes.Where(x => x.Id == id).FirstOrDefault();
            if (perfume == null)
            {
                return;
            }

            dbContext.Perfumes.Remove(perfume);
            dbContext.SaveChanges();
        }

        public IQueryable<Perfume> GetById(int id)
        {
            return this.dbContext.Perfumes.Where(x => x.Id == id);
        }

        public void Update(int id, EditPerfumeInputModel model)
        {
            var perfume = this.GetById(id).FirstOrDefault();

            perfume.Name = model.Name;
            perfume.Desctription = model.Description;
            perfume.ImageUrl = model.ImageUrl;
            perfume.CategoryId = model.CategoryId;
            perfume.BrandId = model.BrandId;
            perfume.Price = model.Price;
            perfume.Qunatity = model.Quantity;

            dbContext.SaveChanges();
        }

        public IEnumerable<ListPerfumesServiceModel> MenAscending(int page, int itemsPerPage)
        {
            return dbContext.Perfumes
             .Where(x => x.CategoryId == 1)
             .OrderBy(x => x.Price)
             .Skip((page - 1) * itemsPerPage)
             .Take(itemsPerPage)
             .Select(x => new ListPerfumesServiceModel
             {
                 Id = x.Id,
                 Name = x.Name,
                 Price = x.Price,
                 ImgUrl = x.ImageUrl,
                 Quantity = x.Qunatity,
             }).ToList();
        }

        public IEnumerable<ListPerfumesServiceModel> MenDescending(int page, int itemsPerPage)
        {
            return dbContext.Perfumes
           .Where(x => x.CategoryId == 1)
           .OrderByDescending(x => x.Price)
           .Skip((page - 1) * itemsPerPage)
           .Take(itemsPerPage)
           .Select(x => new ListPerfumesServiceModel
           {
               Id = x.Id,
               Name = x.Name,
               Price = x.Price,
               ImgUrl = x.ImageUrl,
               Quantity = x.Qunatity,
           }).ToList();
        }

        public IEnumerable<ListPerfumesServiceModel> WomenAscending(int page, int itemsPerPage)
        {
            return dbContext.Perfumes
              .Where(x => x.CategoryId == 2)
              .OrderBy(x => x.Price)
              .Skip((page - 1) * itemsPerPage)
              .Take(itemsPerPage)
              .Select(x => new ListPerfumesServiceModel
              {
                  Id = x.Id,
                  Name = x.Name,
                  Price = x.Price,
                  ImgUrl = x.ImageUrl,
                  Quantity = x.Qunatity,
              }).ToList();
        }

        public IEnumerable<ListPerfumesServiceModel> WomenDescending(int page, int itemsPerPage)
        {
            return dbContext.Perfumes
              .Where(x => x.CategoryId == 2)
              .OrderByDescending(x => x.Price)
              .Skip((page - 1) * itemsPerPage)
              .Take(itemsPerPage)
              .Select(x => new ListPerfumesServiceModel
              {
                  Id = x.Id,
                  Name = x.Name,
                  Price = x.Price,
                  ImgUrl = x.ImageUrl,
                  Quantity = x.Qunatity,
              }).ToList();
        }
    }
}
