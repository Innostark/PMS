using System.Collections;
using PagedList;
using PMS.Web.Models;

namespace PMS.Web.ViewModels.Buildings
{
    public class BuildingViewModel
    {
        //Show List On ClientSide
        public IList BuildingsList { get; set; }

        //Take Data For Edit
        public Building Building { get; set; }
    }
}