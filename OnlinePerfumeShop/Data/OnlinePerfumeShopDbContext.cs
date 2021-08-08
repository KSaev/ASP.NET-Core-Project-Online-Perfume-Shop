using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlinePerfumeShop.Data.Models;
using System;

namespace OnlinePerfumeShop.Data
{
    public class OnlinePerfumeShopDbContext : IdentityDbContext<User>
    {
       
        public OnlinePerfumeShopDbContext(DbContextOptions<OnlinePerfumeShopDbContext> options)
            : base(options)
        {
        }
        public DbSet<Perfume> Perfumes { get; init; }

        public DbSet<Category> Categories { get; init; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Perfume>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Perfumes)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Perfume>()
                .HasOne(x => x.Brand)
                .WithMany(x => x.Perfumes)
                .HasForeignKey(x => x.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ShoppingCart>()
                .HasKey(x => new { x.PerfumeId, x.UserId });

            base.OnModelCreating(builder);
        }
    }
}
