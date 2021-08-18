namespace OnlinePerfumeShop.Test.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using OnlinePerfumeShop.Controllers;
    using OnlinePerfumeShop.Services.Models;
    using System.Collections.Generic;
    using Xunit;
    using static Data.PerfumeData;

    public class ShoppingCartControllerTest
    {
        [Fact]
        public void CartControllerShouldHaveAuthorizedUser()
        {
            MyController<ShoppingCartController>
           .Instance(controller => controller
               .WithUser(TestUser.Identifier, TestUser.Username))
           .ShouldHave()
           .Attributes(attributes => attributes
              .RestrictingForAuthorizedRequests());
        }

        [Fact]
        public void IndexShouldReturnViewAndShouldBeAuthorized() => MyMvc
            .Pipeline()
            .ShouldMap(x => x
                .WithPath("/ShoppingCart/Index")
                .WithUser(TestUser.Identifier, TestUser.Username)
                .WithMethod(HttpMethod.Get))
            .To<ShoppingCartController>(c => c.Index())
            .Which()
            .ShouldReturn()
            .View(x => x
                .WithModelOfType<List<ShoppingCartServiceModel>>());

        [Fact]
        public void AddShouldReturnReditectAndShouldBeAuthorized()
         => MyController<ShoppingCartController>
            .Instance(x => x
                .WithUser(TestUser.Identifier, TestUser.Username))
            .Calling(c => c.Add(1))
            .ShouldReturn()
            .Redirect("/");

        [Fact]
        public void RemoveShouldReturnReditectAndShouldBeAuthorized()
         => MyController<ShoppingCartController>
            .Instance(x => x
                .WithUser(TestUser.Identifier, TestUser.Username))
            .Calling(c => c.Remove(1))
            .ShouldReturn()
            .Redirect("/ShoppingCart/");

        [Fact]
        public void DeleteShouldReturnReditectAndShouldBeAuthorized()
       => MyController<ShoppingCartController>
          .Instance(x => x
              .WithUser(TestUser.Identifier, TestUser.Username))
          .Calling(c => c.Delete())
          .ShouldReturn()
          .Redirect("/ShoppingCart/");
    }
}
