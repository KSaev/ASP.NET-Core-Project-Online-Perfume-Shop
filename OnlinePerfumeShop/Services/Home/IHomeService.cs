namespace OnlinePerfumeShop.Services.Home
{
    using OnlinePerfumeShop.Services.Models;
    using System.Collections.Generic;
    public interface IHomeService
    {
        IEnumerable<ListPerfumesServiceModel> All(int id, int itemsPerPage);

        public int GetCount();
    }
}
