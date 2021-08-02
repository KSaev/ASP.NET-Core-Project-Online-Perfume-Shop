using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static OnlinePerfumeShop.Data.DataConstants;

namespace OnlinePerfumeShop.Data.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(UserFullNameMaxLenght)]
        public string FullName { get; set; }
    }
}
