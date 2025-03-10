﻿namespace OnlinePerfumeShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static OnlinePerfumeShop.Data.DataConstants;
    public class Perfume
    {
        public Perfume()
        {
            this.OrderPerfumes= new HashSet<OrderPerfume>();
        }

        public int Id { get; init; }

        [Required]
        [MaxLength(PerfumeNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(PerfumeDesctriptiondMaxLength)]
        public string Desctription { get; set; }

        [Range(PerfumeMinPrice, PerfumeMaxPrice)]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Range(0,201)]
        public int Qunatity { get; set; }
    
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public ICollection<OrderPerfume> OrderPerfumes { get; set; }

    }
}
