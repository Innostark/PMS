using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PMS.Interfaces.IServices;
using PMS.Models.RequestModels;
using PMS.Web.ModelMappers;
using PMS.Web.ViewModels.Apartment;
using PMS.Web.ViewModels.Common;
using PMS.Web.ViewModels.ServiceCompany;

namespace PMS.Web.Controllers
{
    [Authorize]
    public class ServiceCompanyController : BaseController
    {
        private readonly IServiceCompanyService serviceCompanyService;

        public ServiceCompanyController(IServiceCompanyService companyService)
        {
            this.serviceCompanyService = companyService;
        }
        public ActionResult Index()
        {
            ServiceCompanySearchRequest serviceCompanySearchRequest = Session["PageMetaData"] as ServiceCompanySearchRequest;

            Session["PageMetaData"] = null;

            ViewBag.MessageVM = TempData["MessageVm"] as MessageViewModel;

            return View(new ServiceCompanyViewModel
            {
                SearchRequest = serviceCompanySearchRequest ?? new ServiceCompanySearchRequest()
            });
        }
        [HttpPost]
        public ActionResult Index(ServiceCompanySearchRequest serviceCompanySearchRequest)
        {
            serviceCompanySearchRequest.UserId = Guid.Parse(Session["LoginID"] as string);
            var serviceCompanies = serviceCompanyService.GetAllserviceCompanies(serviceCompanySearchRequest);
            IEnumerable<Models.ServiceCompany> serviceCompaniesList = serviceCompanies.ServiceCompanies.Select(x => x.CreateFrom()).ToList();
            ServiceCompanyAjaxViewModel serviceCompanyAjaxViewModel = new ServiceCompanyAjaxViewModel
            {
                data = serviceCompaniesList,
                recordsTotal = serviceCompanies.TotalCount,
                recordsFiltered = serviceCompanies.TotalCount
            };

            // Keep Search Request in Session
            Session["PageMetaData"] = serviceCompanySearchRequest;

            return Json(serviceCompanyAjaxViewModel, JsonRequestBehavior.AllowGet);
        }
        // GET: ServiceCompany
        public ActionResult AddEdit(int? id)
        {
            ServiceCompanyViewModel serviceCompanyToEdit = new ServiceCompanyViewModel();
            if (id != null)
            {
                var serviceCompany = serviceCompanyService.FindServiceCompany(id);
                if (serviceCompany != null)
                {
                    serviceCompanyToEdit.ServiceCompany = serviceCompany.CreateFrom();
                    return View(serviceCompanyToEdit);
                }
            }
            return View(serviceCompanyToEdit);
            
        }
        [HttpPost]
        public ActionResult AddEdit(ServiceCompanyViewModel serviceCompanyViewModel)
        {
            MessageViewModel messageViewModel = new MessageViewModel();
            //Add New ServiceCompany
            if (serviceCompanyViewModel.ServiceCompany.ServiceCompanyId == 0 )
            {
                var serviceCompanyToSave = serviceCompanyViewModel.ServiceCompany.CreateFrom();
                serviceCompanyToSave.UserId = Guid.Parse(Session["LoginID"] as string);
                serviceCompanyService.AddServiceCompany(serviceCompanyToSave);
            }
            //Update ServiceCompany
            else
            {
                var serviceCompanyToUpdate = serviceCompanyViewModel.ServiceCompany.CreateFrom();
                serviceCompanyToUpdate.UserId = Guid.Parse(Session["LoginID"] as string);
                serviceCompanyService.Update(serviceCompanyToUpdate);
                messageViewModel.IsSaved = true;
            }
            messageViewModel.Message = "Saved Successfully";

            // Update Session
            TempData["MessageVm"] = messageViewModel;

            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int serviceCompanyId)
        {
            var serviceCompanyToBeDeleted = serviceCompanyService.FindServiceCompany(serviceCompanyId);
            try
            {
                serviceCompanyService.DeleteServiceCompany(serviceCompanyToBeDeleted);
            }
            catch (Exception exp)
            {
                return Json(new { response = "Failed to delete. Error: " + exp.Message, status = (int)HttpStatusCode.BadRequest }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { response = "Successfully deleted!", status = (int)HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
        }
    }
}