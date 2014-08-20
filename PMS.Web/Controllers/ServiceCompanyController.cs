using System.Web.Mvc;
using PMS.Interfaces.IServices;
using PMS.Web.ModelMappers;
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
        // GET: ServiceCompany
        public ActionResult AddEdit(int? id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEdit(ServiceCompanyViewModel serviceCompanyViewModel)
        {
            MessageViewModel messageViewModel = new MessageViewModel();
            //Add New ServiceCompany
            if (serviceCompanyViewModel.ServiceCompany.ServiceCompanyId == 0 )
            {
                var serviceCompanyToSave = serviceCompanyViewModel.ServiceCompany.CreateFrom();
                serviceCompanyService.AddServiceCompany(serviceCompanyToSave);
                return View(new ServiceCompanyViewModel());
            }
            //Update ServiceCompany
            else
            {
                
            }
            return View();
        }
    }
}