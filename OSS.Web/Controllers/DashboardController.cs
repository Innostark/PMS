using System.Web.Mvc;

namespace OSS.Web.Controllers
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