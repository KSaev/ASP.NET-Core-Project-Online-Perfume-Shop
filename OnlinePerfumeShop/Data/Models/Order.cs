namespace OnlinePerfumeShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static OnlinePerfumeShop.Data.DataConstants;

    public class Order
    {
        public Order()
        {
            this.OrderPerfumes = new HashSet<OrderPerfume>();
        }
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        [Required]
        [MinLength(OrderAdressMinLenght)]
        public string OrderAddress { get; set; }

        [Required]
        [RegularExpression("[0-9]{4}")]
        public string ZipCode { get; set; }

        [Required]
        [MinLength(OrderSreetMinLenght)]
        public string Street { get; set; }

        [Required]
        [MinLength(OrderSupplierMinLenght)]
        public string Supplier { get; set; }

        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<OrderPerfume> OrderPerfumes { get; set; }
    }
}
