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
            Categories = this.GetCategories()
        });
        

        [HttpPost]
        public IActionResult Add(AddPerfumeInputModel model) 
        {
            if (!ModelState.IsValid)
            {
                model.Categories = this.GetCategories();
                return View(model);
            }
            var perfume = new Perfume
            {
                Name = model.Name,
                Desctription = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                CategoryId = model.CategoryId,
            };

            dbContext.Perfumes.Add(perfume);
            dbContext.SaveChanges();

            return Redirect("/");
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
    }
}
