using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static OnlinePerfumeShop.Data.DataConstants;

namespace OnlinePerfumeShop.Models.Perfumes
{
    public class AddPerfumeInputModel
    {
        [StringLength(PerfumeNameMaxLength, MinimumLength = PerfumeNameMinLength, ErrorMessage = "The name must be between {2} and {1} characters long.")]
        [Required]
        public string Name { get; init; }

        [StringLength(PerfumeDesctriptiondMaxLength, MinimumLength = PerfumeDesctriptiondMinLength, ErrorMessage = "The desctription must be between {2} and {1} characters long.")]
        [Required]
        public string Description { get; init; }

        [Range(PerfumeMinPrice, PerfumeMaxPrice)]
        public decimal Price { get; init; }

        public int Quantity { get; set; }

        [Display(Name = "Image URL")]
        [Required]
        [Url]
        public string ImageUrl { get; init; }

        [Display(Name = "Categories")]
        public int CategoryId { get; init; }

        public IEnumerable<PerfumeCategoryInputModel> Categories { get; set; }

        [Display(Name = "Brands")]
        public int BrandId { get; set; }
        public IEnumerable<PerfumeBrandInputModel> Brands { get; set; }
    }
}
