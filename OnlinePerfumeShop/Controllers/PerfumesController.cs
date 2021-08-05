using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlinePerfumeShop.Data.Models;
using OnlinePerfumeShop.Models.Perfumes;
using OnlinePerfumeShop.Services.Perfumes;
using System.Security.Claims;

namespace OnlinePerfumeShop.Controllers
{
    public class PerfumesController : Controller
    {
        private readonly IPerfumeService service;

        public PerfumesController(IPerfumeService service, UserManager<User> userManager)
        {
            this.service = service;
        }

        [Authorize]
        public IActionResult Add() => View(new AddPerfumeInputModel

        {
            Categories = this.service.GetCategories(),
            Brands = this.service.GetBrands(),
            
        });
        

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddPerfumeInputModel model) 
        {

            if (!ModelState.IsValid)
            {
                model.Categories = this.service.GetCategories();
                model.Brands = this.service.GetBrands();
                return View(model);
            }
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            service.Create(
                model.Name,
                model.Description,
                model.ImageUrl,
                model.Price,
                model.CategoryId,
                model.Quantity,
                model.BrandId,
                userId
               );

            return Redirect("/");
        }

        
        public IActionResult All(int id = 1) 
        {
            var itemsPerPage = 12;
           
            var perfumes = new ListPerfumeViewModel
            {
                Perfumes = service.All(id,itemsPerPage),
                Page = id,
                PerfumeCount = service.GetCount(),
                ItemsPerPage = itemsPerPage,
            };


            return View(perfumes);
        }
        public IActionResult Details(int id)
        {
            var viewModel = service.GetDetails(id);

            return View(viewModel);
        }
    }
}
