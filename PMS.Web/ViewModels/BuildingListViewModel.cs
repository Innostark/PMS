﻿using PagedList;
using PMS.Models.RequestModels;
using PMS.Web.Models;

namespace PMS.Web.ViewModels
{
    public class BuildingListViewModel
    {
        public IPagedList<Building> BuildingList { get; set; }
        public int? TotalNoOfRec { get; set; }
        public BuildingSearchRequest BuildingSearchRequest { get; set; }
        public Product Product { get; set; }
    }
}