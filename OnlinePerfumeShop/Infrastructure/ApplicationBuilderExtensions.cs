using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlinePerfumeShop.Data;
using OnlinePerfumeShop.Data.Models;

namespace OnlinePerfumeShop.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app) 
        {
            using var scopedSercices = app.ApplicationServices.CreateScope();

            var data = scopedSercices.ServiceProvider.GetService<OnlinePerfumeShopDbContext>();

            data.Database.Migrate();

            if (!data.Categories.Any())
            {

            }

            return app;
        }

        private static void SeedCatogory(OnlinePerfumeShopDbContext data)
        {
            if (data.Categories.Any())
            {
                return;
            }
            data.Categories.AddRange(new[]
            {
                new Category{ Name = "Men's perfume"},
                new Category{ Name = "Women's perfume"}
            });

            data.SaveChanges();
        }
      
    }
}
