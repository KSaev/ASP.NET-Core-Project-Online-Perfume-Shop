using OnlinePerfumeShop.Services.Models;
using System;
namespace OnlinePerfumeShop.Services.ShoppingCart
{
    using System.Collections.Generic;
    public interface IShoppingCartService
    {
        public void AddProductToCart(int id, string userId);
        public IEnumerable<ShoppingCartServiceModel> GetViewModel(string userId);
        public void RemovePerfume(int perfumeId, string userId);
        public void Delete(string userId);
        public decimal GetTotalPrice(string userId);
    }
}
