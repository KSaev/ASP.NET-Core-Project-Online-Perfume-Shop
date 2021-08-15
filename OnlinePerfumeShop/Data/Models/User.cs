namespace OnlinePerfumeShop.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    using static OnlinePerfumeShop.Data.DataConstants;

    public class User : IdentityUser
    {
        public User()
        {
            this.Orders = new HashSet<Order>();
        }

        [MaxLength(UserFullNameMaxLenght)]
        public string FullName { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
