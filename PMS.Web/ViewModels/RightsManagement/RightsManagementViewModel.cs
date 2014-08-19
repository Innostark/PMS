using System.Collections.Generic;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity.EntityFramework;
using PMS.Models.MenuModels;

namespace PMS.Web.ViewModels.RightsManagement
{
    public class RightsManagementViewModel
    {
        public List<Rights> Rights { get; set; }
        
        public string SelectedRoleId { get; set; }

        public List<IdentityRole> Roles { get; set; }
    }
}