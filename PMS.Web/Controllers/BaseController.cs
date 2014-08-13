using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            if (Session["FullName"] == null)
                Session["FullName"] = SetUserName();
        }
        private string SetUserName()
        {
            if (User.Identity.IsAuthenticated)
            {
                ApplicationUser result= HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByEmail(User.Identity.Name);
                return result.FirstName + " " + result.LastName;
            }
            
             return string.Empty;

        }
    }
}