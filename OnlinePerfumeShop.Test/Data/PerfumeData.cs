namespace OnlinePerfumeShop.Test.Data
{
    using OnlinePerfumeShop.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public static class PerfumeData
    {
        public static Perfume GetPerfume(int categoryId, int brandId, int pefumeId) 
        {
            var category = new Category { Name = $"TestCategory{categoryId}", Id = categoryId };
            var brand = new Brand { Name = $"TestBrand{brandId}", Id = brandId };

            return Enumerable
                .Range(0, 1)
                .Select(x=> new Perfume 
                {
                    Id = pefumeId,
                    Name = "Test1234",
                    Desctription = "TestTestTestTestTest",
                    Price = x,
                    ImageUrl = "https://www.example.com/?brass=bike&apparel=bubble",
                    Qunatity = x,
                    CategoryId = category.Id,
                    Category = category,
                    BrandId = brand.Id,
                    Brand = brand,
                })
                .FirstOrDefault();
        }

        public static IEnumerable<ShoppingCart> GetCart(int categoryId, int brandId, int pefumeId, int count) 
        {
            var perfume = GetPerfume(categoryId,brandId,pefumeId);

            return Enumerable
                 .Range(1, count)
                 .Select(x => new ShoppingCart
                 {
                     PerfumeId = pefumeId,
                     UserId = new User { Id = "dddddd"}.Id,
                     Quantity = x,
                     Perfume = perfume,
                 })
                 .ToList();

        }
    }
}
