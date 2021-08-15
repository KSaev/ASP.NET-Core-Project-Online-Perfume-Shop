namespace OnlinePerfumeShop.Services.Home
{
    using OnlinePerfumeShop.Services.Models;
    using System.Collections.Generic;
    public interface IHomeService
    {
        public IEnumerable<ListPerfumesServiceModel> All(int id, int itemsPerPage);
        public IEnumerable<ListPerfumesServiceModel> AllDescending(int page, int itemsPerPage);
        public IEnumerable<ListPerfumesServiceModel> AllAscending(int page, int itemsPerPage);
        public int GetCount();
    }
}
