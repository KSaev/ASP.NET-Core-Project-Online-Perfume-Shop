namespace OnlinePerfumeShop.Test.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using OnlinePerfumeShop.Controllers;
    using OnlinePerfumeShop.Data.Models;
    using OnlinePerfumeShop.Models.Perfumes;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    public class HomeControllerTest
    {
        [Fact]
        public void IndexShouldReturnViewWithCorrectModelAndData()
            => MyMvc
                .Pipeline()
                .ShouldMap(x => x
                    .WithPath("/Home/Index/1")
                    .WithMethod(HttpMethod.Get))
                .To<HomeController>(c => c.Index(1))
                .Which()
                .ShouldReturn()
                .View(x => x
                    .WithModelOfType<ListPerfumeViewModel>());
        [Fact]
        public void AscendingShouldReturnViewWithCorrectModelAndData()
           => MyMvc
               .Pipeline()
               .ShouldMap(x => x
                   .WithPath("/Home/Ascending/1")
                   .WithMethod(HttpMethod.Get))
               .To<HomeController>(c => c.Ascending(1))
               .Which()
               .ShouldReturn()
               .View(x => x
                   .WithModelOfType<ListPerfumeViewModel>());
        [Fact]
        public void DescendingShouldReturnViewWithCorrectModelAndData()
         => MyMvc
             .Pipeline()
             .ShouldMap(x => x
                 .WithPath("/Home/Descending/1")
                 .WithMethod(HttpMethod.Get))
             .To<HomeController>(c => c.Descending(1))
             .Which()
             .ShouldReturn()
             .View(x => x
                 .WithModelOfType<ListPerfumeViewModel>());
    }
}
