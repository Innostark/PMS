﻿using System.Collections.Generic;
using OSS.Models.RequestModels;
using OSS.Web.Models;

namespace OSS.Web.ViewModels.Buildings
{
    public class BuildingViewModel
    {
        //Show List On ClientSide
        public IEnumerable<Building> BuildingsList { get; set; }

        //Take Data For Edit
        public Building Building { get; set; }

        /// <summary>
        /// Search Request
        /// </summary>
        public BuildingSearchRequest SearchRequest { get; set; }
    }
}