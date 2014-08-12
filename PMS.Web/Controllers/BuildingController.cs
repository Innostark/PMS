using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Interfaces.IServices;
using PMS.Web.ModelMappers;
using PMS.Web.ViewModels.Buildings;
using PMS.Web.ViewModels.Common;

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
        

        public BuildingViewModel GetAll()
        {
            var buildings = buildingService.GetAllBuildings();
            return new BuildingViewModel
                   {
                       BuildingsList = buildings.Buildings.Select(x => x.CreateFrom()).ToList()
                   };
        }

        public ActionResult AddEdit(int? id)
        {
            if (id != null)
            {
                var building = buildingService.FindBuilding(id);
                if (building != null)
                {
                    var buildingViewModel = new BuildingViewModel
                           {
                               Building = building.CreateFrom()
                           };
                    return View(buildingViewModel);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddEdit(BuildingViewModel buildingViewModel)
        {
            MessageViewModel messageViewModel = new MessageViewModel();
                //Add New Building
                if (buildingViewModel.Building.BuildingId == 0)
                {
                    if (buildingService.AddBuilding(buildingViewModel.Building.CreateFrom()))
                    {
                        messageViewModel.IsUpdated = true;
                    }                   
                }
                //Edit Building
                else
                {
                    if (buildingService.Update(buildingViewModel.Building.CreateFrom()))
                    {
                        messageViewModel.IsSaved = true;
                    }
                }
            return RedirectToAction("GetAll");
        }

    }
}