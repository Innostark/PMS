using System.Collections;
using PagedList;
using PMS.Web.Models;

namespace PMS.Web.ViewModels.Buildings
{
    public class BuildingViewModel
    {
        //To Show List On ClientSide
        public IList BuildingsList { get; set; }

        //To Take Data For Edit
        public Building Building { get; set; }
    }
}