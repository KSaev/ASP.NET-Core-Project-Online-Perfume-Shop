using OnlinePerfumeShop.Data;
using OnlinePerfumeShop.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlinePerfumeShop.Services.ShoppingCart
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly OnlinePerfumeShopDbContext dbContext;

        public ShoppingCartService(OnlinePerfumeShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<ShoppingCartServiceModel> GetViewModel(string userId) 
        {
            return this.dbContext.ShoppingCarts
                .Where(x => x.UserId == userId)
                .Select(x => new ShoppingCartServiceModel
                {
                    Name = x.Perfume.Name,
                    Price = x.Perfume.Price,
                    Brand = x.Perfume.Brand.Name,
                    Category = x.Perfume.Category.Name,
                    Quantity = x.Perfume.Qunatity,
                    ImageUrl = x.Perfume.ImageUrl,
                    Id = x.Perfume.Id,
                    Count = x.Quantity,
                }).ToList();

        }
            
        public void AddProductToCart(int perfumeId, string userId)
        {
            var user = dbContext.Users
                .Where(u => u.Id == userId)
                .FirstOrDefault();

          
            var product = dbContext.Perfumes
                .Where(p => p.Id == perfumeId)
                .FirstOrDefault();

            if (product == null || user == null)
            {
                return;
            }

            if (dbContext.ShoppingCarts.Any(c => c.PerfumeId == perfumeId && c.UserId == userId))
            {
                var cartItem = dbContext.ShoppingCarts
                    .Where(c => c.PerfumeId == perfumeId && c.UserId == userId)
                    .FirstOrDefault();

                cartItem.Quantity++;

                dbContext.SaveChanges();
            }
            else
            {
                var cartItem = new OnlinePerfumeShop.Data.Models.ShoppingCart
                {
                    UserId = userId,
                    Quantity = 1,
                    PerfumeId = perfumeId
                };

                dbContext.ShoppingCarts.Add(cartItem);
                dbContext.SaveChanges();
            }
        }

        public void RemovePerfume(int perfumeId, string userId)
        {
            var cart = this.dbContext.ShoppingCarts
                .Where(x => x.PerfumeId == perfumeId && x.UserId == userId)
                .FirstOrDefault();

            if (cart is null)
            {
                return;
            }

            if (cart.Quantity > 1)
            {
                cart.Quantity -= 1;
            }
            else
            {
                dbContext.ShoppingCarts.Remove(cart);
            }

            dbContext.SaveChanges();
        }

        public void Delete(string userId)
        {
            var carts = dbContext.ShoppingCarts.Where(x => x.UserId == userId).ToList();

            if (carts is null)
            {
                return;
            }

            foreach (var item in carts)
            {
                dbContext.ShoppingCarts.Remove(item);
            }
            dbContext.SaveChanges();
        }

        public decimal GetTotalPrice(string userId)
        {
            var shoppingCart = this.dbContext.ShoppingCarts.Where(x => x.UserId == userId).ToList();

            var total = 0M;
            foreach (var item in shoppingCart)
            {
                var perfumePrice = this.dbContext.Perfumes.FirstOrDefault(x => x.Id == item.PerfumeId).Price;
                total += perfumePrice * item.Quantity;
            }
            return total;
        }
    }
}
