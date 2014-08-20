using System.Web.Mvc;
using PMS.Implementation.Services;
using PMS.Interfaces.IServices;
using PMS.Web.ViewModels.Apartment;
using PMS.Web.ModelMappers;

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
        // GET: Apartment
        public ActionResult AddEdit(int? id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEdit(ApartmentViewModel apartmentViewModel)
        {
            //Add New Apartment
            if (apartmentViewModel.Apartment.ApartmentId == 0)
            {
                var modelToSave = apartmentViewModel.Apartment.CreateFrom();
                apartmentService.AddApartment(modelToSave);
                return View(new ApartmentViewModel());
            }
            //Update Apartment
            return View();
        }
    }
}