using System.Collections.Generic;

namespace PMS.Web.ViewModels.ServiceCompany
{
    public class ServiceCompanyViewModel
    {
        public IEnumerable<Models.ServiceCompany> ServiceCompaniesList { get; set; }

        //Take Data For Edit
        public Models.ServiceCompany ServiceCompany { get; set; }
    }
}