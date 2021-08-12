using OnlinePerfumeShop.Data.Models;
using OnlinePerfumeShop.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePerfumeShop.Services.Orders
{
    public interface IOrderService
    {
        public void MakeOrder(string userId,OrderInputModel inputModel);

        public FinishOrderViewModel Finish(string userId);
    }
}
