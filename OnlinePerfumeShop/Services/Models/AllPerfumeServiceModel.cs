﻿namespace OnlinePerfumeShop.Services.Models
{
    using System;
    using System.Collections.Generic;

    public class AllPerfumeServiceModel
    {
        public IEnumerable<ListPerfumesServiceModel> Perfumes { get; set; }
        public int PerfumeCount { get; set; }
        public int Page { get; set; }
        public int PageCount => (int)Math.Ceiling((double)this.PerfumeCount / this.ItemsPerPage);
        public bool HasNextPage => this.Page < PageCount;
        public bool HasPreviousPage => this.Page > 1;
        public int PreviousPage => this.Page - 1;
        public int NextPage => this.Page + 1;
        public int ItemsPerPage { get; set; }
    }
}
