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
    public class BuildingController : BaseController
    {
        private readonly IBuildingService buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            this.buildingService = buildingService;
        }
        // GET: Building
        [Authorize]
        public ActionResult Index()
        {
            var buildingViewModel = GetAll();
            return View(buildingViewModel);
        }
        private BuildingViewModel GetAll()
        {
            var buildings = buildingService.GetAllBuildings();
            return new BuildingViewModel
                   {
                       BuildingsList = buildings.Buildings.Select(x => x.CreateFrom()).ToList()
                   };
        }
        [Authorize]
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
        [Authorize]
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
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Delete(int? buildingId)
        {
            var buildingToBeDeleted = buildingService.FindBuilding(buildingId);
            buildingService.DeleteBuilding(buildingToBeDeleted);
            return Json(true);
        }

    }
}