namespace OnlinePerfumeShop.Models.Order
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static OnlinePerfumeShop.Data.DataConstants;
    public class OrderInputModel
    {
        public DateTime OrderDate => DateTime.UtcNow;

        [Required]
        [MinLength(OrderAdressMinLenght)]
        [Display( Name = "Address")]
        public string OrderAddress { get; set; }

        [Required]
        [RegularExpression("[0-9]{4}")]
        [Display(Name = "Zip code")]
        public string ZipCode { get; set; }

        [Required]
        [MinLength(OrderSreetMinLenght)]
        public string Street { get; set; }

        [Required]
        [MinLength(OrderSupplierMinLenght)]
        public string Supplier { get; set; }

        [Required]
        [RegularExpression("[0-9]{10}")]
        [Display(Name = "Phonenumber")]
        public string PhoneNumber { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
