using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PMS.Interfaces.IServices;
using PMS.Models.RequestModels;
using PMS.Web.ModelMappers;
using PMS.Web.ViewModels;
using PMS.Web.ViewModels.Buildings;
using PMS.Web.ViewModels.Common;
using PMS.WebBase.Mvc;
using Building = PMS.Web.Models.Building;

namespace PMS.Web.Controllers
{
    [Authorize]
    public class BuildingController : BaseController
    {

        private readonly IBuildingService buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            this.buildingService = buildingService;
        }
        // GET: Building
        [SiteAuthorize(PermissionKey = "Buildings")]
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
                    var modelToSave=buildingViewModel.Building.CreateFrom();
                    modelToSave.UserId = Guid.Parse(Session["LoginID"] as string);

                    if (buildingService.AddBuilding(modelToSave))
                    {
                        messageViewModel.IsUpdated = true;
                    }                   
                }
                //Edit Building
                else
                {
                    var modelToSave = buildingViewModel.Building.CreateFrom();
                    modelToSave.UserId = Guid.Parse(Session["LoginID"] as string);
                    if (buildingService.Update(modelToSave))
                    {
                        messageViewModel.IsSaved = true;
                    }
                }
                return RedirectToAction("BuildingList");
        }
        [Authorize]
        public ActionResult Delete(int? buildingId)
        {
            var buildingToBeDeleted = buildingService.FindBuilding(buildingId);
            buildingService.DeleteBuilding(buildingToBeDeleted);
            return RedirectToAction("BuildingList");
        }
        [SiteAuthorize(PermissionKey = "BuildingList")]
        public ActionResult BuildingList(BuildingSearchRequest request)
        {
            request.UserId = Guid.Parse(Session["LoginID"] as string);
            var buildings = buildingService.GetAllBuildings(request);
            IEnumerable<Building> buildingList = buildings.Buildings.Select(x => x.CreateFrom()).ToList();
            BuildingListViewModel buildingListViewModel = new BuildingListViewModel
                                                          {
                                                              BuildingList = new StaticPagedList<Building>(buildingList, request.PageNo, request.PageSize, buildings.TotalCount),
                                                              BuildingSearchRequest = request,
                                                              TotalNoOfRec = buildings.TotalCount
                                                          };
            if (Request.IsAjaxRequest())
            {
                return PartialView("_BuildingList", buildingListViewModel);
            }

            return View(buildingListViewModel);
        }

    }
}