using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using OSS.Implementation.Identity;
using OSS.Interfaces.IServices;
using OSS.Models.IdentityModels;
using OSS.Models.MenuModels;
using OSS.Web.ViewModels.Common;

namespace OSS.Web.Controllers
{
    /// <summary>
    /// Menu Controller to load menu items
    /// </summary>
    public class MenuController : Controller
    {
        // ReSharper disable InconsistentNaming
        private readonly IMenuRightsService menuRightService;
        // ReSharper restore InconsistentNaming
        
        /// <summary>
        /// Menu Controller Constructure
        /// </summary>
        /// <param name="menuRightService"></param>
        public MenuController(IMenuRightsService menuRightService)
        {
            this.menuRightService = menuRightService;
        }
        
        /// <summary>
        /// User Manger for logged in user credientals
        /// </summary>
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        
        /// <summary>
        /// Load Menu items with respect to roles
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult LoadMenu()
        {
            if (Session["MenuItems"] != null)
            {
                return View(Session["MenuItems"] as MenuViewModel);
            }

            MenuViewModel menuVM = new MenuViewModel();
            string userName = HttpContext.User.Identity.Name;
            if (!String.IsNullOrEmpty(userName))
            {
                ApplicationUser userResult = UserManager.FindByEmail(userName);
                if (userResult != null)
                {
                    IList<IdentityUserRole> roles = userResult.Roles.ToList();   
                    if (roles.Count > 0)
                    {
                        IEnumerable<MenuRight> menuItems = menuRightService.FindMenuItemsByRoleId(roles[0].RoleId);

                        //save menu items in session
                        //Session["UserPermissionSet"] = menuItems;

                        menuVM = new MenuViewModel
                                 {
                                     MenuRights = menuItems,
                                     MenuHeaders = menuItems.Where(x => x.Menu.IsRootItem)
                                 };
                    }
                }
            }

            Session["MenuItems"] = menuVM;
            return View(menuVM);
        }
	}
}