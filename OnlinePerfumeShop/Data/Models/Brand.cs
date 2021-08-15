namespace OnlinePerfumeShop.Data.Models
{
    using System.Collections.Generic;
    public class Brand
    {
        public Brand()
        {
            this.Perfumes = new HashSet<Perfume>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Perfume> Perfumes { get; set; }
    }
}
