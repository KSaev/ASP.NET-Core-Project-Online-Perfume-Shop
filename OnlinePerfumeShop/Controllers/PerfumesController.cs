using Microsoft.AspNetCore.Mvc;
using OnlinePerfumeShop.Models.Perfumes;
using OnlinePerfumeShop.Services.Perfumes;

namespace OnlinePerfumeShop.Controllers
{
    public class PerfumesController : Controller
    {
        private readonly IPerfumeService service;
        

        public PerfumesController(IPerfumeService service)
        {
            this.service = service;
        }

        public IActionResult Add() => View(new AddPerfumeInputModel

        {
            Categories = this.service.GetCategories(),
            Brands = this.service.GetBrands(),
            
        });
        

        [HttpPost]
        public IActionResult Add(AddPerfumeInputModel model) 
        {

            if (!ModelState.IsValid)
            {
                model.Categories = this.service.GetCategories();
                model.Brands = this.service.GetBrands();
                return View(model);
            }

            service.Create(
                model.Name,
                model.Description,
                model.ImageUrl,
                model.Price,
                model.CategoryId,
                model.Quantity,
                model.BrandId
               );

            return Redirect("/");
        }

        
        public IActionResult All() 
        {
            var perfumes = service.All();

            return View(perfumes);
        }

   
    
    }
}
