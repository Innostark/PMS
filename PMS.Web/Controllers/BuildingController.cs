using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Interfaces.IServices;
using PMS.Web.ModelMappers;
using PMS.Web.ViewModels.Buildings;

namespace PMS.Web.Controllers
{
    public class BuildingController : Controller
    {
        private readonly IBuildingService buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            this.buildingService = buildingService;
        }
        // GET: Building
        public ActionResult AddEdit()
        {
            return View();
        }

        public BuildingViewModel GetAll()
        {
            var buildings = buildingService.GetAllBuildings();
            return new BuildingViewModel
                   {
                       BuildingsList = buildings.Buildings.Select(x => x.CreateFrom()).ToList()
                   };
        }
    }
}