﻿namespace OnlinePerfumeShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static OnlinePerfumeShop.Data.DataConstants;


    public class Category
    {
        public Category()
        {
            Perfumes = new HashSet<Perfume>();
        }
        public int Id { get; init; }

        [Required]
        [MinLength(CategoryNameMinLenght)]
        [MaxLength(CategoryNameMaxLenght)]
        public string Name { get; set; }

        public ICollection<Perfume> Perfumes { get; set; }
    }
}
