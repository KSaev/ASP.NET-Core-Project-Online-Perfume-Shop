using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlinePerfumeShop.Models.ShoppingCarts;
using OnlinePerfumeShop.Services.Perfumes;
using OnlinePerfumeShop.Services.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var viewModel = cartService.GetViewModel(userId);

            return View(viewModel);
        }
        public IActionResult Add(int perfumeId, string userId)
        {
            cartService.AddProductToCart(perfumeId, userId);

            return RedirectToAction("All", "Perfumes");
        }

        public IActionResult Remove(int perfumeId) 
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            this.cartService.RemovePerfume(perfumeId, userId);

            return Redirect("/ShoppingCart/");
        }

        public IActionResult Delete() 
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            this.cartService.Delete(userId);

            return Redirect("/ShoppingCart/");
        }
    }
}
