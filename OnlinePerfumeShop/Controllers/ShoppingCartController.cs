using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlinePerfumeShop.Infrastructure;
using OnlinePerfumeShop.Services.ShoppingCart;

namespace OnlinePerfumeShop.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService cartService;

        public ShoppingCartController(IShoppingCartService cartService)
        {
            this.cartService = cartService;
        }
        public IActionResult Index() 
        {
            var userId = this.User.GetUserId();
      
            if (this.IsNotAnAuthorize(userId))
            {
                return Unauthorized();
            }

            var viewModel = cartService.GetViewModel(userId);
            

            return View(viewModel);
        }
        public IActionResult Add(int perfumeId, string userId)
        {
            cartService.AddProductToCart(perfumeId, userId);

            if (this.IsNotAnAuthorize(userId))
            {
                return Unauthorized();
            }

            return Redirect("/");
        }

        public IActionResult Remove(int perfumeId) 
        {
            var userId = this.User.GetUserId();

            if (this.IsNotAnAuthorize(userId))
            {
                return Unauthorized();
            }

            this.cartService.RemovePerfume(perfumeId, userId);

            return Redirect("/ShoppingCart/");
        }

        public IActionResult Delete() 
        {
            var userId = this.User.GetUserId();

            if (this.IsNotAnAuthorize(userId))
            {
                return Unauthorized();
            }

            this.cartService.Delete(userId);

            return Redirect("/ShoppingCart/");
        }

        private bool IsNotAnAuthorize(string userId)
        {
            if (this.User.GetUserId() != userId)
            {
                return true;
            }

            return false;
        }
    }
}
