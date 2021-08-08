using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


using static OnlinePerfumeShop.Data.DataConstants;

namespace OnlinePerfumeShop.Data.Models
{
    public class User : IdentityUser
    {
        [MaxLength(UserFullNameMaxLenght)]
        public string FullName { get; set; }

    }
}
