namespace OnlinePerfumeShop.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using OnlinePerfumeShop.Infrastructure;
    using OnlinePerfumeShop.Models.Order;
    using OnlinePerfumeShop.Services.Orders;
    using OnlinePerfumeShop.Services.ShoppingCart;


    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IShoppingCartService cartService;

        public OrdersController(IOrderService service, IShoppingCartService cartService)
        {
            this.orderService = service;
            this.cartService = cartService;
        }

        public IActionResult Finish() => View();

        [Authorize]
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

            return RedirectToAction("Finish","Orders");

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
