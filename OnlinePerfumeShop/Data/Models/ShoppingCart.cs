namespace OnlinePerfumeShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ShoppingCart
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public int PerfumeId { get; set; }

        public Perfume Perfume { get; set; }

        public int Quantity { get; set; }
    }
}
