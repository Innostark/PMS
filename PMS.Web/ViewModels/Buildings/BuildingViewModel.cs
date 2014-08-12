using System.Collections;
using System.Collections.Generic;
using PagedList;
using PMS.Web.Models;

namespace PMS.Web.ViewModels.Buildings
{
    public class BuildingViewModel
    {
        //Show List On ClientSide
        public IEnumerable<Building> BuildingsList { get; set; }

        //Take Data For Edit
        public Building Building { get; set; }
    }
}