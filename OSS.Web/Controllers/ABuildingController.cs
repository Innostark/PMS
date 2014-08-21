using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Newtonsoft.Json;
using OSS.Interfaces.IServices;
using OSS.Models.RequestModels;
using OSS.Web.ModelMappers;
using OSS.Web.ViewModels;
using OSS.Web.ViewModels.Buildings;
using OSS.Web.ViewModels.Common;
using Building = OSS.Web.Models.Building;

namespace OSS.Web.Controllers
{
    [Authorize]
    public class ABuildingController : BaseController
    {

        private readonly IBuildingService buildingService;

        public ABuildingController(IBuildingService buildingService)
        {
            this.buildingService = buildingService;
        }
        
        // GET: Building
        public ActionResult Index()
        {
            BuildingSearchRequest buildingViewModel = Session["PageMetaData"] as BuildingSearchRequest;
            
            Session["PageMetaData"] = null;

            ViewBag.MessageVM = TempData["MessageVm"] as MessageViewModel;

            return View(new ABuildingViewModel
            {
                SearchRequest = buildingViewModel ?? new BuildingSearchRequest()
            });
        }

        [Authorize]
        public ActionResult AddEdit(int? buildingId)
        {
            Building buildingViewModel = new Building();

            if (buildingId != null)
            {

                var building = buildingService.FindBuilding(buildingId);
                if (building != null)
                {

                    buildingViewModel = building.CreateFrom();

                    return View(buildingViewModel);
                }
            }

            return View(buildingViewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddEdit(Building buildingViewModel)
        {
            MessageViewModel messageViewModel = new MessageViewModel();
            //Add New Building
            if (buildingViewModel.BuildingId == 0)
            {
                var modelToSave=buildingViewModel.CreateFrom();
                modelToSave.UserId = Guid.Parse(Session["LoginID"] as string);

                if (buildingService.AddBuilding(modelToSave))
                {
                    messageViewModel.IsUpdated = true;
                }                   
            }
            //Edit Building
            else
            {
                var modelToSave = buildingViewModel.CreateFrom();
                modelToSave.UserId = Guid.Parse(Session["LoginID"] as string);
                if (buildingService.Update(modelToSave))
                {
                    messageViewModel.IsSaved = true;
                }
            }

            messageViewModel.Message = "Saved Successfully";

            // Update Session
            TempData["MessageVm"] = messageViewModel;
            
            return RedirectToAction("Index");
        }
        
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int buildingId)
        {
            var buildingToBeDeleted = buildingService.FindBuilding(buildingId);
            try
            {
                buildingService.DeleteBuilding(buildingToBeDeleted);
            }
            catch (Exception exp)
            {
                return Json(new { response = "Failed to delete. Error: " + exp.Message, status = (int)HttpStatusCode.BadRequest }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { response = "Successfully deleted!", status = (int)HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
        }
        
        
        [HttpPost]
        public ActionResult Index(BuildingSearchRequest request)
        {
            request.UserId = Guid.Parse(Session["LoginID"] as string);
            var buildings = buildingService.GetAllBuildings(request);
            IEnumerable<Building> buildingList = buildings.Buildings.Select(x => x.CreateFrom()).ToList();
            BuildingAjaxViewModel buildingListViewModel = new BuildingAjaxViewModel
            {
                data = buildingList,
                recordsTotal = buildings.TotalCount,
                recordsFiltered = buildings.TotalCount
            };

            // Keep Search Request in Session
            Session["PageMetaData"] = request;

            return Json(buildingListViewModel, JsonRequestBehavior.AllowGet);
        }

    }
}