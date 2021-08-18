namespace OnlinePerfumeShop.Test.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using OnlinePerfumeShop.Controllers;
    using OnlinePerfumeShop.Models.Order;
    using Xunit;
    public class OrderControllerTest
    {
        [Fact]
        public void FinishShouldReturnView()
            => MyController<OrdersController>
                .Instance()
                .Calling(x => x.Finish())
                .ShouldReturn()
                .View();

        [Fact]
        public void BuyGetShouldReturnViewAndShouldBeAuthorized()
         => MyController<OrdersController>
            .Instance(x => x
                .WithUser(TestUser.Identifier, TestUser.Username))
            .Calling(c => c.Buy())
            .ShouldReturn()
            .View(x => x
                .WithModelOfType<OrderInputModel>());

    }
}
