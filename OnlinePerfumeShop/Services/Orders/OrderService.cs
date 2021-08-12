using OnlinePerfumeShop.Data;
using OnlinePerfumeShop.Data.Models;
using OnlinePerfumeShop.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePerfumeShop.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly OnlinePerfumeShopDbContext dbContext;

        public OrderService(OnlinePerfumeShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public FinishOrderViewModel Finish(string userId)
        {
            return this.dbContext.Orders.Where(x => x.UserId == userId).Select(x => new FinishOrderViewModel
            {
                UserName = x.User.UserName,
                Address = x.OrderAddress,
                Phone = x.User.PhoneNumber,
                Street = x.Street,
                ZipCode = x.ZipCode,
                Perfumes = x.OrderPerfumes.Select(p => new PefumesOrderList
                {
                    Price = p.Perfume.Price,
                    Quantity = p.Perfume.Qunatity,
                    Name = p.Perfume.Name,
                    Total = p.Perfume.Price * p.Perfume.Qunatity,
                }
                ).ToList()
                
            }).FirstOrDefault();
        }

        public void MakeOrder(string userId,OrderInputModel inputModel)
        {
            var order = new Order
            {
                OrderDate = DateTime.UtcNow,
                UserId = userId,
                OrderAddress = inputModel.OrderAddress,
                Street = inputModel.Street,
                Supplier = inputModel.Supplier,
                ZipCode = inputModel.ZipCode,
            };

            var user = dbContext.Users.Where(x => x.Id == userId).FirstOrDefault();
            user.PhoneNumber = inputModel.PhoneNumber;

            dbContext.Orders.Add(order);
            dbContext.SaveChanges();

            var cartPerfumes = dbContext.ShoppingCarts
                .Where(s => s.UserId == userId)
                .ToList();

            if (cartPerfumes == null)
            {
                return;
            }

            foreach (var item in cartPerfumes)
            {
                var perfumeId = item.PerfumeId;
                var quantity = item.Quantity;
                var perfume = this.dbContext.Perfumes.FirstOrDefault(x => x.Id == perfumeId);

                dbContext.OrderPerfumes.Add(new OrderPerfume
                {
                    OrderId = order.Id,
                    PerfumeId = perfumeId,
                    Perfume = perfume,
                    Quantity = quantity,
                });

                dbContext.SaveChanges();
            }
        }
    }
}
