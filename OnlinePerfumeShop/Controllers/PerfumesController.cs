using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlinePerfumeShop.Models.Perfumes;
using OnlinePerfumeShop.Services.Perfumes;
using OnlinePerfumeShop.Infrastructure;

using static OnlinePerfumeShop.Area.Admin.AdminConstants;

namespace OnlinePerfumeShop.Controllers
{
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
    }
}
