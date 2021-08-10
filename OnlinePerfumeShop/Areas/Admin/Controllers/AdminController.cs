using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static OnlinePerfumeShop.Area.Admin.AdminConstants;

namespace OnlinePerfumeShop.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Authorize(Roles = AdministratorRoleName)]
    public abstract class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }   
    }
}
