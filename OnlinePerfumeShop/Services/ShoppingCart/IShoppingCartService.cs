using OnlinePerfumeShop.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePerfumeShop.Services.ShoppingCart
{
    public interface IShoppingCartService
    {
        public void AddProductToCart(int id, string userId);
        public IEnumerable<ShoppingCartServiceModel> GetViewModel(string userId);
        public void RemovePerfume(int perfumeId, string userId);
        public void Delete(string userId);
    }
}
