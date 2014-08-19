using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PMS.Implementation.Identity;
using PMS.Models.IdentityModels;

namespace PMS.Web.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public BaseController()
        {
            //if (Session["FullName"]!=null)
            //    Session["FullName"]= SetUserName();
        }
        protected override async void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session["FullName"] == null || Session["FullName"]== string.Empty)
                SetUserDetail();
        }
        private void SetUserDetail()
        {
            Session["FullName"] = Session["LoginID"] = string.Empty;
            if (User.Identity.IsAuthenticated)
            {
                ApplicationUser result= HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByEmail(User.Identity.Name);
                string role=HttpContext.GetOwinContext().Get<ApplicationRoleManager>().FindById(result.Roles.ToList()[0].RoleId).Name;
                Session["FullName"] = result.FirstName + " " + result.LastName;
                Session["LoginID"] = result.Id;
                Session["RoleName"] = role;
                return;
            }
            
             

        }
    }
}