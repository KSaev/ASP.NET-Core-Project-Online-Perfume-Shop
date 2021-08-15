namespace OnlinePerfumeShop.Services.Orders
{

    using OnlinePerfumeShop.Models.Order;
    public interface IOrderService
    {
        public void MakeOrder(string userId,OrderInputModel inputModel);

    }
}
