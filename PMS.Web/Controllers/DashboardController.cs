using System.Web.Mvc;

namespace PMS.Web.Controllers
{
    public class DashboardController : BaseController
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            
            return View();
        }
    }
}