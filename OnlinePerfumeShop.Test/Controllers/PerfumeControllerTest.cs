namespace OnlinePerfumeShop.Test.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using OnlinePerfumeShop.Controllers;
    using OnlinePerfumeShop.Models.Perfumes;
    using OnlinePerfumeShop.Services.Models;
    using Xunit;
    using static Data.PerfumeData;

    public class PerfumeControllerTest
    {
        [Fact]
        public void WomenShouldReturnViewWithCorrectModelAndData()
        => MyMvc
            .Pipeline()
            .ShouldMap(x => x
                .WithPath("/Perfumes/Women/1")
                .WithMethod(HttpMethod.Get))
            .To<PerfumesController>(c => c.Women(1))
            .Which()
            .ShouldReturn()
            .View(x => x
                .WithModelOfType<ListPerfumeViewModel>());

        [Fact]
        public void WomenAscendingShouldReturnViewWithCorrectModelAndData()
        => MyMvc
            .Pipeline()
            .ShouldMap(x => x
                .WithPath("/Perfumes/WomenAscending/1")
                .WithMethod(HttpMethod.Get))
            .To<PerfumesController>(c => c.WomenAscending(1))
            .Which()
            .ShouldReturn()
            .View(x => x
                .WithModelOfType<ListPerfumeViewModel>());


        [Fact]
        public void WomenDescendingShouldReturnViewWithCorrectModelAndData()
        => MyMvc
            .Pipeline()
            .ShouldMap(x => x
                .WithPath("/Perfumes/WomenDescending/1")
                .WithMethod(HttpMethod.Get))
            .To<PerfumesController>(c => c.WomenDescending(1))
            .Which()
            .ShouldReturn()
            .View(x => x
                .WithModelOfType<ListPerfumeViewModel>());


        [Fact]
        public void MenShouldReturnViewWithCorrectModelAndData()
         => MyMvc
            .Pipeline()
            .ShouldMap(x => x
                .WithPath("/Perfumes/Men/1")
                .WithMethod(HttpMethod.Get))
            .To<PerfumesController>(c => c.Men(1))
            .Which()
            .ShouldReturn()
            .View(x => x
                .WithModelOfType<ListPerfumeViewModel>());


        [Fact]
        public void MenAscendingShouldReturnViewWithCorrectModelAndData()
        => MyMvc
            .Pipeline()
            .ShouldMap(x => x
                .WithPath("/Perfumes/MenAscending/1")
                .WithMethod(HttpMethod.Get))
            .To<PerfumesController>(c => c.MenAscending(1))
            .Which()
            .ShouldReturn()
            .View(x => x
                .WithModelOfType<ListPerfumeViewModel>());

        [Fact]
        public void MenDescendingShouldReturnViewWithCorrectModelAndData()
            => MyMvc
            .Pipeline()
            .ShouldMap(x => x
                .WithPath("/Perfumes/MenDescending/1")
                .WithMethod(HttpMethod.Get))
            .To<PerfumesController>(c => c.MenDescending(1))
            .Which()
            .ShouldReturn()
            .View(x => x
                .WithModelOfType<ListPerfumeViewModel>());

        [Fact]
        public void DetailRouteShouldMapCorrectWithPerfumeId() =>
        MyRouting
        .Configuration()
        .ShouldMap(x => x
            .WithPath($"/Perfumes/Details/1"))
        .To<PerfumesController>(c => c.Details(1));


        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(3, 4, 5)]
        [InlineData(6, 7, 8)]
        public void DetailsShuoldReturnViewWithTheCurrectData(int categoryId, int brandId, int pefumeId) =>
           MyMvc
            .Pipeline()
            .ShouldMap(x => x
                .WithPath($"/Perfumes/Details/{pefumeId}"))
            .To<PerfumesController>(c => c.Details(pefumeId))
            .Which(controller => controller
                .WithData(GetPerfume(categoryId, brandId, pefumeId)))
            .ShouldReturn()
            .View(x => x
                .WithModelOfType<PerfumeDetailsServiceModel>()
                    .Passing(k => Assert.Equal(k.Id, pefumeId)));
    }
}
