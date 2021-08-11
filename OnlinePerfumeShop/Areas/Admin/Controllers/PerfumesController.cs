using Microsoft.AspNetCore.Mvc;
using OnlinePerfumeShop.Areas.Admin.Models.Perfumes;
using OnlinePerfumeShop.Services.Perfumes;
using System.Linq;


namespace OnlinePerfumeShop.Areas.Admin.Controllers
{
    public class PerfumesController : AdminController
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

       
        public IActionResult Edit(int id)
        {
            var perfume = service.GetById(id);

            var inputModel = perfume.Select(x => new EditPerfumeInputModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Desctription,
                Price = x.Price,
                ImageUrl = x.ImageUrl,
                CategoryId = x.CategoryId,
                BrandId = x.BrandId,
                Quantity = x.Qunatity,
            }).FirstOrDefault();

            inputModel.Categories = service.GetCategories();
            inputModel.Brands = service.GetBrands();
            inputModel.Id = id;

            return View(inputModel);
        }

        [HttpPost]
        public IActionResult Edit(int id,EditPerfumeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {

                input.Categories = service.GetCategories();
                input.Brands = service.GetBrands();
                input.Id = id;
                return View(input);
            }

            this.service.Update(id, input);

            return Redirect($"/Perfumes/Details/{id}");
        }

        public IActionResult Delete(int id,int page)
        {
            this.service.Delete(id);

            return Redirect($"/Home/Index/{page}");
        }
    }
}
