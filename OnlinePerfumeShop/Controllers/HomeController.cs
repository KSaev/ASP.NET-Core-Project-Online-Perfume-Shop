namespace OnlinePerfumeShop.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlinePerfumeShop.Models.Perfumes;
    using OnlinePerfumeShop.Services.Home;


    public class HomeController : Controller
    {
        private readonly IHomeService service;
        public HomeController(IHomeService service)
        {
            this.service = service;
        }
        public IActionResult Index(int id = 1)
        {
            var itemsPerPage = 12;

            var perfumes = new ListPerfumeViewModel
            {
                Perfumes = service.All(id, itemsPerPage),
                Page = id,
                PerfumeCount = service.GetCount(),
                ItemsPerPage = itemsPerPage,
            };


            return View(perfumes);
        }
        public IActionResult Ascending(int id) 
        {
            var itemsPerPage = 12;

            var perfumes = new ListPerfumeViewModel
            {
                Perfumes = service.AllAscending(id, itemsPerPage),
                Page = id,
                PerfumeCount = service.GetCount(),
                ItemsPerPage = itemsPerPage,
            };


            return View(perfumes);
        }
        public IActionResult Descending(int id)
        {
            var itemsPerPage = 12;

            var perfumes = new ListPerfumeViewModel
            {
                Perfumes = service.AllDescending(id, itemsPerPage),
                Page = id,
                PerfumeCount = service.GetCount(),
                ItemsPerPage = itemsPerPage,
            };


            return View(perfumes);
        }

    }
}
