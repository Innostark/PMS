using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Newtonsoft.Json;
using PagedList;
using OSS.Interfaces.IServices;
using OSS.Models.RequestModels;
using OSS.Web.ModelMappers;
using OSS.Web.ViewModels;
using OSS.Web.ViewModels.Buildings;
using OSS.Web.ViewModels.Common;
using OSS.WebBase.Mvc;
using Building = OSS.Web.Models.Building;

namespace OSS.Web.Controllers
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
        //[SiteAuthorize(PermissionKey = "Buildings")]
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
                var modelToSave = buildingViewModel.Building.CreateFrom();
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

            messageViewModel.Message = "Saved Successfully";

            // Update Session
            TempData["MessageVm"] = messageViewModel;

            return RedirectToAction("Building");
        }

        //[Authorize]
        //public ActionResult Delete(int? buildingId)
        //{
        //    var buildingToBeDeleted = buildingService.FindBuilding(buildingId);
        //    buildingService.DeleteBuilding(buildingToBeDeleted);
        //    return RedirectToAction("BuildingList");
        //}

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

        //[SiteAuthorize(PermissionKey = "BuildingList")]
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

        // GET: Building
        //[SiteAuthorize(PermissionKey = "Buildings")]
        public ActionResult Building()
        {
            if (Request.UrlReferrer == null || Request.UrlReferrer.AbsolutePath == "/Building/Building")
            {
                Session["PageMetaData"] = null;
            }

            BuildingSearchRequest buildingViewModel = Session["PageMetaData"] as BuildingSearchRequest;
            ViewBag.MessageVM = TempData["MessageVm"] as MessageViewModel;

            return View(new BuildingViewModel
            {
                SearchRequest = buildingViewModel ?? new BuildingSearchRequest()
            });
        }

        [HttpPost]
        public ActionResult Building(BuildingSearchRequest request)
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

            //if (Request.IsAjaxRequest())
            //{
            //    return PartialView("_BuildingList", buildingListViewModel);
            //}

            //JsonConvert.SerializeObject(buildingListViewModel);

            // Keep Search Request in Session
            Session["PageMetaData"] = request;

            return Json(buildingListViewModel, JsonRequestBehavior.AllowGet);
        }

    }
}