using OnlinePerfumeShop.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePerfumeShop.Services.Home
{
    public interface IHomeService
    {
        IEnumerable<ListPerfumesServiceModel> All(int id, int itemsPerPage);

        public int GetCount();
    }
}
