using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlinePerfumeShop.Infrastructure;
using OnlinePerfumeShop.Models.Order;
using OnlinePerfumeShop.Services.Orders;
using OnlinePerfumeShop.Services.ShoppingCart;
using System.Linq;

namespace OnlinePerfumeShop.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IShoppingCartService cartService;

        public OrdersController(IOrderService service, IShoppingCartService cartService)
        {
            this.orderService = service;
            this.cartService = cartService;
        }

        public IActionResult Finish() 
        {
            var userId = this.User.GetUserId();
            var model = orderService.Finish(userId);

            return View(model);
        }
        public IActionResult Buy() => View(new OrderInputModel 
        {
            TotalPrice = this.cartService.GetTotalPrice(this.User.GetUserId()),
        });

        [Authorize] 
        [HttpPost]
        public IActionResult Buy(OrderInputModel input)
        {
            var userId = this.User.GetUserId();
            input.TotalPrice = this.cartService.GetTotalPrice(userId);


            if (this.IsNotAnAuthorize(userId) && !User.IsAdministrator())
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid)
            {
                return View(input);
            }

            orderService.MakeOrder(userId,input);
            this.cartService.Delete(userId);

            return Redirect("/");

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
