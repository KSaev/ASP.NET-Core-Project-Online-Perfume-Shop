namespace OnlinePerfumeShop.Models.Perfumes
{
    using OnlinePerfumeShop.Services.Models;
    using System;
    using System.Collections.Generic;

    public class ListPerfumeViewModel
    {
        public IEnumerable<ListPerfumesServiceModel> Perfumes { get; set; }
        public int PerfumeCount { get; set; }
        public int WomenPerfumeCount { get; set; }
        public int MenPerfumeCount { get; set; }
        public int Page { get; set; }
        public int PageCount => (int)Math.Ceiling((double)this.PerfumeCount / this.ItemsPerPage);
        public int WomenPageCount => (int)Math.Ceiling((double)this.WomenPerfumeCount / this.ItemsPerPage);
        public int MenPageCount => (int)Math.Ceiling((double)this.MenPerfumeCount / this.ItemsPerPage);
        public bool HasNextPage => this.Page < PageCount;
        public bool HasWomenNextPage => this.Page < WomenPageCount;
        public bool HasMenNextPage => this.Page < MenPageCount;
        public bool HasPreviousPage => this.Page > 1;
        public int PreviousPage => this.Page - 1;
        public int NextPage => this.Page + 1;
        public int ItemsPerPage { get; set; }
    }
}
