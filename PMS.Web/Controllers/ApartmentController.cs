using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PMS.Interfaces.IServices;
using PMS.Models.DomainModels;
using PMS.Models.RequestModels;
using PMS.Web.ViewModels.Apartment;
using PMS.Web.ModelMappers;
using PMS.Web.ViewModels.Common;
using ModelState = System.Web.Http.ModelBinding.ModelState;

namespace PMS.Web.Controllers
{
    [Authorize]
    public class ApartmentController : BaseController
    {
        private readonly IApartmentService apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            this.apartmentService = apartmentService;
        }

        public ActionResult Index()
        {
            ApartmentSearchRequest apartmentViewModel = Session["PageMetaData"] as ApartmentSearchRequest;

            Session["PageMetaData"] = null;

            ViewBag.MessageVM = TempData["MessageVm"] as MessageViewModel;

            return View(new ApartmentViewModel
            {
                SearchRequest = apartmentViewModel ?? new ApartmentSearchRequest()
            });
        }

        [HttpPost]
        public ActionResult Index(ApartmentSearchRequest apartmentSearchRequest)
        {
            apartmentSearchRequest.UserId = Guid.Parse(Session["LoginID"] as string);
            var apartments = apartmentService.GetAllApartments(apartmentSearchRequest);
            IEnumerable<Models.Apartment> apartmentsList = apartments.Apartments.Select(x => x.CreateFrom()).ToList();
            ApartmentAjaxViewModel apartmentListViewModel = new ApartmentAjaxViewModel
            {
                data = apartmentsList,
                recordsTotal = apartments.TotalCount,
                recordsFiltered = apartments.TotalCount
            };

            // Keep Search Request in Session
            Session["PageMetaData"] = apartmentSearchRequest;

            return Json(apartmentListViewModel, JsonRequestBehavior.AllowGet);
        }
        // GET: Apartment
        public ActionResult AddEdit(int? id)
        {
            Models.Apartment apartmentToEdit = new Models.Apartment();
            apartmentToEdit.Buildings = apartmentService.GetUserBuildings(Guid.Parse(Session["LoginID"] as string)).Select(x=> x.CreateFrom()).ToList();
            if (id != null)
            {
                var apartment = apartmentService.FindApartmentById(id);
                if (apartment != null)
                {
                    apartmentToEdit = apartment.CreateFrom();
                    return View(apartmentToEdit);
                }
            }

            return View(apartmentToEdit);
        }
        [HttpPost]
        public ActionResult AddEdit(Models.Apartment apartment)
        {
            MessageViewModel messageViewModel = new MessageViewModel();
            //Add New Apartment
            if (apartment.ApartmentId == 0)
            {
                var modelToSave = apartment.CreateFrom();
                apartmentService.AddApartment(modelToSave);
                messageViewModel.IsUpdated = true;
                
            }
            //Update Apartment
            else
            {
                
                apartmentService.UpdateApartment(apartment.CreateFrom());
                messageViewModel.IsSaved = true;
            }

            messageViewModel.Message = "Saved Successfully";

            // Update Session
            TempData["MessageVm"] = messageViewModel;

            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int apartmentId)
        {
            var apartmentToBeDeleted = apartmentService.FindApartmentById(apartmentId);
            try
            {
                apartmentService.DeleteApartment(apartmentToBeDeleted);
            }
            catch (Exception exp)
            {
                return Json(new { response = "Failed to delete. Error: " + exp.Message, status = (int)HttpStatusCode.BadRequest }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { response = "Successfully deleted!", status = (int)HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
        }
    }
}