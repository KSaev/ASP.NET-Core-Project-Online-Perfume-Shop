namespace OnlinePerfumeShop.Data.Models
{
    public class OrderPerfume
    {
        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int PerfumeId { get; set; }

        public Perfume Perfume { get; set; }

        public int Quantity { get; set; }
       
    }
}
