using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlinePerfumeShop.Models;
using OnlinePerfumeShop.Models.Perfumes;
using OnlinePerfumeShop.Services.Home;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePerfumeShop.Controllers
{
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
    }
}
