using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Web.Controllers
{
    [Authorize]
    public class ServiceCompanyController : BaseController
    {
        // GET: ServiceCompany
        public ActionResult AddEdit()
        {
            return View();
        }
    }
}