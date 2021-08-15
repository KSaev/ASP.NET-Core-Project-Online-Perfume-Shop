namespace OnlinePerfumeShop.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlinePerfumeShop.Models.Perfumes;
    using OnlinePerfumeShop.Services.Perfumes;


    public class PerfumesController : Controller
    {
        private readonly IPerfumeService service;

        public PerfumesController(IPerfumeService service)
        {
            this.service = service;
        }  
       public IActionResult Details(int id)
        {
         
            var viewModel = service.GetDetails(id);

            return View(viewModel);
        }
        public IActionResult Men(int id = 1)
        {
            var itemsPerPage = 12;

            var perfumes = new ListPerfumeViewModel
            {
                Perfumes = service.Men(id, itemsPerPage),
                Page = id,
                MenPerfumeCount = service.GetMenCount(),
                ItemsPerPage = itemsPerPage,
            };


            return View(perfumes);
        }
        public IActionResult Women(int id = 1)
        {
            var itemsPerPage = 12;

            var perfumes = new ListPerfumeViewModel
            {
                Perfumes = service.Women(id, itemsPerPage),
                Page = id,
                PerfumeCount = service.GetCount(),
                WomenPerfumeCount = service.GetWomenCount(),
                ItemsPerPage = itemsPerPage,
            };


            return View(perfumes);
        }
    }
}
