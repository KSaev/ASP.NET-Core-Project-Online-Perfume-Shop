using Microsoft.AspNetCore.Mvc;
using OnlinePerfumeShop.Data;
using OnlinePerfumeShop.Data.Models;
using OnlinePerfumeShop.Models.Perfumes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OnlinePerfumeShop.Controllers
{
    public class PerfumesController : Controller
    {
        private readonly OnlinePerfumeShopDbContext dbContext;
        

        public PerfumesController(OnlinePerfumeShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Add() => View(new AddPerfumeInputModel

        {
            Categories = this.GetCategories(),
            Brands = this.GetBrands(),
            
        });
        

        [HttpPost]
        public IActionResult Add(AddPerfumeInputModel model) 
        {
            if (!ModelState.IsValid)
            {
                model.Categories = this.GetCategories();
                model.Brands = this.GetBrands();
                return View(model);
            }
            
            var perfume = new Perfume
            {
                Name = model.Name,
                Desctription = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                CategoryId = model.CategoryId,
                Qunatity = model.Quantity,
                BrandId = model.BrandId
            };

            dbContext.Perfumes.Add(perfume);
            dbContext.SaveChanges();

            return Redirect("/");
        }

        
        public IActionResult All() 
        {
            var perfumes = dbContext.Perfumes.Select(x => new ListPerfumeViewModel
            {
                Id = x.Id,
                Description = x.Desctription,
                Name = x.Name,
                Price = x.Price,
                ImgUrl = x.ImageUrl
            }).ToList();

            return View(perfumes);
        }

        private IEnumerable<PerfumeCategoryInputModel> GetCategories() 
        {
             return this.dbContext
                .Categories
                .Select(x => new PerfumeCategoryInputModel
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToList();

        }
        private IEnumerable<PerfumeBrandInputModel> GetBrands() 
        {
            return this.dbContext
                .Brands
                .Select(x => new PerfumeBrandInputModel
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToList();
        }
    }
}
